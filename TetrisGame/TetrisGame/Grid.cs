using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TetrisGame
{
    public class Grid
    {
        //classe che imposta il campo di gioco
        private int[,] campo;

        public int righe;
        public int colonne;

        public int getRighe()
        {
            return righe;
        }

        public int getColonne()
        {
            return colonne;
        }

        public Grid(int righe, int colonne)
        {
            this.righe = righe;
            this.colonne = colonne;
        }
    }
}
