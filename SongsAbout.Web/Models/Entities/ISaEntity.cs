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
    public interface ISaDbEntityAccessor
    {
        int Id { get; set; }
        string Name { get; set; }
    }

    public interface ISaEntity : ISaDbEntityAccessor
    {
        string ApiHref { get; }
        SaEntityType EntityType { get; }
        string SpotifyId { get; set; }
        string SpotifyUri { get; }
        string SpotifyWebPage { get; }

    }
}