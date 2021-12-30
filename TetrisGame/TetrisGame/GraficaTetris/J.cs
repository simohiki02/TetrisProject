using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace TetrisGame.GraficaTetris
{
    class J
    {
        private static Color colorej = Colors.Violet;

        public int[,] pezzoJ = new int[2, 3] { { 1, 0, 0 }, { 1, 1, 1 } };
        //pezzo j girato di 90°

        public int[,] pezzoJ_90 = new int[3, 2] { { 1, 1 }, { 1, 0 }, { 1, 0 } };
        //pezzo j girato di 180°

        public int[,] pezzoJ_180 = new int[2, 3] { { 1, 1, 1 }, { 0, 0, 1 } };
        //pezzo j girato di 270°

        public int[,] pezzoJ_270 = new int[3, 2] { { 0, 1 }, { 0, 1 }, { 1, 1 } };
    }
}
