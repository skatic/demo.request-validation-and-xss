# Both properties are off and output is encoded

FPR file: both-props-off-encoded.fpr

Settings in web.config:

* `validateRequest="false"` in `<pages>`
* `requestValidationMode="2.0"` in `<httpRuntime>`

## Cross-Site Scripting: Reflected

N/A!

## Cross-Site Scripting: Poor Validation

Category: medium

In this scenario, have have set both of our configuration settings to less then ideal values and SCA is still categorazing the XSS vulnerability as medium.  Remember how this used to be critical XSS: Reflected in `both-props-off`.  Notice that the XSS type reported here is also different.

Why was this reported as different XSS type and criticality lowered to medium?  Here is an excerpt from issue details:

> The use of certain encoding functions will prevent some, but not all cross-site scripting attacks. Depending on the context in which the data appear, characters beyond the basic <, >, &, and " that are HTML-encoded and those beyond <, >, &, ", and ' that are XML-encoded may take on meta-meaning. Relying on such encoding functions is equivalent to using a weak blacklist to prevent cross-site scripting and might allow an attacker to inject malicious code that will be executed in the browser. Because accurately identifying the context in which the data appear statically is not always possible, the Fortify Secure Coding Rulepacks report cross-site scripting findings even when encoding is applied and presents them as Cross-Site Scripting: Poor Validation issues.

We encoded our output and that alone made the XSS drop to medium.  CSA is almost happy but not quite yet!

We are handling the **output** to CSA's satisfaction but we are not doing anything yet with the **input**.

We made impact of XSS go down from `5.0` to `2.0` which is great.

*(Note that if we set the two tracked properties to their default values and use encoding SCA will lower the XSS even further, down to Low category -with impact/likelihood of 2.0/1.6).*

We have now seen scenarios in which SCA scores XSS vulnerabilities as all different categories (Critical/High/Medium/Low).  In the next scenario, we will see what needs to happen for SCA to find no XSS vulnerabilities in our code.

### Priority Metadata Values

```IMPACT: 2.0```

```LIKELIHOOD: 4.0```

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
