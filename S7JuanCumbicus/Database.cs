using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace S7JuanCumbicus
{
    public interface Database
    {
        SQLiteAsyncConnection GetConnection();
    }
}
