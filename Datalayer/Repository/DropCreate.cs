using Datalayer.Entities;
using System.Data.Entity;

namespace Datalayer.Repository
{
    public class DropCreate : DropCreateDatabaseIfModelChanges<Datacontext>
    {
        protected override void Seed(Datacontext context)
        {
            var illidan = new User { Firstname = "Illidan", Lastname = "Stormrage", Email = "illidan@mail.se", Password = "Illidan1", Age = 32, About = "I AM PREPARED", Gender = "Male", Searchable = true, PictureURL = "https://cdn.blizzardwatch.com/wp-content/uploads/2015/08/illidan-stormrage_demon_wow_art.jpg" };
            var slowpoke = new User { Firstname = "Slowpoke", Lastname = "Slow", Email = "slowpoke@mail.se", Password = "Slowpoke1", Age = 32, About = "Hi! I am very slow", Gender = "Male", Searchable = true, PictureURL = "http://i0.kym-cdn.com/entries/icons/facebook/000/000/128/slowpoke.jpg" };
            var jocke = new User { Firstname = "Jocke", Lastname = "Kniv", Email = "jocke@mail.se", Password = "Jocke1", Age = 32, About = "Jag gillar hästar", Gender = "Male", Searchable = true, PictureURL = "https://liberyx.files.wordpress.com/2015/02/jocke_med_kniven.jpg" };
            var Kungen = new User { Firstname = "Kungen", Lastname = "Knug", Email = "kungen@mail.se", Password = "Kungen1", Age = 22, About = "Mitt namn är Kungen men jag är ingen kung för jag är inte tung", Gender = "Other", Searchable = false, PictureURL = "https://pbs.twimg.com/profile_images/2207614930/kungen_back_400x400.jpg" };
            var Timmy = new User { Firstname = "Timmy", Lastname = "Rullstol", Email = "timmy@hotmail.com", Password = "timmy1", Age = 45, About = "Åker rullstol", Gender = "Woman", Searchable = true, PictureURL = "https://vignette.wikia.nocookie.net/southpark/images/0/0b/62a.jpg/revision/latest/scale-to-width-down/310?cb=20100827140143" };

            context.Users.Add(jocke);
            context.Users.Add(slowpoke);
            context.Users.Add(illidan);
            context.Users.Add(Kungen);
            context.Users.Add(Timmy);

            context.SaveChanges();
            base.Seed(context);
        }

    }
}
