// See https://aka.ms/new-console-template for more information
using CodingWiki_DataAccess.Data;
using CodingWiki_Model.Models;
using Microsoft.EntityFrameworkCore;
using static System.Reflection.Metadata.BlobBuilder;

Console.WriteLine("Hello, World!");

//using(ApplicationDbContext context = new())
//{
//    context.Database.EnsureCreated();
//    if (context.Database.GetPendingMigrations().Count() > 0) 
//    {
//        context.Database.Migrate(); 
//    }
//}
//AddBook();
GetAllBooks();
GetBook();

void GetBook()
{
    try
    {
        using var context = new ApplicationDbContext();
        var books = context.Books;
        //Console.WriteLine(book.Title + " - " + book.ISBN);
        foreach (var book in books)
        {
            Console.WriteLine(book.Title + " - " + book.ISBN);
        }
    }
    catch (Exception e)
    {

    }
}

void GetAllBooks()
{
    using var context = new ApplicationDbContext();
    var books = context.Books.ToList();
    foreach (var book in books)
    {
        Console.WriteLine(book.Title + " - " + book.ISBN);
    }
}


void AddBook()
{
    Book book = new() { Title = "New EF Core Book", ISBN = "1231231212", Price = 10.93m, Publisher_Id=1 };
    using var context = new ApplicationDbContext();
    var books = context.Books.Add(book);
    context.SaveChanges();
}