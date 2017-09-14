using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web.Mvc.Html;

namespace SongsAbout.Web.Models
{
    public abstract class SaIntegralEntity : SaSpotifyAccessEntity, ISaIntegralEntity
    {
        [Display(GroupName = "Descriptors")]
        public List<Genre> Genres { get; set; }

        [Display(GroupName = "Descriptors")]
        public List<Topic> Topics { get; set; }

        [Display(Name = "Keywords", GroupName = "Descriptors")]
        public List<Keyword> Keywords { get; set; }

        /// <summary>
        /// Signifies whether or not any of the descriptors of this <see cref="SaIntegralEntity"/> contain the designated <paramref name="term"/>
        /// </summary>
        /// <param name="term">The term to search for</param>
        /// <returns></returns>
        public virtual bool DescribedBy(string term)
        =>
            this.Genres.Any(g => g.Name.ToLower().Contains(term.ToLower()))
            || this.Topics.Any(g => g.Name.ToLower().Contains(term.ToLower()))
            || this.Keywords.Any(g => g.Name.ToLower().Contains(term.ToLower()));

    }
}