# Garage Manager Console Application

Welcome to the **Garage Manager Console Application**, a C# console application designed to manage vehicles in a garage. This application allows users to check in vehicles, perform various operations like fueling, charging, inflating tires, and view detailed information about each vehicle.

## Table of Contents

- [Features](#features)
- [Getting Started](#getting-started)
  - [Prerequisites](#prerequisites)
  - [Installation](#installation)
  - [Running the Application](#running-the-application)
- [Usage](#usage)
- [Project Structure](#project-structure)
- [License](#license)

## Features

- **Check-In Vehicles**: Add new vehicles to the garage with owner details.
- **List Vehicles**: View a list of all vehicles in the garage, with optional filtering by status.
- **Change Vehicle Status**: Update the repair status of vehicles.
- **Inflate Tires**: Inflate all tires of a vehicle to their maximum pressure.
- **Fuel Vehicles**: Fuel fuel-powered vehicles.
- **Charge Vehicles**: Charge electric-powered vehicles.
- **View Vehicle Details**: Display full details of a vehicle, including specific properties.

## Getting Started

### Prerequisites

- **.NET Framework**: Ensure that you have the [.NET Framework](https://dotnet.microsoft.com/download/dotnet-framework) installed on your machine.
- **IDE**: An Integrated Development Environment (IDE) like [Visual Studio](https://visualstudio.microsoft.com/) or [Visual Studio Code](https://code.visualstudio.com/) is recommended for running the application.

### Installation

1. **Clone the Repository**

   Clone the repository to your local machine using Git:

   ```bash
   git clone https://github.com/Yatal42/GarageManager-ConsoleApp.git
   ```

2. **Navigate to the Project Directory**

   ```bash
   cd GarageManager-ConsoleApp
   ```

### Running the Application

1. **Open the Solution**

   - Open the `GarageManager.sln` solution file in Visual Studio.

2. **Build the Solution**

   - Build the solution to restore dependencies and compile the code.
   - Go to **Build** > **Build Solution** or press `Ctrl+Shift+B`.

3. **Run the Application**

   - Set the `ConsoleUI` project as the startup project.
   - Run the application by pressing `F5` or clicking the **Start** button.

## Usage

Upon running the application, you'll be greeted with a menu of actions you can perform:

```
Hi! Here are all the things you can do in the garage:
1). Check In Vehicle
2). List Vehicles License Numbers
3). Change Vehicle Status
4). Inflate To Max
5). Fuel Vehicle
6). Charge Vehicle
7). Show Full Data
8). Close Session
Please choose an action to do in the garage: 1-8
```

- **Check In Vehicle**: Add a new vehicle to the garage.
  - You'll be prompted to enter details like vehicle type, model, license number, owner name, and phone number.
  - Provide specific parameters based on the vehicle type.
- **List Vehicles License Numbers**: View all vehicles, optionally filtered by status.
- **Change Vehicle Status**: Update the status of a vehicle (e.g., Treated, Fixed, Paid).
- **Inflate To Max**: Inflate all tires of a specified vehicle to their maximum pressure.
- **Fuel Vehicle**: Fuel a fuel-powered vehicle.
- **Charge Vehicle**: Charge an electric-powered vehicle.
- **Show Full Data**: Display detailed information about a specific vehicle.
- **Close Session**: Exit the application.

## Project Structure

The solution consists of two main projects:

1. **GarageLogic**: Contains the business logic and domain models.
   - **Classes**:
     - `Vehicle`: Abstract base class for all vehicles.
     - `Car`, `Motorcycle`, `Truck`: Derived classes representing specific vehicle types.
     - `Engine`, `FuelEngine`, `ElectricEngine`: Classes representing different engine types.
     - `Wheel`: Represents a vehicle's wheel.
     - `Garage`: Manages the collection of vehicles.
     - `GarageVehicle`: Encapsulates a vehicle and its associated data in the garage.
     - `VehicleCreator`: Factory class for creating vehicles.
     - `ValueOutOfRangeException`: Custom exception for value range errors.

2. **ConsoleUI**: Contains the user interface and application flow.
   - **Classes**:
     - `GarageManager`: Manages user interactions and coordinates operations between the UI and the logic.
     - `UI`: Handles input/output operations with the user.
     - `Program`: Entry point of the application.
       
## License

This project is licensed under the [MIT License](LICENSE).
