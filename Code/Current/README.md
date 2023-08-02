
# Get up and Running

### Run the Console
To run the console application only the `dotnet run` command is necessary unless running for the first time.

```bash
dotnet clean
dotnet restore
dotnet run --project QikConsole/QikConsole.csproj
```

To enure a clean restart when restoring the cache (or if you run into dependency issues), you an try: `dotnet restore --no-cache`.


### Environment Variables

To check where (or if) Qik's path is in your environment variables you can run this PowerShell statement:

```PowerShell
$env:Path -split ';' | Where-Object { $_ -like '*Qik*' }
```
Once this path is known, you can use `release.sh` or `release.ps1` to publish to it.

dotnet publish -c release
rm -rf /C/Programs/MyConsole/*
cp -rf MyConsole/bin/Release/net7.0/publish/* /C/Programs/MyConsole/


# Tests

To run the tests simply run the following commands.
```bash
dotnet test
```

```bash
dotnet test ./qiktests/qiktests.csproj
```

### Build the Plugins for Testing

In order to prepare the plugin that is used to test that the plugin system works, the below section in `QikConsoleTests.csproj` builds the `QikFunnyFunctions` and then copies the binaries to the plugins folder, so that the tests can run successfully. 

```xml
    <!-- Compile Test Plugin Assembly (QikFunnyFunctions) and copy it into output Plugins folder. -->
    <Target Name="BuildAndCopyTestPlugin" BeforeTargets="BeforeBuild">
        <Exec Command="dotnet build $(ProjectDir)..\QikFunnyFunctions\QikFunnyFunctions.csproj" />
        <Copy SourceFiles="$(ProjectDir)..\QikFunnyFunctions\bin\debug\net6.0\QikFunnyFunctions.dll" DestinationFolder="$(OutDir)\Plugins" />
    </Target>
```

> **Take note** that when you increment the version (from say net6.0 to net7.0), you'll have to modify the `Copy` command.

### Internals Visible

Adding `InternalsVisibleTo` for tests.
```xml
  <ItemGroup>
    <InternalsVisibleTo Include="QikTests" /> <!-- [assembly: InternalsVisibleTo("CustomTest1")] -->
  </ItemGroup>
```

### Possible Test Explorers/Runners

It might be worth exploring these and others like them at a later stage. At this point you haven't found any of these working effectively.

- https://marketplace.visualstudio.com/items?itemName=hbenl.vscode-test-explorer&ssr=false#overview
- https://marketplace.visualstudio.com/items?itemName=formulahendry.dotnet-test-explorer&ssr=false#overview
- https://marketplace.visualstudio.com/items?itemName=wghats.vscode-nxunit-test-adapter&ssr=false#overview

# Maintenance

To see the current status of your installed SDKs and whether there are patches or updates available run `dotnet sdk check`. 

### Version Management

To target an SDK (or SDK range), `global.json` is used:

```json
{
    "sdk": {
        "version": "7.0.203",
        "rollForward": "latestFeature"
    }
}
```
This specifies that the the latest installed "7.0.*" can be used.

When a major version is changed (eg. net6 to net7), the following should be checked and modified:

- `release.sh` needs to target the correct folder.
- `launch.json` must be modified in all places where the new build folders are specified.
- `QikConsoleTests.csproj` must be modified where `BuildAndCopyTestPlugin` is described.

# The Genesis

The initial steps to create the project are as follows. Later, more projects were added using commands similar to those below.

```
dotnet new sln -n Qik
dotnet new classlib -o Qik
dotnet sln add Qik/Qik.csproj
dotnet build
dotnet new console QikConsole
dotnet new console -o QikConsole
dotnet sln add QikConsole/QikConsole.csproj
dotnet add QikConsole/QikConsole.csproj reference Qik/Qik.csproj
```
### Install and create NUnit tests

Install the template
```
dotnet new -i NUnit3.DotNetNew.Template
```
Create the unit tests
```
dotnet new nunit -n QikConsoleTests
dotnet add QikConsoleTests/QikConsoleTests.csproj reference QikConsole/QikConsole.csproj
dotnet sln add QikConsoleTests/QikConsoleTests.csproj

cd ./QikConsoleTests/
dotnet add package FluentAssertions --version 5.10.3
dotnet add package Moq --version 4.15.1

cd ..

dotnet test
```

### Install Packages
Here is an example of how to install a package to a project at the commandline. You need to navigate into the project folder so that the `csproj` file is in the same directory.
```
dotnet add package Newtonsoft.Json
dotnet add package Newtonsoft.Json --version 12.0.1
```

# Antlr

### ANTLR4 grammar syntax support VS Code Plugin

The extension for ANTLR4 support in Visual Studio code. Provides Code Completion + Symbol Information, Grammar Validations, and Visualizations.

- ANTLR4 grammar syntax support [MarketPlace](https://marketplace.visualstudio.com/items?itemName=mike-lischke.vscode-antlr4&ssr=false#qna)
- ANTLR4 grammar syntax support [Github](https://github.com/mike-lischke/vscode-antlr4)

### Usage

Important that the settings are set up correctly or the grammar file will not generate into C# source code. The mode must be external in order to use the CSharp option and it is important to set the output directory and namespace using the item keys below:

 Item | Value |
| --- | :--- |
| mode | external  |
| language | CSharp  |
| listeners | true  |
| visitors | true  |
| outputDir | _antlr  |
| package | CygSoft.Qik.Antlr  |

When everything is working the files in the `./QikAntlr/_antlr` folder will generate every time a change is made to the `QikTemplate.g4` file. If your files aren't generating it is usually because of one of the reasons below:

- Ensuring that you've added the correcdt settings above for both user and workspace.
- It is possible that there is a problem with your `*.g4` template file.

### Plugin Workspace Settings
```
{
    "antlr4.generation": {
        "mode": "external",
        "language": "CSharp",
        "visitors": true,
        "outputDir": "_antlr",
        "package": "CygSoft.Qik.Antlr"
    }
}
```

# Console Application

### Debugging

- Important that the `externalTerminal` is set for the `console` setting in your `launch.json`. Otherwise you'll run the program in your `internalConsole` and it will break. 
- For more information about the 'console' field, see https://aka.ms/VSCode-CS-LaunchJson-Console

```
            "console": "externalTerminal",
```

## System.Commandline

There was concern that the project for this has stalled, however it seems to have picked up again and [here is a code review of Phase 1](https://www.youtube.com/watch?v=yDQGsZSEDOk)

- [System.CommandLine (Nuget)](https://www.nuget.org/packages/System.CommandLine)
- [System.CommandLine (Github)](https://github.com/dotnet/command-line-api/blob/master/docs/Your-first-app-with-System-CommandLine.md)
- [Dependency Injection and Settings](https://espressocoder.com/2018/12/03/build-a-console-app-in-net-core-like-a-pro/)
- [Getting Started with System.CommandLine](https://dotnetdevaddict.co.za/2020/09/25/getting-started-with-system-commandline/)
- Commandline Option commands have a ParseArguments parameter:
  - [ParseArguments Example 1](https://csharp.hotexamples.com/examples/CommandLine/Parser/ParseArguments/php-parser-parsearguments-method-examples.html)
  - [ParseArguments Example 2](https://csharp.hotexamples.com/examples/CommandLine/CommandLineParser/ParseArguments/php-commandlineparser-parsearguments-method-examples.html)


## System Logging

- [NLog Tutorial - The essential guide for logging from C#](https://blog.elmah.io/nlog-tutorial-the-essential-guide-for-logging-from-csharp/)
- [NLog on Github](https://github.com/NLog/NLog)