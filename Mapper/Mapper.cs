using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Repository;

namespace Mapper
{
    public class MapDto
    {
        public string EntityName { get; set; }
        public string PropertyName { get; set; }
        public string ViewName { get; set; }
        public string HtmlPrefix { get; set; }
        public string HtmlSuffix { get; set; }
        public string Type { get; set; }
    }

    public static class Mapper
    {
        static List<MapDto> _maps;
        private static bool _ready;

        static Mapper()
        {
            _ready = false;
            LoadMaps();
            _ready = true;
        }

        private static void LoadMaps()
        {
            _ready = false;
            //get the maps from the repo, load them into memory
            //could be from an XML file, or somehow from a Json file
            //in this case from Map repo
            var repo = new MapRepo();
            var mapEntities = repo.GetMaps().ToList();
            foreach (var map in mapEntities)
            {
                _maps.Add(new MapDto {EntityName = map.EntityName,PropertyName = map.PropertyName,
                    ViewName = map.ViewName, Type = map.Type, HtmlPrefix = map.HtmlPrefix, HtmlSuffix = map.HtmlSuffix});
            }
            _ready = true;

        }

        public static string Map(string entityName, string propertyName, string viewName, string value)
        {
            if (_ready == false)
            {
                Thread.Sleep(500);
            }
            var map = _maps.FirstOrDefault(m => m.EntityName == entityName && m.ViewName == viewName && m.PropertyName == propertyName);
            if (map == null)
                return String.Empty;
            var returnValue = map.HtmlPrefix + value + map.HtmlSuffix;
            return returnValue;

        }

        public static string ReverseMap(string entityName, string propertyName, string formName, string htmlValue)
        {
            if (_ready == false)
            {
                Thread.Sleep(500);
            }
            var map = _maps.FirstOrDefault(m => m.EntityName == entityName && m.ViewName == formName && m.PropertyName == propertyName);
            if (map == null)
                return String.Empty;

            var lengthOfPrefix = map.HtmlPrefix.Length;
            var startOfThisPrefix = htmlValue.IndexOf(map.HtmlPrefix);
            var startOfSuffix = htmlValue.IndexOf(map.HtmlSuffix);
            if (startOfSuffix == 0 || startOfThisPrefix == 0 || lengthOfPrefix == 0)
                throw new Exception("prefix not found or suffix not found");

            var lengthOfValueString = startOfThisPrefix - (lengthOfPrefix + startOfSuffix);
            var returnValue = htmlValue.Substring(startOfThisPrefix+lengthOfPrefix, lengthOfValueString);

            return returnValue;

        }

    }
}
