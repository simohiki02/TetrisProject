using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace TetrisGame.GraficaTetris
{
    class Z
    {
        private static Color coloreZ = Colors.DeepSkyBlue;

        public int[,] pezzoZ = new int[2, 3] { { 1, 1, 0 }, { 0, 1, 1 } };
        //pezzo z girato di 90°

        public int[,] pezzoZ_90 = new int[3, 2] { { 0, 1 }, { 1, 1 }, { 1, 0 } };
    }
}
