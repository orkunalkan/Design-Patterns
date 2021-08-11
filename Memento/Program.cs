﻿using System;

namespace Memento
{
    class Program
    {
        static void Main(string[] args)
        {
            Book book = new Book 
            { 
                Isbn = "12345",
                Title = "Sefiller",
                Author = "Victor Hugo" 
            };

            book.ShowBook();

            Caretaker history = new Caretaker();
            history.Memento = book.CreateUndo();

            book.Isbn = "54321";
            book.Author = "VICTOR HUGO";
            book.ShowBook();

            book.RestoreFromUndo(history.Memento);
            book.ShowBook();
            
            Console.ReadLine();
        }
    }
    class Book
    {
        private string _title { get; set; }
        private string _author { get; set; }
        private string _isbn { get; set; }
        DateTime _lastEdited { get; set; }

        public string Title
        {
            get { return _title; }
            set { _title = value; }
        }


        public string Author
        {
            get { return _author; }
            set { _author = value; }
        }


        public string Isbn
        {
            get { return _isbn; }
            set { _isbn = value; }
        }

        private void SetLastEdited()
        {
            _lastEdited = DateTime.UtcNow;
        }
        public Memento CreateUndo()
        {
            return new Memento(_isbn, _title, _author, _lastEdited);
        }
        public void RestoreFromUndo(Memento memento)
        {
            _title = memento.Title;
            _author = memento.Author;
            _isbn = memento.Isbn;
            _lastEdited = memento.LastEdited;
        }
        public void ShowBook()
        {
            Console.WriteLine("{0},{1},{2} edited : {3}", Isbn, Title, Author, _lastEdited);
        }
    }
    class Memento
    {
        public string Title { get; set; }
        public string Author { get; set; }
        public string Isbn { get; set; }
        public DateTime LastEdited { get; set; }
        public Memento(string isbn, string title, string author, DateTime lastEdit)
        {
            Isbn = isbn;
            Title = title;
            Author = author;
            LastEdited = lastEdit;
        }
    }
    class Caretaker
    {
        public Memento Memento { get; set; }
    }
}
