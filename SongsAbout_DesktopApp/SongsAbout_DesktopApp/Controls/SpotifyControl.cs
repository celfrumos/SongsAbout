using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SongsAbout.Controls
{
    [TypeDescriptionProvider(typeof(AbstractControlDescriptionProvider<SpotifyControl, UserControl>))]
    public partial class SpotifyControl : UserControl, IEntityControl
    {
        public SpotifyControl()
        {
            InitializeComponent();
        }

        public override string Text
        {
            get { return base.Text; }
            set { base.Text = value; }
        }
        public virtual string Level { get; set; }

        public SpotifyControl(string text, string level)
        {
            this.Text = text;
            this.Level = level;
            
        }
        SpotifyAPI.Web.Models.FullAlbum a = new SpotifyAPI.Web.Models.FullAlbum();
       
    }
    
    public interface ISpotifyEntity
    {
        string Name { get; set; }
        string Id { get; set; }
        string Uri { get; set; }
    }
    public class AbstractControlDescriptionProvider<TAbstract, TBase> : TypeDescriptionProvider
    {
        public AbstractControlDescriptionProvider() : base(TypeDescriptor.GetProvider(typeof(TAbstract)))
        {
        }

        public override Type GetReflectionType(Type objectType, object instance)
        {
            if (objectType == typeof(TAbstract))
                return typeof(TBase);

            return base.GetReflectionType(objectType, instance);
        }

        public override object CreateInstance(IServiceProvider provider, Type objectType, Type[] argTypes, object[] args)
        {
            if (objectType == typeof(TAbstract))
                objectType = typeof(TBase);

            return base.CreateInstance(provider, objectType, argTypes, args);
        }
    }

}
