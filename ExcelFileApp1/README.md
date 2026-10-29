# Excel File Manager

A Windows desktop application built with **C# Windows Forms** for basic file management, activity logging, and Excel report generation.

## Features

- **Create Folder** — creates the application's `Data` folder.
- **Write Log** — appends timestamped activity entries to `Data/app_log.txt`.
- **Create Excel** — generates `Data/Report.xlsx` with sample employee data using [ClosedXML](https://github.com/ClosedXML/ClosedXML).
- **Refresh Files** — lists the files currently inside the `Data` folder and displays their count.
- **Delete Data Folder** — deletes the `Data` folder and its contents after confirmation.

## Technologies

- C#
- .NET Windows Forms
- [ClosedXML](https://github.com/ClosedXML/ClosedXML) for creating Excel workbooks

## Sample Excel Data

The generated report contains sample employee records with these columns:

| ID | Name | Department | Salary |
|---:|---|---|---:|
| 1 | Ahmet | IT | 30000 |
| 2 | Mehmet | HR | 12000 |
| 3 | Ayse | Finance | 20000 |

The report includes formatted column headers, adjusted column widths, a frozen header row, and a report-generation timestamp.

> The employee records are sample data for demonstration only.

## Getting Started

1. Clone or download this repository.
2. Open the solution (`.sln`) in Visual Studio.
3. Restore the NuGet packages if prompted.
4. Build the solution.
5. Run the application.

Ensure the project has the required `ClosedXML` NuGet package installed.

## Data and Logs

The application creates a `Data` folder under `Application.StartupPath` (the application's startup directory). Depending on how the application is launched, this may be a build output directory such as `bin/Debug` or `bin/Release`.

- `Report.xlsx` — generated Excel report.
- `app_log.txt` — activity log.

Use the delete feature carefully: it removes the entire `Data` folder and all its contents.

## Repository Hygiene

The repository should include source files and solution/project files, but exclude generated and IDE-specific files such as `.vs/`, `bin/`, `obj/`, and user-specific Visual Studio settings. A `.gitignore` file is recommended.

## Future Improvements

- Allow users to enter employee data instead of using fixed sample records.
- Add clearer operation status messages and validation.
- Allow choosing an output folder for reports.
- Add search and file-opening actions.

