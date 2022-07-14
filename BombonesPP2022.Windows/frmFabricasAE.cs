using BombonesPP2022.Entidades.Entidades;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BombonesPP2022.Windows
{
    public partial class frmFabricasAE : Form
    {
        public frmFabricasAE()
        {
            InitializeComponent();
        }

        private void frmFabricasAE_Load(object sender, EventArgs e)
        {

        }
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            if (fabrica != null)
            {
                FabricaTextBox.Text = fabrica.NombreFabrica;
            }
        }

        private Fabrica fabrica;
        public void SetFabrica(Fabrica fabrica)
        {
            this.fabrica = fabrica;
        }

        public Fabrica GetFabrica()
        {
            return fabrica;
        }
        private void CancelarIconButton_Click(object sender, System.EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        private bool ValidarDatos()
        {
            bool valido = true;

            return valido;
        }
        private void OKIconButton_Click(object sender, EventArgs e)
        {
            if (ValidarDatos())
            {
                if (fabrica == null)
                {
                    fabrica = new Fabrica();
                }

                fabrica.NombreFabrica = FabricaTextBox.Text;
                fabrica.Direccion = DireccionTextBox.Text;
                fabrica.GerenteDeVentas = GerenteTextBox.Text;

                DialogResult = DialogResult.OK;
            }
        }
    }
}
