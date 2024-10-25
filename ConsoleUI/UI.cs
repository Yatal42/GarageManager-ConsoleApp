using GarageLogic;
using System;
using System.Collections.Generic;

namespace ConsoleUI
{
    public class UI
    {
        public enum eUserWelcomeMenu
        {
            CheckInVehicle = 1,
            ListVehiclesLicenseNumbers,
            ChangeVehicleStatus,
            InflateToMax,
            FuelVehicle,
            ChargeVehicle,
            ShowFullData,
            CloseSession
        }

        public UI()
        {

        }

        public int GetMenuSelectionFromUser()
        {
            printMenuOptions();

            return getUserMenuInput();
        }

        private void printMenuOptions()
        {
            Print("Hi! Here are all the things you can do in the garage:");
            foreach (eUserWelcomeMenu menuOption in Enum.GetValues(typeof(eUserWelcomeMenu)))
            {
                string formattedOption = addSpacesBeforeCaps(menuOption.ToString());
                Print(string.Format("{0}). {1}", (int)menuOption, formattedOption));
            }
        }

        private int getUserMenuInput()
        {
            while (true)
            {
                Print("Please choose an action to do in the garage: 1-8");
                string userInput = Console.ReadLine();
                try
                {
                    validateNumberIsIntAndInRange(userInput, 1, 8);
                    int.TryParse(userInput, out int userIntInput);

                    return userIntInput;
                }
                catch (ValueOutOfRangeException exception)
                {
                    Print($"{exception.Message}");
                }
                catch (FormatException exception)
                {
                    Print($"{exception.Message}");
                }
            }
        }

        private string addSpacesBeforeCaps(string i_CamelCaseText)
        {
            var stringBuilder = new System.Text.StringBuilder();

            if (string.IsNullOrWhiteSpace(i_CamelCaseText))
            {
                return string.Empty;
            }

            stringBuilder.Append(i_CamelCaseText[0]);

            for (int i = 1; i < i_CamelCaseText.Length; i++)
            {
                if (char.IsUpper(i_CamelCaseText[i]))
                {
                    stringBuilder.Append(' ');
                }
                stringBuilder.Append(i_CamelCaseText[i]);
            }

            return stringBuilder.ToString();
        }

        public Vehicle.eVehicleType GetVehicleType()
        {
            while (true)
            {
                Console.WriteLine("Please enter the vehicle's type:");
                foreach (Vehicle.eVehicleType type in Enum.GetValues(typeof(Vehicle.eVehicleType)))
                {
                    Console.WriteLine("{0} - {1}", (int)type, type);
                }

                string userInput = Console.ReadLine();

                try
                {
                    validateNumberIsIntAndInRange(userInput, 0, Enum.GetValues(typeof(Vehicle.eVehicleType)).Length - 1);
                    int.TryParse(userInput, out int vehicleTypeIndex);
                    return (Vehicle.eVehicleType)vehicleTypeIndex;
                }
                catch (ValueOutOfRangeException exception)
                {
                    Print($"{exception.Message}");
                }
                catch (FormatException exception)
                {
                    Print($"{exception.Message}");
                }
            }
        }

        public string GetVehicleModel()
        {
            string model = "Not Specified";
            bool isValid = false;

            while (!isValid)
            {
                Print("Please write the vehicle's model, e.g., 'Honda Civic': ");
                model = Console.ReadLine();
                try
                {
                    validateString(model);
                    isValid = true;
                }
                catch (FormatException ex)
                {
                    Print($"Invalid input: {ex.Message}");
                }
            }

            return model;
        }

        public string GetVehicleLicenseNumber()
        {
            string licenseString = "Not Specified";
            bool isValid = false;

            while (!isValid)
            {
                Print("Please enter the vehicle's license number:");
                licenseString = Console.ReadLine();
                try
                {
                    ValidateLicenseNumber(licenseString);
                    isValid = true;
                }
                catch (FormatException ex)
                {
                    Print($"Invalid input: {ex.Message}");
                }
            }

            return licenseString;
        }

