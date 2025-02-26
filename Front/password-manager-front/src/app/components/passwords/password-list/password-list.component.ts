import { Component } from '@angular/core';
import {PasswordDto} from '../../../dto/password-dto';
import {PasswordService} from '../../../services/password-service.service';
import {RouterLink} from '@angular/router';
import {FormsModule} from '@angular/forms';

@Component({
  selector: 'app-password-list',
  standalone: true,
  imports: [
    RouterLink,
    FormsModule
  ],
  templateUrl: './password-list.component.html',
  styleUrl: './password-list.component.scss'
})
export class PasswordListComponent {
  passwords: PasswordDto[] = [];
  loading: boolean = false;
  errorMessage: string = '';

  // Two-way bound to the search input.
  searchTerm: string = '';

  constructor(private passwordService: PasswordService) {}

  ngOnInit(): void {
    this.fetchPasswords();
  }

  fetchPasswords() {
    this.loading = true;
    this.passwordService.getPasswords().subscribe({
      next: (data) => {
        this.passwords = data;
        this.loading = false;
      },
      error: (err) => {
        console.error(err);
        this.errorMessage = 'Failed to load passwords.';
        this.loading = false;
      }
    });
  }

  deletePassword(id: number) {
    this.passwordService.deletePassword(id).subscribe({
      next: () => this.fetchPasswords(),
      error: (err) => console.error(err)
    });
  }

  // Getter to filter passwords based on searchTerm.
  get filteredPasswords(): PasswordDto[] {
    if (!this.searchTerm) {
      return this.passwords;
    }
    return this.passwords.filter(p =>
      p.accountName.toLowerCase().includes(this.searchTerm.toLowerCase())
    );
  }
}
