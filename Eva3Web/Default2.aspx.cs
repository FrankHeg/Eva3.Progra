using Eva3Model.DAL;
using Eva3Model.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Eva3Web
{
    public partial class Default2 : System.Web.UI.Page
    {
        private IMedidoresDAL medidoresDAL = new MedidoresDALObjetos();
        private ILecturasDAL lecturasDAL = new LecturasDALObjetos();

        private List<Medidor> medidoresAAA = new List<Medidor>();
        protected void Page_Load(object sender, EventArgs e)
        {
            //Este Metodo se ejecuta cuando se carga el form puede ser:
            //- cuando es una peticion GET (!PostBack)
            //- cuando es una peticion POST (PostBack)
            if (!IsPostBack)
            {
                //aqui cargar la lista del dropdown
                List<Medidor> medidores = medidoresDAL.Obtener();
                this.medidorDd2.DataSource = medidores;
                this.medidorDd2.DataTextField = "numero";
                this.medidorDd2.DataValueField = "numero";
                this.medidorDd2.DataBind();
                

                this.medidoresAAA = medidores;
            }
        }

        protected void agregarBtn2_Click(object sender, EventArgs e)
        {
            //1. obtener los datos del formulario
            string numero = this.medidorDd2.SelectedValue.ToString();
            
            string fecha = this.Calendar1.SelectedDate.ToString();
            string hora = this.horaTxt.Text.Trim();
            string minuto = this.minutosTxt.Text.Trim();
            string consumo = this.consumoTxt.Text.Trim();
            //eso obtiene el valor del dropdown
            string lecturaValor = this.medidorDd2.SelectedValue;

            //eso obtiene el texto
            string lecturaTexto = this.medidorDd2.SelectedValue.ToString();
            

            //2. construir el objeto de tipo medidor
            List<Lectura> lecturas = lecturasDAL.ObtenerLecturas();
            Medidor medidor = this.medidoresAAA.Find(b => b.Numero == lecturaTexto);

            List<Medidor> medidores = this.medidoresAAA;
            Lectura lectura = new Lectura()
            {
                NumeroLec = numero,
                FechaLec = fecha,
                HoraLec = hora,
                MinutoLec = minuto,
                ConsumoLec = consumo,
                
            };
            
            
            //3. Llamar al DAL
            lecturasDAL.Agregar(lectura);
            //4. Mostrar mensaje de exito
            this.mensajeLb1.Text = "Lectura Ingresada";
            Response.Redirect("VerLecturas.aspx");
        }
    }
}