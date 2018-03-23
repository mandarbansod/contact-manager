import { EditContactComponent } from '@app/edit-contact/edit-contact.component';
import { NgModule } from '@angular/core';
import { Routes, RouterModule, PreloadAllModules } from '@angular/router';
import { Route } from '@app/core';
import { ViewContactComponent } from '@app/view-contact/view-contact.component';

const routes: Routes = [
  Route.withShell([
    { path: 'about', loadChildren: 'app/about/about.module#AboutModule' },
    { path: 'contact-list', loadChildren: 'app/contact-list/contact-list.module#ContactListModule' },
    { path: 'view-contact/:contactId', component: ViewContactComponent },
    { path: 'edit-contact/:contactId', component: EditContactComponent },
    { path: 'add-contact', component: EditContactComponent }
  ]),
  // Fallback when no prior route is matched
  { path: '**', redirectTo: '', pathMatch: 'full' }
];

@NgModule({
  imports: [RouterModule.forRoot(routes, { preloadingStrategy: PreloadAllModules })],
  exports: [RouterModule],
  providers: []
})
export class AppRoutingModule { }
