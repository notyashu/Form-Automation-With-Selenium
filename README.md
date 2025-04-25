# Form Automation with Selenium

This project contains UI automation tests using **Selenium WebDriver** with **NUnit**, targeting the **.NET 8.0** framework. It interacts with form elements, modal dialogs, iframes, and shadow DOM components on the [CloudQA Automation Practice Form](https://app.cloudqa.io/home/AutomationPracticeForm).

## Project Structure

- [Test.sln](Test.sln): Visual Studio solution file.
- [Test/Test.csproj](Test/Test.csproj): The test project file containing dependencies and configurations.
- [Test/UnitTest1.cs](Test/UnitTest1.cs): The main test class containing all test cases.

## Prerequisites

- [.NET 8.0 SDK](https://dotnet.microsoft.com/download)
- [Visual Studio](https://visualstudio.microsoft.com/) or [Visual Studio Code](https://code.visualstudio.com/)
- Microsoft Edge browser (as used in the tests)
- Selenium WebDriver for Edge (installed via NuGet as part of the project dependencies)

## Setup

1.  Clone the repository:
    ```sh
    git clone <your-repository-url>
    cd Form-Automation-With-Selenium
    ```
2.  Restore the .NET dependencies:
    ```sh
    dotnet restore
    ```
3.  (Optional) Open the [Test.sln](Test.sln) file in Visual Studio for a richer development experience, including the Test Explorer.

## Running Tests

You can run the tests using the .NET CLI:

````sh
dotnet test

Collecting workspace information```markdown
# Form Automation with Selenium

This project contains UI automation tests using **Selenium WebDriver** with **NUnit**, targeting the **.NET 8.0** framework. It interacts with form elements, modal dialogs, iframes, and shadow DOM components on the [CloudQA Automation Practice Form](https://app.cloudqa.io/home/AutomationPracticeForm).

## Project Structure

- [Test.sln](Test.sln): Visual Studio solution file.
- [Test/Test.csproj](Test/Test.csproj): The test project file containing dependencies and configurations.
- [Test/UnitTest1.cs](Test/UnitTest1.cs): The main test class containing all test cases.

## Prerequisites

- [.NET 8.0 SDK](https://dotnet.microsoft.com/download)
- [Visual Studio](https://visualstudio.microsoft.com/) or [Visual Studio Code](https://code.visualstudio.com/)
- Microsoft Edge browser (as used in the tests)
- Selenium WebDriver for Edge (installed via NuGet as part of the project dependencies)

## Setup

1.  Clone the repository:
    ```sh
    git clone <your-repository-url>
    cd Form-Automation-With-Selenium
    ```
2.  Restore the .NET dependencies:
    ```sh
    dotnet restore
    ```
3.  (Optional) Open the [Test.sln](Test.sln) file in Visual Studio for a richer development experience, including the Test Explorer.

## Running Tests

You can run the tests using the .NET CLI:

```sh
dotnet test
````

Alternatively, if using Visual Studio, you can run the tests through the Test Explorer window.

## Test Scenarios

The following scenarios are covered in UnitTest1.cs:

- **`TestFillFirstNameAndGender`**: Fills the 'First Name' input field and selects the 'Female' gender radio button.
- **`TestModal`**: Opens and closes a modal dialog window.
- **`TestIFrameWithoutId`**: Switches into an iframe that does not have an ID attribute and interacts with its content.
- **`TestIFrameWithID`**: Switches into an iframe using its ID attribute and verifies its content.
- **`TestShadowDOMWithJS`**: Uses JavaScript execution to interact with an input element located inside a Shadow DOM.

## Configuration

Project dependencies (like Selenium WebDriver, NUnit) and the target framework are defined in the Test.csproj file.

## License

This project is licensed under the MIT License. See the LICENSE.txt file for details.
