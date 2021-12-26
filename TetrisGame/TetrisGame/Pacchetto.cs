using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TetrisGame
{
    class Pacchetto
    {
        public int stato, righe, malus; //stato del gioco, righe risolte, malus
        public  String nome; //nome del giocatore
        public char connessione; //stato connessione
        
        public Pacchetto(String csv) //arriva un pacchetto, lo devo splittare
        {
            String[] dati = csv.Split(';'); //splitto i dati
            if(dati[0] == "g") //se si tratta di un pacchetto game
            {
                stato = int.Parse(dati[1]); //salvo lo stato del gioco
                righe = int.Parse(dati[2]); //salvo le righe
                malus = int.Parse(dati[3]); //salvo il malus 
            }
            else
            {
                connessione = char.Parse(dati[0]); //stato connessione
                nome = dati[1]; //nome 
            }
        }
    }
}
