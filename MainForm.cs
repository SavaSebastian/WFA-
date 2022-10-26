using System;
using System.Data;
using System.Data.SQLite;
using System.Windows.Forms;
using TNSA_Test.Utilities;

namespace TNSA_Test
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Maximized;
            DataGridSetup();
            GetData();
        }

        private void DataGridSetup()
        {
            var deleteButton = new DataGridViewButtonColumn
            {
                Name = "dataGridViewDeleteButton",
                HeaderText = "Delete",
                Text = "Delete",
                UseColumnTextForButtonValue = true,
                AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            };

            var access = new DataGridViewButtonColumn
            {
                Name = "dataGridViewAccessButton",
                HeaderText = "Access",
                Text = "Access",
                UseColumnTextForButtonValue = true,
                AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            };

            cantaririDataGrid.Columns.Add(access);
            cantaririDataGrid.Columns.Add(deleteButton);
        }

        private void GetData()
        {
            var connection = Helper.CreateConnection();

            var command = new SQLiteCommand("", connection);
            var dataAdapter = new SQLiteDataAdapter("SELECT * from TichetCantar", connection);
            var dataSet = new DataSet();

            dataAdapter.Fill(dataSet, "TichetCantar");

            dateCantaririBinding.Clear();

            foreach (DataRow dr in dataSet.Tables["TichetCantar"].Rows)
            {
                var tichetId = (int)dr.Field<Int64>("ID");

                var clientId = (int)dr.Field<Int64>("ID_Client");
                command.CommandText = ("Select Nume from Clienti where ID ='" + clientId + "'");
                var numeClient = (string)command.ExecuteScalar();

                var furnizorId = (int)dr.Field<Int64>("ID_Furnizor");
                command.CommandText = ("Select Nume from Furnizori where ID ='" + furnizorId + "'");
                var numeFurnizor = (string)command.ExecuteScalar();

                var vehiculId = (int)dr.Field<Int64>("ID_Vehicul");
                command.CommandText = ("Select NumarInmatriculare from Vehicul where ID ='" + vehiculId + "'");
                var numarInmatriculareVehicul = (string)command.ExecuteScalar();

                var produsId = (int)dr.Field<Int64>("ID_Produs");
                command.CommandText = ("Select Nume from Produse where ID ='" + produsId + "'");
                var numeProdus = (string)command.ExecuteScalar();

                var cantarireId = (int)dr.Field<Int64>("ID_Cantarire");

                command.CommandText = ("Select Tara from Cantariri where ID = '" + cantarireId + "'");
                var tara = (int)(Int64)command.ExecuteScalar();

                command.CommandText = ("Select Brut from Cantariri where ID = '" + cantarireId + "'");
                var brut = (int)(Int64)command.ExecuteScalar();

                command.CommandText = ("Select Net from Cantariri where ID = '" + cantarireId + "'");
                var net = (int)(Int64)command.ExecuteScalar();

                dateCantaririBinding.Add(new DetaliiCantarire
                {
                    TichetId = tichetId,
                    NumeClient = numeClient,
                    NumeFurnizor = numeFurnizor,
                    NumeProdus = numeProdus,
                    NumeSofer = dr.Field<string>("NumeSofer"),
                    NumeOperator = dr.Field<string>("NumeOperator"),
                    Vehicul = numarInmatriculareVehicul,
                    Tip = dr.Field<string>("Tip"),
                    Tara = tara,
                    Brut = brut,
                    Net = net,
                    Data = dr.Field<string>("DataCreeriTichetului")
                });
            }
        }

        private void AddButton_Click(object sender, EventArgs e)
        {
            var formCantarire = new FormCantarire();
            formCantarire.Show();
        }

        private void RefreshButton_Click(object sender, EventArgs e)
        {
            GetData();
        }

        private void CantaririDataGrid_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == cantaririDataGrid.NewRowIndex || e.RowIndex < 0)
                return;

            if (e.ColumnIndex == cantaririDataGrid.Columns["dataGridViewDeleteButton"].Index)
            {
                var detaliiCantarire = (DetaliiCantarire)cantaririDataGrid.Rows[e.RowIndex].DataBoundItem;

                var deleteCommand = new SQLiteCommand("Delete from TichetCantar where ID = @tichetId", Helper.CreateConnection());
                deleteCommand.Parameters.Add("@tichetId", DbType.Int32, 2000).Value = detaliiCantarire.TichetId;

                deleteCommand.ExecuteNonQuery();

                dateCantaririBinding.RemoveAt(e.RowIndex);
            }

            if (e.ColumnIndex == cantaririDataGrid.Columns["dataGridViewAccessButton"].Index)
            {
                var detaliiCantarire = (DetaliiCantarire)cantaririDataGrid.Rows[e.RowIndex].DataBoundItem;
                
                new FormCantarire(detaliiCantarire.TichetId).Show();
            }
        }
    }
}