import { Component } from '@angular/core';
import {FormBuilder, FormGroup, ReactiveFormsModule, Validators} from '@angular/forms';
import {ApplicationService} from '../../services/application.service';
import {CreateApplicationDto} from '../../dto/application-dto';
import {MatSelectModule} from '@angular/material/select';
import {MatFormFieldModule} from '@angular/material/form-field';

@Component({
  selector: 'app-add-application',
  standalone: true,
  imports: [
    ReactiveFormsModule,
    MatSelectModule,
    MatFormFieldModule,
  ],
  templateUrl: './add-application.component.html',
  styleUrl: './add-application.component.scss'
})
export class AddApplicationComponent {
  applicationForm: FormGroup;
  successMessage = '';
  errorMessage = '';

  constructor(private fb: FormBuilder, private appService: ApplicationService) {
    this.applicationForm = this.fb.group({
      applicationName: ['', Validators.required],
      applicationType: ['Public', Validators.required] // default value can be "Public"
    });
  }

  ngOnInit(): void { }

  onSubmit() {
    if (this.applicationForm.invalid) {
      return;
    }

    const createDto: CreateApplicationDto = this.applicationForm.value;
    this.appService.addApplication(createDto).subscribe({
      next: (app) => {
        this.successMessage = 'Application added successfully!';
        this.applicationForm.reset({ applicationType: 'Public' });
      },
      error: (err) => {
        console.error(err);
        this.errorMessage = 'Failed to add application';
      }
    });
  }
}
