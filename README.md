# 🎟️ Ticket Manager

**Ticket Manager** is a web application built using **Next.js** for the frontend, **Firebase** for authentication and database, and **ASP.NET Core** for the backend.  
The application is designed to manage movie cinema threads, display movie tickets, and handle seat booking systems.

---

## 🎯 Application Goals

- 🎬 Manage movie cinema threads
- 🎟️ Display movie tickets
- 🪑 Buy and display seat system

---

## 🛠️ Technologies Used

- ⚡ Next.js
- 🔥 Firebase
- 🖥️ ASP.NET Core

---

## ⚙️ Setup Guide

### 📦 Prerequisites

- [Node.js](https://nodejs.org/)
- [.NET Core SDK](https://dotnet.microsoft.com/)
- [Firebase Account](https://firebase.google.com/)

---

### 🌐 Frontend Setup (Next.js)

1. **Clone the repository**:
   ```bash
   git clone https://github.com/hangnguyen118/Ticket-Manager.git
   cd ticket-manager/frontend
   ```

2. **Install dependencies**:
   ```bash
   npm install
   ```

3. **Configure environment variables**:  
   Create a `.env.local` file inside the `frontend` directory with the following content:
   ```env
   NEXT_PUBLIC_FIREBASE_API_KEY=your_api_key
   NEXT_PUBLIC_FIREBASE_AUTH_DOMAIN=your_auth_domain
   NEXT_PUBLIC_FIREBASE_PROJECT_ID=your_project_id
   NEXT_PUBLIC_FIREBASE_STORAGE_BUCKET=your_storage_bucket
   NEXT_PUBLIC_FIREBASE_MESSAGING_SENDER_ID=your_messaging_sender_id
   NEXT_PUBLIC_FIREBASE_APP_ID=your_app_id
   ```

4. **Run the development server**:
   ```bash
   npm run dev
   ```
   Open your browser at `http://localhost:3000` 🚀

---

### 🖥️ Backend Setup (ASP.NET Core)

1. **Navigate to the backend directory**:
   ```bash
   cd ../backend
   ```

2. **Restore dependencies**:
   ```bash
   dotnet restore
   ```

3. **Configure settings**:  
   Update your `appsettings.json` file with your Firebase credentials and other necessary settings.

4. **Run the backend server**:
   ```bash
   dotnet run
   ```
   Backend will be running at `http://localhost:5000` 🎯

---

## 🔥 Firebase Setup

1. Go to the [Firebase Console](https://console.firebase.google.com/).
2. Create a new project.
3. Add a Web App and copy your Firebase configuration.
4. Enable:
   - Firestore Database
   - Authentication (Email/Password)

---

## 🚀 Usage

- Frontend: `http://localhost:3000`
- Backend: `http://localhost:5000`

---

## 🤝 Contributing

Contributions are welcome!  
Please feel free to **open an issue** or **submit a pull request**.  
Together, we can make **Ticket Manager** even better! 🙌

---

## 📄 License

Distributed under the MIT License. See `LICENSE` for more information.
