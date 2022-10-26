using Microsoft.Reporting.WinForms;
using TNSA_Test.Models;
using System.Windows.Forms;

namespace TNSA_Test
{
    public partial class PreviewTichet : Form
    {
        public PreviewTichet(Tichet tichet, Cantarire cantarire, Client client, Furnizor furnizor, Produs produs, Vehicul vehicul)
        {
            InitializeComponent();
            SetUp(tichet, cantarire, client, furnizor, produs, vehicul);
        }

        private void SetUp(Tichet tichet, Cantarire cantarire, Client client, Furnizor furnizor, Produs produs, Vehicul vehicul)
        {
            ReportParameter[] parameters =
                { 
                    // parametrii client
                    new ReportParameter("numeClient", client.Nume),
                    new ReportParameter("RCClient", client.RegistrulComertului),
                    new ReportParameter("CUIClient", client.CodFiscal),
                    new ReportParameter("adresaClient", client.Adresa),
                    new ReportParameter("contClient", client.IBAN),
                    new ReportParameter("bancaClient", client.Banca),
                    // parametrii furnizor
                    new ReportParameter("numeFurnizor", furnizor.Nume),
                    new ReportParameter("RCFurnizor", furnizor.RegistrulComertului),
                    new ReportParameter("CUIFurnizor", furnizor.CodFiscal),
                    new ReportParameter("adresaFurnizor", furnizor.Adresa),
                    new ReportParameter("contFurnizor", furnizor.IBAN),
                    new ReportParameter("bancaFurnizor", furnizor.Banca),
                    // parametrii vehicul
                    new ReportParameter("nrInmatriculare", vehicul.NumarInmatriculare),
                    new ReportParameter("nrAxe", vehicul.NumarAxe.ToString()),
                    new ReportParameter("tipVehicul", vehicul.Tip),
                    new ReportParameter("delegat", vehicul.NumeSofer),
                    // parametrii produs
                    new ReportParameter("numeProdus", produs.Nume),
                    // parametrii tichet
                    new ReportParameter("dataCreareTichet", tichet.DataCreeare),
                    new ReportParameter("dataTiparireTichet", tichet.DataTiparire),
                    new ReportParameter("numarTichet", tichet.NumarTichet.ToString()),
                    new ReportParameter("tipTichet", tichet.TipTichet),
                    new ReportParameter("dataCantarireTara", tichet.DataCreeare),
                    // parametrii cantarire
                    new ReportParameter("operatorCantar", cantarire.Operator),
                    
                };


            var axe = new DetaliiAxe()
            {
                NumarAxa = 1,
                Tara = cantarire.Tara,
                Brut = cantarire.Brut,
                Net = cantarire.Net
            };

            var binding = new BindingSource
            {
                DataSource = axe
            };

            reportViewer1.LocalReport.DataSources.Add(new ReportDataSource("DataSetAxe", binding));
            reportViewer1.LocalReport.SetParameters(parameters);
        }

        private void PreviewTichet_Load(object sender, System.EventArgs e)
        {
            reportViewer1.RefreshReport();
        }
    }
}
