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

        public Peer()
        {
            dati = new DatiCondivisi();
            server = new Server(dati);
        }

        public void StartThread()
        {
            Thread t = new Thread(new ThreadStart(server.Ricevi));
            t.Start();
        }
    }
}
