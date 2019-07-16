using SQLite_net.Helper;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SqliteTestConsole
{
    class Program
    {
        
        static void Main(string[] args)
        {
            SQLiteHelper sqliteHelper = new SQLiteHelper();
            var list = sqliteHelper.Query<Stock>("select * from Stock");
            sqliteHelper.Add(new Valuation() { Price = 100, StockId = 1, Time = DateTime.Now });
            var list2 = sqliteHelper.Query<Valuation>("select *  from Valuation");
            var list3 = sqliteHelper.Query<Valuation>("select *   from Valuation INDEXED BY ValuationStockId2 WHERE StockId > 2");//使用索引ValuationStockId2查询
            try
            {
                sqliteHelper.Execute("drop index ValuationStockId");//删除索引，因为该索引已被删除，所以抛异常
            }
            catch (Exception ex)
            {

            }
        }
    }
}
