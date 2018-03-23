import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { TranslateModule } from '@ngx-translate/core';
import { DataTableModule, CheckboxModule, InputTextModule } from 'primeng/primeng';
import { ViewContactComponent } from '@app/view-contact/view-contact.component';
import { ViewContactRoutingModule } from '@app/view-contact/view-contact-routing.module';


@NgModule({
    imports: [
        CommonModule,
        TranslateModule,
        ViewContactRoutingModule,
        DataTableModule,
        CheckboxModule,
        InputTextModule
    ],
    declarations: [
        ViewContactComponent
    ]
})
export class ViewContactModule { }
