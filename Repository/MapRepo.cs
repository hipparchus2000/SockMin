using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Repository.Entities;
using Repository.Entities.Html;

namespace Repository
{
    public class MapRepo
    {
        public IQueryable<Map> GetMaps()
        {
            using (var context = new SockMinDbContext())
            {
                return context.Maps;
            }
        }
    }
}
