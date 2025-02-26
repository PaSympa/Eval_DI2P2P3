/**
 * Data Transfer Object for retrieving a password.
 */
export interface PasswordDto {
  passwordId: number;
  accountName: string;
  encryptedPassword: string;
  applicationId: number;
}

/**
 * Data Transfer Object for creating a new password.
 * The plain password is provided and will be encrypted by the service.
 */
export interface CreatePasswordDto {
  accountName: string;
  plainPassword: string;
  applicationId: number;
}
