using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace TetrisGame.GraficaTetris
{
    public class T: Blocco
    {
        private static Color coloreT = Colors.LightSeaGreen;

        public int[,] pezzoT = new int[2, 3] { { 0, 1, 0 }, { 1, 1, 1 } };
        //pezzo t girato di 90°

        public int[,] pezzoT_90 = new int[3, 2] { { 1, 0 }, { 1, 1 }, { 1, 0 } };
        //pezzo t girato di 180°

        public int[,] pezzoT_180 = new int[2, 3] { { 1, 1, 1 }, { 0, 1, 0 } };
        //pezzo t girato di 270°

        public int[,] pezzoT_270 = new int[3, 2] { { 0, 1 }, { 1, 1 }, { 0, 1 } };
    }
}
