using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TetrisGame
{
    //classe che imposta il campo di gioco
    public class Grid
    {
        private int[,] campo;

        public int righe;
        public int colonne;

        public int GetRighe()
        {
            return righe;
        }

        public int GetColonne()
        {
            return colonne;
        }

        //costruttore
        public Grid(int righe, int colonne)
        {
            this.righe = righe;
            this.colonne = colonne;
            campo = new int[righe, colonne]; //inizializzazione matrice (grid)
        }

        //check se una cella della grid è vuota o no
        public bool IsEmpty(int r, int c)
        {
            bool vuota = false;
            if (IsInside(r, c) && campo[r, c] == 0) //check se è all'interno e per essere vuota riga e colonna = 0
            {
                vuota = true;
                return vuota;
            }
            else
            {
                return vuota;
            }
        }

        public bool IsInside(int r, int c)
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

        //check se una riga della grid è vuota
        public bool RigaVuota(int r)
        {
            for (int c = 0; c < colonne; c++)
            {
                if (campo[r, c] != 0) //se riga e colonna != 0 = riga vuota
                {
                    return false;
                }
            }
            return true;
        }

        //check se una riga della grid è piena
        public bool RigaPiena(int r)
        {
            for(int c = 0; c < colonne; c++) //scorro le colonne
            {
                if(campo[r, c] == 0) //se riga e colonna = 0 = riga piena
                {
                    return false;
                }
            }
            return true;
        }

        public void PulisciRiga(int r)
        {
            for (int c = 0; c < colonne; c++)
            {
                campo[r, c] = 0;
            }
        }

        //metodo per spostare una riga sotto di tot righe
        public void MuoviRiga(int r, int numeroRighe) //prendo la riga corrente, e le righe completate
        {
            for (int c = 0; c < colonne; c++) //per ogni colonna
            {
                campo[r + numeroRighe, c] = campo[r, c]; //alla riga corrente sommo quelle completate e assegno i valori di quella corrente
                campo[r, c] = 0; //svuoto la riga corrente
            }
        }

        //metodo per controllare le righe della grid
        public int CheckGrid()
        {
            int righeCompletate = 0; //contatore per le righe completate
            for (int r = righe - 1; r >= 0; r--) //partiamo dall'ultima riga della grid
            {
                if (RigaPiena(r) == true) //se la riga è piena
                {
                    PulisciRiga(r); //puliamo la riga
                    righeCompletate++; //incrementiamo le righe completate
                }
                else if (righeCompletate > 0) //se sono > 0
                {
                    MuoviRiga(r, righeCompletate); //muoviamo le righe in basso
                }
            }
            return righeCompletate;
        }
    }
}
