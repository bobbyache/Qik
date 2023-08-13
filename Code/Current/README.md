
# Operational Information

### Simple Operation

To set up a project file for testing do the following:

```bash
mkdir TestDir
cd TestDir

touch ./script.qik
touch ./input.qikt
touch ./project.json
```

Your `project.json` file should end up looking like this.

```json
{
    "scriptPath": ".\\script.qik",
    "fragments": [
        {
            "id": "input",
            "path": "input.qikt"
        }
    ],
    "documents": [
        {
            "outputFilePaths": ["output.md"],
            "structure": ["input" ]
        }
    ]
}
```

Your `script.qik` file should end up looking like this.

```
@Variable => "my variable text here...";
```

Your `input.qikt` file should end up looking like this.

```
@{Variable}
```

Add the path to your `QikConsole` to the PATH environment variable and run the following command:

```PowerShell
qikconsole gen simple -f .\project.json
```

### Using inputs

To set up a project file for testing do the following:

```bash
mkdir TestDir
cd TestDir

touch ./script.qik
touch ./input.qikt
touch ./project.json
```

Your `project.json` file should end up looking like this.

```json
{
    "scriptPath": ".\\script.qik",
    "fragments": [
        {
            "id": "input",
            "path": "input.qikt"
        }
    ],
    "documents": [
        {
            "outputFilePaths": ["output.md"],
            "structure": ["input" ]
        }
    ]
}
```

Your `script.qik` file should end up looking like this.

```
[title="Variable 1", type="text"] @Variable1 => "default value 1";
[title="Variable 2", type="text"] @Variable1 => "default value 2";
```

Your `input.qikt` file should end up looking like this.

```
@{Variable1}
@{Variable2}
```

Add the path to your `QikConsole` to the PATH environment variable and run the following command:

```PowerShell
qikconsole gen simple -f .\TestDir\project.json -i "Variable1=An Elephant;Variable2=A Rhino"
```

You should see `An elephant` and `A Rhino` in the output document. Using `qikconsole gen simple -f .\TestDir\project.json` will generate with the default values.


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

### Internals Visible

Adding `InternalsVisibleTo` for tests.
```xml
  <ItemGroup>
    <InternalsVisibleTo Include="QikTests" /> <!-- [assembly: InternalsVisibleTo("QikConsoleTests")] -->
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