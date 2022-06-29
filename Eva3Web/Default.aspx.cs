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
    public partial class Default : System.Web.UI.Page
    {
        private IMedidoresDAL medidoresDAL = new MedidoresDALObjetos();
        private ILecturasDAL lecturasDAL = new LecturasDALObjetos();
        protected void Page_Load(object sender, EventArgs e)
        {
            
            if (!IsPostBack)
            {
                
                List<Lectura> lecturas = lecturasDAL.ObtenerLecturas();
                this.lecturaDd1.DataSource = lecturas;
                this.lecturaDd1.DataTextField = "NumeroLec";
                this.lecturaDd1.DataValueField = "ConsumoLec";
                this.lecturaDd1.DataBind();
            }
        }

        protected void agregarBtn_Click(object sender, EventArgs e)
        {
            // obtener los datos del formulario
            string numero = this.numeroTxt.Text.Trim();
            
            string lecturaValor = this.lecturaDd1.SelectedValue;
            //eso obtiene el texto
            
            int tipo = Convert.ToInt32(this.tipoRb1.SelectedItem.Value);

            //2. construir el objeto de tipo medidor
            List<Lectura> lecturas = lecturasDAL.ObtenerLecturas();
            Lectura lectura = lecturas.Find(b => b.NumeroLec == this.lecturaDd1.SelectedItem.Value);

            Medidor medidor = new Medidor()
            {
                Numero = numero,
                
               
                Tipo = tipo,
                
            };
            medidor.Lecturas = new List<Lectura>();

            //3. Llamar al DAL
            medidoresDAL.Agregar(medidor);
            //4. Mostrar mensaje de exito
            this.mensajeLb1.Text = "Medidor Ingresado";
            Response.Redirect("VerMedidores.aspx");
        }
    }
}