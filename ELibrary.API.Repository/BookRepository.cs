using ELibrary.API.Data;
using ELibrary.API.Model;
using ELibrary.API.Model.DTO.RequestDTO;
using ELibrary.API.Services.ImageUploadService.Interface;
using ELibrary.API.Services.PaginationService.Implementation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ELibrary.API.Repository
{
    public class BookRepository : IBookRepository
    {
        private readonly ElibraryDbContext _context;
        private readonly IUploadImage _uploadImage;
        private readonly IPageUriService _pageUriService;

        public BookRepository(ElibraryDbContext context, IUploadImage uploadImage, IPageUriService pageUriService)
        {
            _context = context;
            _uploadImage = uploadImage;
            _pageUriService = pageUriService;
        }

        // Gets a book using it's Id
        public Book GetBookById(string bookId)
        {
            return _context.Books.FirstOrDefault(book => book.Id == bookId);
        }

        /// <summary>
        /// Returns an IEnumerable of all books in data store including their SubCategories
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Book> GetAllBooks()
        {
            var result = _context.Books;
            return result;
        }

        /// <summary>
        /// Saves a new book to the data store
        /// </summary>
        /// <param name="newbook"></param>
        /// <returns></returns>
        public async Task<bool> AddBook(AddBookRequestDTO newbook)
        {
            // Maps AddBookRequestDTO model to Book model
            var upload = await _uploadImage.ImageUploadAsync(newbook.BookAvatar);     // Uploads the Image to cloudinary

            Book book = new()
            {
                Id = Guid.NewGuid().ToString(),
                SubCategoryId = newbook.SubCategoryId,
                Author = newbook.Author,
                Title = newbook.Title,
                ISBN = newbook.ISBN,
                Publisher = newbook.Publisher,
                PublishedDate = newbook.PublishedDate,
                ThumbnailUrl = upload.SecureUrl.ToString(),   //Result.Url.ToString(),
                ShortDescription = newbook.ShortDescription,
                LongDescription = newbook.LongDescription,
                CreatedAt = DateTime.Now
            };

            _context.Books.Add(book);
            if (_context.SaveChanges() != 0)
                return true;
            return false;
        }

        /// <summary>
        /// Gets a collection of books whose properties match the search word.  Returns an IEnumerable of Books.
        /// </summary>
        /// <param name="searchBookRequest"></param>
        /// <returns></returns>
        public IEnumerable<Book> SearchBooks(string searchWord)
        {
            searchWord = searchWord.Trim();
            var collection = _context.Books as IQueryable<Book>;                        // Fetches all books from the data store

            collection = collection.Where(book => book.ISBN.Contains(searchWord)      // Gets all Books whose fields contains the search word
                                         || book.Title.Contains(searchWord)
                                         || book.Author.Contains(searchWord)
                                         || book.Publisher.Contains(searchWord));
            //|| book.PublishedDate.ToString() == searchWord);

            return collection.ToList();    // Returns the a piginated collection of selected books
        }

        /// <summary>
        /// Updates the properties of a particular book.  Returns a bool.
        /// </summary>
        /// <param name="bookUpdate"></param>
        /// <returns></returns>
        public async Task<bool> UpdateBook(BookUpdateRequestDTO bookUpdate)
        {
            string thumbnailUrl = string.Empty;
            if (bookUpdate.Image != null)              // Uploads the Image if there's any and assigns the Url to thumbnailUrl
            {
                var upload = await _uploadImage.ImageUploadAsync(bookUpdate.Image);
                thumbnailUrl = upload.SecureUrl.ToString();
            }
            Book book = GetBookById(bookUpdate.Id);

            // Updates all fields that are not null in the Book Update Request fields.
            book.SubCategoryId = String.IsNullOrWhiteSpace(bookUpdate.SubCategoryId) ? book.SubCategoryId : bookUpdate.SubCategoryId;
            book.Title = String.IsNullOrWhiteSpace(bookUpdate.Title) ? book.Title : bookUpdate.Title;
            book.Author = String.IsNullOrWhiteSpace(bookUpdate.Author) ? book.Author : bookUpdate.Author;
            book.Publisher = String.IsNullOrWhiteSpace(bookUpdate.Publisher) ? book.Publisher : bookUpdate.Publisher;
            book.PublishedDate = (bookUpdate.PublishedDate == DateTime.MinValue) ? book.PublishedDate : bookUpdate.PublishedDate;
            book.ThumbnailUrl = String.IsNullOrWhiteSpace(thumbnailUrl) ? book.ThumbnailUrl : thumbnailUrl;
            book.ShortDescription = String.IsNullOrWhiteSpace(bookUpdate.ShortDescription) ? book.ShortDescription : bookUpdate.ShortDescription;
            book.LongDescription = String.IsNullOrWhiteSpace(bookUpdate.LongDescription) ? book.LongDescription : bookUpdate.LongDescription;
            book.ISBN = String.IsNullOrWhiteSpace(bookUpdate.ISBN) ? book.ISBN : bookUpdate.ISBN;

            _context.Books.Update(book);
            if (_context.SaveChanges() != 0)
                return true;
            return false;
        }

        /// <summary>
        /// Removes a book from the data store. Returns a bool.
        /// </summary>
        /// <param name="bookId"></param>
        /// <returns></returns>
        public bool DeleteBook(string bookId)
        {
            Book book = GetBookById(bookId);            // Fetches the book to be deleted from the data store
            _context.Books.Remove(book);
            if (_context.SaveChanges() != 0)
                return true;
            return false;
        }
    }
}