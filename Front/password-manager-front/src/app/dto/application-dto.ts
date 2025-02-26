/**
 * Data Transfer Object for an Application (output from the API)
 */
export interface ApplicationDto {
  applicationId: number;
  applicationName: string;
  applicationType: string; // e.g., "Public" or "Professional"
}

/**
 * DTO for creating a new Application (input to the API)
 */
export interface CreateApplicationDto {
  applicationName: string;
  applicationType: string; // e.g., "Public" or "Professional"
}
