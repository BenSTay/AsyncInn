# AsyncInn
**Author**: Benjamin Taylor  
**Version**: 1.2.0

## Overview
A ASP.NET web application designed to simulate a hotel inventory system.

## Getting Started
1. Create a fork of this repository, and clone your fork to your device.
2. Open the solution file `AsyncInn` in Visual Studio.
3. To initialize the database, open the Package Manager Console and enter the command "update-database". 
4. To run the app, go to `Debug` > `Start Without Debugging` (or press Ctrl+f5).

## Using The Application
![screenshot](./assets/screenshot.webp)
1. Upon starting the application, you will be directed to the home page. Use the navbar to navigate to the other parts of the site.
2. After clicking on one of the links, you will see a table filled with all of the items currently in that table (seen above).
3. To create a new item, click on the "create new" button and fill out the form.
4. To update, delete, or view the details of an item, click on the respective link on the items row.

## Architecture
**Languages Used**:
* C# 7.3 (ASP.NET Core 2.2)

Written with Visual Studio Community 2019.

## Acknowledgements
- **Eric Meyer** - Reset CSS ([MeyerWeb](https://meyerweb.com/eric/tools/css/reset/))
- **Google Fonts** - Yellowtail and Gravitas One Fonts ([Google Fonts](https://fonts.google.com/))

## Change Log
- **04-04-2019 9:37PM** - Initial Version
- **08-04-2018 8:20PM** - Added CRUD UI, data seeding
- **09-04-2018 7:33PM** - Added dependency injection
