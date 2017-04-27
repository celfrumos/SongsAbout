using System.Collections.Generic;

namespace SongsAbout.Web.Models
{
    public interface ISaIntegralEntity : ISaEntity
    {
        List<Keyword> Keywords { get; set; }
        List<Topic> Topics { get; set; }
        List<Genre> Genres { get; set; }
        bool DescribedBy(string term);

    }

    public interface ISaEntity
    {
        string ApiHref { get; }
        SaEntityType EntityType { get; }
        string TypeName { get; }
        int Id { get; set; }
        string Name { get; set; }
        string SpotifyId { get; set; }
        string SpotifyUri { get; }
        string SpotifyWebPage { get; }

    }
}