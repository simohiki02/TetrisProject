using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TetrisGame.GraficaTetris;

namespace TetrisGame
{
    public class ListaBlocchi
    {
        //classe necessaria a scegliere random il blocco successivo
        private Blocco[] blocchi = new Blocco[]
        {
            new T(),
            new Z(),
            new S(),
            new J(),
            new I(),
            new L(),
            new Q(),
        };
        public Blocco prossimoBlocco { get; set; } //property per il blocco successivo

        //oggetto random per prendere un blocco casuale
        private Random random = new Random();
        
        //metodo per prendere un blocco random dal vettore
        private Blocco BloccoRandom()
        {
            return blocchi[random.Next(blocchi.Length)];
        }

        //il costruttore assegna semplicemente il blocco estratto dal vettore
        public ListaBlocchi()
        {
            prossimoBlocco = BloccoRandom();
        }

        //metodo che aggiorna il prossimo blocco scelto
        public Blocco AggiornaBlocco()
        {
            Blocco b = prossimoBlocco;
            //il ciclo estrae un blocco il cui id deve essere diverso da quello appena estratto
            do{ prossimoBlocco = BloccoRandom(); }
            while (b.id == prossimoBlocco.id);
            return b;
        }
    }
}
