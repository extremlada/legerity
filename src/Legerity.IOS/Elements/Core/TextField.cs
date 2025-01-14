namespace Legerity.IOS.Elements.Core;

using Legerity.IOS.Elements;
using Legerity.IOS.Extensions;
using OpenQA.Selenium;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.iOS;
using OpenQA.Selenium.Remote;

/// <summary>
/// Defines a <see cref="IOSElement"/> wrapper for the core iOS TextField control.
/// </summary>
public class TextField : IOSElementWrapper
{
    /// <summary>
    /// Initializes a new instance of the <see cref="TextField"/> class.
    /// </summary>
    /// <param name="element">The <see cref="IOSElement"/> representing the <see cref="TextField"/> element.</param>
    public TextField(IOSElement element)
        : base(element)
    {
    }

    /// <summary>
    /// Gets the text value of the text field.
    /// </summary>
    /// <exception cref="StaleElementReferenceException">Thrown when an element is no longer valid in the document DOM.</exception>
    public virtual string Text => this.GetValue();

    /// <summary>
    /// Gets the element associated with the clear text button, if shown.
    /// </summary>
    /// <exception cref="NoSuchElementException">Thrown when no element matches the expected locator.</exception>
    public virtual Button ClearTextButton => this.FindElement(IOSByExtras.Label("Clear text"));

    /// <summary>
    /// Allows conversion of a <see cref="IOSElement"/> to the <see cref="TextField"/> without direct casting.
    /// </summary>
    /// <param name="element">
    /// The <see cref="IOSElement"/>.
    /// </param>
    /// <returns>
    /// The <see cref="TextField"/>.
    /// </returns>
    public static implicit operator TextField(IOSElement element)
    {
        return new TextField(element);
    }

    /// <summary>
    /// Allows conversion of a <see cref="AppiumWebElement"/> to the <see cref="TextField"/> without direct casting.
    /// </summary>
    /// <param name="element">
    /// The <see cref="AppiumWebElement"/>.
    /// </param>
    /// <returns>
    /// The <see cref="TextField"/>.
    /// </returns>
    public static implicit operator TextField(AppiumWebElement element)
    {
        return new TextField(element as IOSElement);
    }

    /// <summary>
    /// Allows conversion of a <see cref="RemoteWebElement"/> to the <see cref="TextField"/> without direct casting.
    /// </summary>
    /// <param name="element">
    /// The <see cref="RemoteWebElement"/>.
    /// </param>
    /// <returns>
    /// The <see cref="TextField"/>.
    /// </returns>
    public static implicit operator TextField(RemoteWebElement element)
    {
        return new TextField(element as IOSElement);
    }

    /// <summary>
    /// Sets the text of the text field to the specified text.
    /// </summary>
    /// <param name="text">The text to display.</param>
    /// <exception cref="ElementNotVisibleException">Thrown when an element is not visible.</exception>
    /// <exception cref="InvalidElementStateException">Thrown when an element is not enabled.</exception>
    /// <exception cref="StaleElementReferenceException">Thrown when an element is no longer valid in the document DOM.</exception>
    public virtual void SetText(string text)
    {
        this.ClearText();
        this.AppendText(text);
    }

    /// <summary>
    /// Appends the specified text to the text field.
    /// </summary>
    /// <param name="text">The text to append.</param>
    /// <exception cref="InvalidElementStateException">Thrown when an element is not enabled.</exception>
    /// <exception cref="ElementNotVisibleException">Thrown when an element is not visible.</exception>
    /// <exception cref="StaleElementReferenceException">Thrown when an element is no longer valid in the document DOM.</exception>
    public virtual void AppendText(string text)
    {
        this.Click();
        this.Element.SendKeys(text);
    }

    /// <summary>
    /// Clears the text from the text field.
    /// </summary>
    /// <exception cref="InvalidElementStateException">Thrown when an element is not enabled.</exception>
    /// <exception cref="ElementNotVisibleException">Thrown when an element is not visible.</exception>
    /// <exception cref="StaleElementReferenceException">Thrown when an element is no longer valid in the document DOM.</exception>
    public virtual void ClearText()
    {
        this.Click();
        this.Element.Clear();
    }
}