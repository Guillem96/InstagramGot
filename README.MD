# InstagramGot

<img src="InstagramGotLogo.png" alt="InstagramGot Logo" style="width: 200px;"/>

Instagram C# Library In order to simplify the calls to instagram api.

### Prerequisites

Nuget packages for visual studio

```
Id                                  Versions                                 ProjectName                         
--                                  --------                                 -----------                         
MSTest.TestAdapter                  {1.1.11}                                 InstagramGot.Test                   
MSTest.TestFramework                {1.1.11}                                 InstagramGot.Test                   
PhantomJS                           {1.9.8}                                  InstagramGot.Test                   
Selenium.WebDriver                  {3.4.0}                                  InstagramGot.Test                   
Newtonsoft.Json                     {10.0.3}                                 InstagramGot     
```

## Running the tests

Run tests from Visual Studio's Test Explorer. There are some tests playlist in case you 
want to run tests separately.

### Test Issue

Search functionality can't be tested because the application client ID for instagram api is in SandBoxmode.

Instagram stuff is paranoid about users data...


## Deployment

Add additional notes about how to deploy this on a live system

## Built With

* [PhantomJS](http://phantomjs.org/) - PhantomJS for initialize the tests

## Authors

* **Guillem Orellana Trullols** - *All work* - [Guillem96](https://github.com/Guillem96)
