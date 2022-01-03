using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TetrisGame
{
    public class Cella
    {
        //classe per rappresentare la posizione nella grid
        public int riga;
        public int colonna;

        public Cella(int riga, int colonna)
        {
            this.riga = riga;
            this.colonna = colonna;
        }
    }
}
