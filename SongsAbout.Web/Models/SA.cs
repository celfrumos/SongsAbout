using System;

using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SongsAbout.Web.Models
{
    public static class SA
    {
        public static T GetByName<T>(T prototype) where T : ISaDbEntityAccessor, new()
        {


            throw new NotImplementedException();
        }

        public static int Create<T>(T prototype) where T : ISaDbEntityAccessor, new()
        {


            throw new NotImplementedException();
        }
    }

    public enum DbProperty
    {
        PrimaryKey,
        Nullable,
        SelectableBy
    }

    [AttributeUsage(AttributeTargets.Class, Inherited = false, AllowMultiple = true)]
    sealed class DbTableAttribute : Attribute
    {
        public string TableName { get; set; }

        public DbTableAttribute(string tableName)
        {
        }
    }

    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Parameter, Inherited = true, AllowMultiple = true)]
    sealed class DbFieldAttribute : Attribute
    {
        public DbProperty DbProperties { get; set; }
        public string ColumnName { get; }

        public bool Insertable { get; set; } = true;
        public bool Updateable { get; set; } = true;
        public bool Deletable { get; set; } = false;


        public DbFieldAttribute(string columnName) => this.ColumnName = columnName;
    }
}