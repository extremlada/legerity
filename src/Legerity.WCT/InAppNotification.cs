namespace Legerity.Windows.Elements.WCT;

using System.Linq;
using Legerity.Windows.Elements.Core;
using OpenQA.Selenium;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Windows;
using OpenQA.Selenium.Remote;

/// <summary>
/// Defines a <see cref="WindowsElement"/> wrapper for the Windows Community Toolkit InAppNotification control.
/// </summary>
public class InAppNotification : WindowsElementWrapper
{
    /// <summary>
    /// Initializes a new instance of the <see cref="InAppNotification"/> class.
    /// </summary>
    /// <param name="element">
    /// The <see cref="WindowsElement"/> reference.
    /// </param>
    public InAppNotification(WindowsElement element)
        : base(element)
    {
    }

    /// <summary>
    /// Gets the dismiss button.
    /// </summary>
    /// <exception cref="NoSuchElementException">Thrown when no element matches the expected locator.</exception>
    public virtual Button DismissButton => this.FindElement(WindowsByExtras.AutomationId("PART_DismissButton"));

    /// <summary>
    /// Gets the message displayed.
    /// <para>
    /// Note, this only works if the Content is based on a <see cref="string"/> or if the ContentTemplate includes a TextBlock element with the message.
    /// </para>
    /// </summary>
    /// <exception cref="StaleElementReferenceException">Thrown when an element is no longer valid in the document DOM.</exception>
    public virtual string Message => this.Element.FindElementsByClassName("TextBlock").FirstOrDefault()?.Text;

    /// <summary>
    /// Allows conversion of a <see cref="WindowsElement"/> to the <see cref="InAppNotification"/> without direct casting.
    /// </summary>
    /// <param name="element">
    /// The <see cref="WindowsElement"/>.
    /// </param>
    /// <returns>
    /// The <see cref="InAppNotification"/>.
    /// </returns>
    public static implicit operator InAppNotification(WindowsElement element)
    {
        return new InAppNotification(element);
    }

    /// <summary>
    /// Allows conversion of a <see cref="AppiumWebElement"/> to the <see cref="InAppNotification"/> without direct casting.
    /// </summary>
    /// <param name="element">
    /// The <see cref="AppiumWebElement"/>.
    /// </param>
    /// <returns>
    /// The <see cref="InAppNotification"/>.
    /// </returns>
    public static implicit operator InAppNotification(AppiumWebElement element)
    {
        return new InAppNotification(element as WindowsElement);
    }

    /// <summary>
    /// Allows conversion of a <see cref="RemoteWebElement"/> to the <see cref="InAppNotification"/> without direct casting.
    /// </summary>
    /// <param name="element">
    /// The <see cref="RemoteWebElement"/>.
    /// </param>
    /// <returns>
    /// The <see cref="InAppNotification"/>.
    /// </returns>
    public static implicit operator InAppNotification(RemoteWebElement element)
    {
        return new InAppNotification(element as WindowsElement);
    }

    /// <summary>
    /// Dismissed the in-app notification.
    /// </summary>
    /// <exception cref="NoSuchElementException">Thrown when no element matches the expected locator.</exception>
    /// <exception cref="InvalidElementStateException">Thrown when an element is not enabled.</exception>
    /// <exception cref="ElementNotVisibleException">Thrown when an element is not visible.</exception>
    /// <exception cref="StaleElementReferenceException">Thrown when an element is no longer valid in the document DOM.</exception>
    public virtual void Dismiss()
    {
        this.DismissButton.Click();
    }
}