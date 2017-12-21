using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datalayer.Entities
{
    public class FriendEntity
    {
        public int Id { get; set; }
        public virtual User Friend1 { get; set; }
        public virtual User Friend2 { get; set; }
        public bool Accepted { get; set; }
    }
}
