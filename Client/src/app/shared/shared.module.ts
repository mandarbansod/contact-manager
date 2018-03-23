import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { LoaderComponent } from './loader/loader.component';
import { ValidateCssClassDirective } from '@app/shared/validate-css-class.directive';
import { ValidationMessageComponent } from './validation-message/validation-message.component';

@NgModule({
  imports: [
    CommonModule,
    FormsModule,
    ReactiveFormsModule
  ],
  declarations: [
    LoaderComponent,
    ValidateCssClassDirective,
    ValidationMessageComponent
  ],
  exports: [
    LoaderComponent,
    ValidateCssClassDirective,
    ValidationMessageComponent
  ]
})
export class SharedModule { }
