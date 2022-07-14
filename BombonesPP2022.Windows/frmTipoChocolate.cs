using BombonesPP2022.Entidades.Entidades;
using BombonesPP2022.Servicios.Servicios;
using BombonesPP2022.Windows.Helpers;
using FontAwesome.Sharp;
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
    public partial class frmTipoChocolate : Form
    {
        public frmTipoChocolate()
        {
            InitializeComponent();
        }

        private TiposDeChocolateServicios servicio;
        private List<TipoDeChocolate> lista;


        private void frmTipoChocolate_Load(object sender, EventArgs e)
        {
            servicio = new TiposDeChocolateServicios();
            try
            {
                lista = servicio.GetLista();
                HelperForm.MostrarDatosEnGrilla(DatosDataGridView, lista);

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private void AbrirFormulario(frmTipoChocolate frmTipoChocolate)
        {
            frmTipoChocolate.TopLevel = false;
            frmTipoChocolate.FormBorderStyle = FormBorderStyle.None;
            frmTipoChocolate.Dock = DockStyle.Fill;

            DatosDataGridView.Controls.Add(frmTipoChocolate);

            frmTipoChocolate.Show();
        }

        private void MostrarDatosEnGrilla()
        {
            HelperGrid.LimpiarGrilla(DatosDataGridView);
            foreach (var categoria in lista)
            {
                var r = HelperGrid.ConstruirFila(DatosDataGridView);
                HelperGrid.SetearFila(r, categoria);
                HelperGrid.AgregarFila(DatosDataGridView, r);
            }
        }

        private void RecargarGrilla()
        {
            try
            {
                lista = servicio.GetLista();
                MostrarDatosEnGrilla();
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }



        private void DatosDataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void NuevoIconButton_Click(object sender, EventArgs e)
        {
            frmTipoChocolateAE frm = new frmTipoChocolateAE() { Text = "Agregar un chocolate" };
            DialogResult dr = frm.ShowDialog(this);
            if (dr == DialogResult.Cancel)
            {
                return;
            }

            try
            {
                TipoDeChocolate chocolate = frm.GetChocolate();
                int registrosAfectados = servicio.Agregar(chocolate);
                if (registrosAfectados == 0)
                {
                    MessageBox.Show("No se agregaron registros...",
                        "Advertencia",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);
                    //Recargar grilla
                    RecargarGrilla();
                }
                else
                {
                    //var r = ConstruirFila();
                    var r = HelperGrid.ConstruirFila(DatosDataGridView);
                    //SetearFila(r,categoria);
                    HelperGrid.SetearFila(r, chocolate);
                    //AgregarFila(r);
                    HelperGrid.AgregarFila(DatosDataGridView, r);
                    MessageBox.Show("Registro agregado",
                        "Mensaje",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);

                }
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message,
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void BorrarIconButton_Click(object sender, EventArgs e)
        {
            if (DatosDataGridView.SelectedRows.Count == 0)
            {
                return;
            }

            try
            {
                var r = DatosDataGridView.SelectedRows[0];
                TipoDeChocolate chocolate = (TipoDeChocolate)r.Tag;
                DialogResult dr = MessageBox.Show($"¿Desea borrar el registro seleccionado de {chocolate.Chocolate}?",
                    "Confirmar Eliminación",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question,
                    MessageBoxDefaultButton.Button2);
                if (dr == DialogResult.No)
                {
                    return;
                }

                int registrosAfectados = servicio.Borrar(chocolate);
                if (registrosAfectados == 0)
                {
                    MessageBox.Show("No se borraron registros...",
                        "Advertencia",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);
                    //Recargar grilla
                    RecargarGrilla();

                }
                else
                {
                    DatosDataGridView.Rows.Remove(r);
                    MessageBox.Show("Registro eliminado",
                        "Mensaje",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);
                }
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message,
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);

            }
        }

        private void EditarIconButton_Click(object sender, EventArgs e)
        {
            if (DatosDataGridView.SelectedRows.Count == 0)
            {
                return;
            }

            var r = DatosDataGridView.SelectedRows[0];
            TipoDeChocolate chocolate = (TipoDeChocolate)r.Tag;
            TipoDeChocolate chocolateAux = (TipoDeChocolate)chocolate.Clone();
            try
            {
                frmTipoChocolateAE frm = new frmTipoChocolateAE() { Text = "Editar un chocolate" };
                frm.SetChocolate(chocolate);
                DialogResult dr = frm.ShowDialog(this);
                if (dr == DialogResult.Cancel)
                {
                    return;
                }

                chocolate = frm.GetChocolate();
                int registrosAfectados = servicio.Editar(chocolate);
                if (registrosAfectados == 0)
                {
                    MessageBox.Show("No se borraron registros...",
                        "Advertencia",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);
                    //Recargar grilla
                    RecargarGrilla();

                }
                else
                {
                    //SetearFila(r,categoria);
                    HelperGrid.SetearFila(r, chocolate);
                    MessageBox.Show("Registro modificado",
                        "Mensaje",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);
                }
            }
            catch (Exception exception)
            {
                //SetearFila(r, catAuxiliar);
                HelperGrid.SetearFila(r, chocolateAux);
                MessageBox.Show(exception.Message,
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }
    }
}
