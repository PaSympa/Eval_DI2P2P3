import { Routes } from '@angular/router';
import { ApplicationListComponent } from './components/applications/application-list/application-list.component';
import { AddApplicationComponent } from './components/applications/add-application/add-application.component';
import {PasswordListComponent} from './components/passwords/password-list/password-list.component';
import {AddPasswordComponent} from './components/passwords/add-password/add-password.component';

export const routes: Routes = [
  { path: 'applications', component: ApplicationListComponent },
  { path: 'add-application', component: AddApplicationComponent },
  { path: 'passwords', component: PasswordListComponent },
  { path: 'add-password', component: AddPasswordComponent },
  { path: '', redirectTo: 'applications', pathMatch: 'full' },
  { path: '**', redirectTo: 'applications' }
];
