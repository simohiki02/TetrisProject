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
                        if (Pacchetto.connessione == 'a') //se arriva una richiesta di connessione
                            MainWindow.MessConnessione(p.nome);
                    }
                }
            }
        }
    }
}
