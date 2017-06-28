using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MySql.Data.MySqlClient;

namespace ConexaoMysql
{
    public class ConexaoBancoMySQL
    {
        private static MySqlConnection objConexao = null;

        // string mysql acessa o banco do servidor de hospedagem
        private String stringconnection1 ="server=mysqlghos.mysql.database.azure.com;User Id=ghos@mysqlghos;password=gui!@#$395778;database=appLocadora";

        //string mysql rodando na maquina do desenvolvedor.
        private String stringconnection2 = "server=localhost;User Id = seuid; password=suasenha;database=suainstancialocalmysql";

        #region metodos que tentam abrir conexao com projeto rodando local ou hospedado

        public void tentarAbrirConexaoLocal()
        {
            objConexao = new MySqlConnection();
            objConexao.ConnectionString = stringconnection2;
            objConexao.Open();
        }

        public void tentarAbrirConexaoRemota()
        {
            objConexao = new MySqlConnection();
            objConexao.ConnectionString = stringconnection1;
            objConexao.Open();
        }
        #endregion

        public ConexaoBancoMySQL()
        {
            try
            {
                tentarAbrirConexaoRemota();
            }
            catch (Exception e)
            {
                
                try
                {
                    tentarAbrirConexaoLocal();
                }
                catch
                {
                    Console.WriteLine("Não foi possível validar seu acesso.Tente novamente.");

                    // Você pode substituir esta notificação por qualquer outra coisa que faça o mesmo que o metodo console.whiteline
                }
            }

        }

        public static MySqlConnection getConexao()
        {
            new ConexaoBancoMySQL();
            return objConexao;
        }
        public static void fecharConexao()
        {
            objConexao.Close();
        }
    }
}

