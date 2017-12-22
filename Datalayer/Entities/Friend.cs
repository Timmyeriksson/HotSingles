using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datalayer.Entities
{
    public class Friend
    {
        public int Id { get; set; }
        public virtual int Friend1 { get; set; }
        public virtual int Friend2 { get; set; }
        public bool Accepted { get; set; }
    }
}