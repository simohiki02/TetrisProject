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
            bloccoCorrente.reset();
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
            foreach (Cella c in bloccoCorrente.posizioneBlocchi())
            {
                if (!campoGioco.isEmpty(c.riga, c.colonna))
                {
                    return false;
                }
            }
            return true;
        }
        //metodi per ruotare il blocco



        public void muoviSinistra()
        {
            bloccoCorrente.muoviPezzo(0, -1);
            if (!bloccoValido())
            {
                bloccoCorrente.muoviPezzo(0, -1);
            }
        }

        public void muoviDestra()
        {
            bloccoCorrente.muoviPezzo(0, 1);
            if (!bloccoValido())
            {
                bloccoCorrente.muoviPezzo(0, 1);
            }
        }

        /*private bool giocoFinito()
        {
            bool perso = false;
            
        }*/

        public void muoviSotto()
        {
            bloccoCorrente.muoviPezzo(1, 0);
            if (!bloccoValido())
            {
                bloccoCorrente.muoviPezzo(-1, 0);
            }
        }
    }
}
