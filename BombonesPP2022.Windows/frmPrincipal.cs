
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FontAwesome.Sharp;

namespace BombonesPP2022.Windows
{
    public partial class frmPrincipal : Form
    {

        public frmPrincipal()
        {
            InitializeComponent();
        }

        private void frmInicio_Load(object sender, EventArgs e)
        {
            
        }

        private void ChocolatesButton_Click(object sender, EventArgs e)
        {
            Form tiposDeChocolate = new frmTipoChocolate();
            tiposDeChocolate.Show();
        }

        private void CerrarButton_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void FabricasButton_Click(object sender, EventArgs e)
        {
            Form fabricas = new frmFabricas();
            fabricas.Show();
        }
    }
}
