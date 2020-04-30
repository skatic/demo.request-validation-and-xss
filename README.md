# ASP.NET Request Validation And Xss
Lets take a closer look at how SCA handles and scores various web.config settings for request validation that comes integrated with ASP.NET frameworks.

## Overview

Here is a [Whitepaper from Microsoft](https://docs.microsoft.com/en-us/aspnet/whitepapers/request-validation) that covers the basics of request validation.  This is for old ASP.NET versions (1.1 and 2.0)

The code in this simple application uses .NET version 4.5 in which, in addition to what is described in the article above, `requestValidationMode` property in `<httpRuntime>` section has to be set to `2.0` in order to "disable" the built in ASP.NET request validation.

This will demonstrate how SCA tracks these properties and how it reports on `Cross-Site Scripting: Reflected` issues found due to different configuration of these settings.

## Scenarios

Each scenario has been put in its own branch with its own readme file that looks at how SCA behaves.  Each branch also has an fpr file that was generated.

List of scenarios (I recommend to visit them in order listed below):

1. Both properties have been disabled.  Branch `both-props-off`
2. One property is disabled and the other one is enabled. Branch `one-prop-off`
3. Both properties have been enabled.  Branch `both-props-on`
4. Both properties have been enabled and output is being encoded. Branch `both-props-on-encoded`
5. Both properties have been disabled and a sanatizing library has been added. Branch `both-props-off-encoded-filtered`

## SCA Commands used

### Build command
For all of these different scenarios I've used below basic build command that uses msbuild in the backend
```
sourceanalyzer -b mybuild -exclude bin devenv RequestValidationAndXss.sln /Build
```

### Scan command
```
sourceanalyzer -b mybuild -scan -f fpr-file-name.fpr
```

### SCA version
```
19.2
```

## Notes
* Each branch has its own readme file that explains its scenario
* Even though SCA finds bunch of different types of voulnerabilities in a very minimalistic application such as this one, we will only track and look at two types:
	* Cross-Site Scripting: Reflected
	* ASP.NET Misconfiguration: Request Validation Disabled
* I realize that I worded some readme titles (and branch names)  somewhat badly.  For example, "Property is Off" doesn't mean what it sounds like.  Setting `requestValidationMode` to `2.0` for example, doesn't "turn it off" but just makes the application process certain things in a different way.
