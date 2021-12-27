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
        public string nome, tipo; //nome del giocatore
        public static char connessione; //stato connessione
        
        public Pacchetto(string csv) //arriva un pacchetto, splitto i dati
        {
            string[] dati = csv.Split(';'); //splitto i dati
            if(dati[0] == "g") //se si tratta di un pacchetto game
            {
                tipo = "g"; //pacchetto game
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
