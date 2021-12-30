using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace TetrisGame.GraficaTetris
{
    class S
    {
        private static Color coloreS = Colors.Green;

        public int[,] pezzoS = new int[2, 3] { { 0, 1, 1 }, { 1, 1, 0 } };
        //pezzo s girato di 90°

        public int[,] pezzoS_90 = new int[3, 2] { { 1, 0 }, { 1, 1 }, { 0, 1 } };
    }
}
