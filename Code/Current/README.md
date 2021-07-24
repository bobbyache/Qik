
# Qik

Why Qik? Qik was designed for a singular purpose. Generate templates into code skeletons. Yes, we have [T4 Templates](https://docs.microsoft.com/en-us/visualstudio/modeling/code-generation-and-t4-text-templates?view=vs-2019), but it seemed so complicated just to get a basic code skeleton to work.

This is not a full solution. But I use it every day. Wish I could spend more time on it...

I'll admit that the idea came from a foolish act of mine to try and generate patterns based on a requirement. I came up with a complex solution which you can find [here](http:/fixthelink). Although I put a number of good design patterns to use I was enlightened by a member of fthe development team that there was a better, tested, alternative. Why not use an established lexer and parser to build the patterns. After licking my wounds I became interested. I realized that maybe I had an interest in having a look at it.

Turns out there was a gap in my education. The experience led me into the domain of Lexers, Parsers, Abstract Syntax Trees, Symbols, and Scope. I learned a lot more about how languages worked. I think the experience might turn me into a better programmer. I now understand why JavaScript, Python, and C# works the way it does. I say this not just because of Udemy or YouTube, but because I've read `The Definitive ANTLR 4 Reference` by Terrence Parr, who has dedicated much of his life to designing a language engine.


I've digressed. What is the point to Qik? Qik takes a number of inputs and transforms them through expressions to generate code templates of your entire architecture. Its not about the details... such as properties of classes. Its more about the framework or structure of your layers. UI, Services, and Repositories (and I'm NOT a fan of repositories).

Much of what you have to do manually is generated. But you have to approach it from an architectural stand point.


## Get up and Running

### Run the Console
To run the console application only the `dotnet run` command is necessary unless running for the first time.

```
dotnet clean
dotnet restore
dotnet run --project QikConsole/QikConsole.csproj
```

### Cmd Execution
```
cd "C:\Code\you\Qik\Code\Current\QikConsole\bin\Debug\net5.0"
qikconsole --path C:\Users\RobB\Desktop\TestQik
```

### Powershell Execution
```
Start-Process -NoNewWindow -FilePath "C:\Code\you\Qik\Code\Current\QikConsole\bin\Debug\net5.0\qikconsole.exe" -ArgumentList "--inputs","--path=C:\Users\RobB\Desktop\TestQik"
```
### Run the tests

```
dotnet test
```

```
dotnet test ./qiktests/qiktests.csproj
```

## Tips and Tricks

### Deep Testing

Adding `InternalsVisibleTo` for tests.
```
<InternalsVisibleTo Include="CustomTest1" /> <!-- [assembly: InternalsVisibleTo("CustomTest1")] -->
```

### Console Project Creation
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
dotnet new nunit -n QikTests
dotnet add qiktests/qiktests.csproj reference Qik/Qik.csproj
```
Run the tests
```
dotnet test ./qiktests/qiktests.csproj
```
Note that the tests can be run using CodeLens. In the NUnit test classes each test method will have a `Run Test` and a `Debug Test` above the method declaration.

### Install Packages
Here is an example of how to install a package to a project at the commandline. You need to navigate into the project folder so that the `csproj` file is in the same directory.
```
dotnet add package Newtonsoft.Json
dotnet add package Newtonsoft.Json --version 12.0.1
```

## Antlr

### ANTLR4 grammar syntax support VS Code Plugin

The extension for ANTLR4 support in Visual Studio code. Provides Code Completion + Symbol Information, Grammar Validations, and Visualizations.

- ANTLR4 grammar syntax support [MarketPlace](https://marketplace.visualstudio.com/items?itemName=mike-lischke.vscode-antlr4&ssr=false#qna)
- ANTLR4 grammar syntax support [Github](https://github.com/mike-lischke/vscode-antlr4)

### Usage

Important that the settings are set up correctly or your grammar file will not generate into C# source code. The mode must be external in order to use the CSharp option and it is important to set the output directory and namespace using the item keys below:

 Item | Value |
| --- | :--- |
| mode | external  |
| language | CSharp  |
| listeners | true  |
| visitors | true  |
| outputDir | _antlr  |
| package | CygSoft.Qik.Antlr  |

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
### Possible Test Explorers/Runners

- https://marketplace.visualstudio.com/items?itemName=hbenl.vscode-test-explorer&ssr=false#overview
- https://marketplace.visualstudio.com/items?itemName=formulahendry.dotnet-test-explorer&ssr=false#overview
- https://marketplace.visualstudio.com/items?itemName=wghats.vscode-nxunit-test-adapter&ssr=false#overview

## Console Application

### Debugging

- Important that the `externalTerminal` is set for the `console` setting in hyour launch.json. Otherwise you'll run the program in your `internalConsole` and it will break. 
- For more information about the 'console' field, see https://aka.ms/VSCode-CS-LaunchJson-Console

```
            "console": "externalTerminal",
```

### System.Commandline

- [System.CommandLine (Nuget)](https://www.nuget.org/packages/System.CommandLine)
- [System.CommandLine (Github)](https://github.com/dotnet/command-line-api/blob/master/docs/Your-first-app-with-System-CommandLine.md)
- [Dependency Injection and Settings](https://espressocoder.com/2018/12/03/build-a-console-app-in-net-core-like-a-pro/)
- [Getting Started with System.CommandLine](https://dotnetdevaddict.co.za/2020/09/25/getting-started-with-system-commandline/)
- Commandline Option commands have a ParseArguments parameter:
  - [ParseArguments Example 1](https://csharp.hotexamples.com/examples/CommandLine/Parser/ParseArguments/php-parser-parsearguments-method-examples.html)
  - [ParseArguments Example 2](https://csharp.hotexamples.com/examples/CommandLine/CommandLineParser/ParseArguments/php-commandlineparser-parsearguments-method-examples.html)


### System Logging

- [NLog Tutorial - The essential guide for logging from C#](https://blog.elmah.io/nlog-tutorial-the-essential-guide-for-logging-from-csharp/)
- [NLog on Github](https://github.com/NLog/NLog)