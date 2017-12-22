using Datalayer.Entities;
using System.Data.Entity;

namespace Datalayer.Repository
{
    public class DropCreate : DropCreateDatabaseIfModelChanges<Datacontext>
    {
        protected override void Seed(Datacontext context)
        {
            var jocke = new User { Firstname = "Jocke", Lastname = "Kniv", Email = "jocke@mail.se", Password = "Jocke1", Age = 32, About = "Jag gillar hästar", Gender = "Male", Searchable = true, PictureURL = "https://pbs.twimg.com/profile_images/1724449330/stick_man_by_minimoko94-d2zvfn8.png" };
            var Kungen = new User { Firstname = "Kungen", Lastname = "Knug", Email = "kungen@mail.se", Password = "Kungen1", Age = 22, About = "Mitt namn är Kungen men jag är ingen kung för jag är inte tung", Gender = "Other", Searchable = false, PictureURL = "https://pbs.twimg.com/profile_images/1724449330/stick_man_by_minimoko94-d2zvfn8.png" };
            var Dicken = new User { Firstname = "Dicken", Lastname = "Dick", Email = "dicken@hotmail.com", Password = "dicken1", Age = 45, About = "Lorem ipsum", Gender = "Woman", Searchable = true, PictureURL = "https://pbs.twimg.com/profile_images/1724449330/stick_man_by_minimoko94-d2zvfn8.png" };

            var friends1 = new Friend { Friend1 = 1, Friend2 = 2, Accepted = true };
            var friends2 = new Friend { Friend1 = 3, Friend2 = 1, Accepted = false };

            context.Users.Add(jocke);
            context.Users.Add(Kungen);
            context.Users.Add(Dicken);
            context.Friends.Add(friends1);
            context.Friends.Add(friends2);

            context.SaveChanges();
            base.Seed(context);
        }

    }
}
