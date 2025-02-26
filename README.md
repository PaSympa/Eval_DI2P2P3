# Password Manager 🚀🔐

This is a simple Password Manager application built with Angular and .NET. It allows users to store and retrieve passwords for defined applications, using dynamic encryption (AES for public apps and RSA for professional apps) with a clean N-Layer architecture.

## Project Overview

- **Backend (.NET):**
    - **Architecture:** N-Layer (Controllers, Services, Repositories)
    - **Database:** EF Core with migrations
    - **Security:** API key protection and dynamic encryption strategies (AES/RSA)
    - **Endpoints:**
        - `GET/POST/DELETE /passwords`
        - `GET/POST /applications`

- **Frontend (Angular):**
    - **Design:** Tailwind CSS & Angular Material
    - **Features:**
        - Reactive forms with validations
        - Dynamic routing with parameters and fallback routes
        - Components for listing and adding passwords and applications

## Setup Instructions

### Backend Setup

1. **Install .NET SDK** (version 6 or above) from [here](https://dotnet.microsoft.com/download).
2. **Clone the repository** and open the solution in your IDE (Rider or Visual Studio).
3. **Configure** your connection string in `appsettings.json`.
4. Run migrations by executing the following command in the terminal:
```bash
   dotnet ef database update
```

5. **Run the API**:

```bash
dotnet run
```

Your API should be running at [http://localhost:5238](http://localhost:5238) 🚀.

**Frontend Setup**

1. Install **Node.js** (LTS version, e.g., v16 or v18) from [here](https://nodejs.org/).
2. Navigate to the frontend directory.
3. **Install dependencies**:

```bash
npm install
```

4. Run the Angular app:

```bash
ng serve
```

Open your browser at http://localhost:4200.

**Final Notes**

- The project uses a mono-repo strategy for both frontend and backend.
- Each major feature is committed separately to maintain clear progress.