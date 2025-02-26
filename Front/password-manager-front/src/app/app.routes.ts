import { Routes } from '@angular/router';
import { ApplicationListComponent } from './components/application-list/application-list.component';
import { AddApplicationComponent } from './components/add-application/add-application.component';

export const routes: Routes = [
  { path: 'applications', component: ApplicationListComponent },
  { path: 'add-application', component: AddApplicationComponent },
  { path: '', redirectTo: 'applications', pathMatch: 'full' },
  { path: '**', redirectTo: 'applications' }
];
