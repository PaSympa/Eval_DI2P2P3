import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs';
import { ApplicationDto, CreateApplicationDto } from '../dto/application-dto';
import { environment } from '../../environments/environment';

@Injectable({
  providedIn: 'root'
})
export class ApplicationService {
  // URL to the backend API endpoint for applications.
  private apiUrl = 'http://localhost:5238/api/applications';

  constructor(private http: HttpClient) { }

  /**
   * Retrieves all applications from the API.
   */
  getApplications(): Observable<ApplicationDto[]> {
    const headers = new HttpHeaders().set('x-api-key', environment.apiKey);
    return this.http.get<ApplicationDto[]>(this.apiUrl, { headers });
  }

  /**
   * Adds a new application by sending a POST request.
   * @param application The application data to add.
   */
  addApplication(application: CreateApplicationDto): Observable<ApplicationDto> {
    const headers = new HttpHeaders().set('x-api-key', environment.apiKey);
    return this.http.post<ApplicationDto>(this.apiUrl, application, { headers });
  }
}
