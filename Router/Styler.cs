using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Repository;
using Repository.Entities.ConnectionAndState;
using Repository.Entities.Html;
using Repository.Entities.UserAndPermissions;

namespace Router
{
    public class Styler : IStyler
    {
        private readonly IRepository<Connection> _connectionRepo;
        private readonly IRepository<User> _userRepo;
        private readonly IRepository<HtmlStyle> _htmlStyleRepo;
        private HtmlStyle _htmlStyle;

        public Styler(IRepository<Connection> connectionRepo, IRepository<User> userRepo, IRepository<HtmlStyle> htmlStyleRepo)
        {
            _connectionRepo = connectionRepo;
            _userRepo = userRepo;
            _htmlStyleRepo = htmlStyleRepo;
        }

        private void InitStyle(Guid connectionId)
        {
            if (_htmlStyle == null)
            {
                //fetch the style to use
                var connection = _connectionRepo.All().Single(c => c.Id == connectionId);
                _htmlStyle = _userRepo.All().Single(u => u.Id == connection.UserId).HtmlStyle;
                if (_htmlStyle == null)
                    _htmlStyle = _htmlStyleRepo.All().Single(h => h.IsDefault);
            }
        }

        public string MakeHtmlForNav(Guid connectionId, NavCategory[] NavCategories)
        {
            InitStyle(connectionId);

            var html = "nav";
            foreach (var navCategory in NavCategories)
            {
                html = _htmlStyle.NavCategoryHtmlPrefix;
                html += navCategory.Description;
                html += _htmlStyle.NavCategoryHtmlSuffix;
                foreach (var navItem in navCategory.NavItems)
                {
                    html += _htmlStyle.NavCategoryItemHtmlPrefix;
                    html += navItem.Description;
                    html += _htmlStyle.NavCategoryItemHtmlSuffix;
                }
            }
            return html;
        }

        public string MakeHtmlForStatusBar(Guid connectionId, StatusBarItem[] StatusBarItems)
        {
            InitStyle(connectionId);

            var html = "topbar~";
            foreach (var statusBarItem in StatusBarItems)
            {
                html = _htmlStyle.NavCategoryHtmlPrefix;
                html += statusBarItem.Description;
                html += _htmlStyle.NavCategoryHtmlSuffix;
            }
            return html;
        }

        public string MakeHtmlForSubscription(Guid connectionId, Subscription Subscription)
        {
            InitStyle(connectionId);
            //TODO

            var html = "content~";
                html = _htmlStyle.NavCategoryHtmlPrefix;
                //html += Subscription;
                html += _htmlStyle.NavCategoryHtmlSuffix;

            return html;

        }

        public string MakeErrorMessage(Guid connectionId, string ErrorText) {
            var html = "messages~<span style='color: white; background - color:red; font - weight:bold'>" + ErrorText + "</span>";
            return html;
        }

    }
}
