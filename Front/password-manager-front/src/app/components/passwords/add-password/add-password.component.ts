import { Component } from '@angular/core';
import {FormBuilder, FormGroup, ReactiveFormsModule, Validators} from '@angular/forms';
import {PasswordService} from '../../../services/password-service.service';
import {CreatePasswordDto} from '../../../dto/password-dto';
import {ApplicationService} from '../../../services/application.service';
import {ApplicationDto} from '../../../dto/application-dto';
import {MatFormField, MatLabel} from '@angular/material/form-field';
import {MatOption} from '@angular/material/core';
import {MatSelect} from '@angular/material/select';
import {NgClass} from '@angular/common';

@Component({
  selector: 'app-add-password',
  standalone: true,
  imports: [
    ReactiveFormsModule,
    MatFormField,
    MatLabel,
    MatOption,
    MatSelect,
    NgClass
  ],
  templateUrl: './add-password.component.html',
  styleUrl: './add-password.component.scss'
})
export class AddPasswordComponent {
  passwordForm: FormGroup;
  applications: ApplicationDto[] = [];
  successMessage: string = '';
  errorMessage: string = '';

  constructor(
    private fb: FormBuilder,
    private passwordService: PasswordService,
    private applicationService: ApplicationService
  ) {
    // Initialize the reactive form
    this.passwordForm = this.fb.group({
      accountName: ['', Validators.required],
      plainPassword: ['', Validators.required],
      applicationId: ['', Validators.required]
    });
  }

  ngOnInit(): void {
    // Load the list of available applications when the component initializes
    this.loadApplications();
  }

  loadApplications(): void {
    this.applicationService.getApplications().subscribe({
      next: (apps) => {
        this.applications = apps;
      },
      error: (err) => {
        console.error(err);
        this.errorMessage = 'Failed to load applications.';
      }
    });
  }

  onSubmit(): void {
    if (this.passwordForm.invalid) {
      return;
    }
    // Extract the form values to create a new password DTO
    const newPassword: CreatePasswordDto = this.passwordForm.value;
    this.passwordService.addPassword(newPassword).subscribe({
      next: (data) => {
        this.successMessage = 'Password added successfully!';
        this.passwordForm.reset();
      },
      error: (error) => {
        console.error(error);
        this.errorMessage = 'Failed to add password.';
      }
    });
  }
}
