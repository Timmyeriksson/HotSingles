using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datalayer.Entities
{
    public class Posts
    {
        public virtual int ID { get; set; }

        public int SenderID { get; set; }

        public int ReciverID { get; set; }

        public virtual string TextContent { get; set; }
    }
}
