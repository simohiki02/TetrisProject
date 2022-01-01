using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;


namespace TetrisGame
{
    public class Blocco
    {
        //array contenente i pezzi
        string[] arrayTetrominos = { "", "pezzoQ", "pezzoI", "pezzoT", "pezzoS", "pezzoZ", "pezzoJ", "pezzoL" };

        //array contenente le rotazioni dei pezzi
        int[] posizioni;

        //array contenente i colori dei pezzi
        //Color[] shapeColor = { coloreQ,coloreI,coloreT,coloreS,coloreZ,coloreJ,coloreL};

        //id per distinguere i vari blocchi
        public int id;

        //valori per determinare posizioni dei pezzi
        private int statoRotazione;
        private int posizionePartenza;
        private int posizioneCorrente;

        //costruttore da definire classe per posizione 
        public Blocco()
        {
            posizioneCorrente = posizionePartenza;
        }

        //metodo per resettare posizioni dei blocchi
        public void reset()
        {
            statoRotazione = 0;
            posizionePartenza = 0;

        }

        //metodo per rotazione dei pezzi


        //metodo per muovere un pezzo di un numero di righe e colonne
    }
}
