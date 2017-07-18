using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleClienteRest
{
    class InserirRegistroRequest
    {
        private UsuarioEntity usuario;  

        public UsuarioEntity usuarioEntity
        {
            get
            {
                return usuario;
            }

            set
            {
                usuario = value;
            }
        }
    }
}
