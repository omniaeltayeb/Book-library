using System;
using System.Collections.Generic;

class Book {
    public int Id { get; set; }
    public string Title { get; set; }
    public string Author { get; set; }
}

class Program {
    static List<Book> books = new List<Book>();
    static int nextId = 1;

    static void Main() {
        Console.WriteLine("📚 Book Library - Console Version");
        while (true) {
            Console.WriteLine("\nOptions: list / add / update / delete / exit");
            Console.Write("> ");
            var input = Console.ReadLine();
            switch (input.ToLower()) {
                case "list": ListBooks(); break;
                case "add": AddBook(); break;
                case "update": UpdateBook(); break;
                case "delete": DeleteBook(); break;
                case "exit": return;
                default: Console.WriteLine("Unknown command."); break;
            }
        }
    }

    static void ListBooks() {
        if (books.Count == 0) {
            Console.WriteLine("No books found.");
            return;
        }

        foreach (var book in books) {
            Console.WriteLine($"[{book.Id}] {book.Title} by {book.Author}");
        }
    }

    static void AddBook() {
        Console.Write("Title: ");
        string title = Console.ReadLine();
        Console.Write("Author: ");
        string author = Console.ReadLine();
        books.Add(new Book { Id = nextId++, Title = title, Author = author });
        Console.WriteLine("Book added.");
    }

    static void UpdateBook() {
        Console.Write("Book ID to update: ");
        int id = int.Parse(Console.ReadLine());
        var book = books.Find(b => b.Id == id);
        if (book == null) {
            Console.WriteLine("Book not found.");
            return;
        }
        Console.Write("New Title: ");
        book.Title = Console.ReadLine();
        Console.Write("New Author: ");
        book.Author = Console.ReadLine();
        Console.WriteLine("Book updated.");
    }

    static void DeleteBook() {
        Console.Write("Book ID to delete: ");
        int id = int.Parse(Console.ReadLine());
        var removed = books.RemoveAll(b => b.Id == id);
        Console.WriteLine(removed > 0 ? "Book deleted." : "Book not found.");
    }
}
