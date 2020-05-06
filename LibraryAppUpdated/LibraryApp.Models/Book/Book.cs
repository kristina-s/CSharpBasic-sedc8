using System;
using System.Collections.Generic;
using System.Text;

namespace LibraryApp.Models.Book
{
    public class Book
    {
        private static int _idGenerator = 0;
        public int Id { get; set; }

        public string Title { get; set; }

        public string Author { get; set; }

        public Genres Genre { get; set; }

        public int Pages { get; set; }

        // delete this
        // public DateTime PublishDate { get; set; }


        public Book()
        {
        }

        public Book(string title, string author, Genres genre, int pages)
        {
            // dynamicaly add ID
            _idGenerator++;
            Id = _idGenerator;

            this.Title = title;
            this.Author = author;
            this.Genre = genre;
            this.Pages = pages;
        }


        public virtual string BookInfo()
        {
            return $"{Id} {Title} - {Author} {Pages} pages ({Genre})";
        }
    }
}
