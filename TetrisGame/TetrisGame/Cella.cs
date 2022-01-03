using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TetrisGame
{
    //classe per rappresentare la posizione della cella nella grid
    public class Cella
    {
        public int riga;
        public int colonna;
        public Cella(int riga, int colonna) //semplice costruttore con riga e colonna della cella
        {
            this.riga = riga;
            this.colonna = colonna;
        }
    }
}
