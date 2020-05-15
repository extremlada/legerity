# Writing tests

As with the aim of the control wrappers, writing tests should be super easy to get started with. 

Legerity exposes an AppManager which is a lightweight wrapper for the application driver that allows you to simply start your applications using a configuration object.

## Creating a base test class

Using your testing framework of choice, getting your application started in the appropriate Appium driver is as simple as calling `AppManager.StartApp()` passing through a `AppManagerOptions` configuration object.

Depending on your configuration object, the specific application will launch.

Currently the `AppManager` configuration supports the following app drivers.

- [WindowsDriver](https://github.com/microsoft/WinAppDriver)
  - [WindowsAppManagerOptions](../src/Legerity/Windows/WindowsAppManagerOptions.cs)

The options object also provides the use of additional capabilities using the `AppiumOptions` object to apply to the driver when the app is started.

### Example base test class

In this example, using the Microsoft Testing Framework, each test that implements the `BaseTestClass` will launch the application on the start of each test, then close the application once the test has completed.

```csharp
namespace WindowsAlarmsAndClock
{
    using Legerity;
    using Legerity.Windows;

    using Microsoft.VisualStudio.TestTools.UnitTesting;

    public abstract class BaseTestClass
    {
        [TestInitialize]
        public virtual void Initialize()
        {
            AppManager.StartApp(
                new WindowsAppManagerOptions("Microsoft.WindowsAlarms_8wekyb3d8bbwe!App")
                {
                    AppiumDriverUrl = "http://127.0.0.1:4723"
                });
        }

        [TestCleanup]
        public virtual void Cleanup()
        {
            AppManager.StopApp();
        }
    }
}
```