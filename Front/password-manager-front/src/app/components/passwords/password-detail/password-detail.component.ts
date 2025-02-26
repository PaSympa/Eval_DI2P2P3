import { Component } from '@angular/core';
import {ActivatedRoute} from '@angular/router';
import {PasswordDto} from '../../../dto/password-dto';
import {PasswordService} from '../../../services/password-service.service';

@Component({
  selector: 'app-password-detail',
  standalone: true,
  imports: [],
  templateUrl: './password-detail.component.html',
  styleUrl: './password-detail.component.scss'
})
export class PasswordDetailComponent {
  password?: PasswordDto;
  loading: boolean = false;
  errorMessage: string = '';

  constructor(private route: ActivatedRoute, private passwordService: PasswordService) { }

  ngOnInit(): void {
    this.route.params.subscribe(params => {
      const id = +params['id'];
      if (id) {
        this.fetchPassword(id);
      }
    });
  }

  fetchPassword(id: number): void {
    this.loading = true;
    this.passwordService.getPasswordById(id).subscribe({
      next: (data) => {
        this.password = data;
        this.loading = false;
      },
      error: (err) => {
        console.error(err);
        this.errorMessage = 'Failed to load password details.';
        this.loading = false;
      }
    });
  }
}
