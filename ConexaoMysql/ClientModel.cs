using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConexaoMysql
{
      public struct ClientModel
    {

        public int id;
        public string name;
        public int cnh;
        
        public ClientModel(int _id, string _name,int _cnh)
        {

            id = _id;
            name = _name;
            cnh = _cnh;

        }

        public static List<string> GetOptions()
        {
            List<string> items = new List<string>
            {
                "Selecione",
                "Apollo",
                "Bravos",
                "DealerNet",
                "NBS",
                "Sercon",
                "Sisdia",
                "AutoPlus"
            };

            return items;
        }

        public string GetName(int id)
        {
            List<string> items = GetOptions();
            return items[id];
        }

        public int GetId(string name)
        {
            List<string> items = GetOptions();
            return items.IndexOf(name);
        }

    }
}
