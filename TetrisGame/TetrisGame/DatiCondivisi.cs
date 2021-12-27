using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TetrisGame
{
    class DatiCondivisi
    {
        private List<Pacchetto> DaElaborare; //lista pacchetti da elaborare
        private List<string> DaInviare; //lista pacchetti da inviare

        public DatiCondivisi()
        {
            DaElaborare = new List<Pacchetto>();
            DaInviare = new List<string>();
        }

        public void addDaElaborare(Pacchetto p) //aggiungo il pacchetto da elaborare
        {
            DaElaborare.Add(p);
        }

        public Pacchetto getDaElaborare() //prendo il pacchetto da elaborare
        {
            Pacchetto p = DaElaborare[DaElaborare.Count - 1]; //prendo l'ultimo pacchetto
            DaElaborare.RemoveAt(DaElaborare.Count - 1); //lo rimuovo dalla lista
            return p;
        }

        public int getSizeDaElaborare() //mi restituisce il n degli elementi della lista
        {
            return DaElaborare.Count;
        }

        public void addDaInviare(string p) //aggiungo il pacchetto da inviare
        {
            DaInviare.Add(p);
        }

        public string getDaInviare() //prendo il pacchetto da inviare
        {
            string p = DaInviare[DaInviare.Count - 1]; //prendo l'ultimo pacchetto
            DaInviare.RemoveAt(DaInviare.Count - 1); //lo rimuovo dalla lista
            return p;
        }

        public int getSizeDaInviare() //mi restituisce il n degli elementi della lista
        {
            return DaInviare.Count;
        }
    }
}
