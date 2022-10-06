# Introduction 
The purpose of this library is to standardized logging code across all VAI projects. The facade itself do not perform any logging, that is delegated to NLog

# Design Considerations
1. Should be easy to use - any configuration setup will be handled internally
2. Facilitate a uniformed way of coding logging requirements irrespective of the application that uses the library
3. Standardized the log output irrespective of the application that uses the library
4. Thread-safe
5. To not reinvent the wheel and instead leverage on industry proven third-party logging libraries that are already proven to work
6. Will instantiate via a factory method to allow for extensibility

# Why NLog?
NLog is easy to implement, that was really all to it in terms of deciding which library to use. There are other libraries as popular if not more popular, like Serilog. Serilog can do structured logging similar to how a JSON looks like. It is an interesting alternative that can may be considered in the future. Extending the facade is as simple as creating a wrapper class to, for example Serilog, and adding that to the factory method.

# Usage
## Basic usage
First, you need to crete an instance of the logger.
```csharp
var logger = LoggerFactory.CreateLoggerInstance(LoggerEnum.NLog, path);
```

Then you can start logging.
```csharp
logger.LogTrace("Hi there!");
```
## Dependency Injection

You only need a singleton instance of the logger
Then you can start logging.
```csharp
var logger = LoggerFactory.CreateLoggerInstance(LoggerEnum.NLog, path);
services.AddSingleton<ILogger>(logger);
```
# Types of logging
## Trace
```csharp
// for debugging purposes
// this log will appear both in Debug and Release builds
logger.LogTrace("Hi there!");
```
## Debug
```csharp
// for debugging purposes
// this log will only appear with Debug builds
logger.LogDebug("Hi there!");
```
## Info
```csharp
// general information to indicate an action to perform or have been performed
// e.g. "Starting process...", "Process was scuccesful!", etc.
logger.LogInfo("Hi there!");
```
## Warning
```csharp
// This is for errors where the application can safely recover from
// e.g. failed connection attempt and retry
logger.LogWarning("Hi there!");
```
## Error
```csharp
// This is for critical errors, where the application cannot recover from
// e.g. failure to load a configuration file
logger.LogError(exception, "Hi there!");
```
## Fatal
```csharp
// This is for heinous errors that will require the system to shutdown
// e.g. insufficient hard disk space
logger.LogFatal(exception, "Hi there!");
```