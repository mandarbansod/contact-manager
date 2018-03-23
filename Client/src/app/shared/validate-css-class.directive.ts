 // tslint:disable:max-line-length
import { AfterViewInit, Directive, ElementRef, Host, Input, Optional, Renderer } from '@angular/core';
import { FormControl, FormGroupDirective, NgForm, Validator, Validators } from '@angular/forms';

/**
 * This directive is intended to be used with the input controls.
 * Method of use
 * for Template forms
 *      <input class="form-controlName" id="Longitude" type="text" name="longitude" [(ngModel)]="occupancy.Longitude" #longitude="ngModel"
 *         applyValidCss [controlName]="longitude" />
 *      NOTE - Here the value being sent is the #longitude which represents the ngModel
 * for Reactive forms
 *      <input class="form-controlName" id="Longitude" type="text" Name="longitude" formControlName='Longitude'
 *          applyValidCss controlName="Longitude"/>
 *      NOTE - Here the value being sent is the formControlName
 */
// tslint:disable-next-line:directive-selector
@Directive({ selector: '[applyValidCss]' })
export class ValidateCssClassDirective implements AfterViewInit {

    @Input('controlName')
    controlName: FormControl;
    private form: any;
    private isReactiveForm = false;
    private readonly ValidationSuccessCssClass = 'border-filled';
    private readonly ValidationFailedCssClass = 'border-critical';
    private readonly ValidationOptionalyFailedCssClass = 'border-important';

    constructor( @Optional() @Host() private _form: NgForm,
        @Optional() @Host() private _reactiveForm: FormGroupDirective,
        private el: ElementRef,
        renderer: Renderer) {
        this.form = _form || _reactiveForm;

        if (_reactiveForm) {
            this.isReactiveForm = true;
        }
        if (!this.form) {
            throw new Error('control-errors must be used with a parent formGroup directive');
        }
    }

    ngAfterViewInit(): void {
        if (this.form) {
            /// This hack is required to be used with the Reactive forms as for reactive forms the controlName variable is  not
            // sending appropriate value. Probably needs further more investigation.
            if (!(this.controlName instanceof FormControl)) {
                this.controlName = this.form.form.controls[this.controlName as string];
            }
            if (this.controlName) {
                this.controlName.statusChanges.subscribe((status) => {
                    this.onStatusChange(status);
                });
                this.onStatusChange(this.controlName.status);
            }
        }
    }

    private onStatusChange(status: string) {
        const cl = this.el.nativeElement.classList;
        const errors = this.controlName.errors;
        if (cl) {
            cl.remove(this.ValidationSuccessCssClass);
            cl.remove(this.ValidationFailedCssClass);
            cl.remove(this.ValidationOptionalyFailedCssClass);

            if (status === 'VALID' && this.hasValidations()) {
                cl.add(this.ValidationSuccessCssClass);
            } else if (status === 'INVALID' && errors['optionalyRequired']) {
                cl.add(this.ValidationOptionalyFailedCssClass);
            } else if (status === 'INVALID') {
                cl.add(this.ValidationFailedCssClass);
            }
        }
    }

    private hasValidations() {
        let hasValidations = false;
        const _validator: any = this.controlName.validator && this.controlName.validator(new FormControl());
        if (_validator) {
            if (_validator.required) {
                hasValidations = _validator && _validator.required;
            } else if (_validator.optionalyRequired) {
                hasValidations = _validator && _validator.optionalyRequired;
            } else if (_validator.minLength) {
                hasValidations = _validator && _validator.minLength;
            } else if (_validator.maxLength) {
                hasValidations = _validator && _validator.maxLength;
            } else if (_validator.min) {
                hasValidations = _validator && _validator.min;
            } else if (_validator.max) {
                hasValidations = _validator && _validator.max;
            } else if (_validator.pattern) {
                hasValidations = _validator && _validator.pattern;
            }
        }
        return hasValidations;
    }
}
