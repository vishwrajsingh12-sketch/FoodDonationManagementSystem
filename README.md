🍲 Food Donation Management System

A web-based Food Donation Management System developed using ASP.NET Core MVC, Entity Framework Core, SQL Server, ASP.NET Identity, Bootstrap, and Chart.js.

The main purpose of this project is to provide a digital platform where Donors can donate surplus food and NGOs can find, accept, and manage food donations. Administrators can manage users, donations, categories, and monitor the overall system through a dedicated dashboard.

---

📌 Project Overview

Food wastage is a major social and environmental problem. At the same time, many people and organizations need food assistance.

The Food Donation Management System provides a centralized platform to connect food donors with NGOs. Donors can add available food details, while NGOs can view and accept available donations for pickup.

The system also provides role-based dashboards for Admin, Donor, and NGO users, making the management process organized and secure.

---

🎯 Objectives

- Reduce food wastage by connecting donors with NGOs.
- Provide an easy platform for donating surplus food.
- Allow NGOs to find and manage available food donations.
- Provide secure user authentication and role-based access.
- Track donation status from creation to completion.
- Allow administrators to manage users and system data.
- Provide useful statistics through an admin dashboard.
- Maintain organized records of donations and requests.

---

👥 User Roles

The system contains three major roles:

👨‍💼 Admin

The Admin manages and monitors the complete system.

Admin features:

- Admin Dashboard
- View system statistics
- Manage users
- Manage donations
- Manage food categories
- View contact messages
- Delete/manage records
- Monitor donation status
- Donation status chart

🍱 Donor

Donors can add and manage their food donations.

Donor features:

- Register and login
- Donor Dashboard
- Add food donation
- Upload food image
- Enter food quantity and type
- Add expiry date
- Add pickup address
- View personal donations
- Edit donation
- Delete donation
- Track donation status

🏢 NGO

NGOs can find available donations and manage pickups.

NGO features:

- NGO Dashboard
- View available food donations
- Search donations
- View donation details
- Accept donations
- Complete food pickup
- Track donation status

---

✨ Key Features

🔐 Authentication & Authorization

- User Registration
- User Login
- Logout
- Forgot Password
- Reset Password
- Role-based authorization
- Secure access to Admin, Donor, and NGO dashboards

🍲 Donation Management

Donors can create food donation records containing:

- Food Name
- Food Type
- Food Image
- Quantity
- Expiry Date
- Pickup Address
- Donation Status

🔎 Donation Search

NGOs can search available donations to quickly find suitable food based on the available donation records.

📊 Admin Dashboard

The Admin dashboard provides an overview of the system, including:

- Total Users
- Total Donations
- Pending Donations
- Completed Donations
- Donation status visualization

📩 Contact Management

Visitors can contact the organization through the contact form.

Administrators can view and manage submitted contact messages.

🏷️ Category Management

Admin can manage food categories to keep donation data organized.

📱 Responsive UI

The application uses Bootstrap 5 and custom CSS to provide a responsive interface for different screen sizes.

---

🔄 System Workflow

             ┌───────────────┐
             │     Donor     │
             └───────┬───────┘
                     │
                     ▼
             Add Food Donation
                     │
                     ▼
              Donation Pending
                     │
                     ▼
             ┌───────────────┐
             │      NGO      │
             └───────┬───────┘
                     │
                     ▼
              View Available
                 Donations
                     │
                     ▼
              Accept Donation
                     │
                     ▼
              Food Pickup
                     │
                     ▼
             Mark as Completed

---

🛠️ Technologies Used

Frontend

- HTML5
- CSS3
- Bootstrap 5
- JavaScript
- Chart.js
- Razor Views

Backend

- C#
- ASP.NET Core MVC
- ASP.NET Core Identity
- Entity Framework Core

Database

- Microsoft SQL Server
- Entity Framework Core Migrations

Development Tools

- Visual Studio
- SQL Server Management Studio (SSMS)
- Git
- GitHub

---

🏗️ Project Architecture

The application follows the MVC (Model-View-Controller) architecture.

FoodDonationManagementSystem
│
├── Controllers
│   ├── AccountController
│   ├── AdminController
│   ├── DonorController
│   ├── NGOController
│   ├── ContactController
│   └── HomeController
│
├── Models
│   ├── User
│   ├── Donation
│   ├── Category
│   ├── Contact
│   └── Request
│
├── Data
│   └── FoodDonationContext
│
├── Views
│   ├── Account
│   ├── Admin
│   ├── Donor
│   ├── NGO
│   ├── Contact
│   └── Home
│
├── wwwroot
│   ├── css
│   ├── js
│   ├── images
│   └── uploads
│
└── Program.cs

---

🗄️ Database

The application uses SQL Server with Entity Framework Core.

Main entities include:

User

Stores registered user information and authentication details.

Donation

