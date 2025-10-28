# 🎓 Information System for Recording Non-formal Education (ISRNE)

### `WFApp_NFE` - Desktop Application for NUVGP

## 📚 How to Use non-formal-education

New to this repository? Watch our step-by-step video guide to get started quickly.

[**▶️ Watch the Video Guide on YouTube**]https://youtu.be/Hqtdi1Fu40w

---

---

## 💡 About the Project

The **Information System for Recording Non-formal Education (ISRNE)** is a robust desktop application designed to streamline the management of non-formal educational achievements (certificates, training, courses, etc.) within the university setting (specifically at NUVGP).

The primary goal of the system is to provide administrative staff with an efficient tool for:
* Maintaining a comprehensive database of non-formal education achievements.
* Generating required reports and statistical data.
* Ensuring standardized and organized data storage.

## ✨ Key Features

| Icon | Feature | Description |
| :--- | :--- | :--- |
| 🔑 | **User Authorization** | Secure, role-based access control (Administrator, User) for system integrity. |
| 📜 | **Certificate Management** | Full CRUD (Create, Read, Update, Delete) functionality for records of received certificates. |
| 📚 | **Reference Data Management** | Ability to manage standardized directories (disciplines, groups, course types) to maintain data consistency. |
| 📈 | **Non-formal Education Tracking** | Detailed, structured record-keeping of all forms of non-formal education achievements. |
| 📄 | **PDF Integration** | Built-in viewer (powered by PdfiumViewer) to display scanned certificates and documents directly within the application. |
| 🔎 | **Query & Reporting** | Advanced tools for searching, filtering, and generating customized data reports. |

## 🛠️ Technology Stack

The application is built using standard Microsoft technologies for stable, high-performance desktop deployment.

* **Primary Language:** C# (.NET Framework)
* **User Interface:** Windows Forms (WinForms)
* **Database:** Microsoft Access (`.accdb`) - used for local, structured data storage.
* **External Library:** `PdfiumViewer` - integrated for handling and displaying PDF files.

## 🚀 Installation and Launch

### Prerequisites

1.  Windows Operating System.
2.  The required **.NET Framework** version (installed on the target machine).

### Deployment Steps

1.  **Clone the Repository:**
    ```bash
    git clone [https://github.com/YourUsername/YourRepositoryName.git](https://github.com/YourUsername/YourRepositoryName.git)
    cd WFApp_NFE
    ```
2.  **Database Placement:** Ensure the primary database file, `NFE_db.accdb`, is correctly placed according to the application's configuration path.
3.  **Build:** Open the solution file (`.sln`) in **Visual Studio** and compile the project to generate the executable files.
4.  **Run:** Launch the compiled application file, `WFApp_NFE.exe`.

### 🔑 Test Credentials (Example)

| Role | Username | Password |
| :--- | :--- | :--- |
| **Administrator** | `admin` | `admin` |
| **or** | `111` | `111` |

---

## 🤝 Author

This project was developed as a Bachelor's qualification work.

* **Author:** Vladyslav Leshchuk
* **Qualification:** Bachelor's Thesis (2024)
* **University:** National University of Water and Environmental Engineering (НУВГП / NUVGP)
* **Contact:** vladleshchuk69@gmail.com
