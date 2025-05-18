# CarService Manager

A simple car‑service management application built with **Blazor WebAssembly** (standalone) for the UI and **ASP.NET Core Web API** for the backend, using **SQLite** as the database.  
Allows you to manage customers and works (service records): list, view details, add, update, and delete.

---

## Table of Contents

- [Features](#features)  
- [Tech Stack](#tech-stack)  
- [Getting Started](#getting-started)  
  - [Prerequisites](#prerequisites)  
  - [Installation](#installation)  
  - [Configuration](#configuration)  
  - [Database Initialization](#database-initialization)  
- [Usage](#usage)  
  - [Web UI](#web-ui)  
  - [API Endpoints](#api-endpoints)  
- [Project Structure](#project-structure)  
- [Contributing](#contributing)  
- [License](#license)  

---

## Features

- **Customer Management**  
  - List all customers  
  - View customer details  
  - Add new customer  
  - Update existing customer
  - List works filtered by customer 

- **Work (Service Record) Management**  
  - List all works  
  - View work details  
  - Add new work  
  - Update existing work   

---

## Tech Stack

- **Frontend**:  
  - Blazor WebAssembly (Standalone)  
  - Razor Components  

- **Backend**:  
  - ASP.NET Core Web API  
  - Entity Framework Core with SQLite  

- **Database**:  
  - SQLite (`.db` file in project root or specified Data folder)  

---

## Getting Started

### Prerequisites

- [.NET 9 SDK (or later)](https://dotnet.microsoft.com/download)  
- Node.js & npm (if you plan to install additional client-side packages)  
- Git  

### Installation

1. **Clone the repo**  
   ```bash
   git clone https://github.com/SzPeti8/Beadando_AutoService
   cd Beadando_AutoService
