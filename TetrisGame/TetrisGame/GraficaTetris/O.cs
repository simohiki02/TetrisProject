using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace TetrisGame.GraficaTetris
{
    public class O: Blocco
    {
        protected override Cella PosizioneIniziale => new Cella(0, 4);
        public override int Id => 4;
        protected override Cella[][] Pezzi => new Cella[][]
        {
            new Cella[]{new Cella(0,0), new Cella (0,1), new Cella(1,0), new Cella(1,1)}
        };
        
    }
}
