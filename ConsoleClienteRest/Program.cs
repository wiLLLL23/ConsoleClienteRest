using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleClienteRest
{
    class Program
    {
        static void Main(string[] args)
        {
            ServiceClient client = new ServiceClient();

            UsuarioEntity usuarioEntity = new UsuarioEntity();

            string resultado = null;
            string opcao = null;

            Console.ForegroundColor = ConsoleColor.Green;

            while (true)
            {
                Console.Clear();
                Console.WriteLine("FAVOR SELECIONAR UMA DAS OPÇÕES E PRESSIONAR ENTER");
                Console.WriteLine("\n"); 

                Console.WriteLine("(1)=INSERIR, (2)=ATUALIZAR, (3)=EXCLUIR, (4)=CONSULTAR, (5)=TODOS REGISTROS");
                opcao = Console.ReadLine();
                Console.WriteLine("\n");

                if (opcao.Equals("1"))
                {
                    Console.WriteLine("NOVO CADASTRO DE USUÁRIO\n\n");

                    Console.Write("NOME:");
                    usuarioEntity.Nome = Console.ReadLine();

                    Console.Write("LOGIN:");
                    usuarioEntity.Login = Console.ReadLine();

                    Console.Write("SENHA:");
                    usuarioEntity.Senha = Console.ReadLine(); 

                    Console.Write("TIPO:");
                    usuarioEntity.Tipo = Console.ReadLine();

                    Console.Write("CÓDIGO DO SETOR:");
                    usuarioEntity.CodigoSetor = Convert.ToInt32(Console.ReadLine());

                    usuarioEntity.RegistroAtivo = true;

                    resultado = client.InserirNovoRegistro(usuarioEntity);

                    Console.WriteLine("\n\n");
                    Console.WriteLine(resultado);
                    Console.WriteLine("\n\n");
                    Console.WriteLine("PRESSIONE ENTER PARA CONTINUAR!");
                    Console.ReadLine();
                }
                else if (opcao.Equals("2"))
                {
                    Console.WriteLine("ATUALIZAR CADASTRO DE USUÁRIO\n\n");

                    Console.Write("CÓDIGO:");
                    usuarioEntity.Codigo = Convert.ToInt32(Console.ReadLine());

                    Console.Write("NOME:");
                    usuarioEntity.Nome = Console.ReadLine();

                    Console.Write("LOGIN:");
                    usuarioEntity.Login = Console.ReadLine();

                    Console.Write("SENHA:");
                    usuarioEntity.Senha = Console.ReadLine();

                    Console.Write("TIPO:");
                    usuarioEntity.Tipo = Console.ReadLine();

                    Console.Write("CÓDIGO DO SETOR:");
                    usuarioEntity.CodigoSetor = Convert.ToInt32(Console.ReadLine());

                    usuarioEntity.RegistroAtivo = true;

                    resultado = client.AtualizarRegistro(usuarioEntity);

                    Console.WriteLine("\n\n");
                    Console.WriteLine(resultado);
                    Console.WriteLine("\n\n");
                    Console.WriteLine("PRESSIONE ENTER PARA CONTINUAR!");
                    Console.ReadLine();
                }
                else if (opcao.Equals("3"))
                {
                    Console.WriteLine("EXCLUIR CADASTRO DE USUÁRIO\n\n");

                    Console.Write("CÓDIGO:");
                    usuarioEntity.Codigo = Convert.ToInt32(Console.ReadLine());

                    resultado = client.ExcluirUsuario(usuarioEntity.Codigo.Value);

                    Console.WriteLine("\n\n");
                    Console.WriteLine(resultado);
                    Console.WriteLine("\n\n");
                    Console.WriteLine("PRESSIONE ENTER PARA CONTINUAR!");
                    Console.ReadLine();
                }
                else if (opcao.Equals("4"))
                {
                    Console.WriteLine("CONSULTAR USUÁRIO\n\n");

                    Console.Write("CÓDIGO PARA CONSULTA:");
                    usuarioEntity.Codigo = Convert.ToInt32(Console.ReadLine());

                    usuarioEntity = client.ConsultarRegistroPorCodigo(usuarioEntity.Codigo.Value);

                    Console.WriteLine("\n\n");
                    Console.WriteLine("CÓDIGO:" + usuarioEntity.Codigo);
                    Console.WriteLine("NOME:" + usuarioEntity.Nome);
                    Console.WriteLine("LOGIN:" + usuarioEntity.Login);
                    Console.WriteLine("SENHA:" + usuarioEntity.Senha);
                    Console.WriteLine("TIPO:" + usuarioEntity.Tipo);
                    Console.WriteLine("CÓDIGO DO SETOR:" + usuarioEntity.CodigoSetor);
                    Console.WriteLine("REGISTRO ATIVO:" + (usuarioEntity.RegistroAtivo ? "SIM" : "NÃO"));
                    Console.WriteLine("\n\n");
                    Console.WriteLine("\n\n");
                    Console.WriteLine("PRESSIONE ENTER PARA CONTINUAR!");
                    Console.ReadLine();
                }
                else if (opcao.Equals("5"))
                {
                    Console.WriteLine("CONSULTAR TODOS USUÁRIOS\n\n");

                    IList<UsuarioEntity> usuarios = client.ConsultarUsuarios();

                    foreach (UsuarioEntity item in usuarios)
                    {

                        Console.WriteLine("\n\n");
                        Console.WriteLine("#########################################################################");
                        Console.WriteLine("CÓDIGO:" + item.Codigo);
                        Console.WriteLine("NOME:" + item.Nome);
                        Console.WriteLine("LOGIN:" + item.Login);
                        Console.WriteLine("SENHA:" + item.Senha);
                        Console.WriteLine("TIPO:" + item.Tipo);
                        Console.WriteLine("CÓDIGO DO SETOR:" + item.CodigoSetor);
                        Console.WriteLine("REGISTRO ATIVO:" + (item.RegistroAtivo ? "SIM" : "NÃO"));
                        Console.WriteLine("#########################################################################");
                        Console.WriteLine("\n\n");
                    }
                    Console.WriteLine("\n\n");
                    Console.WriteLine("PRESSIONE ENTER PARA CONTINUAR!");
                    Console.ReadLine();
                }
                else
                {
                    Console.WriteLine("\n\n");
                    Console.WriteLine("OPÇÃO INVÁLIDA !!!");
                    Console.WriteLine("\n\n");
                    Console.WriteLine("PRESSIONE ENTER PARA CONTINUAR!");
                    Console.ReadLine();
                }
            }
        }
    }
}
