using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace TetrisGame.GraficaTetris
{
    public class Q: Blocco
    {
        private Cella[][] blocchi = new Cella[][]
        {
            new Cella[]{new Cella(0,0), new Cella (0,1), new Cella(1,0), new Cella(1,1)}
        };


        public int id = 4;

        private Cella posizionePartenza = new Cella(0, 4);

        public Cella[][] GetPosizioni()
        {
            return blocchi;
        }
    }
}
