import { CoreModule } from './../core/core.module';
import { SharedModule } from './../shared/shared.module';
import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { TranslateModule } from '@ngx-translate/core';
import { DataTableModule, GrowlModule } from 'primeng/primeng';
import { EditContactRoutingModule } from '@app/edit-contact/edit-contact-routing.module';
import { EditContactComponent } from '@app/edit-contact/edit-contact.component';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';


@NgModule({
    imports: [
        CommonModule,
        TranslateModule,
        EditContactRoutingModule,
        DataTableModule,
        FormsModule,
        ReactiveFormsModule,
        SharedModule,
        GrowlModule
    ],
    declarations: [
        EditContactComponent
    ]
})
export class EditContactModule { }
