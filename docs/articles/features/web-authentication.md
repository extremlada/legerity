---
uid: web-authentication
title: Using the Web authentication helpers
---

# Using the Web authentication helpers

The goal of the Web authentication library is to provide an easy set of standard page objects to interact with common authentication provider flows on the web.

## Azure AD login

- [AzureAdLoginPage](https://github.com/MADE-Apps/legerity/blob/main/src/Legerity.Web.Authentication/Pages/AzureAdLoginPage.cs)

## Facebook login

The Facebook login page object is designed to automate the [Facebook authentication flow](https://developers.facebook.com/docs/facebook-login/guides/advanced/manual-flow) when building applications that support Facebook identity.

Simply initialize the `FacebookLoginPage` when the page is in view, and call the `Login` method with a username and password to login.

```csharp
new FacebookLoginPage(AppManager.App)
        .Login("example@example.com", "example");
```

- [FacebookLoginPage](https://github.com/MADE-Apps/legerity/blob/main/src/Legerity.Web.Authentication/Pages/FacebookLoginPage.cs)