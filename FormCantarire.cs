using System;
using System.Data;
using System.Data.SQLite;
using System.Windows.Forms;
using TNSA_Test.Models;
using TNSA_Test.Utilities;

namespace TNSA_Test
{
    public partial class FormCantarire : Form
    {
        public FormCantarire()
        {
            InitializeComponent();
            DefaultLoad();
            SetHistory();
        }

        public FormCantarire(int tichetId)
        {
            InitializeComponent();
            EntryLoad(tichetId);
        }

        private void DefaultLoad()
        {
            intrareIesireComboBox.SelectedIndex = intrareIesireComboBox.Items.Count - 1;
            dataTextBox.Text = DateTime.Now.ToString("d/M/yyyy h:mm:ss");

            try
            {
                var connection = Helper.CreateConnection();
                var command = new SQLiteCommand("Select MAX(ID) from TichetCantar", connection);
                numarTichetTextBox.Text = (Convert.ToInt32(command.ExecuteScalar()) + 1).ToString();
            }
            catch
            {
                numarTichetTextBox.Text = 1.ToString();
            }
        }

        private void SetHistory()
        {
            nrInmatriculareTextBox.DataBindings.Clear();
            var connection = Helper.CreateConnection();
            var dataAdapter = new SQLiteDataAdapter("Select DISTINCT NumarInmatriculare from Vehicul", connection);
            var dataSet = new DataSet();
            dataAdapter.Fill(dataSet, "Vehicul");

            var listaVehicule = new AutoCompleteStringCollection();

            foreach (DataRow dr in dataSet.Tables["Vehicul"].Rows)
            {
                listaVehicule.Add(dr.Field<string>("NumarInmatriculare"));
            }

            nrInmatriculareTextBox.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            nrInmatriculareTextBox.AutoCompleteCustomSource = listaVehicule;
            nrInmatriculareTextBox.AutoCompleteSource = AutoCompleteSource.CustomSource;
        }