        public string GetNewVehicleOwnerName()
        {
            string name = "Not Specified";
            bool isValid = false;

            while (!isValid)
            {
                Print("Please enter the owner's name:");
                name = Console.ReadLine();
                try
                {
                    validateString(name);
                    isValid = true;
                }
                catch (FormatException ex)
                {
                    Print($"Invalid input: {ex.Message}");
                }
            }

            return name;
        }

        public string GetNewVehicleOwnerPhoneNumber()
        {
            string phoneString = "Not Specified";
            bool isValid = false;

            while (!isValid)
            {
                Print("Please enter the owner's phone or mobile number:");
                phoneString = Console.ReadLine();
                try
                {
                    ValidatePhoneNumber(phoneString);
                    isValid = true;
                }
                catch (FormatException ex)
                {
                    Print($"Invalid input: {ex.Message}");
                }
            }

            return phoneString;
        }

        public FuelEngine.eFuelType GetFuelTypeFromUser()
        {
            while (true)
            {
                Print("Enter fuel type to fill:");
                foreach (FuelEngine.eFuelType fuelType in Enum.GetValues(typeof(FuelEngine.eFuelType)))
                {
                    Console.WriteLine("{0} - {1}", (int)fuelType, fuelType);
                }
                string inputFuelType = Console.ReadLine();
                try
                {
                    validateNumberIsIntAndInRange(inputFuelType, 0, Enum.GetValues(typeof(FuelEngine.eFuelType)).Length - 1);
                    int.TryParse(inputFuelType, out int fuelType);

                    return (FuelEngine.eFuelType)fuelType;
                }
                catch (ValueOutOfRangeException exception)
                {
                    Print($"{exception.Message}");
                }
                catch (FormatException exception)
                {
                    Print($"{exception.Message}");
                }
            }
        }

        public float GetFuelVolumeFromUser(float i_EngineCapacity, float i_CurrentEnergyLevel)
        {
            while (true)
            {
                Print("Enter energy volume (liters): ");
                string inputFuelVolume = Console.ReadLine();
                try
                {
                    validateNumberIsFloatAndInRange(inputFuelVolume, 0, i_EngineCapacity - i_CurrentEnergyLevel);
                    float.TryParse(inputFuelVolume, out float fuelVolume);

                    return fuelVolume;
                }
                catch (ValueOutOfRangeException exception)
                {
                    Print($"{exception.Message}");
                }
                catch (FormatException exception)
                {
                    Print($"{exception.Message}");
                }
            }
        }

        public float GetMinutesToChargeFromUser(float i_EngineHoursCapacity, float i_CurrentHoursLeft)
        {
            while (true)
            {
                Print("Enter energy volume (minutes): ");
                string inputMinutesVolume = Console.ReadLine();
                try
                {
                    validateNumberIsFloatAndInRange(inputMinutesVolume, 0, (i_EngineHoursCapacity - i_CurrentHoursLeft) * 60);
                    float.TryParse(inputMinutesVolume, out float minutesVolume);

                    return minutesVolume / 60;
                }
                catch (ValueOutOfRangeException exception)
                {
                    Print($"{exception.Message}");
                }
                catch (FormatException exception)
                {
                    Print($"{exception.Message}");
                }
            }
        }

        public string GetStatusFromUserForFilteredListOfVehicles()
        {
            while (true)
            {
                Print("Choose a status from the list:");
                foreach (Garage.eVehicleStatus status in Enum.GetValues(typeof(Garage.eVehicleStatus)))
                {
                    Console.WriteLine("{0} - {1}", (int)status, status);
                }
                string inputFilter = Console.ReadLine();
                try
                {
                    validateNumberIsIntAndInRange(inputFilter, 1, Enum.GetValues(typeof(Garage.eVehicleStatus)).Length);
                    return inputFilter;
                }
                catch (ValueOutOfRangeException exception)
                {
                    Print($"{exception.Message}");
                }
                catch (FormatException exception)
                {
                    Print($"{exception.Message}");
                }
            }
        }

