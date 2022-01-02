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
        private int[,] campo { get; set; }

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
            campo = new int[righe, colonne];
        }

        public bool isInside(int r, int c)
        {
            bool valida = false;
            if(r >= 0 && r < righe && c >= 0 && c < colonne)
            {
                valida = true;
                return valida;
            }
            else
            {
                return valida;
            }

        }

        public bool isEmpty(int r, int c)
        {
            bool vuota = false;
            if(isInside(r,c) && campo[r,c] == 0)
            {
                vuota = true;
                return vuota;
            }
            else
            {
                return vuota;
            }
        }

        public bool rigaPiena(int r)
        {
            for(int c = 0; c < colonne; c++)
            {
                if(campo[r, c] == 0)
                {
                    return false;
                }
            }
            return true;
        }

        public bool rigaVuota(int r)
        {
            for (int c = 0; c < colonne; c++)
            {
                if (campo[r, c] != 0)
                {
                    return false;
                }
            }
            return true;
        }

        public void pulisciRiga(int r)
        {
            for (int c = 0; c < colonne; c++)
            {
                campo[r, c] = 0;
            }
        }
        //metodo per spostare di tot righe sotto una riga
        public void muoviRiga(int r, int numeroRighe)
        {

        }
    }
}