        private void EntryLoad(int tichetId)
        {
            var connection = Helper.CreateConnection();

            var dataAdapter = new SQLiteDataAdapter("SELECT * from TichetCantar where ID = @tichetId", connection);
            dataAdapter.SelectCommand.Parameters.Add("@tichetId", DbType.Int32, 2000).Value = tichetId;
            var dataSetTichet = new DataSet();
            dataAdapter.Fill(dataSetTichet, "TichetCantar");
            var dataRowTichet = dataSetTichet.Tables["TichetCantar"].Rows[0];

            dataAdapter.SelectCommand.CommandText = "SELECT * from Clienti where ID = @clientId";
            dataAdapter.SelectCommand.Parameters.Add("@clientId", DbType.Int32, 2000).Value = (int)dataRowTichet.Field<Int64>("ID_Client");
            var dataSetClienti = new DataSet();
            dataAdapter.Fill(dataSetClienti, "Clienti");
            var dataRowClienti = dataSetClienti.Tables["Clienti"].Rows[0];

            dataAdapter.SelectCommand.CommandText = "SELECT * from Furnizori where ID = @furnizorId";
            dataAdapter.SelectCommand.Parameters.Add("@furnizorId", DbType.Int32, 2000).Value = (int)dataRowTichet.Field<Int64>("ID_Furnizor");
            var dataSetFurnizori = new DataSet();
            dataAdapter.Fill(dataSetFurnizori, "Furnizori");
            var dataRowFurnizori = dataSetFurnizori.Tables["Furnizori"].Rows[0];

            dataAdapter.SelectCommand.CommandText = "SELECT * from Vehicul where ID = @vehiculId";
            dataAdapter.SelectCommand.Parameters.Add("@vehiculId", DbType.Int32, 2000).Value = (int)dataRowTichet.Field<Int64>("ID_Vehicul");
            var dataSetVehicul = new DataSet();
            dataAdapter.Fill(dataSetVehicul, "Vehicul");
            var dataRowVehicul = dataSetVehicul.Tables["Vehicul"].Rows[0];

            dataAdapter.SelectCommand.CommandText = "SELECT * from Produse where ID = @produsId";
            dataAdapter.SelectCommand.Parameters.Add("@produsId", DbType.Int32, 2000).Value = (int)dataRowTichet.Field<Int64>("ID_Produs");
            var dataSetProdus = new DataSet();
            dataAdapter.Fill(dataSetProdus, "Produs");
            var dataRowProdus = dataSetProdus.Tables["Produs"].Rows[0];

            dataAdapter.SelectCommand.CommandText = "SELECT * from Cantariri where ID = @cantarireId";
            dataAdapter.SelectCommand.Parameters.Add("@cantarireId", DbType.Int32, 2000).Value = (int)dataRowTichet.Field<Int64>("ID_Cantarire");
            var dataSetCantarire = new DataSet();
            dataAdapter.Fill(dataSetCantarire, "Cantariri");
            var dataRowCantarire = dataSetCantarire.Tables["Cantariri"].Rows[0];

            numarTichetTextBox.Text = tichetId.ToString();
            numeOperatorTextBox.Text = dataRowTichet.Field<string>("NumeOperator");
            numeProdusTextBox.Text = dataRowProdus.Field<string>("Nume");
            numeSoferTextBox.Text = dataRowTichet.Field<string>("NumeSofer");
            clientCodFiscalTextBox.Text = dataRowClienti.Field<string>("CodFiscal");
            furnizorCodFiscalTextBox.Text = dataRowFurnizori.Field<string>("CodFiscal");
            intrareIesireComboBox.Text = dataRowTichet.Field<string>("Tip");
            nrInmatriculareTextBox.Text = dataRowVehicul.Field<string>("NumarInmatriculare");
            nrAxeTextBox.Text = dataRowVehicul.Field<Int64>("NumarAxe").ToString();
            tipVehiculTextBox.Text = dataRowVehicul.Field<string>("Tip");
            dataTextBox.Text = dataRowTichet.Field<string>("DataCreeriTichetului");
            taraTextBox.Text = dataRowCantarire.Field<Int64>("Tara").ToString();
            brutTextBox.Text = dataRowCantarire.Field<Int64>("Brut").ToString();
            netTextBox.Text = dataRowCantarire.Field<Int64>("Net").ToString();
            addROClientCheckBox.Checked = dataRowTichet.Field<Boolean>("ROClient");
            addROFurnizorCheckBox.Checked = dataRowTichet.Field<Boolean>("ROFurnizor");

            numeOperatorTextBox.ReadOnly = true;
            numeProdusTextBox.ReadOnly = true;
            numeSoferTextBox.ReadOnly = true;
            nrAxeTextBox.ReadOnly = true;
            tipVehiculTextBox.ReadOnly = true;
            nrInmatriculareTextBox.ReadOnly = true;
            clientAdresaTextBox.ReadOnly = true;
            clientBancaTextBox.ReadOnly = true;
            clientCodFiscalTextBox.ReadOnly = true;
            clientIBANTextBox.ReadOnly = true;
            clientJudetTextBox.ReadOnly = true;
            clientNumeTextBox.ReadOnly = true;
            clientRegComTextBox.ReadOnly = true;
            furnizorAdresaTextBox.ReadOnly = true;
            furnizorBancaTextBox.ReadOnly = true;
            furnizorCodFiscalTextBox.ReadOnly = true;
            furnizorIBANTextBox.ReadOnly = true;
            furnizorJudetTextBox.ReadOnly = true;
            furnizorNumeTextBox.ReadOnly = true;
            furnizorRegComTextBox.ReadOnly = true;
            taraTextBox.ReadOnly = true;
            brutTextBox.ReadOnly = true;
            intrareIesireComboBox.Enabled = false;
            addROClientCheckBox.Enabled = false;
            addROFurnizorCheckBox.Enabled = false;
        }

