using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;


namespace TetrisGame
{
    public class Blocco
    {
        //array contenente i pezzi
        //string[] arrayTetrominos = { "", "pezzoQ", "pezzoI", "pezzoT", "pezzoS", "pezzoZ", "pezzoJ", "pezzoL" };

        //array contenente le rotazioni dei pezzi
        private Cella[][] blocchi;
        public Cella posizioneIniziale;

        //array contenente i colori dei pezzi
        //Color[] shapeColor = { coloreQ,coloreI,coloreT,coloreS,coloreZ,coloreJ,coloreL};

        //id per distinguere i vari blocchi
        public int id;

        //valori per determinare posizioni dei pezzi
        private int statoRotazione;
        private Cella posizione;

        //costruttore da definire classe per posizione 
        public Blocco()
        {
            posizione = new Cella(posizioneIniziale.riga, posizioneIniziale.colonna);
        }

        //metodo che ritorna le posizioni occupate dai blocchi
        public Cella posizioneBlocchi()
        {
            foreach (Cella c in blocchi[statoRotazione])
            {

                return new Cella(c.riga + posizione.riga, c.colonna + posizione.colonna);
            }
        }

        //metodo per resettare posizioni dei blocchi
        public void reset()
        {
            statoRotazione = 0;
            posizione.riga = posizioneIniziale.riga;
            posizione.colonna = posizioneIniziale.colonna;

        }

        //metodo per rotazione dei pezzi
        public void ruotaPezzo()
        {
            statoRotazione = statoRotazione + 1;
        }

        //metodo per muovere un pezzo di un numero di righe e colonne
        public void muoviPezzo(int righe, int colonne)
        {
            posizione.riga += righe;
            posizione.colonna += colonne;
        }
    }
}
