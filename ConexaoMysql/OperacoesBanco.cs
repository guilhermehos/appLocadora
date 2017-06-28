using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MySql.Data.MySqlClient;

namespace ConexaoMysql
{
    public class OperacaoBanco
    {
        private MySqlCommand TemplateMethod(String query)
        {
            MySqlConnection Conexao = ConexaoBancoMySQL.getConexao();
            MySqlCommand Commando = new MySqlCommand(query, Conexao);
            try
            {
                Commando.ExecuteNonQuery();
                return Commando;
            }
            catch
            {
                return Commando;
            }
        }

        public MySqlDataReader Select(String query)
        {
            MySqlDataReader dadosObtidos = TemplateMethod(query).ExecuteReader();
            return dadosObtidos;
        }

        public Boolean Insert(String query)
        {
            MySqlConnection Conexao = ConexaoBancoMySQL.getConexao();
            MySqlCommand Commando = new MySqlCommand(query, Conexao);
            try
            {
                Commando.ExecuteNonQuery();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public Boolean Update(String query)
        {
            MySqlConnection Conexao = ConexaoBancoMySQL.getConexao();
            MySqlCommand Commando = new MySqlCommand(query, Conexao);
            try
            {
                Commando.ExecuteNonQuery();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public Boolean Delete(String query)
        {
            MySqlConnection Conexao = ConexaoBancoMySQL.getConexao();
            MySqlCommand Commando = new MySqlCommand(query, Conexao);
            try
            {
                Commando.ExecuteNonQuery();
                return true;
            }
            catch
            {
                return false;
            }
        }

    }
}
