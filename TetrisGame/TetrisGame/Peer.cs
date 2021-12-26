using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace TetrisGame
{
    class Peer
    {
        DatiCondivisi dati; //inizializzo i dati condivisi
        Server server; //inizializzo il server
        Elabora elabora; //inizializzo il thread per l'elaborazione dati
        public Peer(DatiCondivisi dati)
        {
            this.dati = dati;
            server = new Server(dati);
            elabora = new Elabora(dati);
        }

        public void StartThread()
        {
            Thread threadServer = new Thread(new ThreadStart(server.Ricevi));
            threadServer.Start();
            Thread threadElabora = new Thread(new ThreadStart(elabora.Esamina));
            threadElabora.Start();
        }
    }
}
