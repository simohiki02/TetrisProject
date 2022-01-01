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
        private static Color coloreI = Colors.Orange;

        int[,] pezzoI = new int[2, 4] { { 1, 1, 1, 1 }, { 0, 0, 0, 0 } };
        //pezzo i girato di 90°
        public int[,] pezzoI_90 = new int[4, 2] { { 1, 0 }, { 1, 0 }, { 1, 0 }, { 1, 0 } };

    }
}
