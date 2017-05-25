using System.Collections.Generic;

namespace SongsAbout.Web.Models
{
    public interface ISaDbEntityAccessor
    {
        int Id { get; set; }
        string Name { get; set; }
    }
    public interface ISpotifyAccessor
    {
        string SpotifyUri { get; }
        string SpotifyWebPage { get; }
        string SpotifyId { get; set; }
        string ApiHref { get; }

    }


    public interface ISaEntity : ISaDbEntityAccessor
    {
        SaEntityType EntityType { get; }
    }

    public interface ISaDescriptor : ISaEntity
    {
        bool Describes(ISaIntegralEntity entity);
    }

    public interface ISaIntegralEntity : ISaEntity
    {
        List<Keyword> Keywords { get; set; }
        List<Topic> Topics { get; set; }
        List<Genre> Genres { get; set; }
        bool DescribedBy(string term);

    }
}