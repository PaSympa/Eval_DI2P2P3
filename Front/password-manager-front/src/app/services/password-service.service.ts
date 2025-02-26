import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs';
import { PasswordDto, CreatePasswordDto } from '../dto/password-dto';
import { environment } from '../../environments/environment';

@Injectable({
  providedIn: 'root'
})
export class PasswordService {
  // Base URL for the passwords API endpoint.
  private apiUrl = 'http://localhost:5238/api/passwords';

  constructor(private http: HttpClient) {}

  /**
   * Retrieves a list of all passwords.
   * @returns An Observable containing an array of PasswordDto.
   */
  getPasswords(): Observable<PasswordDto[]> {
    const headers = new HttpHeaders().set('x-api-key', environment.apiKey);
    return this.http.get<PasswordDto[]>(this.apiUrl, { headers });
  }

  /**
   * Retrieves a list of all passwords with encrypted passwords.
   */
  getEncryptedPasswords(): Observable<PasswordDto[]> {
    const headers = new HttpHeaders().set('x-api-key', environment.apiKey);
    return this.http.get<PasswordDto[]>(`${this.apiUrl}/encrypted`, { headers });
  }

  /**
   * Retrieves a password by its ID.
   * @param id The unique identifier of the password.
   * @returns An Observable containing the PasswordDto for the given ID.
   */
  getPasswordById(id: number): Observable<PasswordDto> {
    const headers = new HttpHeaders().set('x-api-key', environment.apiKey);
    return this.http.get<PasswordDto>(`${this.apiUrl}/${id}`, { headers });
  }

  /**
   * Retrieves a single password by its ID, returning the encrypted value.
   * @param id The unique identifier of the password.
   */
  getEncryptedPasswordById(id: number): Observable<PasswordDto> {
    const headers = new HttpHeaders().set('x-api-key', environment.apiKey);
    return this.http.get<PasswordDto>(`${this.apiUrl}/${id}/encrypted`, { headers });
  }

  /**
   * Adds a new password.
   * @param createPasswordDto The data required to create a new password.
   * @returns An Observable containing the newly created PasswordDto.
   */
  addPassword(createPasswordDto: CreatePasswordDto): Observable<PasswordDto> {
    const headers = new HttpHeaders().set('x-api-key', environment.apiKey);
    return this.http.post<PasswordDto>(this.apiUrl, createPasswordDto, { headers });
  }

  /**
   * Deletes a password by its ID.
   * @param id The unique identifier of the password to delete.
   * @returns An Observable for the deletion operation.
   */
  deletePassword(id: number): Observable<any> {
    const headers = new HttpHeaders().set('x-api-key', environment.apiKey);
    return this.http.delete(`${this.apiUrl}/${id}`, { headers });
  }
}
