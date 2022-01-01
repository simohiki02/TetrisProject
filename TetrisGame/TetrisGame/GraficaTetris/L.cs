using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace TetrisGame.GraficaTetris
{
    public class L: Blocco
    {
        private static Color coloreL = Colors.Red;

        public int[,] pezzoL = new int[2, 3] { { 0, 0, 1 }, { 1, 1, 1 } };
        //pezzo l girato di 90°

        public int[,] pezzoL_90 = new int[3, 2] { { 1, 0 }, { 1, 0 }, { 1, 1 } };
        //pezzo l girato di 180°

        public int[,] pezzoL_180 = new int[2, 3] { { 1, 1, 1 }, { 1, 0, 0 } };
        //pezzo l girato di 270°

        public int[,] pezzoL_270 = new int[3, 2] { { 1, 1 }, { 0, 1 }, { 0, 1 } };
    }
}
