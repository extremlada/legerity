namespace Legerity.WinUI.Tests.Pages;

using Legerity.Windows;
using Legerity.Windows.Elements.WinUI;
using OpenQA.Selenium.Remote;

internal class RatingControlPage : BaseNavigationPage
{
    public RatingControlPage(RemoteWebDriver app) : base(app)
    {
    }

    public RatingControl SimpleRatingControl => this.FindElement(WindowsByExtras.AutomationId("RatingControl1"));

    public RatingControlPage SetSimpleRatingValue(double value)
    {
        this.SimpleRatingControl.SetValue(value);
        return this;
    }
}