using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Repository.Entities.BaseClasses;

namespace Repository.Entities.Html
{
    public class HtmlStyle : NamedDeletableBase
    {
        public string NavCategoryHtmlPrefix { get; set; }
        public string NavCategoryHtmlSuffix { get; set; }
        public string NavCategoryItemHtmlPrefix { get; set; }
        public string NavCategoryItemHtmlSuffix { get; set; }
        public string StatusBarHtmlPrefix { get; set; }
        public string StatusBarHtmlSuffix { get; set; }
        public string ViewHtmlPrefix { get; set; }
        public string ViewHtmlSuffix { get; set; }
        public string ViewHeaderRowHtmlPrefix { get; set; }
        public string ViewHeaderRowHtmlSuffix { get; set; }
        public string ViewRowHtmlPrefix { get; set; }
        public string ViewRowHtmlSuffix { get; set; }
        public string ViewColumnHtmlPrefix { get; set; }
        public string ViewColumnHtmlSuffix { get; set; }
        public bool IsDefault { get; set; }
    }
}
