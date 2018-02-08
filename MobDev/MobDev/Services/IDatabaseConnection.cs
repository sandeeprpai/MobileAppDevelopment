using System;
using System.Collections.Generic;
using System.Text;

namespace MobDev.Services
{
    interface IDatabaseConnection
    {
        SQLite.SQLiteConnection DbConnection();
    }
}
