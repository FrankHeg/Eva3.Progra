using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eva3Model.DTO
{
    public class Medidor
    {
        private string numero;
        private string fecha;
        private string consumo;
        private int tipo;
        private List<Lectura> lecturas = new List<Lectura>();

        public string TipoTxt
        {
            get
            {
                string tipoTxt = "";
                switch (tipo)
                {
                    case 1:
                        tipoTxt = "Analogo";
                        break;
                    case 2:
                        tipoTxt = "Digital";
                        break;
                }
                return tipoTxt;
            }
        }

        public string Numero { get => numero; set => numero = value; }
        public string Fecha { get => fecha; set => fecha = value; }
        public string Consumo { get => consumo; set => consumo = value; }
        public int Tipo { get => tipo; set => tipo = value; }
        public List<Lectura> Lecturas { get => lecturas; set => lecturas = value; }
    }
}
