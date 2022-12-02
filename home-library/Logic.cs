using System.Data.OleDb;

namespace home_library
{
    public static class Logic
    {
        private static readonly string _connectString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=DB.mdb;";
        public static OleDbConnection Connection { get; } = new OleDbConnection(_connectString);

        public static bool IsGenre { get; set; } = false;

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
                return false;
            }
        }

        // возвращает лист строк со значениями 
        public static List<List<string>> ExecuteQuery(string query)
        {
            List<List<string>> data = new();

            object[] meta = new object[10];
            bool read;

            OleDbCommand command = new(query, Logic.Connection);
            OleDbDataReader reader = command.ExecuteReader();

            if (reader.Read())
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
