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
        Client client; //inizializzo il client
        Server server; //inizializzo il server
        Elabora elabora; //inizializzo il thread per l'elaborazione dati

        Thread threadClient;
        Thread threadServer;
        Thread threadElabora;
        public Peer(DatiCondivisi dati)
        {
            this.dati = dati;
            client = new Client(dati);
            server = new Server(dati);
            elabora = new Elabora(dati);
        }

        public void StartThread()
        {
            threadClient = new Thread(new ThreadStart(client.Invia));
            threadClient.Start();
            threadServer = new Thread(new ThreadStart(server.Ricevi));
            threadServer.Start();
            threadElabora = new Thread(new ThreadStart(elabora.Esamina));
            threadElabora.Start();
        }

        public void StopThread() //fermo i thread
        {
            threadClient.Abort();
            threadServer.Abort();
            threadElabora.Abort();
        }
    }
}
