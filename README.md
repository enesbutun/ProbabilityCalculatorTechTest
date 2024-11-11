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
## Getting Started

### Prerequisites

- Ensure you have [Node.js](https://nodejs.org/) and [npm](https://www.npmjs.com/) installed.

### Setup and Installation

1. **Clone the Repository**
   ```bash
   git clone <repository-url>
   
Install Dependencies

Use the following command to install all necessary npm packages:

bash
Copy code
npm install
Ensure the Backend API is Running

First, navigate to the ProbabilityCalculatorAPI backend project directory.
Start the API server:
bash
Copy code
# In the ProbabilityCalculatorAPI project directory
npm install
npm start
Set the API Base URL

Open the .env file (or create one if it doesn’t exist).
Set the **REACT_APP_API_BASE_URL** environment variable to point to the base URL of the running ProbabilityCalculatorAPI backend. This should be the API endpoint, which might look like https://localhost:7082 (or the port your API server runs on).

Example:
plaintext
Copy code
**REACT_APP_API_BASE_URL=https://localhost:7082**
Run the React Project

Start the ProbabilityCalculatorUI React app by running:

bash
Copy code
npm start
The app should now be accessible at http://localhost:3000 (or the default port React is set to use).

Usage
Once both the API and UI are running, you can use the Probability Calculator UI to interact with the backend API and calculate probabilities based on your requirements.

This setup ensures a scalable, maintainable, and testable architecture for the Probability Calculator application, leveraging modern technologies and best practices in both frontend and backend development.
