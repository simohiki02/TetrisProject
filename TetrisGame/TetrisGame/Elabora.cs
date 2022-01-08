using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
                    Pacchetto p = dati.GetDaElaborare(); //prendo il pacchetto
                    if(p.tipo == "g") //pacchetto game
                    {

                    }
                    else //pacchetto connessione
                    {
                        char connection = Pacchetto.connessione; //controllo lo stato della connessione
                        switch(connection)
                        {
                            case 'a': //richiesta di connessione
                                //arrivandomi una richiesta il campo "nome" del pacchetto corrisponde al nome dell'avversario
                                Pacchetto.nomeAvversario = Pacchetto.nome; //mi salvo il nome dell'avversario
                                MainWindow.MessConnessione(Pacchetto.nomeAvversario); //visualizzo il po-up con il nome del mittente
                                break;
                            case 'y': //ho inviato la richiesta, il destinatario ha accettato
                                Pacchetto.nomeAvversario = Pacchetto.nome;
                                MainWindow.StartGame();
                                break;
                            case 'n': //ho inviato la richiesta, il destinatario non ha accettato
                                MainWindow.MessNoConnessione();
                                break;
                        }
                    }
                }
            }
        }
    }
}
