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
    public partial class frmTipoChocolateAE : Form
    {
        public frmTipoChocolateAE()
        {
            InitializeComponent();
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            if (chocolate != null)
            {
                ChocolateTextBox.Text = chocolate.Chocolate;
            }
        }

        private TipoDeChocolate chocolate;
        public void SetChocolate(TipoDeChocolate chocolate)
        {
            this.chocolate = chocolate;
        }

        public TipoDeChocolate GetChocolate()
        {
            return chocolate;
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
        private void frmTipoChocolateAE_Load(object sender, EventArgs e)
        {

        }

        private void CancelarIconButton_Click_1(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void OKIconButton_Click(object sender, EventArgs e)
        {
            if (ValidarDatos())
            {
                if (chocolate == null)
                {
                    chocolate = new TipoDeChocolate();
                }

                chocolate.Chocolate = ChocolateTextBox.Text;

                DialogResult = DialogResult.OK;
            }
        }
    }
}
