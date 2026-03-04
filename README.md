# PharmaVault

PharmaVault is a secure, enterprise-ready pharmaceutical inventory management system designed to ensure data integrity, operational efficiency, and production-level security.

This system is built to manage pharmaceutical stock, monitor product lifecycle (including expiry tracking), and provide structured audit logging for accountability and compliance.

---

## Overview

PharmaVault enables organizations to:

- Manage pharmaceutical products with full CRUD functionality
- Monitor stock levels and expiry dates
- Track operational changes via audit trail
- Enforce role-based access control (RBAC)
- Secure APIs using JWT authentication
- Protect services with rate limiting and security headers

The system is designed with a strong emphasis on security, scalability, and clean architecture.

---

## Key Features

### Secure Authentication & Authorization
- ASP.NET Core Identity integration
- JWT-based authentication
- Role-based access control (Admin / User)
- Account lockout policy
- Secure password policy enforcement

### Inventory Management
- Add, edit, delete pharmaceutical products
- Expiry date tracking
- Stock level monitoring
- Dashboard summary statistics

### Audit & Compliance
- Audit trail logging for product operations
- Role-based activity traceability
- Structured backend service layer

### Production-Level Security
- HTTPS enforced
- Rate limiting (fixed window limiter)
- Security headers (X-Content-Type-Options, X-Frame-Options, etc.)
- CORS policy configuration

### Modern UI/UX
- Apple-inspired dark interface
- Clean glassmorphism styling
- Smooth micro-interactions (Framer Motion)
- Responsive layout
- Modular component structure

---

## Technology Stack

### Frontend
- Next.js (App Router)
- React
- TypeScript
- Tailwind CSS
- Framer Motion

### Backend
- ASP.NET Core Web API
- ASP.NET Core Identity
- JWT Authentication
- Entity Framework Core
- SQL Server

### Security & Infrastructure
- Rate Limiting Middleware
- HTTPS Enforcement
- Secure CORS Policy
- Swagger with JWT Authorization Support

---

## Architecture

PharmaVault follows a clean separation of concerns:

- Controllers → Handle HTTP requests
- Services → Business logic layer
- Data Layer → Entity Framework Core
- Identity Layer → Authentication & Authorization
- Frontend → Consumes RESTful API securely

The application is structured to support scalability and future enterprise expansion.

---

## System Goals

PharmaVault was built with the following objectives:

- Ensure secure pharmaceutical inventory management
- Provide auditability for compliance-driven environments
- Deliver a modern, high-quality user experience
- Demonstrate production-grade backend security practices
- Showcase full-stack engineering capability

---

## Future Enhancements

- Advanced stock analytics and reporting
- Search & filtering system
- Role-specific dashboards
- Real-time notification system
- Deployment to cloud infrastructure (Azure / AWS)
- CI/CD pipeline integration

---

## Project Status

Actively developed as a full-stack production-ready portfolio system demonstrating secure architecture and modern frontend engineering.

---

## Author

Developed as a full-stack project showcasing enterprise-level system design, secure backend implementation, and premium UI architecture. Lutfi Julpian

