# Both properties have been turned off

FPR file: both-props-off.fpr

Settings in web.config:

* `validateRequest="false"` in `<pages>`
* `requestValidationMode="2.0"` in `<httpRuntime>`

With these settings, our application processes request validation as an old ASP.NET application.
[This link](https://docs.microsoft.com/en-us/dotnet/api/system.web.configuration.httpruntimesection.requestvalidationmode?redirectedfrom=MSDN&view=netframework-4.8#System_Web_Configuration_HttpRuntimeSection_RequestValidationMode) explains what `requestValidationMode="2.0"` does:

>`2.0` Request validation is enabled only for pages, not for all HTTP requests. In addition, the request validation settings of the `<pages>` element (if any) in the configuration file or of the @ Page directive in an individual page are used to determine which page requests to validate.

Validation now also happens later in the request life cycle than it does with default setting of `4.5`

## Cross-Site Scripting: Reflected

Category: **critical**

SCA assigns both Impact and Likelihood to 5.
This makes sense as anyone can attack the app with basic scripting knowledge as the app is fully open to XSS.

### Priority Metadata Values

```IMPACT: 5.0```

```LIKELIHOOD: 5.0```

### Testing
You can test this out by entering something like below in the input box and submitting the form.
```
<script>alert('hello')</script>
```

## ASP.NET Misconfiguration: Request Validation Disabled

Category: Medium

SCA caught both properties we are tracking

* `<pages validateRequest="false"/>`
* `<httpRuntime targetFramework="4.5" requestValidationMode="2.0"/>`

Both have been assigned same Priority values

### Priority Metadata Values

```IMPACT: 2.0```

```LIKELIHOOD: 3.5```

