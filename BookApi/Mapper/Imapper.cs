using AutoMapper;
using BookApi.Models;
using BookApi.ModelVM;

namespace BookApi.Mapper
{
    public class Imapper:Profile
    {
        public Imapper()
        {
            CreateMap<Auther, AutherVM>();
            CreateMap<AutherVM, Auther>();

            CreateMap<Book, BookVM>();
            CreateMap<BookVM, Book>();
        }
    }
}
