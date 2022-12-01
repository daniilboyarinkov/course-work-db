using System.Data.OleDb;

namespace home_library
{
    public static class Logic
    {
        private static readonly string _connectString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=DB.mdb;";
        public static OleDbConnection Connection { get; } = new OleDbConnection(_connectString);

    }
}