        private void TichetCantarButton_Click(object sender, EventArgs e)
        {
            var cantarire = CreateCantarire();
            var client = CreateClient();
            var furnizor = CreateFurnizor();
            var produs = CreateProdus();
            var vehicul = CreateVehicul();
            var tichet = CreateTichet();

            var previewTichet = new PreviewTichet(tichet, cantarire, client, furnizor, produs, vehicul);
            previewTichet.Show();
        }

        private void AvizExpeditieButton_Click(object sender, EventArgs e)
        {
            var cantarire = CreateCantarire();
            var client = CreateClient();
            var furnizor = CreateFurnizor();
            var produs = CreateProdus();
            var vehicul = CreateVehicul();
            var aviz = CreateAviz();

            var previewAviz = new PreviewAviz(aviz, cantarire, client, furnizor, produs, vehicul);
            previewAviz.Show();
        }

        private void SalveazaButton_Click(object sender, EventArgs e)
        {
            var connection = Helper.CreateConnection();
            var dataAdapter = new SQLiteDataAdapter("Select ID from TichetCantar where ID = @id", connection);
            dataAdapter.SelectCommand.Parameters.Add("@id", DbType.Int32, 2000).Value = Convert.ToInt32(numarTichetTextBox.Text);
            var dataSet = new DataSet();
            dataAdapter.Fill(dataSet, "TichetCantar");
            
            if (dataSet.Tables["TichetCantar"].Rows.Count != 0)
            {
                MessageBox.Show("ID-ul tichetului curent exista deja in baza de date", "Tichet existent");
                return;
            }

            try
            {
                int clientId = InsertIntoClienti(connection);
                int furnizorId = InsertIntoFurnizori(connection);
                int cantaririId = InsertIntoCantariri(connection);
                int vehiculId = InsertIntoVehicul(connection);
                int produsId = InsertIntoProdus(connection);

                InsertIntoTichetCantar(connection, clientId, furnizorId, vehiculId, produsId, cantaririId);
                MessageBox.Show("Inserare cu successs!", "Successful");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Failed");
            }

            connection.Close();
        }

        private void TaraTextBox_TextChanged(object sender, EventArgs e)
        {
            try
            {
                var taraValue = Convert.ToInt32(taraTextBox.Text.ToString());
                var brutValue = Convert.ToInt32(brutTextBox.Text.ToString());
                netTextBox.Text = (brutValue - taraValue).ToString();
            }
            catch
            {
                // updates value only if both textBoxes have value inserted
            }
        }

        private void BrutTextBox_TextChanged(object sender, EventArgs e)
        {
            try
            {
                var taraValue = Convert.ToInt32(taraTextBox.Text.ToString());
                var brutValue = Convert.ToInt32(brutTextBox.Text.ToString());
                netTextBox.Text = (brutValue - taraValue).ToString();
            }
            catch
            {
                // updates value only if both textBoxes have value inserted
            }
            
        }

        private void TaraTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) &&
                (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
        }

