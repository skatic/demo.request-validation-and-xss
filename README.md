# Both properties are off and we are sanitizing using a NuGet package

FPR file: both-props-off-encoded.fpr

Settings in web.config:

* `validateRequest="false"` in `<pages>`
* `requestValidationMode="2.0"` in `<httpRuntime>`

NuGet package used:

* `HtmlSanitizer @4.0.217` [doco](https://github.com/mganss/HtmlSanitizer)

> HtmlSanitizer is a .NET library for cleaning HTML fragments and documents from 	constructs that can lead to XSS attacks. It uses AngleSharp to parse, manipulate,and render HTML and CSS.

In this scenario, have have set both of our configuration settings to less then ideal values.  We are not encoding our output and we've installed HTML Sanatizer.  What do you think SCA will do here?  Lets see below

## Cross-Site Scripting: Reflected

N/A!

## Cross-Site Scripting: Poor Validation

N/A!

### Testing
You can test this out by entering something like below in the input box and submitting the form.  

```
<script>alert('hello')</script>wef<b>af</b>af3f
```

You can see the sanitizer removing certain tags.  In this case, it removes the `<script>` tag but it keeps the `<b>` tag so the final output  looks something like this: wef**af**af3f

## ASP.NET Misconfiguration: Request Validation Disabled

Category: Medium

SCA caught both properties we are tracking

* `<pages validateRequest="false"/>`
* `<httpRuntime targetFramework="4.5" requestValidationMode="2.0"/>`

Both have been assigned same Priority values

### Priority Metadata Values

```IMPACT: 2.0```

```LIKELIHOOD: 3.5```
