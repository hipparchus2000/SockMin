using System;
using Repository.Entities.Html;

namespace Router
{
    public interface IStyler
    {
        string MakeHtmlForNav(Guid connectionId, NavCategory[] NavCategories);
        string MakeHtmlForStatusBar(Guid connectionId, StatusBarItem[] StatusBarItems);
        string MakeHtmlForSubscription(Guid connectionId, Subscription Subscription);
        string MakeErrorMessage(Guid connectionId, string ErrorText);
    }
}
