using System.Collections.Generic;

namespace SongsAbout.Web.Models
{
    public interface ISaEntity
    {
        string ApiHref { get; }
        SaEntityType EntityType { get; }
        string TypeName { get; }
        //     List<Genre> Genres { get; set; }
        int Id { get; set; }
        //int? Index { get; }
        List<Keyword> Keywords { get; set; }
        string Name { get; set; }
        string SpotifyId { get; set; }
        string SpotifyUri { get; }
        string SpotifyWebPage { get; }
        List<Topic> Topics { get; set; }
    }
}