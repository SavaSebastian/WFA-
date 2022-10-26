using System;
using System.Data.SQLite;
using System.Windows.Forms;

namespace TNSA_Test.Utilities
{
    public static class Helper
    {
        public static SQLiteConnection CreateConnection()
        {
            SQLiteConnection sqlite_conn;
            sqlite_conn = new SQLiteConnection("Data Source=TNSA-Test.db; Version=3; New=True; Compress=True;");
            try
            {
                sqlite_conn.Open();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Something went wrong, error: " + ex.Message, "DatabaseError");
            }
            return sqlite_conn;
        }
    }
}
