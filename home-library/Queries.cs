
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
        public static string GetUserBooks() => $"";
        // история книг пользователя
        public static string GetUserHistory() => $"";
        // все свободные отфильтрованные по жанрам
        public static string GetAllAvailableBooksByGenre() => $"";
        // все свободные отфильтрованные по автору
        public static string GetAllAvailableBooksByAuthor(bool isGenre, string author) => 
            $"SELECT books.title, authors.fio, books.publication_year{(isGenre ? ", genres.genre_name" : "")} " +
            $"FROM (authors INNER JOIN books ON authors.author_id = books.author) INNER JOIN library ON books.book_id = library.book " +
            $"WHERE (((authors.fio)=\"Лев Толстой\") AND ((library.taken)=False));";
        // получить всю историю
        public static string GetAllHistory() => $"";
        // получить все 
        public static string GetAllBooks() => $"";
        public static string GetAllGenres() => $"";
        public static string GetAllReaders() => $"";
        public static string GetAllAuthors() => $"";
        public static string GetAllAdminExceptYourself() => $"";

        public static string GetAdminHash() => $"";

        // получить конкретное
        public static string GetBook() => $"";
        public static string GetGenre() => $"";
        public static string GetReader() => $"";
        public static string GetAuthor() => $"";
        public static string GetAdmin() => $"";

        // получить айдишники 
        public static string GetReaderId() => $"";
        public static string GetBookId() => $"";


        // авторы у которых сегодня др
        public static string GetBirthdayAuthors() => 
            $"SELECT authors.fio, authors.death_date " +
            $"FROM authors " +
            $"WHERE (Month(authors.birth_date) = Month(Date())) " +
            $"AND ((Day(authors.birth_date) = Day(Date())));";

        // просрочка
        public static string GetDeptedBooks() => $"";

        public static string AddUserTakeApply() => $"";
        public static string RemoveUserTakeApply() => $"";

        public static string AddUserTakeLibraryMarker() => $"";
        public static string RemoveUserTakeLibraryMarker() => $"";

        public static string AddUserTakenBook() => $"";
        public static string RemoveUserTakenBook() => $"";


        // злосчастный жанр
        public static string AddGenreTable() => $"";
        public static string RemoveGenreTable() => $"";
        public static string AddGenreBookField() => $"";
        public static string RemoveGenreBookField() => $"";
        public static string AddGenreConnection() => $"";
        public static string RemoveGenreConnection() => $"";



    }
}
