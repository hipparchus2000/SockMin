using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Repository.Entities.BaseClasses;

namespace Repository.Entities.Generic
{
    public class LogEntry: IEntity
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public DateTime Date { get; set; }
        public string Text { get; set; }
    }
}
