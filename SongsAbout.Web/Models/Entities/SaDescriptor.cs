using System.Collections.Generic;

namespace SongsAbout.Web.Models
{
    public abstract class SaDescriptor : SaEntity, ISaDescriptor
    {
        public virtual bool Describes(ISaIntegralEntity entity)
        {
            return entity.DescribedBy(this.Name);
        }
        public List<Artist> Artists { get; set; }
        public List<Album> Albums { get; set; }
        public List<Track> Tracks { get; set; }
    }
}