Stores food donation information such as food name, type, quantity, expiry date, pickup address, status, and donor information.

Category

Stores food donation categories.

Contact

Stores messages submitted through the contact form.

Request

Stores donation-related request information.

---

📌 Donation Status

The donation workflow uses different statuses to track the progress of a donation.

Pending
   ↓
Accepted
   ↓
Completed

This makes it easier for donors, NGOs, and administrators to understand the current state of each donation.

---

🔒 Security

The application uses ASP.NET Core Identity and role-based authorization.

Examples of protected areas include:

- Admin Dashboard → Admin only
- Donor Dashboard → Donor only
- NGO Dashboard → NGO only

Unauthorized users cannot directly access protected role-based pages.

---

📈 Admin Dashboard

The Admin dashboard provides centralized monitoring of the application.

It displays important information such as:

- Number of registered users
- Number of food donations
- Pending donations
- Completed donations
- Donation status statistics

Chart.js is used to provide a visual representation of donation statistics.

---

🖥️ User Interface

The project includes a modern Bootstrap-based interface with:

- Responsive navigation bar
- Dashboard cards
- Food donation forms
- Login and registration pages
- Contact form
- Donation management tables
- Admin management pages
- Responsive layouts
- Custom styling

---

⚙️ Installation & Setup

1. Clone the Repository

git clone YOUR_GITHUB_REPOSITORY_URL

2. Open the Project

Open the project in Visual Studio.

3. Configure Database

Open:

appsettings.json

Configure the SQL Server connection string according to your local SQL Server environment.

Example:

"ConnectionStrings": {
  "DefaultConnection": "Server=(localdb)\\MSSQLLocalDB;Database=FoodDonationDB;Trusted_Connection=True;MultipleActiveResultSets=true;TrustServerCertificate=True"
}

4. Apply Database Migrations

Open Package Manager Console in Visual Studio and run:

Update-Database

Alternatively, using .NET CLI:

dotnet ef database update

5. Run the Application

Run the project from Visual Studio using:

Ctrl + F5

or:

F5

The application will open in the browser.

---

🧪 Testing

The following areas can be tested:

- User registration
- User login
- Role-based redirection
- Forgot password
- Reset password
- Donor donation creation
- Donation editing
- Donation deletion
- NGO donation search
- NGO donation acceptance
- Donation completion
- Admin user management
- Admin donation management
- Category management
- Contact form
- Admin contact messages
- Dashboard statistics

---

🚀 Future Scope

The system can be further enhanced with:

- 📍 Google Maps integration for pickup locations
- 🔔 Email notifications
- 📱 Mobile application
- 🤖 AI-based food demand prediction
- 📊 Advanced analytics and reports
- 🔔 Real-time donation notifications
- 📷 QR-based donation tracking
- 🌐 Multi-language support
- ☁️ Cloud deployment
- 📍 Location-based NGO and donor matching

---

🌍 Benefits

The system can help:

- Reduce food wastage
- Improve donation management
- Connect food donors with NGOs
- Track food donations efficiently
- Reduce manual record keeping
- Improve transparency
- Organize donation and pickup processes

---

🎓 Academic Project

This project was developed as an MCA project to demonstrate practical implementation of:

- Web application development
- MVC architecture
- Database management
- Entity Framework Core
- Authentication and authorization
- CRUD operations
- Role-based access control
- Dashboard development
- Data visualization

---

📸 Screenshots

Add project screenshots here after uploading them to GitHub.

Example:

screenshots/
├── home.png
├── login.png
├── register.png
├── admin-dashboard.png
├── donor-dashboard.png
├── ngo-dashboard.png
├── add-donation.png
└── donation-management.png

You can display them in the README using:

![Home Page](screenshots/home.png)
![Admin Dashboard](screenshots/admin-dashboard.png)
![Donor Dashboard](screenshots/donor-dashboard.png)
![NGO Dashboard](screenshots/ngo-dashboard.png)

---

📂 Main Modules

Module| Description
Authentication| Registration, Login, Logout, Password Reset
Admin| Users, Donations, Categories, Messages & Statistics
Donor| Create and manage food donations
NGO| Search, accept and complete donations
Contact| Public contact form and admin message management
Category| Manage food donation categories
Dashboard| Statistics and donation status visualization

---

🔮 Future Vision

The Food Donation Management System can be expanded into a complete food redistribution platform by connecting restaurants, hotels, individuals, NGOs, volunteers, and food distribution organizations.

With additional features such as location services, notifications, analytics, and mobile support, the system can provide a more efficient digital solution for managing surplus food donations.

---

👨‍💻 Developer

MCA – Big Data Analytics Project

Developed as an academic project to demonstrate full-stack web application development using ASP.NET Core MVC and SQL Server.

---

⭐ Support

If you find this project useful or interesting, consider giving the repository a ⭐ on GitHub.

---

📜 License

This project is created for educational and academic purposes.
