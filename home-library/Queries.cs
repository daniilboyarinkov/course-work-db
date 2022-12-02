
namespace home_library
{
    public static class Queries
    {
        private static readonly string innerJoinBooksWithoutGenre = "(books INNER JOIN library ON books.book_id = library.book)";
        private static readonly string innerJoinBooksWithGenre = "(genres INNER JOIN (books INNER JOIN library ON books.book_id = library.book) ON genres.genre_id = books.genre)";

        // dp qeuries -----------------------------------------

        // все свободные
        public static string GetAllAvailableBooks(bool isGenre) => 
            $"SELECT books.title, authors.fio, books.publication_year{(isGenre ? ", genres.genre_name" : "")} " +
            $"FROM authors INNER JOIN {(isGenre ? innerJoinBooksWithGenre : innerJoinBooksWithoutGenre)} ON authors.author_id = books.author " +
            $"WHERE (((library.taken)=False));";
        // те что у пользователя на руках
        public static string GetUserBooks(string username) => 
            $"SELECT books.title, books.author, books.publication_year, taken_books.taken_date, taken_books.return_date " +
            $"FROM readers INNER JOIN ((authors INNER JOIN books ON authors.author_id = books.author) " +
            $"INNER JOIN taken_books ON books.book_id = taken_books.book) ON readers.reader_id = taken_books.reader " +
            $"WHERE (((readers.reader_name)=\"{username}\"));";
            
        // история книг пользователя
        public static string GetUserHistory(string username) =>
            $"SELECT books.title, books.author, books.publication_year, history.take_date, history.return_date " +
            $"FROM readers INNER JOIN ((authors INNER JOIN books ON authors.author_id = books.author) " +
            $"INNER JOIN history ON books.book_id = history.book) ON readers.reader_id = history.reader " +
            $"WHERE (((readers.reader_name)=\"{username}\"));";
        // все свободные отфильтрованные по жанрам
        public static string GetAllAvailableBooksByGenre(string genre) => 
            $"SELECT books.title, authors.fio, books.publication_year, books.genre " +
            $"FROM genres INNER JOIN ((authors INNER JOIN books ON authors.author_id = books.author) " +
            $"INNER JOIN library ON books.book_id = library.book) ON genres.genre_id = books.genre " +
            $"WHERE (((genres.genre_name)=\"{genre}\") AND ((library.taken)=False));";
        // все свободные отфильтрованные по автору
        public static string GetAllAvailableBooksByAuthor(bool isGenre, string author) =>
            $"{GetAllAvailableBooks(isGenre)[..^1]} AND (((authors.fio)=\"{author}\");";
        // получить всю историю
        public static string GetAllHistory() => $"SELECT books.title, readers.reader_name, history.take_date, history.return_date " +
            $"FROM readers INNER JOIN (books INNER JOIN history ON books.book_id = history.book) ON readers.reader_id = history.reader;";
        // получить все 
        public static string GetAllBooks() => $"SELECT books.title FROM books;";
        public static string GetAllGenres() => $"SELECT genres.genre_name FROM genres;";
        public static string GetAllReaders() => $"SELECT readers.reader_name FROM readers;";
        public static string GetAllAuthors() => $"SELECT authors.fio FROM authors;";
        public static string GetAllAdminExceptYourself(string admin) => 
            $"SELECT admins.username FROM admins WHERE (((admins.username)<>\"{admin}\"));";

        public static string GetAdminHash(string admin) => $"SELECT admins.hash_password FROM admins WHERE (((admins.username)=\"{admin}\")); ";

        // получить конкретное
        public static string GetBook(string title) => $"SELECT books.* FROM books WHERE (((books.title)=\"{title}\")); ";
        public static string GetGenre(string genre) => $"SELECT genres.* FROM genres WHERE (((genres.genre_name)=\"{genre}\")); ";
        public static string GetReader(string username) => $"SELECT readers.* FROM readers WHERE (((readers.reader_name)=\"{username}\")); ";
        public static string GetAuthor(string author) => $"SELECT authors.*, authors.fio FROM authors WHERE (((authors.fio)=\"{author}\")); ";
        public static string GetAdmin(string admin) => $"SELECT admins.* FROM admins WHERE (((admins.username)=\"{admin}\")); ";