        public string GetStatusFromUserForUpdatingVehicle()
        {
            while (true)
            {
                Print("Choose a status from the list:");
                foreach (Garage.eVehicleStatus status in Enum.GetValues(typeof(Garage.eVehicleStatus)))
                {
                    Console.WriteLine("{0} - {1}", (int)status, status);
                }
                string inputFilter = Console.ReadLine();
                try
                {
                    validateNumberIsIntAndInRange(inputFilter, 1, Enum.GetValues(typeof(Garage.eVehicleStatus)).Length);
                    return inputFilter;
                }
                catch (ValueOutOfRangeException exception)
                {
                    Print($"{exception.Message}");
                }
                catch (FormatException exception)
                {
                    Print($"{exception.Message}");
                }
            }
        }

        public void GetVehicleWheelManufacturersAndPressureFromUser(int i_NumberOfWheels, float i_MaxWheelsPressure,
            out List<string> o_Manufacturers, out List<float> o_Pressures)
        {
            bool fillAllAtOnce = GetWheelDetailsInputChoiceFromUser();
            o_Manufacturers = new List<string>();
            o_Pressures = new List<float>();

            if (fillAllAtOnce)
            {
                Print("Please write the wheels manufacturer's name and current pressure (it will be applied to all wheels): ");
                string manufacturer = getValidatedManufacturer();
                o_Manufacturers.Add(manufacturer);
                float pressure = getValidatedPressure(i_MaxWheelsPressure);
                o_Pressures.Add(pressure);
            }
            else
            {
                Print($"Please enter the wheel manufacturer's name and current pressure for each of the {i_NumberOfWheels} wheels:");
                for (int i = 0; i < i_NumberOfWheels; i++)
                {
                    Print($"Wheel {i + 1}:");
                    string manufacturer = getValidatedManufacturer();
                    o_Manufacturers.Add(manufacturer);
                    float pressure = getValidatedPressure(i_MaxWheelsPressure);
                    o_Pressures.Add(pressure);
                }
            }
        }


        public void DeclareVehicleAdded()
        {
            Print("Vehicle added to the garage. Status set to 'Treated'.");
        }

        public void DeclareVehicleExists()
        {
            Print("Vehicle already in the garage, status updated to 'Treated'.");
        }

        public void Print(string i_Text)
        {
            int colonIndex = i_Text.IndexOf(':');

            if (colonIndex > 0)
            {
                string propertyName = i_Text.Substring(0, colonIndex).Trim();
                string propertyValue = i_Text.Substring(colonIndex + 1).Trim();
                string formattedText = string.Format("{0}: {1}", addSpacesBeforeCaps(propertyName), propertyValue);
                Console.WriteLine(formattedText);
            }
            else
            {
                Console.WriteLine(i_Text);
            }
        }
        public bool GetWheelDetailsInputChoiceFromUser()
        {
            int choice;

            while (true)
            {
                Print("Would you like to fill wheel details for each wheel individually or all at once?");
                Print("1) All at once");
                Print("2) Individually");
                string inputChoice = Console.ReadLine();
                try
                {
                    validateNumberIsIntAndInRange(inputChoice, 1, 2);
                    choice = int.Parse(inputChoice);

                    return choice == 1;
                }
                catch (ValueOutOfRangeException exception)
                {
                    Print($"{exception.Message}");
                }
                catch (FormatException exception)
                {
                    Print($"{exception.Message}");
                }
            }
        }

        public Dictionary<string, object> GetParametersFromUser(List<VehicleParameter> i_RequiredParameters)
        {
            Dictionary<string, object> parameters = new Dictionary<string, object>();

            foreach (var param in i_RequiredParameters)
            {
                object value = null;
                bool validInput = false;
                while (!validInput)
                {
                    Print($"Please enter {param.Name}:");
                    string input = Console.ReadLine();
                    try
                    {
                        value = parseInput(param.Type, input);
                        validInput = true;
                    }
                    catch (Exception ex)
                    {
                        Print($"Invalid input: {ex.Message}");
                    }
                }
                parameters.Add(param.Name, value);
            }

            return parameters;
        }

