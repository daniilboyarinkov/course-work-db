using System.Data.OleDb;

namespace home_library
{
    internal static class UserLogic
    {
        // queries sections -----------------------------------------------------------
        public static string GetAllAvailableBooks(bool isGenre) => $"SELECT books.title, authors.fio, books.publication_year{(isGenre ? ", books.genre" : "")} " +
                $"FROM authors INNER JOIN (books INNER JOIN library ON books.book_id = library.book) " +
                $"ON (authors.author_id = books.author) AND (authors.author_id = books.author);";
        
        public static string GetUsersBooks(bool isGenre, string username) => $"SELECT books.title, books.author, books.publication_year, library.take_date, library.return_date{(isGenre ? ", books.genre" : "")} " +
            $"FROM readers INNER JOIN (authors INNER JOIN (books INNER JOIN library ON books.book_id = library.book) ON (authors.author_id = books.author) " +
            $"AND (authors.author_id = books.author)) ON readers.reader_id = library.reader " +
            $"WHERE (((readers.reader_name)=\"{username}\"));";

        public static string GetUsersHistory(bool isGenre, string username) => $"SELECT books.title, books.author, books.publication_year, history.take_date, history.return_date{(isGenre ? ", books.genre" : "")} " +
            $"FROM authors INNER JOIN (readers INNER JOIN (books INNER JOIN history ON books.book_id = history.book) ON readers.reader_id = history.reader) ON (authors.author_id = books.author) " +
            $"AND (authors.author_id = books.author) " +
            $"WHERE (((readers.reader_name)=\"{username}\"));";


        // --------------------------------------------------------------------------------


        public static bool IsGenre { get; set; } = false;
        public static string Username { get; set; } = string.Empty; 

        // methods ------------------------------------------------------
        public static void InitializeLogic()
        {
            IsGenre = CheckGenre();
        }

        public static bool CheckGenre()
        {
            try
            {
                string query = "SELECT * FROM genres";
                OleDbCommand command = new(query, Logic.Connection);
                command.ExecuteNonQuery();
                return true;
            }
            catch
            {
                MessageBox.Show("Erroe!@");
                return false;
            }
        }

        // возвращает лист строк со значениями 
        public static List<List<string>> UpdateBooks(string query)
        {
            List<List<string>> data = new();

            object[] meta = new object[10];
            bool read;

            OleDbCommand command = new(query, Logic.Connection);
            OleDbDataReader reader = command.ExecuteReader();

            if (reader.Read() == true)
            {
                do
                {
                    List<string> row = new();
                    int NumberOfColums = reader.GetValues(meta);
                    for (int i = 0; i < NumberOfColums; i++)
                    {
                        row.Add(meta[i].ToString() ?? "");
                    }
                    data.Add(row);
                    read = reader.Read();
                } while (read == true);
            }
            reader.Close();

            return data;
        }

    }
}
