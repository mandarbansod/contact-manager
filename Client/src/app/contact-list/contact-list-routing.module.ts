import { ContactListComponent } from './contact-list.component';
import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

import { extract } from '@app/core';

const routes: Routes = [
  // Module is lazy loaded, see app-routing.module.ts
  { path: '', component: ContactListComponent, data: { title: extract('Contact List') } }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule],
  providers: []
})
export class ContactListRoutingModule { }
