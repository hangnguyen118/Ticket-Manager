# Ticket Manager

Ticket Manager is a web application built using Next.js for the frontend, Firebase for authentication and database, and ASP.NET Core for the backend. The application is designed to manage movie cinema threads, display movie tickets, and handle seat booking systems.

## Application Goals

- Manage movie cinema threads
- Display movie tickets
- Buy and display seat system

## Technologies Used

- Next.js
- Firebase
- ASP.NET Core

## Setup Guide

### Prerequisites

- Node.js
- .NET Core SDK
- Firebase account

### Frontend Setup (Next.js)

1. Clone the repository:

   ```bash
   git clone https://github.com/hangnguyen118/Ticket-Manager.git
   cd ticket-manager/frontend
   ```

2. Install dependencies:

   ```bash
   npm install
   ```

3. Create a `.env.local` file in the `frontend` directory and add your Firebase configuration:

   ```env
   NEXT_PUBLIC_FIREBASE_API_KEY=your_api_key
   NEXT_PUBLIC_FIREBASE_AUTH_DOMAIN=your_auth_domain
   NEXT_PUBLIC_FIREBASE_PROJECT_ID=your_project_id
   NEXT_PUBLIC_FIREBASE_STORAGE_BUCKET=your_storage_bucket
   NEXT_PUBLIC_FIREBASE_MESSAGING_SENDER_ID=your_messaging_sender_id
   NEXT_PUBLIC_FIREBASE_APP_ID=your_app_id
   ```

4. Run the development server:
   ```bash
   npm run dev
   ```

### Backend Setup (ASP.NET Core)

1. Navigate to the backend directory:

   ```bash
   cd ../backend
   ```

2. Restore dependencies:

   ```bash
   dotnet restore
   ```

3. Update `appsettings.json` with your Firebase configuration and other necessary settings.

4. Run the backend server:
   ```bash
   dotnet run
   ```

## Firebase Setup

1. Go to the [Firebase Console](https://console.firebase.google.com/).
2. Create a new project.
3. Add a web app to your project and copy the Firebase configuration.
4. Enable Firestore Database and Authentication (Email/Password).

## Usage

1. Open your browser and navigate to `http://localhost:3000` for the frontend.
2. The backend will be running on `http://localhost:5000`.

## Contributing

Contributions are welcome! Please open an issue or submit a pull request.
