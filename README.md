# Only one property is disabled

FPR file: one-prop-off.fpr

Settings in web.config:

* `validateRequest="true"` in `<pages>`
* `requestValidationMode="2.0"` in `<httpRuntime>`

We've fixed `validateRequest` by setting it to true (also the default value, if not set explicitly).  As mentioned in master branch's readme file, for .NET 4.0 and above this is not enough!  We also have to set `requestValidationMode` to correct value (i.e. 4.5) or not set it at all.
Since we set `validateRequest` to true,  setting `requestValidationMode` to 2.0 will still protect our application but in a way that used to work in old ASP.NET where validation is done in a later parts of the request life cycle. [This document](https://docs.microsoft.com/en-us/dotnet/api/system.web.configuration.httpruntimesection.requestvalidationmode?redirectedfrom=MSDN&view=netframework-4.8#System_Web_Configuration_HttpRuntimeSection_RequestValidationMode) covers what different values for `requestValidationMode` do.  Basically, if set to 2.0 this property will **only** apply the default ASP.NET request validation to our pages files (i.e. .aspx files).  Since our page files are protected, we will have to find a way using another type of file.  In this example I used a generic handler (.ashx) file.

## Cross-Site Scripting: Reflected

Category: high

Compared to the previous example, SCA actually dropped the severity of the issue found due to likelihood value going down to 2 (in last example it was at 5):

### Priority Metadata Values

```IMPACT: 5.0```

```LIKELIHOOD: 2.0```

### Testing
You can test this by entering something like below in the URL as the value for queryparam1.
```
<script>alert('hello')</script>
```

## ASP.NET Misconfiguration: Request Validation Disabled

Category: Medium

This time, SCA correctly points out the vulnerability in one section only:
`requestValidationMode="2.0"` in `<httpRuntime>`

### Priority Metadata Values

```IMPACT: 2.0```

```LIKELIHOOD: 3.5```

## Conclusions

* If `requestValidationMode` is set to `2.0` default ASP.NET is enabled only for .aspx files and **disabled** for other files, like handlers.
* SCA does not categorize the XSS vulnerability made in this manner as critical but rather high.
