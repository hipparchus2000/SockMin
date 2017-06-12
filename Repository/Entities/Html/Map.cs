using System;
using Repository.Entities.BaseClasses;

namespace Repository.Entities.Html
{
    public class Map: IEntity
    {
        public Guid Id { get; set; }
        public string EntityName { get; set; }
        public string PropertyName { get; set; }
        public string ViewName { get; set; }
        public string HtmlPrefix { get; set; }
        public string HtmlSuffix { get; set; }
        public string Type { get; set; }
    }
}
