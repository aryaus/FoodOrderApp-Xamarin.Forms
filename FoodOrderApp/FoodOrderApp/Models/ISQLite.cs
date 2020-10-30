using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace FoodOrderApp.Models
{
    interface ISQLite
    {
        SQLiteConnection GetConnection();
    }
}
