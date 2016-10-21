﻿using System;
using System.Collections.Generic;
using System.Data.Linq;
using System.Data.Linq.Mapping;
using System.Linq.Expressions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SongsAbout_DesktopApp.Classes.Entities
{
    public abstract class DbEntity
    {

        public string TitleColumnName { get; set; }
        public string TableName { get; set; }
        public string TypeName { get; set; }
        public abstract void Save();
        protected static void formatName(ref string name)
        {
            if (name.Contains("\'"))
            {
                int i = name.IndexOf("\'");
                name = name.Insert(i, "'");
            }
        }
    }
    //    public abstract class DbEntity<U>
    //    {
    //        public string TitleColumnName { get; set; }
    //        public string TableName { get; set; }
    //        public string TypeName { get; set; }


    //        protected DbEntity(string titleColumn = "Not Set", string table = "Not Set", string typeName = "Not Set")
    //        {
    //            this.TitleColumnName = titleColumn;
    //            this.TableName = table;
    //            this.TypeName = TypeName;
    //        }

    //        //public virtual void Submit(ref Artist _entity)
    //        //{
    //        //    try
    //        //    {
    //        //        string table = TableName;
    //        //        using (DataClassContext context = new DataClassContext())
    //        //        {

    //        //            //switch (table)
    //        //            //{
    //        //            //    case "Artists":
    //        //            //        context.Artists.InsertOnSubmit(_entity as Artist);
    //        //            //        break;
    //        //            //    case "Albums":
    //        //            //        context.Albums.InsertOnSubmit(_entity as Album);
    //        //            //        break;
    //        //            //    case "Tracks":
    //        //            //        context.Tracks.InsertOnSubmit(_entity as Track);
    //        //            //        break;
    //        //            //    case "Genres":
    //        //            //        context.Genres.InsertOnSubmit(_entity as Genre);
    //        //            //        break;
    //        //            //    case "TrackGenres":
    //        //            //        context.TrackGenres.InsertOnSubmit(_entity as TrackGenre);
    //        //            //        break;
    //        //            //    default:
    //        //            //        break;
    //        //            //}

    //        //        }
    //        //    }
    //        //    catch (Exception ex)
    //        //    {
    //        //        throw new SaveError<U>(ex.Message);
    //        //    }
    //        //}


    //        public virtual void Submit(string table)
    //        {
    //            try
    //            {
    //                //using (DataClassesDataContext context = new DataClassesDataContext())
    //                //{
    //                //    switch (table)
    //                //    {
    //                //        case "Artists":
    //                //            context.Artists.InsertOnSubmit(_entity as Artist);
    //                //            break;
    //                //        case "Albums":
    //                //            context.Albums.InsertOnSubmit(_entity as Album);
    //                //            break;
    //                //        case "Tracks":
    //                //            context.Tracks.InsertOnSubmit(_entity as Track);
    //                //            break;
    //                //        case "Genres":
    //                //            context.Genres.InsertOnSubmit(_entity as Genre);
    //                //            break;
    //                //        case "TrackGenres":
    //                //            context.TrackGenres.InsertOnSubmit(_entity as TrackGenre);
    //                //            break;
    //                //        default:
    //                //            break;
    //                //    }
    //                //    context.SubmitChanges();
    //                //}
    //            }
    //            catch (Exception ex)
    //            {
    //                throw new SaveError<U>(ex.Message);
    //            }
    //        }

    //        public static bool Exists(int id, string column, string table)
    //        {
    //            //try
    //            //{
    //            //    string aquery = $"SELECT {column} FROM {table} WHERE {column} = '{id}'";
    //            //    //LINQ syntax
    //            //    var j =
    //            //        from _titleColumn in _table
    //            //        where _titleColumn == id
    //            //        select id;

    //            //    using (DataClassesDataContext db = new DataClassesDataContext())
    //            //    {

    //            //        List<U> entities = db.ExecuteQuery<U>(aquery).ToList();
    //            //        return entities.Count > 0;
    //            //    }
    //            //}
    //            //catch (Exception ex)
    //            //{
    //            //    throw new EntityNotFoundError<U>(id, ex.Message);
    //            //}
    //            return true;
    //        }

    //        public virtual bool Exists(string name)
    //        {
    //            try
    //            {
    //                string column = TitleColumnName,
    //                    table = TableName;

    //                formatName(ref name);
    //                string aquery = $"SELECT {column} FROM {table} WHERE {column} = '{name}'";
    //                //using (DataClassesDataContext db = new DataClassesDataContext())
    //                //{
    //                //    List<U> entities = db.ExecuteQuery<U>(aquery).ToList();
    //                //    return entities.Count > 0;
    //                //}
    //                throw new EntityNotFoundError<U>(name);
    //            }
    //            catch (Exception ex)
    //            {
    //                throw new EntityNotFoundError<U>(name, ex.Message);
    //            }
    //        }

    //        //public virtual bool Exists<T>(string name, ref DataClassesDataContext db)
    //        //{
    //        //    try
    //        //    {
    //        //        string column = TitleColumnName,
    //        //            table = TableName;

    //        //        formatName(ref name);
    //        //        string aquery = $"SELECT {column} FROM {table} WHERE {column} = '{name}'";

    //        //        List<T> entities = db.ExecuteQuery<T>(aquery).ToList();
    //        //        return entities.Count > 0;

    //        //    }
    //        //    catch (Exception ex)
    //        //    {
    //        //        throw new EntityNotFoundError<T>(name, ex.Message);
    //        //    }
    //        //}

    //        public static U Load(string title)
    //        {
    //            try
    //            {
    //                //formatName(ref title);
    //                //using (DataClassesDataContext db = new DataClassesDataContext())
    //                //{
    //                //    string query = $"SELECT {_titleColumn} FROM {_table} WHERE {_titleColumn} = '{title}'";
    //                //    var entities = db.ExecuteQuery<U>(query);
    //                //    foreach (U t in entities)
    //                //    {
    //                //        return t;
    //                //    }
    //                //}
    //                throw new EntityNotFoundError<U>(title);
    //            }
    //            catch (Exception ex)
    //            {
    //                throw new LoadError<U>(title, ex.Message);
    //            }
    //        }

    //        public static U Load(int id)
    //        {
    //            try
    //            {
    //                //using (DataClassesDataContext db = new DataClassesDataContext())
    //                //{
    //                //    string query = $"SELECT {_titleColumn} FROM {_table} WHERE {_titleColumn} = '{id}'";
    //                //    var entities = db.ExecuteQuery<U>(query);
    //                //    foreach (U t in entities)
    //                //    {
    //                //        return t;
    //                //    }

    //                //}
    //                throw new EntityNotFoundError<U>(id);
    //            }
    //            catch (Exception ex)
    //            {
    //                throw new LoadError<U>(id, ex.Message);
    //            }
    //        }


    //        private static void formatName(ref string name)
    //        {
    //            if (name.Contains("\'"))
    //            {
    //                int i = name.IndexOf("\'");
    //                name = name.Insert(i, "'");
    //            }
    //        }
    //    }
}
