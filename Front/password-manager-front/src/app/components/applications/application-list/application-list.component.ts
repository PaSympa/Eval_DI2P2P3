import { Component } from '@angular/core';
import {ApplicationService} from '../../../services/application.service';
import {ApplicationDto} from '../../../dto/application-dto';
import {RouterLink} from '@angular/router';

@Component({
  selector: 'app-application-list',
  standalone: true,
  imports: [
    RouterLink
  ],
  templateUrl: './application-list.component.html',
  styleUrl: './application-list.component.scss'
})
export class ApplicationListComponent {
  applications: ApplicationDto[] = [];
  loading = false;
  errorMessage = '';

  constructor(private appService: ApplicationService) { }

  ngOnInit(): void {
    this.fetchApplications();
  }

  fetchApplications() {
    this.loading = true;
    this.appService.getApplications().subscribe({
      next: (apps) => {
        this.applications = apps;
        this.loading = false;
      },
      error: (err) => {
        console.error(err);
        this.errorMessage = 'Error loading applications';
        this.loading = false;
      }
    });
  }
}
