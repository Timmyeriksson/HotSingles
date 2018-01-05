using Datalayer.Entities;
using System.Data.Entity;

namespace Datalayer.Repository
{
    public class DropCreate : DropCreateDatabaseIfModelChanges<Datacontext>
    {
        protected override void Seed(Datacontext context)
        {
            var bamse = new User { Firstname = "Bamse", Lastname = "Dunderhonung", Email = "bamse@mail.se", Password = "Bamse1", Age = 32, About = "I like to eat my honey", Gender = "Male", Searchable = true, PictureURL = "https://www.bamse.se/wp-content/uploads/Bamse.jpg" };
            var kalle = new User { Firstname = "Kalle", Lastname = "Anka", Email = "kalle@mail.se", Password = "Kalle1", Age = 42, About = "My name is Kalle Anka, and I am a duck without pants", Gender = "Male", Searchable = true, PictureURL = "https://vignette.wikia.nocookie.net/kalleankasverige/images/b/b5/Kalle_anka.gif/revision/latest?cb=20130719090853&path-prefix=sv" };
            var fiona = new User { Firstname = "Fiona", Lastname = "of Far, far, away", Email = "fiona@mail.se", Password = "Fiona1", Age = 24, About = "Once I was turned into an ogre. BEST. DAY. EVER.", Gender = "Female", Searchable = true, PictureURL = "https://orig00.deviantart.net/4c8b/f/2016/137/0/f/princess_fiona_ogre_by_shrek_is_death-da2usgi.jpg" };
            var shrek = new User { Firstname = "Shrek", Lastname = "the Ogre", Email = "shrek@mail.se", Password = "Shrek1", Age = 56, About = "I am a big ogre! How about them apples?", Gender = "Male", Searchable = true, PictureURL = "https://vignette.wikia.nocookie.net/its-always-veggie-bone-lebowski-party-knuckles/images/1/1f/Shrek-0.jpg/revision/latest?cb=20170328013347" };
            var walle = new User { Firstname = "Wall", Lastname = "E", Email = "walle@mail.se", Password = "Walle1", Age = 89, About = "Bip bop bepilo bop biiip", Gender = "Other", Searchable = false, PictureURL = "https://vignette.wikia.nocookie.net/disney/images/2/2b/Wall-E.png/revision/latest?cb=20151002192237" };

            context.Users.Add(bamse);
            context.Users.Add(kalle);
            context.Users.Add(fiona);
            context.Users.Add(shrek);
            context.Users.Add(walle);

            context.SaveChanges();
            base.Seed(context);
        }

    }
}
