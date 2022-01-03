using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TetrisGame
{
    public class Gioco
    {
        private Blocco bloccoCorrente;
        public Grid campoGioco;
        public ListaBlocchi listaBlocchi;
        public bool gameOver;

        public Blocco getBlocco()
        {
            return bloccoCorrente;
        }

        public void setBlocco()
        {
            bloccoCorrente.Reset();
        }

        public Grid getCampoGioco()
        {
            return campoGioco;
        }

        public ListaBlocchi getListaBlocchi()
        {
            return listaBlocchi;
        }

        public Gioco()
        {
            this.campoGioco = new Grid(22, 10);
            this.listaBlocchi = new ListaBlocchi();
            this.bloccoCorrente = listaBlocchi.aggiornaBlocco();
        }

        //metodo che verifica se il blocco è in una posizione valida
        private bool bloccoValido()
        {
            foreach (Cella c in bloccoCorrente.PosizioneBlocchi())
            {
                if (!campoGioco.IsEmpty(c.riga, c.colonna))
                {
                    return false;
                }
            }
            return true;
        }
        //metodi per ruotare il blocco



        public void muoviSinistra()
        {
            bloccoCorrente.MuoviPezzo(0, -1);
            if (!bloccoValido())
            {
                bloccoCorrente.MuoviPezzo(0, -1);
            }
        }

        public void muoviDestra()
        {
            bloccoCorrente.MuoviPezzo(0, 1);
            if (!bloccoValido())
            {
                bloccoCorrente.MuoviPezzo(0, 1);
            }
        }

        /*private bool giocoFinito()
        {
            bool perso = false;
            
        }*/

        public void muoviSotto()
        {
            bloccoCorrente.MuoviPezzo(1, 0);
            if (!bloccoValido())
            {
                bloccoCorrente.MuoviPezzo(-1, 0);
            }
        }
    }
}
