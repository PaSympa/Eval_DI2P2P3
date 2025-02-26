import { Routes } from '@angular/router';
import { ApplicationListComponent } from './components/applications/application-list/application-list.component';
import { AddApplicationComponent } from './components/applications/add-application/add-application.component';
import {PasswordListComponent} from './components/passwords/password-list/password-list.component';
import {AddPasswordComponent} from './components/passwords/add-password/add-password.component';
import {PasswordDetailComponent} from './components/passwords/password-detail/password-detail.component';

export const routes: Routes = [
  {
    path: 'applications',
    children: [
      { path: '', component: ApplicationListComponent },
      { path: 'add', component: AddApplicationComponent },
      { path: '**', redirectTo: '' }
    ]
  },
  {
    path: 'passwords',
    children: [
      { path: '', component: PasswordListComponent },
      { path: 'add', component: AddPasswordComponent },
      { path: ':id', component: PasswordDetailComponent },
      { path: '**', redirectTo: '' }
    ]
  },

  { path: '', redirectTo: 'applications', pathMatch: 'full' },

  { path: '**', redirectTo: 'applications', pathMatch: 'full' }
];
