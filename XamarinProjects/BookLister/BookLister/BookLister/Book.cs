using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace BookLister
{
    public class Book
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Author { get; set; }
        public string TimeStamp { get; set; }
    }
}
