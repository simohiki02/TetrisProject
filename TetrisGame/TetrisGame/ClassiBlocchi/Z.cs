using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace TetrisGame.GraficaTetris
{
    public class Z: Blocco
    {
        protected override Cella PosizioneIniziale => new Cella(0, 3);
        public override int Id => 7;
        protected override Cella[][] Pezzi => new Cella[][]
        {
           new Cella[]  { new Cella (0,0), new Cella(0,1), new Cella(1,1), new Cella (1,2) },
           new Cella[]  {new Cella(0,2), new Cella(1,1), new Cella(1,2), new Cella(2,1)},
           new Cella[]  { new Cella(1,0),new Cella(1,1), new Cella(2,1), new Cella(2,2)},
           new Cella[]  { new Cella(0,1),new Cella(1,0), new Cella(1,1), new Cella(2,0) }
        };  
    }
}
