using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Storage;
using MobDev.Services;
using MobDev.UWP;
using SQLite;
using Xamarin.Forms;

[assembly: Dependency(typeof(DatabaseConnection_UWP))]

namespace MobDev.UWP
{
    public class DatabaseConnection_UWP : IDatabaseConnection
    {
        public SQLiteConnection DbConnection()
        {
            var dbName = "CustomersDb.db3";
            var path = Path.Combine(ApplicationData.
                Current.LocalFolder.Path, dbName);
            return new SQLiteConnection(path);
        }
    }
}
