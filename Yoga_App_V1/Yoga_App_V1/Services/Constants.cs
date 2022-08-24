﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Yoga_App_V1.Services
{
    public class Constants
    {
        public const string DatabaseName = "Yoga_App_Data.db3";
        public const SQLite.SQLiteOpenFlags Flags =
       // open the database in read/write mode
       SQLite.SQLiteOpenFlags.ReadWrite |
       // create the database if it doesn't exist
       SQLite.SQLiteOpenFlags.Create |
       // enable multi-threaded database access
       SQLite.SQLiteOpenFlags.SharedCache;

        public static string DatabasePath
        {
            get
            {
                var basePath = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
                return Path.Combine(basePath, DatabaseName);
            }
        }
    }
}
