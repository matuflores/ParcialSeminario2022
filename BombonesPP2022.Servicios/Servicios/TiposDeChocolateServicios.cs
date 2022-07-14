using BombonesPP2022.Datos.Repositorios;
using BombonesPP2022.Entidades.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BombonesPP2022.Servicios.Servicios
{
    public class TiposDeChocolateServicios
    {
        private readonly TiposDeChocolateRepositorio repositorio;

        public TiposDeChocolateServicios()
        {
            repositorio = new TiposDeChocolateRepositorio();
        }

        public List<TipoDeChocolate> GetLista()
        {
            try
            {
                return repositorio.GetLista();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
        public int Agregar(TipoDeChocolate tipoDeChocolate)
        {
            try
            {
                return repositorio.Agregar(tipoDeChocolate);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public int Borrar(TipoDeChocolate tipoDeChocolate)
        {
            try
            {
                return repositorio.Borrar(tipoDeChocolate);
            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }
        }

        public int Editar(TipoDeChocolate tipoDeChocolate)
        {
            try
            {
                return repositorio.Editar(tipoDeChocolate);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
    }
}
