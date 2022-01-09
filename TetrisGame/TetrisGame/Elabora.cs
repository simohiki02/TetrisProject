using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Threading;
using static System.Net.Mime.MediaTypeNames;

namespace TetrisGame
{
    class Elabora
    {
        DatiCondivisi dati;
        public Elabora(DatiCondivisi dati)
        {
            this.dati = dati;
        }

        public void Esamina()
        {
            while(Pacchetto.connessione != 'c')
            {
                if(dati.GetSizeDaElaborare() > 0) //se sono presenti pacchetti
                {
                    dati.GetDaElaborare(); //rimuovo il pacchetto dalla lista

                    /*Versione precedente: durante l'esecuzione del gioco quando arrivava
                     * un pacchetto non entrava nel ciclo quindi nel caso di pacchetti game
                     * calcolo i campi direttamente nella classe "Server", per quello delli della
                     * connessione li calcolo qui

                    //Pacchetto p = dati.GetDaElaborare(); //prendo il pacchetto
                    //if (p.tipo == "g") //pacchetto game
                    //{
                    //    //variabili statiche della classe Game
                    //    //Game.righe = p.righe; //righe avversario
                    //    //Game.stato = p.stato; //stato gioco 
                    //}
                    //else //pacchetto connessione
                    //{ 
                    
                     */

                    char connection = Pacchetto.connessione; //controllo lo stato della connessione
                    switch (connection)
                    {
                        case 'a': //richiesta di connessione
                            //arrivandomi una richiesta il campo "nome" del pacchetto corrisponde al nome dell'avversario
                            Pacchetto.nomeAvversario = Pacchetto.nome; //mi salvo il nome dell'avversario
                            dati.mw.MessConnessione(Pacchetto.nomeAvversario); //visualizzo il po-up con il nome del mittente
                            break;
                        case 'y': //ho inviato la richiesta, il destinatario ha accettato
                            Pacchetto.nomeAvversario = Pacchetto.nome;
                            dati.mw.StartGame();
                            break;
                        case 'n': //ho inviato la richiesta, il destinatario non ha accettato
                            dati.mw.MessNoConnessione();
                            break;
                    }
                }
            }
        }
    }
}
