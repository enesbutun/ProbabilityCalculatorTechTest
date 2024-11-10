# Probability Calculator

The **Probability Calculator** application is a technical test and designed to perform probability calculations based on user-provided inputs and log these calculations for future reference. 
It consists of a backend API for processing calculations and logging results, and a frontend react application for user interaction.

## Tech Stack

### Backend (API)

- **ASP.NET Core**: Builds a RESTful API for handling probability calculations and logging.
- **C#**: Primary programming language.
- **Dependency Injection (DI)**: Manages services and enables loose coupling between components.
- **Logging**: Integrated with `ILogger` for structured and configurable logging.
- **Unit Testing**: Utilizes **xUnit** and **Moq** for mocking dependencies in unit tests.

### Frontend

- **React**: Builds a responsive and interactive user interface.
- **JavaScript (ES6+)**: For client-side scripting and React component logic.
- **CSS Modules**: Styles individual components in an isolated manner.
- **Jest & React Testing Library**: Tests React components.

## Configuration

- **appsettings.json (Backend)**: Stores configuration values such as API endpoints, logging configuration, and environment-specific settings.
- **Environment Variables (Frontend and Backend)**: Manages secrets and sensitive information, such as API URLs.

---

This setup ensures a scalable, maintainable, and testable architecture for the Probability Calculator application, leveraging modern technologies and best practices in both frontend and backend development.
