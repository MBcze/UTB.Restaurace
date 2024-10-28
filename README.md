# Restaurant Reservation and Menu Management System

### Project Purpose

This project was developed as part of a school assignment to practice building a full-stack web application using ASP.NET Core MVC. The application implements multi-layered architecture, code-first database design, and role-based authorization, with the goal of simulating a real-world restaurant management system.

### Key Features

* **User Registration and Role Management**: Allows for two user roles: Customer and Admin. Customers can make reservations and view the menu, while Admins can manage all data, including users, reservations, and menu items.
* **Reservation System**: Enables customers to book reservations with specific dates and times.
* **Menu Management**: Admins can create, read, update, and delete menu items, as well as upload item images.
* **Data Validation**: Includes server-side and client-side validation, plus a custom validation attribute for additional data integrity.

### Application Architecture
This project follows a layered architecture with the following main layers:

1. **Presentation Layer**: Contains the controllers and views for the UI, ensuring separation from the database and business logic.
2. **Application Layer**: Manages application services, isolating business logic.
3. **Infrastructure Layer**: Manages data access through Entity Framework Core with a Code-First approach and handles database migrations.
4. **Domain Layer**: Contains the core business entities, interfaces, and validation logic for the application.

### Entity Overview
* User: Includes attributes such as `user_id`, `username`, `email`, `password_hash`, `phone`, `address`, `role`, `firstname`, and `lastname`.
* Meal: Represents a menu item, including `meal_id`, `name`, `description`, `price`, `category`, `available`, and `imagesrc`.
* Reservation: Contains reservation details, with attributes like `reservation_id`, `user_id`, `reservation_time`, `status`, `total_price`, and `payment_method`.
* Reservation_Meal: Maps meals to reservations and includes `reservation_meal_id`, `reservation_id`, `meal_id`, `amount`, and `price`.
* Role: Defines user roles with `role_id` and `name`.

### License
This project is licensed under the MIT License.
