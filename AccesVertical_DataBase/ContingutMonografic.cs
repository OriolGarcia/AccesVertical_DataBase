using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccesVertical_DataBase
{
    class ContingutMonografic
    {
        string Contingutid;
        
        public string titol { get; set; }
        public string subtitols { get; set; }
        public string TipusModul { get; set; }
       
       public ContingutMonografic(string Contingutid, string titol, string subtitols, string TipusModul)
        {
            this.Contingutid = Contingutid;
            this.titol = titol;
            this.subtitols = subtitols;
            this.TipusModul = TipusModul;


        }
     
    }
}
