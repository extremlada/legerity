namespace Legerity.Windows.Elements.Core;

using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Windows;
using OpenQA.Selenium.Remote;

/// <summary>
/// Defines a <see cref="WindowsElement"/> wrapper for the core UWP TimePicker control.
/// </summary>
public class TimePicker : WindowsElementWrapper
{
    /// <summary>
    /// Initializes a new instance of the <see cref="TimePicker"/> class.
    /// </summary>
    /// <param name="element">
    /// The <see cref="WindowsElement"/> reference.
    /// </param>
    public TimePicker(WindowsElement element)
        : base(element)
    {
    }

    /// <summary>
    /// Allows conversion of a <see cref="WindowsElement"/> to the <see cref="TimePicker"/> without direct casting.
    /// </summary>
    /// <param name="element">
    /// The <see cref="WindowsElement"/>.
    /// </param>
    /// <returns>
    /// The <see cref="TimePicker"/>.
    /// </returns>
    public static implicit operator TimePicker(WindowsElement element)
    {
        return new TimePicker(element);
    }

    /// <summary>
    /// Allows conversion of a <see cref="AppiumWebElement"/> to the <see cref="TimePicker"/> without direct casting.
    /// </summary>
    /// <param name="element">
    /// The <see cref="AppiumWebElement"/>.
    /// </param>
    /// <returns>
    /// The <see cref="TimePicker"/>.
    /// </returns>
    public static implicit operator TimePicker(AppiumWebElement element)
    {
        return new TimePicker(element as WindowsElement);
    }

    /// <summary>
    /// Allows conversion of a <see cref="RemoteWebElement"/> to the <see cref="TimePicker"/> without direct casting.
    /// </summary>
    /// <param name="element">
    /// The <see cref="RemoteWebElement"/>.
    /// </param>
    /// <returns>
    /// The <see cref="TimePicker"/>.
    /// </returns>
    public static implicit operator TimePicker(RemoteWebElement element)
    {
        return new TimePicker(element as WindowsElement);
    }

    /// <summary>
    /// Sets the time to the specified time.
    /// </summary>
    /// <param name="time">
    /// The time to set.
    /// </param>
    /// <exception cref="InvalidElementStateException">Thrown when an element is not enabled.</exception>
    /// <exception cref="StaleElementReferenceException">Thrown when an element is no longer valid in the document DOM.</exception>
    /// <exception cref="ElementNotVisibleException">Thrown when an element is not visible.</exception>
    /// <exception cref="NoSuchElementException">Thrown when no element matches the expected locator.</exception>
    public virtual void SetTime(TimeSpan time)
    {
        // Taps the time picker to show the popup.
        this.Click();

        // Finds the popup and changes the time.
        WindowsElement popup = this.Driver.FindElement(WindowsByExtras.AutomationId("TimePickerFlyoutPresenter"));
        popup.FindElement(WindowsByExtras.AutomationId("HourLoopingSelector")).FindElementByName(time.ToString("%h")).Click();
        popup.FindElement(WindowsByExtras.AutomationId("MinuteLoopingSelector")).FindElementByName(time.ToString("mm")).Click();
        popup.FindElement(WindowsByExtras.AutomationId("AcceptButton")).Click();
    }
}