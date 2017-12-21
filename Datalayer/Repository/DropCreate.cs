using Datalayer.Entities;
using System.Data.Entity;

namespace Datalayer.Repository
{
    public class DropCreate : DropCreateDatabaseIfModelChanges<Datacontext>
    {
        protected override void Seed(Datacontext context)
        {
            var jocke = new User { Firstname = "Jocke", Lastname = "Kniv", Email = "jocke@mail.se", Password = "Jocke1" };
            var Kungen = new User { Firstname = "Kungen", Lastname = "Knug", Email = "kungen@mail.se", Password = "Kungen1" };
            var Dicken = new User { Firstname = "Dicken", Lastname = "Dick", Email = "dicken@hotmail.com", Password = "dicken1" };

            context.Users.Add(jocke);
            context.Users.Add(Kungen);
            context.Users.Add(Dicken);

            context.SaveChanges();
            base.Seed(context);
        }

    }
}
