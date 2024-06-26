# SKU System

This repository contains a system for managing SKU (Stock Keeping Unit) data. The system includes models for representing cabinets, rows, lanes, and SKUs, as well as services and controllers for retrieving and managing SKU data.

## Models

### Cabinet
- Represents a cabinet containing rows of shelves.
- **Properties:**
  - Number: Integer representing the cabinet number.
  - Rows: List of Row objects representing the rows of shelves in the cabinet.
  - Position: Position object representing the position of the cabinet.
  - Size: Size object representing the size of the cabinet.

### Row
- Represents a row of shelves within a cabinet.
- **Properties:**
  - Number: Integer representing the row number.
  - Lanes: List of Lane objects representing the lanes within the row.
  - PositionZ: Integer representing the Z-coordinate position of the row.
  - Size: Size object representing the size of the row.

### Lane
- Represents a lane within a row, containing SKUs.
- **Properties:**
  - Number: Integer representing the lane number.
  - JanCode: String representing the JanCode of the SKU.
  - Quantity: Integer representing the quantity of the SKU.
  - PositionX: Integer representing the X-coordinate position of the lane.

### Sku
- Represents a Stock Keeping Unit.
- **Properties:**
  - JanCode: String representing the JanCode of the SKU.
  - Name: String representing the name of the SKU.
  - X, Y, Z: Doubles representing the coordinates of the SKU.
  - ImageURL: String representing the URL of the SKU's image.
  - Width, Depth, Height: Integers representing the dimensions of the SKU.
  - TimeStamp: Integer representing the timestamp of the SKU.
  - Shape: String representing the shape of the SKU.

### LaneWithSkuViewModel
- Represents a Lane with associated SKU data.
- **Properties:**
  - CabinetNumber: Integer representing the number of the cabinet.
  - RowNumber: Integer representing the number of the row.
  - PositionZ: Integer representing the Z-coordinate position of the row.
  - LaneNumber: Integer representing the number of the lane.
  - JanCode: String representing the JanCode of the SKU.
  - Quantity: Integer representing the quantity of the SKU.
  - PositionX: Integer representing the X-coordinate position of the lane.
  - Name: String representing the name of the SKU.
  - X, Y, Z: Doubles representing the coordinates of the SKU.
  - ImageURL: String representing the URL of the SKU's image.

## Services

### ShelfManager
- Service for managing shelf data.
- **Methods:**
  - GetShelfCabinets: Retrieves a list of cabinets containing shelf data.

## Controllers

### ShelfController
- Controller for managing shelf views and actions.
- **Actions:**
  - Index: Displays a view of shelf data.
  - Add: Displays a view for adding new shelf items.

## API

### ShelfApiController
- API controller for managing shelf data.
- **Actions:**
  - GetCabinets: Retrieves cabinet data as JSON.

## Usage
1. Clone the repository to your local machine.
2. Configure the application settings, such as API URLs and file paths, in the `appsettings.json` file.
3. Build and run the application.

# System Requirements

## Software Requirements:
- **Operating System:** Windows 10 or later, macOS 10.15 or later, Linux distributions supported by .NET 6.
- **.NET SDK:** .NET 6 SDK installed on the development machine.
- **Integrated Development Environment (IDE):** Visual Studio 2022, Visual Studio Code, or any other IDE/editor compatible with .NET 6 development.

## Additional Dependencies:
- **NuGet Packages:**
 1. Newtonsoft
