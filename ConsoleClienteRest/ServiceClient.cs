using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleClienteRest
{
    class ServiceClient
    {
        private string url = "http://localhost:61263/ServiceUsuario.svc";
        private string contentType = "application/json; charset=utf-8";
        private System.Net.WebRequest webRequest;

        /// <param name="operacao"></param>
        /// <param name="metodo"></param>
        private void PreparaWebRequest(string operacao, string metodo)
        {

            webRequest = System.Net.WebRequest.Create(url + "/" + operacao);
            webRequest.Method = metodo;
            webRequest.ContentType = this.contentType;
        }
        /// ESSE MÉTODO RETORNA UM Dictionary QUANDO O JSON PASSADO FOR UMA STRING COM CHAVE E VALOR
        /// <param name="json"></param>
        public Dictionary<string, string> DeserializeString(string json)
        {
            string[] resultado = json.Replace("{", string.Empty)
                                .Replace("}", string.Empty)
                                .Replace(@"\", string.Empty)
                                .Replace("\"", string.Empty).Split(':');

            Dictionary<string, string> saida = new Dictionary<string, string>();

            saida.Add(resultado[0], resultado[1]);

            return saida;
        }
        /// ESSE MÉTODO TORNAR UM OBJETO EM STRING JSON PARA ENVIARMOS PARA O SERVIÇO REST
        /// <typeparam name="T"></typeparam>
        /// <param name="objeto"></param>
        public string Serialize<T>(T objeto)
        {
            System.Runtime.Serialization.Json.DataContractJsonSerializer serializer = new System.Runtime.Serialization.Json.DataContractJsonSerializer(objeto.GetType());

            System.IO.MemoryStream memoryStream = new System.IO.MemoryStream();

            serializer.WriteObject(memoryStream, objeto);

            string stringJson = Encoding.UTF8.GetString(memoryStream.ToArray());

            return stringJson;
        }
        /// ESSE MÉTODO TRANSFORMA UMA STRING JSON EM UM OBJETO QUE É PASSADO NO TIPO GENÉRICO (T)
        /// <typeparam name="T"></typeparam>
        /// <param name="stringJson"></param>
        public T Deserialize<T>(string stringJson)
        {
            T objeto = Activator.CreateInstance<T>();

            System.IO.MemoryStream memoryStream = new System.IO.MemoryStream(Encoding.Unicode.GetBytes(stringJson));

            System.Runtime.Serialization.Json.DataContractJsonSerializer serializer = new System.Runtime.Serialization.Json.DataContractJsonSerializer(objeto.GetType());

            objeto = (T)serializer.ReadObject(memoryStream);

            memoryStream.Close();

            return objeto;
        }

        /// ESSE MÉTODO VAI CHAMAR A OPERAÇÃO PARA INSERIR UM NOVO REGISTRO DO SERVIÇO REST
        /// <param name="usuarioEntity"></param>
        public string InserirNovoRegistro(UsuarioEntity usuarioEntity)
        {
            PreparaWebRequest("InserirNovoRegistro", "POST");

            InserirRegistroRequest inserirRegistroRequest = new InserirRegistroRequest();
            inserirRegistroRequest.usuarioEntity = usuarioEntity;

            string jsonSerialize = this.Serialize<InserirRegistroRequest>(inserirRegistroRequest);

            using (var streamWriter = new System.IO.StreamWriter(webRequest.GetRequestStream()))
            {
                streamWriter.Write(jsonSerialize);
                streamWriter.Flush();
                streamWriter.Close();
            }

            var response = (System.Net.HttpWebResponse)webRequest.GetResponse();


            string resultadoJson = null;

            using (var streamReader = new System.IO.StreamReader(response.GetResponseStream()))
                resultadoJson = streamReader.ReadToEnd();


            return DeserializeString(resultadoJson).Values.First();

        }
        /// ESSE MÉTODO VAI CONSULTAR UM ÚNICO REGISTRO PELO SEU CÓDIGO(ID)
        /// <param name="codigo"></param>
        public UsuarioEntity ConsultarRegistroPorCodigo(int codigo)
        {
            ConsultarRegistroPorCodigo usuario = new ConsultarRegistroPorCodigo();

            string resultadoJson = "";

            PreparaWebRequest("ConsultarRegistroPorCodigo/" + codigo, "GET");

            var response = (System.Net.HttpWebResponse)webRequest.GetResponse();

            using (var streamReader = new System.IO.StreamReader(response.GetResponseStream()))
            {

                resultadoJson = streamReader.ReadToEnd();

                usuario = Deserialize<ConsultarRegistroPorCodigo>(resultadoJson);
            }

            return usuario.ConsultarRegistroPorCodigoResult;
        }
        /// ESSE MÉTODO VAI RETORNAR TODOS OS REGISTROS CADASTRADOS
        public List<UsuarioEntity> ConsultarUsuarios()
        {
            ConsultarTodosRegistros registros = new ConsultarTodosRegistros();

            string resultadoJson = "";

            PreparaWebRequest("ConsultarTodosUsuarios", "GET");

            var response = (System.Net.HttpWebResponse)webRequest.GetResponse();

            using (var sr = new System.IO.StreamReader(response.GetResponseStream()))
            {

                resultadoJson = sr.ReadToEnd();

                registros = Deserialize<ConsultarTodosRegistros>(resultadoJson);
            }

            return registros.ConsultarTodosUsuariosResult;
        }

        /// ESSE MÉTODO VAI ATUALIZAR O REGISTRO INFORMADO
        /// <param name="usuarioEntity"></param>
        public string AtualizarRegistro(UsuarioEntity usuarioEntity)
        {
            PreparaWebRequest("AtualizarRegistro", "PUT");

            string jsonSerialize = this.Serialize<UsuarioEntity>(usuarioEntity);

            using (var streamWriter = new System.IO.StreamWriter(webRequest.GetRequestStream()))
            {
                streamWriter.Write(jsonSerialize);
                streamWriter.Flush();
                streamWriter.Close();
            }

            var response = (System.Net.HttpWebResponse)webRequest.GetResponse();

            string resultadoJson = null;

            using (var streamReader = new System.IO.StreamReader(response.GetResponseStream()))
                resultadoJson = streamReader.ReadToEnd();

            return resultadoJson.Replace(@"\", string.Empty).Replace("\"", string.Empty);
        }

        /// ESSE MÉTODO VAI EXCLUIR UM REGISTRO PELO CÓDIGO
        /// <param name="codigo"></param>
        public string ExcluirUsuario(int codigo)
        {
            PreparaWebRequest("ExcluirUsuario/" + codigo, "DELETE");

            var response = (System.Net.HttpWebResponse)webRequest.GetResponse();

            string resultadoJson = null;
            using (var streamReader = new System.IO.StreamReader(response.GetResponseStream()))
            {
                resultadoJson = streamReader.ReadToEnd();
            }

            return resultadoJson.Replace(@"\", string.Empty).Replace("\"", string.Empty);
        }
    }
}
