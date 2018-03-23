import { ContactListComponent } from './contact-list.component';
import { ContactListRoutingModule } from './contact-list-routing.module';
import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { TranslateModule } from '@ngx-translate/core';
import { DataTableModule, DialogModule, GrowlModule, ConfirmDialogModule } from 'primeng/primeng';


@NgModule({
    imports: [
        CommonModule,
        TranslateModule,
        ContactListRoutingModule,
        DataTableModule,
        DialogModule,
        GrowlModule,
        ConfirmDialogModule
    ],
    declarations: [
        ContactListComponent
    ]
})
export class ContactListModule { }
