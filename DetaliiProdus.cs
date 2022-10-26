namespace TNSA_Test
{
    public class DetaliiProdus
    {
        public string Descriere { set; get; }
        public string UM { set; get; }
        public int Cantitate { set; get; }
        public int PretUnitar { set; get; }
        public double Valoare {
            get
            {
                return Cantitate * PretUnitar;
            }
        }
    }
}
