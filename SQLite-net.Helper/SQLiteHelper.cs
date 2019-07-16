using SQLite;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SQLite_net.Helper
{
    public class SQLiteHelper
    {
        public string connstr = Path.Combine(Environment.CurrentDirectory, "User.db");//没有数据库会创建数据库
        public SQLiteConnection db;
        public SQLiteHelper()
        {
            db = new SQLiteConnection(connstr);
            db.CreateTable<Stock>();//表已存在不会重复创建
            db.CreateTable<Valuation>();
        }

        public int Add<T>(T model)
        { 
           return db.Insert(model);
        }

        public int Update<T>(T model)
        {
            return db.Update(model);
        }

        public int Delete<T>(T model)
        {
            return db.Update(model);
        }
        public List<T> Query<T>(string sql) where T : new()
        {
            return db.Query<T>(sql);
        }
        public int Execute(string sql) 
        {
            return db.Execute(sql);
        }
    } 
}
