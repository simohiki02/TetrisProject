using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace TetrisGame
{
    //classe madre da cui erediteranno i blocchi
    public class Blocco
    {
        public int id; //inizialmente un id per distinguere i vari blocchi
        public Cella[][] pezzi; //posizione dei singoli pezzi dei blocchi nei 4 stati [riga][colonna]
        public Cella posizioneIniziale; //posizione iniziale del blocco all'interno della grid

        //valori fondamentali del blocco
        private int statoRotazione; //stato rotazione del blocco
        private Cella posizione; //posizione corrente del blocco

        public Blocco()
        {
            //nel costruttore assegnamo la posizione iniziale alla posizione corrente come prima posizione del blocco appunto
            posizione = new Cella(posizioneIniziale.riga, posizioneIniziale.colonna);
        }

        //metodo che ritorna le posizioni occupate dai blocchi
        //uso un enum perchè ho bisogno solo di leggere dalla raccolta
        public IEnumerable<Cella> PosizionePezzi() //restituisce un enum
        {
            foreach (Cella c in pezzi[statoRotazione]) //posizioni dei blocchi nello stato di rotazione corrente
            {
                //restituisco una nuova cella sommando le righe e le colonne della grid per arrivare alla matrice del blocco nella grid
                //yield: restituisce un'espressione alla volta e mantiene l'indice nell'iterazione per ripartire da li quando viene richiamato
                yield return new Cella(c.riga + posizione.riga, c.colonna + posizione.colonna);
            }
        }

        //metodo per muovere un pezzo di un numero di righe e colonne
        public void MuoviPezzo(int righe, int colonne)
        {
            posizione.riga += righe; //alla riga corrente del blocco sommo il numero di righe passate 
            posizione.colonna += colonne; //stessa cosa per le colonne
        }

        //rotazione pezzo in senso orario
        public void RuotaPezzoSensoOrario()
        {
            //passo allo stato di rotazione successivo --> (statoRotazione + 1)
            //e dividendolo per il numero degli stati dei blocchi quindi 4 
            //ottengo il resto che sarà sempre compreso tra 0 e 3
            //in questo modo se sono a uno stato di rotazione 4 tornerò al primo stato, 5 al secondo e cosi via...
            statoRotazione = (statoRotazione + 1) % pezzi.Length;
        }

        //rotazione pezzo in senso anti orario
        public void RuotaPezzoSensoAntiOrario()
        {
            if(statoRotazione == 0) //se sono al primo stato devo andare all'ultimo
            {
                statoRotazione = pezzi.Length - 1; //quindi assegno alla posizione corrente l'ultimo stato del blocco
            }
            else //se sono in un qualcunque altro stato
            {
                statoRotazione--; //vado a quello prima decrementando
            }
        }

        //metodo per resettare la posizione dei blocchi
        public void Reset()
        {
            //riporto la posizione del blocco allo stato iniziale
            posizione.riga = posizioneIniziale.riga; 
            posizione.colonna = posizioneIniziale.colonna;
            statoRotazione = 0; //riporto il blocco successivo al primo stato di rotazione quindi allo stato 0
        }
    }
}
