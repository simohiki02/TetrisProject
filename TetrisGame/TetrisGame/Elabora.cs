using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
                if(dati.getSizeDaElaborare() > 0) //se sono presenti pacchetti
                {
                    Pacchetto p = dati.getDaElaborare(); //prendo il pacchetto
                    if(p.tipo == "g") //pacchetto game
                    {

                    }
                    else //pacchetto connessione
                    {
                        char connection = Pacchetto.connessione; //controllo lo stato della connessione
                        switch(connection)
                        {
                            case 'a': //richiesta di connessione
                                MainWindow.MessConnessione(p.nome); //visualizzo il po-up con il nome del mittente
                                break;
                            case 'y': //ho inviato la richiesta, il destinatario ha accettato
                                Game game = new Game();
                                game.ShowDialog(); //apro la finestra del gioco
                                break;
                        }
                    }
                }
            }
        }
    }
}
