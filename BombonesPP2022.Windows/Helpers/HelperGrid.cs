using BombonesPP2022.Entidades.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BombonesPP2022.Windows.Helpers
{
    public static class HelperGrid
    {
        public static void LimpiarGrilla(DataGridView dataGrid)
        {
            dataGrid.Rows.Clear();

        }
        public static DataGridViewRow ConstruirFila(DataGridView dataGrid)
        {
            var c = new DataGridViewRow();
            c.CreateCells(dataGrid);
            return c;
        }

        public static void AgregarFila(DataGridView dataGrid, DataGridViewRow c)
        {
            dataGrid.Rows.Add(c);
        }

        public static void SetearFila(DataGridViewRow c, Object obj)
        {
            c.Cells[0].Value = ((TipoDeChocolate)obj).Chocolate;

            c.Tag = obj;

        }
        public static void SetearFilaF(DataGridViewRow c, Object obj)
        {
            c.Cells[0].Value = ((Fabrica)obj).NombreFabrica;
            c.Cells[1].Value = ((Fabrica)obj).Direccion;
            c.Cells[2].Value = ((Fabrica)obj).GerenteDeVentas;
            c.Cells[3].Value = ((Fabrica)obj).PaisId;

            c.Tag = obj;

        }
    }
}
