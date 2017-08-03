using System;

namespace AppLocadora
{
    [Serializable]
    public class Empregado
    {
        public int Id;
        public string PrimeiroNome;
        public string SobreNome;
        public string Titulo;
        public double SalarioPorHora;
        public string Codigo;

        public string Nome
        {
            get { return SobreNome + ", " + PrimeiroNome; }
        }

        public Empregado()
        {
            Id = 0;
            PrimeiroNome = "Desconhecido";
            SobreNome = "Desconhecido";
            Titulo = "N/A";
            SalarioPorHora = 0.00;
            Codigo = "";
        }

        // construtor define um empregado
        public Empregado(string fname, string lname,
                        string title, double salary)
        {
            PrimeiroNome = fname;
            SobreNome = lname;
            Titulo = title;
            SalarioPorHora = salary;
        }
    }
}
