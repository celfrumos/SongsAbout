using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.Entity;

namespace SongsAbout.Web.Models
{
    public class EntityInitializer : DropCreateDatabaseIfModelChanges<EntityDbContext>
    {
        protected override void Seed(EntityDbContext context)
        {
            context.Artists.Add(new Artist { ArtistId = 0, Name = "Solarsuit", Bio = "I went to school with and took music lessons with half of these guys. They just got over 100,000 listens on their latest single, \"For the thrill\"", Href = @"https://api.spotify.com/v1/artists/0baEjE334rm6o1DfzbTcHT", Uri = "spotify:artist:0baEjE334rm6o1DfzbTcHT" });
            context.Artists.Add(new Artist { ArtistId = 1, Name = "William Fitzsimmons", Bio = "Slow is is forte. And he's killin it", Href = @"https://api.spotify.com/v1/artists/41FEVJCBGidsJwbjq0KfgM", Uri = "spotify:artist:41FEVJCBGidsJwbjq0KfgM" });
            context.Artists.Add(new Artist { ArtistId = 2, Name = "Christina Grimmie", Bio = "Started on Youtube, made it big on The Voice, but was tragically murdered last year.", Href = @"https://api.spotify.com/v1/artists/0Cav8jyZKAHMFbAusOmjku", Uri = "spotify:artist:0Cav8jyZKAHMFbAusOmjku" });
            context.Artists.Add(new Artist { ArtistId = 3, Name = "John Mayer", Bio = "The magical d-bag everyone wants to be.", Href = @"https://api.spotify.com/v1/artists/0hEurMDQu99nJRq8pTxO14", Uri = "spotify:artist:0hEurMDQu99nJRq8pTxO14" });


            base.Seed(context);
        }
    }
}