        // получить айдишники 
        public static string GetReaderId(string username) => $"SELECT reader_id FROM readers WHERE ((readers.reader_name)=\"{username}\"); ";
        public static string GetBookId(string title) => $"SELECT book_id FROM books WHERE ((books.title)=\"{title}\"); ";


        // авторы у которых сегодня др
        public static string GetBirthdayAuthors() => 
            $"SELECT authors.fio, authors.death_date " +
            $"FROM authors " +
            $"WHERE (Month(authors.birth_date) = Month(Date())) " +
            $"AND ((Day(authors.birth_date) = Day(Date())));";

        // просрочка
        public static string GetDeptedBooks() => 
            $"SELECT books.title, readers.reader_name, taken_books.taken_date, taken_books.return_date, DateDiff(\"d\",taken_books.return_date,Date()) AS dept " +
            $"FROM readers INNER JOIN (books INNER JOIN taken_books ON books.book_id = taken_books.book) ON readers.reader_id = taken_books.reader " +
            $"WHERE (((taken_books.return_date)<Date())); ";

        public static string AddUserTakeApply(int readerId, int bookId) => 
            $"INSERT INTO take_applies ( reader, book, apply_date ) VALUES ({readerId}, {bookId}, Date());";
        public static string RemoveUserTakeApply(string username, string title) =>
            $"DELETE readers.reader_name, books.title, take_applies.* " +
            $"FROM readers INNER JOIN (books INNER JOIN take_applies ON books.book_id = take_applies.book) ON readers.reader_id = take_applies.reader " +
            $"WHERE (((readers.reader_name)=\"{username}\") AND ((books.title)=\"{title}\")); ";

        public static string AddUserTakeLibraryMarker(string title) => 
            $"UPDATE books INNER JOIN library ON books.book_id = library.book SET library.taken = True " +
            $"WHERE (((books.title)=\"{title}\")); ";
        public static string RemoveUserTakeLibraryMarker(string title) =>
            $"UPDATE books INNER JOIN library ON books.book_id = library.book SET library.taken = False " +
            $"WHERE (((books.title)=\"{title}\")); ";

        public static string AddUserTakenBook(string title, string username) => 
            $"INSERT INTO taken_books (book, reader, taken_date, return_date) " +
            $"SELECT books.book_id, readers.reader_id, DATE(), DateAdd('d', 14, DATE())  " +
            $" FROM books, readers WHERE books.title =\"{title}\" AND readers.reader_name = \"{username}\";";
        public static string RemoveUserTakenBook(string title, string username) => 
            $"DELETE books.title, readers.reader_name, taken_books.*, * " +
            $"FROM readers INNER JOIN (books INNER JOIN taken_books ON books.book_id = taken_books.book) ON readers.reader_id = taken_books.reader " +
            $"WHERE (((books.title)=\"{title}\") AND ((readers.reader_name)=\"{username}\")); ";

        // злосчастный жанр
        public static string AddGenreTable() => $"CREATE TABLE genres ( genre_id counter(1, 1) NOT NULL Primary key, genre_name CHAR(25) NOT NULL ) ";
        public static string RemoveGenreTable() => $"DROP TABLE genres;";
        public static string AddGenreBookField() => $"ALTER TABLE books ADD genre INT;";
        public static string RemoveGenreBookField() => $" ALTER TABLE books DROP COLUMN genre;";
        public static string AddGenreConnection() => $"ALTER TABLE books ADD CONSTRAINT genres FOREIGN KEY (genre) REFERENCES genres (genre_id) ;";
        public static string RemoveGenreConnection() => $"alter table books drop constraint genres;";



    }
}
