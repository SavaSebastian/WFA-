using Microsoft.Reporting.WinForms;
using System;
using System.Windows.Forms;
using TNSA_Test.Models;

namespace TNSA_Test
{
    public partial class PreviewAviz : Form
    {
        public PreviewAviz(Aviz aviz, Cantarire cantarire, Client client, Furnizor furnizor, Produs produs, Vehicul vehicul)
        {
            InitializeComponent();
            SetUp(aviz, cantarire, client, furnizor, produs, vehicul);
        }

        private void SetUp(Aviz aviz, Cantarire cantarire, Client client, Furnizor furnizor, Produs produs, Vehicul vehicul)
        {
            ReportParameter[] parameters =
                { 
                    // parametrii client
                    new ReportParameter("numeCumparator", client.Nume),
                    new ReportParameter("cumparatorNrRegCom", client.RegistrulComertului),
                    new ReportParameter("cumparatorCIF", client.CodFiscal),
                    new ReportParameter("cumparatorSediu", client.Adresa),
                    new ReportParameter("cumparatorJudet", client.Judet),
                    new ReportParameter("cumparatorContBancar", client.IBAN),
                    new ReportParameter("cumparatorBanca", client.Banca),
                    // parametrii furnizor
                    new ReportParameter("numeFurnizor", furnizor.Nume),
                    new ReportParameter("furnizorNrRegCom", furnizor.RegistrulComertului),
                    new ReportParameter("furnizorCIF", furnizor.CodFiscal),
                    new ReportParameter("furnizorSediu", furnizor.Adresa),
                    new ReportParameter("furnizorJudet", furnizor.Judet),
                    new ReportParameter("furnizorContBancar", furnizor.IBAN),
                    new ReportParameter("furnizorBanca", furnizor.Banca),
                    // parametrii vehicul
                    new ReportParameter("nrInmatriculareAutoturism", vehicul.NumarInmatriculare),
                    new ReportParameter("numeDelegat", vehicul.NumeSofer),
                    // parametrii aviz
                    new ReportParameter("nrAviz", aviz.NumarAviz.ToString()),
                    new ReportParameter("dataAviz", aviz.DataAviz + " " + aviz.OraAviz),
                    // date expeditie
                    new ReportParameter("dataExpeditie", aviz.DataAviz),
                    new ReportParameter("oraExpeditie", aviz.OraAviz)
                };


            var ceva = new DetaliiProdus()
            {
                Descriere = produs.Nume,
                Cantitate = cantarire.Net,
                UM = "Kg"
            };

            var binding = new BindingSource
            {
                DataSource = ceva
            };

            reportViewer1.LocalReport.DataSources.Add(new ReportDataSource("avizProdusDataSet", binding));
            reportViewer1.LocalReport.SetParameters(parameters);
        }

        private void PreviewAviz_Load(object sender, EventArgs e)
        {
            reportViewer1.RefreshReport();
        }
    }
}
