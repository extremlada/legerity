namespace Legerity.Web.Elements.Core
{
    using System.Collections.ObjectModel;
    using Elements;
    using OpenQA.Selenium;
    using OpenQA.Selenium.Remote;

    /// <summary>
    /// Defines a <see cref="IWebElement"/> wrapper for the core web ol or ul control.
    /// </summary>
    public class List : WebElementWrapper
    {
        private readonly By listItemQuery = By.TagName("li");

        /// <summary>
        /// Initializes a new instance of the <see cref="List"/> class.
        /// </summary>
        /// <param name="element">
        /// The <see cref="RemoteWebElement"/> reference.
        /// </param>
        public List(RemoteWebElement element)
            : base(element)
        {
        }

        /// <summary>
        /// Gets the collection of items associated with the list.
        /// </summary>
        public ReadOnlyCollection<IWebElement> Items => this.Element.FindElements(this.listItemQuery);

        /// <summary>
        /// Allows conversion of a <see cref="RemoteWebElement"/> to the <see cref="List"/> without direct casting.
        /// </summary>
        /// <param name="element">
        /// The <see cref="RemoteWebElement"/>.
        /// </param>
        /// <returns>
        /// The <see cref="List"/>.
        /// </returns>
        public static implicit operator List(RemoteWebElement element)
        {
            return new List(element);
        }
    }
}