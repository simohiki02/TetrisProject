using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace TetrisGame.GraficaTetris
{
    public class I : Blocco
    {
        //matrice contenente vettori di posizioni per tutti i pezzi
        protected override Cella[][] Pezzi => new Cella[][]
        {
           new Cella[]  { new Cella (1,0), new Cella(1,1), new Cella(1,2), new Cella (1,3) },
           new Cella[]  {new Cella(0,2), new Cella(1,2), new Cella(2,2), new Cella(3,2)},
           new Cella[]  { new Cella(2,0),new Cella(2,1), new Cella(2,2), new Cella(2,3)},
           new Cella[]  { new Cella(0,1),new Cella(1,1), new Cella(2,1), new Cella(3,1) }
        };
        public override int Id => 1;
        protected override Cella PosizioneIniziale => new Cella(-1, 3);
    }
}
