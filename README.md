# Both properties are enabled

FPR file: both-props-on.fpr

Settings in web.config:

* `validateRequest="true"` in `<pages>`
* `requestValidationMode="4.5"` in `<httpRuntime>`

These are default values for these two settings.  Lets see what SCA does.  I would suggest reading [this article](https://www.codeproject.com/Articles/358993/Examining-Request-Validation-with-ASP-NET-4-5) if you're curious about differences in how requests are validated with setting of `4.5` vs `2.0`.

## Cross-Site Scripting: Reflected

Category: high

Just like in the previous example, SCA categorizes the vulnerability as High.  This could be somewhat surprising (since the values are set to their defaults) but it is a good thing since the default ASP.NET request validation is first line of defence and not meant to be a panacea for XSS issues.

### Priority Metadata Values

```IMPACT: 5.0```

```LIKELIHOOD: 2.0```


## ASP.NET Misconfiguration: Request Validation Disabled

Category: N/A

As expected, we have zero issues found in this category since both tracked setting are set to default values.


## Conclusions

SCA categorized the XSS vulnerability high in both, this scenario and the past one where we had one of the settings configured less then idealy.