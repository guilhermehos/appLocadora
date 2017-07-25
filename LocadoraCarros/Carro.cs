using System;

namespace AppLocadora
{
    [Serializable]
    public class Carro
    {
        public int Id;
        public string Fabricante;
        public string Modelo;
        public int Ano;
        public string Categoria;
        public bool TemCDPlayer;
        public bool TemDVDPlayer;
        public bool EstaDisponivel;
        public string Placa;

        public Carro()
        {
            Id = 0;
            Fabricante = "";
            Modelo = "";
            Ano = 0;
            Categoria = "";
            TemCDPlayer = false;
            TemDVDPlayer = false;
            EstaDisponivel = false;
            Placa = "";
        }

        public Carro(string fb, string mdl,
                   int an, string cat, bool cd,
                   bool dvd, bool disp, string plate)
        {
            Fabricante = fb;
            Modelo = mdl;
            Ano = an;
            Categoria = cat;
            TemCDPlayer = cd;
            TemDVDPlayer = dvd;
            EstaDisponivel = disp;
            Placa = plate;
           
        }
    }
}
