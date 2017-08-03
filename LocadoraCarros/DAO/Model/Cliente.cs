using System;

namespace AppLocadora
{
    [Serializable]
    public class Cliente
    {
        public int Id;
        public string Nome;
        public string Endereco;
        public string Cidade;
        public string Estado;
        public string CodigoPostal;
        public string CNH;
        public string Pais;
        public string Telefone;

        public Cliente()
        {
            Id = 0;
            Nome = "";
            Endereco = "";
            Cidade = "";
            Estado = "";
            CodigoPostal = "";
            CNH = "";
            Pais = "";
            Telefone = "";
        }

        // define o cliente
        public Cliente(string fNome,
                        string end, string cid,
                        string est, string cep)
        {
            Nome = fNome;
            Endereco = end;
            Cidade = cid;
            Estado = est;
            CodigoPostal = cep;
        }
    }
}
