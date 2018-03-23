import { ContactService } from './contact.service';
import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

@NgModule({
    imports: [
        CommonModule,
    ],
    providers: [
        ContactService
    ]
})
export class ServiceModule { }