        private object parseInput(Type i_Type, string i_Input)
        {
            if (i_Type.IsEnum)
            {
                try
                {
                    object enumValue = Enum.Parse(i_Type, i_Input, true);
                    return enumValue;
                }
                catch (ArgumentException)
                {
                    throw new FormatException($"Invalid value for {i_Type.Name}.");
                }
            }
            else if (i_Type == typeof(int))
            {
                int intValue;
                if (int.TryParse(i_Input, out intValue))
                {
                    return intValue;
                }
                else
                {
                    throw new FormatException("Input must be an integer.");
                }
            }
            else if (i_Type == typeof(float))
            {
                float floatValue;
                if (float.TryParse(i_Input, out floatValue))
                {
                    return floatValue;
                }
                else
                {
                    throw new FormatException("Input must be a floating-point number.");
                }
            }
            else if (i_Type == typeof(bool))
            {
                bool boolValue;
                if (bool.TryParse(i_Input, out boolValue))
                {
                    return boolValue;
                }
                else
                {
                    throw new FormatException("Input must be 'true' or 'false'.");
                }
            }
            else
            {
                validateString(i_Input);
                return i_Input;
            }
        }


        private void validateString(string i_Input)
        {
            if (string.IsNullOrWhiteSpace(i_Input))
            {
                throw new FormatException("The input cannot be empty. Please enter a valid input.");
            }
        }

        private void validateNumberIsIntAndInRange(string i_Input, int i_MinNum, int i_MaxNum)
        {
            if (!int.TryParse(i_Input, out int intInput))
            {
                throw new FormatException("The input must be an integer. Please enter a valid input.");
            }

            if (intInput < i_MinNum || intInput > i_MaxNum)
            {
                throw new ValueOutOfRangeException(i_MaxNum, i_MinNum);
            }
        }

        private void validateNumberIsFloatAndInRange(string i_Input, float i_MinNum, float i_MaxNum)
        {
            if (!float.TryParse(i_Input, out float floatInput))
            {
                throw new FormatException("The input must be a floating-point number. Please enter a valid input.");
            }

            if (floatInput < i_MinNum || floatInput > i_MaxNum)
            {
                throw new ValueOutOfRangeException(i_MaxNum, i_MinNum);
            }
        }

        public static void ValidatePhoneNumber(string i_PhoneString)
        {
            if (string.IsNullOrWhiteSpace(i_PhoneString))
            {
                throw new FormatException("Phone number cannot be null or empty.");
            }

            if (!i_PhoneString.StartsWith("0"))
            {
                throw new FormatException("Phone number must start with '0'.");
            }

            if (i_PhoneString.Length < 8 || i_PhoneString.Length > 10)
            {
                throw new FormatException("Phone number must be between 8 and 10 digits long.");
            }

            for (int i = 1; i < i_PhoneString.Length; i++)
            {
                if (!char.IsDigit(i_PhoneString[i]))
                {
                    throw new FormatException("Phone number must contain only digits after the initial '0'.");
                }
            }
        }

        public static void ValidateLicenseNumber(string i_LicenseString)
        {
            if (string.IsNullOrWhiteSpace(i_LicenseString))
            {
                throw new FormatException("License number cannot be null or empty.");
            }

            if (i_LicenseString.Length < 7 || i_LicenseString.Length > 8)
            {
                throw new FormatException("License number must be 7 (before 2018 vehicles) or 8 digits long.");
            }

            for (int i = 0; i < i_LicenseString.Length; i++)
            {
                if (!char.IsDigit(i_LicenseString[i]))
                {
                    throw new FormatException("License number must contain only digits.");
                }
            }
        }

        private string getValidatedManufacturer()
        {
            string manufacturer = string.Empty;
            bool isValid = false;

            while (!isValid)
            {
                manufacturer = Console.ReadLine();

                try
                {
                    validateString(manufacturer);
                    isValid = true;
                }
                catch (FormatException ex)
                {
                    Console.WriteLine($"Invalid input: {ex.Message}");
                }
            }

            return manufacturer;
        }

        private float getValidatedPressure(float i_MaxWheelsPressure)
        {
            string inputPressure = string.Empty;
            bool isValid = false;

            while (!isValid)
            {
                inputPressure = Console.ReadLine();
                try
                {
                    validateNumberIsFloatAndInRange(inputPressure, 0, i_MaxWheelsPressure);
                    isValid = true;
                }
                catch (ValueOutOfRangeException exception)
                {
                    Print($"{exception.Message}");
                }
                catch (FormatException ex)
                {
                    Console.WriteLine($"Invalid input: {ex.Message}");
                }
            }

            return float.Parse(inputPressure);
        }
    }
}
