using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BombonesPP2022.Windows.Helpers
{
    public static class HelperForm
    {
        public static void MostrarDatosEnGrilla<T>(DataGridView dataGrid, List<T> lista)
        {
            HelperGrid.LimpiarGrilla(dataGrid);
            foreach (var obj in lista)
            {
                DataGridViewRow c = HelperGrid.ConstruirFila(dataGrid);
                HelperGrid.SetearFila(c, obj);
                HelperGrid.AgregarFila(dataGrid, c);
            }
        }
    }
}
