using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SongsAbout_DesktopApp.Controls
{
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

    [TypeDescriptionProvider(typeof(AbstractControlDescriptionProvider<SpotifyControl, UserControl>))]
    public abstract partial class SpotifyControl : UserControl
    {
        public SpotifyControl()
        {
            InitializeComponent();
        }

        internal class ConcreteClassProvider : TypeDescriptionProvider
        {
            public ConcreteClassProvider() : base(TypeDescriptor.GetProvider(typeof(SpotifyControl)))
            {
            }

        }
        [AttributeUsage(AttributeTargets.Class)]
        internal class ConcreteClassAttribute : Attribute
        {
            Type _concreteType;
            public ConcreteClassAttribute(Type concreteType)
            {
                _concreteType = concreteType;
            }

            public Type ConcreteType { get { return _concreteType; } }
        }
        virtual public Type GetReflectionType(Type objectType, object instance)
        {
            return typeof(SpotifyControl);

        }
        public virtual string Level { get; set; }

        public override string Text
        {
            get { return base.Text; }

            set { base.Text = value; }
        }
    }
}
