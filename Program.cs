using System;
using System.Windows.Forms;
using TNSA_Test.Utilities;

namespace TNSA_Test
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            var connection = Helper.CreateConnection();

            var command = connection.CreateCommand();

            command.CommandText = "CREATE TABLE IF NOT EXISTS Cantariri (ID INTEGER PRIMARY KEY AUTOINCREMENT UNIQUE NOT NULL, Tara INTEGER NOT NULL, Brut INTEGER NOT NULL, Net INTEGER NOT NULL, DataCantarire TEXT NOT NULL DEFAULT (datetime('now', 'localtime')));";
            command.ExecuteNonQuery();
            command.CommandText = "CREATE TABLE IF NOT EXISTS Clienti (ID INTEGER PRIMARY KEY AUTOINCREMENT UNIQUE NOT NULL, Nume STRING, RegistrulComertului STRING, CodFiscal STRING NOT NULL, Judet STRING, Adresa STRING, Banca STRING, IBAN STRING, DataAdaugat STRING NOT NULL DEFAULT (datetime('now', 'localtime')));";
            command.ExecuteNonQuery();
            command.CommandText = "CREATE TABLE IF NOT EXISTS Furnizori (ID INTEGER PRIMARY KEY AUTOINCREMENT UNIQUE NOT NULL, Nume STRING, RegistrulComertului STRING, CodFiscal STRING NOT NULL, Judet STRING, Adresa STRING, Banca STRING, IBAN STRING, DataAdaugat STRING DEFAULT (datetime('now', 'localtime')) NOT NULL);";
            command.ExecuteNonQuery();
            command.CommandText = "CREATE TABLE IF NOT EXISTS Produse (ID INTEGER PRIMARY KEY AUTOINCREMENT NOT NULL UNIQUE, Nume STRING NOT NULL, PretPerUnitate INTEGER, Tip STRING);";
            command.ExecuteNonQuery();
            command.CommandText = "CREATE TABLE IF NOT EXISTS Vehicul (ID INTEGER PRIMARY KEY UNIQUE NOT NULL, NumarInmatriculare STRING NOT NULL, NumarAxe INTEGER, Tip STRING, DataAdaugat STRING DEFAULT (datetime('now', 'localtime')) NOT NULL);";
            command.ExecuteNonQuery();
            command.CommandText = "CREATE TABLE IF NOT EXISTS TichetCantar (ID INTEGER PRIMARY KEY AUTOINCREMENT UNIQUE NOT NULL, ID_Client INTEGER REFERENCES Clienti (ID) NOT NULL, ID_Furnizor INTEGER REFERENCES Furnizori (ID) NOT NULL, ID_Vehicul INTEGER REFERENCES Vehicul (ID) NOT NULL, ID_Produs INTEGER REFERENCES Produse (ID) NOT NULL, ID_Cantarire INTEGER REFERENCES Cantariri (ID) NOT NULL, NumeSofer STRING NOT NULL, NumeOperator STRING NOT NULL, Tip STRING NOT NULL, DataCreeriTichetului TEXT NOT NULL, ROClient BOOLEAN, ROFurnizor BOOLEAN);";
            command.ExecuteNonQuery();
            command.CommandText = "CREATE TABLE IF NOT EXISTS Aviz (ID_Aviz INTEGER PRIMARY KEY AUTOINCREMENT UNIQUE NOT NULL, ID_Tichet_Cantar INTEGER REFERENCES TichetCantar (ID) NOT NULL, DataCreeareAviz TEXT NOT NULL DEFAULT (datetime('now', 'localtime')));";
            command.ExecuteNonQuery();

            SqlServerTypes.Utilities.LoadNativeAssemblies(AppDomain.CurrentDomain.BaseDirectory);

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainForm());
            
        }
    }
}

// By Sebastian Sava