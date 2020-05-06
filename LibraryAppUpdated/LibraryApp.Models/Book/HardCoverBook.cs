using System;
using System.Collections.Generic;
using System.Text;

namespace LibraryApp.Models.Book
{
    public class HardCoverBook : Book
    {
        public int InStock { get; set; }
        public DateTime Printed { get; set; }
        public HardCoverBook(string title, string author, Genres genre, int pages, int inStock, DateTime printed)
            : base(title, author, genre, pages)
        {
            this.InStock = inStock;
            this.Printed = printed;
        }

        public override string BookInfo()
        {
            return $"{Id} {Title} - {Author} | {Pages} pages | Genre: {Genre} | Printed: {Printed}";
        }
    }
}