        private void BrutTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) &&
                (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
        }

        private void NrInmatriculareTextBox_TextChanged(object sender, EventArgs e)
        {
            var connection = Helper.CreateConnection();
            try
            {
                var dataAdapter = new SQLiteDataAdapter("SELECT * from Vehicul where NumarInmatriculare = @numarInmatriculare ORDER BY DataAdaugat DESC Limit 1", connection);
                dataAdapter.SelectCommand.Parameters.Add("@numarInmatriculare", DbType.String, 2000).Value = nrInmatriculareTextBox.Text;

                var dataSet = new DataSet();
                dataAdapter.Fill(dataSet, "Vehicul");

                var dataRow = dataSet.Tables["Vehicul"].Rows[0];

                nrAxeTextBox.Text = dataRow.Field<Int64>("NumarAxe").ToString();
                tipVehiculTextBox.Text = dataRow.Field<string>("Tip");
            }
            catch
            {
                // do nothing
            }
        }

        private void ClientCodFiscalTextBox_TextChanged(object sender, EventArgs e)
        {
            var connection = Helper.CreateConnection();
            try
            {
                var dataAdapter = new SQLiteDataAdapter("SELECT * from Clienti where CodFiscal = @codFiscalClient ORDER BY DataAdaugat DESC Limit 1", connection);
                dataAdapter.SelectCommand.Parameters.Add("@codFiscalClient", DbType.String, 2000).Value = clientCodFiscalTextBox.Text;
                
                var dataSet = new DataSet();
                dataAdapter.Fill(dataSet, "Clienti");

                var dataRow = dataSet.Tables["Clienti"].Rows[0];

                clientNumeTextBox.Text = dataRow.Field<string>("Nume");
                clientRegComTextBox.Text = dataRow.Field<string>("RegistrulComertului");
                clientJudetTextBox.Text = dataRow.Field<string>("Judet");
                clientAdresaTextBox.Text = dataRow.Field<string>("Adresa");
                clientBancaTextBox.Text = dataRow.Field<string>("Banca");
                clientIBANTextBox.Text = dataRow.Field<string>("IBAN");
            }
            catch
            {
                // tested, completeaza textBoxurile daca exista codul fiscal in baza de date
            }
        }

        private void FurnizorCodFiscalTextBox_TextChanged(object sender, EventArgs e)
        {
            var connection = Helper.CreateConnection();
            try
            {
                var dataAdapter = new SQLiteDataAdapter("SELECT * FROM Furnizori where CodFiscal = @codFiscalFurnizor ORDER BY DataAdaugat DESC Limit 1", connection);
                dataAdapter.SelectCommand.Parameters.Add("@codFiscalFurnizor", DbType.String, 2000).Value = furnizorCodFiscalTextBox.Text;

                var dataSet = new DataSet();
                dataAdapter.Fill(dataSet, "Furnizori");

                var dataRow = dataSet.Tables["Furnizori"].Rows[0];

                furnizorNumeTextBox.Text = dataRow.Field<string>("Nume");
                furnizorRegComTextBox.Text = dataRow.Field<string>("RegistrulComertului");
                furnizorJudetTextBox.Text = dataRow.Field<string>("Judet");
                furnizorAdresaTextBox.Text = dataRow.Field<string>("Adresa");
                furnizorBancaTextBox.Text = dataRow.Field<string>("Banca");
                furnizorIBANTextBox.Text = dataRow.Field<string>("IBAN");
            }
            catch
            {
                // tested, completeaza textBoxurile daca exista codul fiscal in baza de date
            }
        }

        private int InsertIntoClienti(SQLiteConnection connection)
        {
            var dataAdapter = new SQLiteDataAdapter("SELECT * from Clienti where CodFiscal = @codFiscal", connection);
            dataAdapter.SelectCommand.Parameters.Add("@codFiscal", DbType.String, 2000).Value = clientCodFiscalTextBox.Text;

            var dataSet = new DataSet();
            dataAdapter.Fill(dataSet, "Clienti");

            if (dataSet.Tables["Clienti"].Rows.Count == 0)
            {
                var insertCommandClienti = new SQLiteCommand("Insert into Clienti(Nume, RegistrulComertului, CodFiscal, Judet, Adresa, Banca, IBAN) values (?,?,?,?,?,?,?)", connection);
                insertCommandClienti.Parameters.Add("@param1", DbType.String).Value = clientNumeTextBox.Text;
                insertCommandClienti.Parameters.Add("@param2", DbType.String).Value = clientRegComTextBox.Text;
                insertCommandClienti.Parameters.Add("@param3", DbType.String).Value = clientCodFiscalTextBox.Text;
                insertCommandClienti.Parameters.Add("@param4", DbType.String).Value = clientJudetTextBox.Text;
                insertCommandClienti.Parameters.Add("@param5", DbType.String).Value = clientAdresaTextBox.Text;
                insertCommandClienti.Parameters.Add("@param6", DbType.String).Value = clientBancaTextBox.Text;
                insertCommandClienti.Parameters.Add("@param7", DbType.String).Value = clientIBANTextBox.Text;

                try
                {
                    insertCommandClienti.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error occured while inserting in database: " + ex.Message, "DatabaseInsertError");
                }

                return LastInsertedRowId(connection);
            }
            else
            {
                int id = 0;
                bool isDifferent = false;
                foreach (DataRow dr in dataSet.Tables["Clienti"].Rows)
                {
                    if (!clientNumeTextBox.Text.Equals(dr.Field<string>("Nume")) ||
                    !clientRegComTextBox.Text.Equals(dr.Field<string>("RegistrulComertului")) ||
                    !clientJudetTextBox.Text.Equals(dr.Field<string>("Judet")) ||
                    !clientAdresaTextBox.Text.Equals(dr.Field<string>("Adresa")) ||
                    !clientBancaTextBox.Text.Equals(dr.Field<string>("Banca")) ||
                    !clientIBANTextBox.Text.Equals(dr.Field<string>("IBAN")))
                    {
                        isDifferent = true;
                    }
                    else
                    {
                        id = (int)dr.Field<Int64>("ID");
                        isDifferent = false;
                        break;
                    }
                }

                if (isDifferent)
                {
                    var insertCommandClienti = new SQLiteCommand("Insert into Clienti(Nume, RegistrulComertului, CodFiscal, Judet, Adresa, Banca, IBAN) values (?,?,?,?,?,?,?)", connection);
                    insertCommandClienti.Parameters.Add("@param1", DbType.String).Value = clientNumeTextBox.Text;
                    insertCommandClienti.Parameters.Add("@param2", DbType.String).Value = clientRegComTextBox.Text;
                    insertCommandClienti.Parameters.Add("@param3", DbType.String).Value = clientCodFiscalTextBox.Text;
                    insertCommandClienti.Parameters.Add("@param4", DbType.String).Value = clientJudetTextBox.Text;
                    insertCommandClienti.Parameters.Add("@param5", DbType.String).Value = clientAdresaTextBox.Text;
                    insertCommandClienti.Parameters.Add("@param6", DbType.String).Value = clientBancaTextBox.Text;
                    insertCommandClienti.Parameters.Add("@param7", DbType.String).Value = clientIBANTextBox.Text;

                    try
                    {
                        insertCommandClienti.ExecuteNonQuery();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error occured while inserting in database: " + ex.Message, "DatabaseInsertError");
                    }

                    return LastInsertedRowId(connection);
                }
                else
                {
                    return id;
                }
            }
        }

        private int InsertIntoFurnizori(SQLiteConnection connection)
        {
            var dataAdapter = new SQLiteDataAdapter("SELECT * from Furnizori where CodFiscal = @codFiscal", connection);
            dataAdapter.SelectCommand.Parameters.Add("@codFiscal", DbType.String, 2000).Value = furnizorCodFiscalTextBox.Text;

            var dataSet = new DataSet();
            dataAdapter.Fill(dataSet, "Furnizori");

            if (dataSet.Tables["Furnizori"].Rows.Count == 0)
            {
                var insertCommandFurnizori = new SQLiteCommand("Insert into Furnizori(Nume, RegistrulComertului, CodFiscal, Judet, Adresa, Banca, IBAN) values (?,?,?,?,?,?,?)", connection);
                insertCommandFurnizori.Parameters.Add("@param1", DbType.String).Value = furnizorNumeTextBox.Text;
                insertCommandFurnizori.Parameters.Add("@param2", DbType.String).Value = furnizorRegComTextBox.Text;
                insertCommandFurnizori.Parameters.Add("@param3", DbType.String).Value = furnizorCodFiscalTextBox.Text;
                insertCommandFurnizori.Parameters.Add("@param4", DbType.String).Value = furnizorJudetTextBox.Text;
                insertCommandFurnizori.Parameters.Add("@param5", DbType.String).Value = furnizorAdresaTextBox.Text;
                insertCommandFurnizori.Parameters.Add("@param6", DbType.String).Value = furnizorBancaTextBox.Text;
                insertCommandFurnizori.Parameters.Add("@param7", DbType.String).Value = furnizorIBANTextBox.Text;

                try
                {
                    insertCommandFurnizori.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error occured while inserting in database: " + ex.Message, "DatabaseInsertError");
                }

                return LastInsertedRowId(connection);
            }
            else
            {
                int id = 0;
                bool isDifferent = false;
                foreach (DataRow dr in dataSet.Tables["Furnizori"].Rows)
                {
                    if (!furnizorNumeTextBox.Text.Equals(dr.Field<string>("Nume")) ||
                    !furnizorRegComTextBox.Text.Equals(dr.Field<string>("RegistrulComertului")) ||
                    !furnizorJudetTextBox.Text.Equals(dr.Field<string>("Judet")) ||
                    !furnizorAdresaTextBox.Text.Equals(dr.Field<string>("Adresa")) ||
                    !furnizorBancaTextBox.Text.Equals(dr.Field<string>("Banca")) ||
                    !furnizorIBANTextBox.Text.Equals(dr.Field<string>("IBAN")))
                    {
                        isDifferent = true;
                    }
                    else
                    {
                        id = (int)dr.Field<Int64>("ID");
                        isDifferent = false;
                        break;
                    }
                }

                if (isDifferent)
                {
                    var insertCommandFurnizori = new SQLiteCommand("Insert into Furnizori(Nume, RegistrulComertului, CodFiscal, Judet, Adresa, Banca, IBAN) values (?,?,?,?,?,?,?)", connection);
                    insertCommandFurnizori.Parameters.Add("@param1", DbType.String).Value = furnizorNumeTextBox.Text;
                    insertCommandFurnizori.Parameters.Add("@param2", DbType.String).Value = furnizorRegComTextBox.Text;
                    insertCommandFurnizori.Parameters.Add("@param3", DbType.String).Value = furnizorCodFiscalTextBox.Text;
                    insertCommandFurnizori.Parameters.Add("@param4", DbType.String).Value = furnizorJudetTextBox.Text;
                    insertCommandFurnizori.Parameters.Add("@param5", DbType.String).Value = furnizorAdresaTextBox.Text;
                    insertCommandFurnizori.Parameters.Add("@param6", DbType.String).Value = furnizorBancaTextBox.Text;
                    insertCommandFurnizori.Parameters.Add("@param7", DbType.String).Value = furnizorIBANTextBox.Text;

                    try
                    {
                        insertCommandFurnizori.ExecuteNonQuery();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error occured while inserting in database: " + ex.Message, "DatabaseInsertError");
                    }
                    return LastInsertedRowId(connection);
                }
                else
                {
                    return id;
                }
            }
        }

        private int InsertIntoCantariri(SQLiteConnection connection)
        {
            var insertCommandCantariri = new SQLiteCommand("Insert into Cantariri(Tara, Brut, Net) values (?,?,?)", connection);
            insertCommandCantariri.Parameters.Add("@param1", DbType.Int32).Value = Convert.ToInt32(taraTextBox.Text);
            insertCommandCantariri.Parameters.Add("@param2", DbType.Int32).Value = Convert.ToInt32(brutTextBox.Text);
            insertCommandCantariri.Parameters.Add("@param3", DbType.Int32).Value = Convert.ToInt32(netTextBox.Text);

            try
            {
                insertCommandCantariri.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error occured while inserting in database: " + ex.Message, "DatabaseInsertError");
            }

            return LastInsertedRowId(connection);
        }

        private int InsertIntoProdus(SQLiteConnection connection)
        {
            var insertCommandProduse = new SQLiteCommand("Insert into Produse(Nume) values (?)", connection);
            insertCommandProduse.Parameters.Add("@param1", DbType.String).Value = numeProdusTextBox.Text;

            try
            {
                insertCommandProduse.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error occured while inserting in database: " + ex.Message, "DatabaseInsertError");
            }

            return LastInsertedRowId(connection);
        }

        private int InsertIntoVehicul(SQLiteConnection connection)
        {
            var dataAdapter = new SQLiteDataAdapter("SELECT * from Vehicul where NumarInmatriculare = @nrInmatriculare", connection);
            dataAdapter.SelectCommand.Parameters.Add("@nrInmatriculare", DbType.String, 2000).Value = nrInmatriculareTextBox.Text;

            var dataSet = new DataSet();
            dataAdapter.Fill(dataSet, "Vehicul");

            if (dataSet.Tables["Vehicul"].Rows.Count == 0)
            {
                var insertCommandVehicul = new SQLiteCommand("Insert into Vehicul(NumarInmatriculare, NumarAxe, Tip) values (?,?,?)", connection);
                insertCommandVehicul.Parameters.Add("@param1", DbType.String).Value = nrInmatriculareTextBox.Text;
                insertCommandVehicul.Parameters.Add("@param2", DbType.Int32).Value = Convert.ToInt32(nrAxeTextBox.Text);
                insertCommandVehicul.Parameters.Add("@param3", DbType.String).Value = tipVehiculTextBox.Text;

                try
                {
                    insertCommandVehicul.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error occured while inserting in database: " + ex.Message, "DatabaseInsertError");
                }

                return LastInsertedRowId(connection);
            }
            else
            {
                int id = 0;
                bool isDifferent = false;

                foreach (DataRow dr in dataSet.Tables["Vehicul"].Rows)
                {
                    if (!nrAxeTextBox.Text.Equals(dr.Field<Int64>("NumarAxe").ToString()) ||
                    !tipVehiculTextBox.Text.Equals(dr.Field<string>("Tip")))
                    {
                        isDifferent = true;
                    }
                    else
                    {
                        id = (int)dr.Field<Int64>("ID");
                        isDifferent = false;
                        break;
                    }
                }

                if (isDifferent)
                {
                    var insertCommandVehicul = new SQLiteCommand("Insert into Vehicul(NumarInmatriculare, NumarAxe, Tip) values (?,?,?)", connection);
                    insertCommandVehicul.Parameters.Add("@param1", DbType.String).Value = nrInmatriculareTextBox.Text;
                    insertCommandVehicul.Parameters.Add("@param2", DbType.Int32).Value = Convert.ToInt32(nrAxeTextBox.Text);
                    insertCommandVehicul.Parameters.Add("@param3", DbType.String).Value = tipVehiculTextBox.Text;

                    try
                    {
                        insertCommandVehicul.ExecuteNonQuery();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error occured while inserting in database: " + ex.Message, "DatabaseInsertError");
                    }

                    return LastInsertedRowId(connection);
                }
                else
                {
                    return id;
                }
            }
        }

        private void InsertIntoTichetCantar(SQLiteConnection connection, int clientId, int furnizorId, int vehiculId, int produsId, int cantaririId)
        {
            var insertCommandTichetCantar = new SQLiteCommand("Insert into TichetCantar(ID_Client, ID_Furnizor, ID_Vehicul, ID_Produs, ID_Cantarire, NumeSofer, NumeOperator, Tip, ROClient, ROFurnizor, DataCreeriTichetului) values (?,?,?,?,?,?,?,?,?,?,?)", connection);
            insertCommandTichetCantar.Parameters.Add("@param1", DbType.Int32).Value = clientId;
            insertCommandTichetCantar.Parameters.Add("@param2", DbType.Int32).Value = furnizorId;
            insertCommandTichetCantar.Parameters.Add("@param3", DbType.Int32).Value = vehiculId;
            insertCommandTichetCantar.Parameters.Add("@param4", DbType.Int32).Value = produsId;
            insertCommandTichetCantar.Parameters.Add("@param5", DbType.Int32).Value = cantaririId;
            insertCommandTichetCantar.Parameters.Add("@param6", DbType.String).Value = numeSoferTextBox.Text;
            insertCommandTichetCantar.Parameters.Add("@param7", DbType.String).Value = numeOperatorTextBox.Text;
            insertCommandTichetCantar.Parameters.Add("@param8", DbType.String).Value = intrareIesireComboBox.Text;
            insertCommandTichetCantar.Parameters.Add("@param9", DbType.Boolean).Value = addROClientCheckBox.Checked;
            insertCommandTichetCantar.Parameters.Add("@param10", DbType.Boolean).Value = addROFurnizorCheckBox.Checked;
            insertCommandTichetCantar.Parameters.Add("@param11", DbType.String).Value = dataTextBox.Text;

            try
            {
                insertCommandTichetCantar.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error occured while inserting in database: " + ex.Message, "DatabaseInsertError");
            }
        }

        private Client CreateClient()
        {
            return new Client()
            {
                Nume = clientNumeTextBox.Text,
                RegistrulComertului = clientRegComTextBox.Text,
                CodFiscal = addROClientCheckBox.Checked ? "RO" + clientCodFiscalTextBox.Text : clientCodFiscalTextBox.Text,
                Judet = clientJudetTextBox.Text,
                Adresa = clientAdresaTextBox.Text,
                Banca = clientBancaTextBox.Text,
                IBAN = clientIBANTextBox.Text,
            };
        }

        private Furnizor CreateFurnizor()
        {
            return new Furnizor()
            {
                Nume = furnizorNumeTextBox.Text,
                RegistrulComertului = furnizorRegComTextBox.Text,
                CodFiscal = addROFurnizorCheckBox.Checked ? "RO" + furnizorCodFiscalTextBox.Text : furnizorCodFiscalTextBox.Text,
                Judet = furnizorJudetTextBox.Text,
                Adresa = furnizorAdresaTextBox.Text,
                Banca = furnizorBancaTextBox.Text,
                IBAN = furnizorIBANTextBox.Text,
            };
        }

        private Vehicul CreateVehicul()
        {
            return new Vehicul()
            {
                NumarInmatriculare = nrInmatriculareTextBox.Text,
                NumarAxe = Convert.ToInt32(nrAxeTextBox.Text),
                Tip = tipVehiculTextBox.Text,
                NumeSofer = numeSoferTextBox.Text
            };
        }

        private Produs CreateProdus()
        {
            return new Produs()
            {
                Nume = numeProdusTextBox.Text
            };
        }

        private Cantarire CreateCantarire()
        {
            return new Cantarire()
            {
                Operator = numeOperatorTextBox.Text,
                Tara = Convert.ToInt32(taraTextBox.Text),
                Brut = Convert.ToInt32(brutTextBox.Text),
                Net = Convert.ToInt32(netTextBox.Text),
                Data = dataTextBox.Text,
            };
        }

        private Tichet CreateTichet()
        {
            return new Tichet()
            {
                NumarTichet = Convert.ToInt32(numarTichetTextBox.Text),
                TipTichet = intrareIesireComboBox.Text,
                DataCreeare = dataTextBox.Text,
                DataTiparire = DateTime.Now.ToString("d/M/yyyy h:mm:ss")
            };
        }

        private Aviz CreateAviz()
        {
            var connection = Helper.CreateConnection();
            var insertCommandTichetCantar = new SQLiteCommand("Insert into Aviz(ID_Tichet_Cantar) values (?)", connection);
            insertCommandTichetCantar.Parameters.Add("@param1", DbType.Int32, 2000).Value = Convert.ToInt32(numarTichetTextBox.Text);

            try
            {
                insertCommandTichetCantar.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Something went wrong");
            }

            var id = LastInsertedRowId(connection);

            return new Aviz()
            {
                NumarAviz = id,
                DataAviz = DateTime.Now.ToString("dd/MM/yyyy"),
                OraAviz = DateTime.Now.ToString("hh:mm")
            };
        }

        private int LastInsertedRowId(SQLiteConnection connection)
        {
            var command = new SQLiteCommand("select last_insert_rowid()", connection);
            var LastRowID64 = (Int64)command.ExecuteScalar();
            return (int)LastRowID64;
        }
    }
}
