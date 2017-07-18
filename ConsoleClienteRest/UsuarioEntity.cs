using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleClienteRest
{
    public class UsuarioEntity
    {
        private Nullable<Int32> codigo; 
        private String nome;
        private String login;
        private String senha;
        private String tipo;
        private Boolean registroAtivo;
        private Int32 codigoSetor;

        public int? Codigo
        {
            get
            {
                return codigo;
            }

            set
            {
                codigo = value;
            }
        }

        public string Nome
        {
            get
            {
                return nome;
            }

            set
            {
                nome = value;
            }
        }

        public string Login
        {
            get
            {
                return login;
            }

            set
            {
                login = value;
            }
        }

        public string Senha
        {
            get
            {
                return senha;
            }

            set
            {
                senha = value;
            }
        }

        public string Tipo
        {
            get
            {
                return tipo;
            }

            set
            {
                tipo = value;
            }
        }

        public bool RegistroAtivo
        {
            get
            {
                return registroAtivo;
            }

            set
            {
                registroAtivo = value;
            }
        }

        public int CodigoSetor
        {
            get
            {
                return codigoSetor;
            }

            set
            {
                codigoSetor = value;
            }
        }
    }
}
