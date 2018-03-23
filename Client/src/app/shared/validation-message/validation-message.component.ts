import { Component, Host, Input, Optional } from '@angular/core';
import { FormControl, FormGroupDirective, NgForm } from '@angular/forms';
import { ValidationService } from '@app/core/validation-services.service';

@Component({
  selector: 'app-validation-message',
  templateUrl: './validation-message.component.html',
  styleUrls: ['./validation-message.component.scss']
})
export class ValidationMessageComponent  {
  _serrorMessage: string;
  @Input()
  controlName: string;
  control: FormControl;
  form: any;
  private isReactiveForm = false;

  constructor( @Optional() @Host() private _form: NgForm,
    @Optional() @Host() private _reactiveForm: FormGroupDirective) {

    this.form = _form || _reactiveForm;

    if (_reactiveForm) {
      this.isReactiveForm = true;
    }
  }


  get validationMessage() {
    try {
      if (this.form) {
        if (this.isReactiveForm) {
          this.control = this.form.form.controls[this.controlName];
        } else {
          this.control = this.form.controls[this.controlName];
        }
        if (this.control) {
          if (this.control.errors) {
            for (const propertyName in this.control.errors) {
              if (this.control.errors.hasOwnProperty(propertyName) && (this.form.submitted || this.control.touched)) {
                return ValidationService.getValidatorErrorMessage(propertyName, this.control.errors[propertyName]);
              }
            }
          }
        }
      }
    } catch (e) {
      throw new Error('Error from ControlMessageComponent :- ' + e.Message);
    }
    return null;
  }
}

