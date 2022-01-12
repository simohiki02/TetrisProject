using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TetrisGame
{
    public class Gioco
    {
        private DatiCondivisi dati;
        private int punteggio = 0; //variabile temporanea per il punteggio
        private Blocco bloccoCorrente;
        public Grid CampoGioco { get; }
        public ListaBlocchi ListaBlocchi { get; }
        public bool GameOver { get; set; } 
        public int Score { get; set; }

        bool okMalus1 = false, okMalus2 = false; //servono nel caso in cui l'utente superi il punteggio necessario per l'invio del malus e quindi devono essere mandati solo una volta

        string p = ""; //pacchetto da inviare
        public Blocco BloccoCorrenteProp
        {
            get => bloccoCorrente;

            private set
            {
                bloccoCorrente = value;
                bloccoCorrente.Reset();

                //migliora la posizione iniziale dei blocchi, li fa apparire sempre dalla stessa riga e colonna
                for (int i = 0; i < 2; i++)
                {
                    bloccoCorrente.MuoviPezzo(1, 0);

                    if (!BloccoValido())
                    {
                        bloccoCorrente.MuoviPezzo(-1, 0);
                    }
                }
            }
        }

        public Gioco(object dati)
        {
            this.dati = dati as DatiCondivisi;
            this.CampoGioco = new Grid(22, 10); //inizializza la grid con 22 righe e 10 colonne
            this.ListaBlocchi = new ListaBlocchi(); //inizializza la lista dei blocchi
            BloccoCorrenteProp = ListaBlocchi.AggiornaBlocco(); //prendo il primo blocco
        }

        
        //metodo per posizionare il blocco all'interno della grid
        public void PosizionaBlocco()
        {
            //ad ogni pezzo del blocco corrente assegno l'id del pezzo corrispondente
            foreach(Cella c in BloccoCorrenteProp.PosizionePezzi())
            {
                CampoGioco[c.riga, c.colonna] = BloccoCorrenteProp.Id; 
            }
            //controlliamo se ci sono righe completate
            //e le aggiungiamo al punteggio che poi verrà visualizzato nella grafica
            //tramite la classe "Game"
            Score += CampoGioco.CheckRigheCompletate(); //il punteggio equivale al numero di righe completate
            if(Score != punteggio) //se non completo altre righe è inutile mandare pacchetti
            {
                //se completo 2 righe o le supero e non ho ancora raggiunto il malus successivo, mando il primo malus
                if (Score >= 2 && okMalus1 == false) 
                {
                    p = "g;0;" + Score + ";0";
                    okMalus1 = true;
                }
                    
                //se ne completo 3 mando il secondo malus
                //è inutile sviluppare il caso in cui l'utente ne completi direttamente 3
                //perchè i malus in termini di punteggio saranno distanziati di molto
                else if (Score >= 3 && okMalus2 == false)
                {
                    p = "g;0;" + Score + ";1";
                    okMalus2 = true;
                }
                else //se non c'è nessun malus invio semplicemente il punteggio 
                    p = "g;0;" + Score + ";-1"; //invio semplicemente il mio punteggio
                punteggio = Score;
                dati.AddDaInviare(p);
            }

            //controlliamo se l'utente ha perso
            if(IsGameOver() == true)
            {
                GameOver = true; //sentinella
            }
            else //altrimenti passo al prossimo blocco
            {
                BloccoCorrenteProp = ListaBlocchi.AggiornaBlocco();
            }
        }

        //metodo per controllare se l'utente ha perso
        public bool IsGameOver()
        {
            //se le prime due righe della grid non sono vuote l'utente ha perso
            return !(CampoGioco.RigaVuota(0) && CampoGioco.RigaVuota(1));
        }

        //metodo che verifica se il blocco è in una posizione valida
        //il blocco deve essere completamente all'interno della grid
        private bool BloccoValido()
        {
            //per ogni pezzo del blocco corrente 
            foreach (Cella c in BloccoCorrenteProp.PosizionePezzi())
            {
                //se uno dei pezzi del blocco è fuori dalla grid o si sovrappone a un altro non è valido 
                if (CampoGioco.IsEmpty(c.riga, c.colonna) == false)
                {
                    return false;
                }
            }
            return true;
        }

        //metodo per ruotare il blocco in senso orario
        public void RuotaBloccoOrario()
        {
            BloccoCorrenteProp.RuotaPezzoSensoOrario();
            //se il blocco non può essere ruotato perchè altrimenti andrebbe fuori dalla grid
            if (BloccoValido() == false) 
            {
                //lo ruotiamo nell'altro senso
                BloccoCorrenteProp.RuotaPezzoSensoAntiOrario();
            }
        }

        //metodo per ruotare il blocco in senso orario
        //operazioni inverse di quello orario
        public void RuotaBloccoAntiOrario()
        {
            BloccoCorrenteProp.RuotaPezzoSensoAntiOrario();
            if (BloccoValido() == false)
            {
                BloccoCorrenteProp.RuotaPezzoSensoOrario();
            }
        }

        //metodo per muovere il pezzo in basso
        public void MuoviInBasso()
        {
            //sommo semplicemente 1 alle righe del pezzo
            BloccoCorrenteProp.MuoviPezzo(1, 0);
            if (BloccoValido() == false) //se il pezzo esce dalla grid
            {
                //lo risposto in alto quindi sposto la riga indietro di 1
                BloccoCorrenteProp.MuoviPezzo(-1, 0);

                //e chiamo il blocco successivo dato che sono arrivato in fondo o ho colliso con un altro pezzo
                PosizionaBlocco();
            }
        }

        //metodo per muovere il pezzo a destra
        public void MuoviADestra()
        {
            //sommo semplicemente 1 alle colonne del pezzo
            BloccoCorrenteProp.MuoviPezzo(0, 1); 
            if (BloccoValido() == false) //se il pezzo esce dalla grid
            {
                //lo risposto indietro quindi sposto la colonna indietro di 1
                BloccoCorrenteProp.MuoviPezzo(0, -1);
            }
        }

        //metodo per muovere il pezzo a sinistra
        public void MuoviASinistra()
        {
            //sottraggo semplicemente 1 alle colonne del pezzo
            BloccoCorrenteProp.MuoviPezzo(0, -1);
            if (BloccoValido() == false) //se il pezzo esce dalla grid
            {
                //lo risposto avanti quindi sposto la colonna avanti di 1
                BloccoCorrenteProp.MuoviPezzo(0, 1);
            }
        }

        //metodo che prende la posizione di un blocco e ne ritorna le celle vuote immediatamente sotto di lui
        //in questo modo troviamo di quante celle verso il basso, può essere mosso il blocco
        
        private int NumCelleCaduta(Cella c)
        {
            int distanza = 0;
            while(CampoGioco.IsEmpty(c.riga + distanza + 1 , c.colonna))    
            {
                distanza++;
            }
            return distanza;
        }

        //metodo che richiama il NumCelleCaduta per ogni pezzo nel blocco corrente e controlla il valore minimo con l'apposita funzione Math
        public int DistanzaCadutaBlocco()
        {
            int distanza = CampoGioco.righe;
            foreach(Cella c in BloccoCorrenteProp.PosizionePezzi())
            {
                distanza = System.Math.Min(distanza, NumCelleCaduta(c));
            }
            return distanza;
        }

        //metodo che muove il blocco verso il basso di quante più righe possibile
        public void CadutaBlocco()
        {
            BloccoCorrenteProp.MuoviPezzo(DistanzaCadutaBlocco(), 0);
            PosizionaBlocco();
        }
    }
}
