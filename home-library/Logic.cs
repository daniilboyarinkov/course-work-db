using System.Data.OleDb;

namespace home_library
{
    public static class Logic
    {
        public static OleDbConnection Connection { get; }
        static Logic()
        {
            string _connectString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=DB.mdb;";
            Connection = new OleDbConnection(_connectString);
        }
    }
}
