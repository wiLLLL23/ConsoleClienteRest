using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleClienteRest
{
    class ConsultarRegistroPorCodigo
    {
        private UsuarioEntity consultarRegistroPorCodigoResult;

        public UsuarioEntity ConsultarRegistroPorCodigoResult
        {
            get
            {
                return consultarRegistroPorCodigoResult;
            }

            set
            {
                consultarRegistroPorCodigoResult = value;
            }
        }
    }
}
