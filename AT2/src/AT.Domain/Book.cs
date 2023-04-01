﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AT.Domain
{
    public class Book
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string ISBN { get; set; }
        public int Ano { get; set; }
        public ICollection<Author> Authors { get; set; }
        public List<BookAuthor> BookAuthors { get; set; }
    }
}
