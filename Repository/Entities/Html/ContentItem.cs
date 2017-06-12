using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mime;
using System.Text;
using System.Threading.Tasks;
using Repository.Entities.BaseClasses;

namespace Repository.Entities.Html
{
    public enum ContentItemType
    {
        Html = 0,
        Css,
        Js
    }

    public class ContentItem : NamedDeletableBase
    {
        public string Content { get; set; } //html or CSS or js
        public ContentItemType ContentItemType { get; set; }
    }
}
