using System.Collections.Generic;
using System.Collections;
using System.Data;
using System;

using Anonimizzatore.Persistence;
using Anonimizzatore.Model;
using System.Linq;

namespace Anonimizzatore.Ctrl
{
    /// <summary>
    /// Classe Controller main del progetto
    /// </summary>
    class Controller
    {
        /// <summary>
        /// Acquisisce dal database di lavoro tutti i Dipendenti presenti e ne anonimizza (mediante selezione RND da elenchi generici) Cognome, Nome, Luogo di Nascita, Codice Fiscale
        /// </summary>
        public static void anonimizzaAnagraficheDipendenti()
        {
            const string ANONIM = "ZX";
            const string DB_COGNOMI_NOMI = "cognominomi";

            Hashtable connectionStringElement;
            DataTable tables;
            Dictionary<int, string> cognomi;
            Dictionary<int, string> nomi;
            Dictionary<int, string> sesso;
            ArrayList unique;

            IList comuni;
            IList dipendenti;

            Random _random = new Random();

            int nRand = 0;
            int nCognome;
            int nNome;
            int nComune;

            try
            {
                cognomi = new Dictionary<int, string>();
                nomi = new Dictionary<int, string>();
                sesso = new Dictionary<int, string>();
                unique = new ArrayList();

                connectionStringElement = new Hashtable();
                connectionStringElement["Database"] = DB_COGNOMI_NOMI;

                //Vengono eseguite query RAW per non dover sviluppare tutto il sistema NHibernate anche sul db di servizio e solo per queste due SELECT
                //In considerazione del tipo di query, non vi è alcun rischio di SQL Injection o problematiche affini
                tables = DbRawManager.eseguiRawQuery("SELECT id, cognome FROM cognomi ORDER BY cognome", connectionStringElement);
                foreach (DataRow r in tables.Rows)
                    cognomi[(int)r[0]] = (string)r[1];

                tables = DbRawManager.eseguiRawQuery("SELECT id, nome, sesso FROM nomi ORDER BY nome", connectionStringElement);
                foreach (DataRow r in tables.Rows)
                {
                    nomi[(int)r[0]] = (string)r[1];
                    sesso[(int)r[0]] = (string)r[2];    //M / F
                }

                comuni = Comune.recuperaListaComuni();
                dipendenti = Dipendente.recuperaListaDipendenti();

                if (dipendenti.Count > cognomi.Count * nomi.Count)
                    throw new Exception("Il numero di Dipendenti supera il totale delle anagrafiche univoche generabili");

                Comune comuneDefaultIstat = new Comune();
                comuneDefaultIstat.denominazione = "placeholder";
                comuneDefaultIstat.codiceIstat = "X001";

                using (PersistenceManager i_persistence = new PersistenceManager())
                {                    
                    while (nRand < dipendenti.Count)
                    {
                        Dipendente d = (Dipendente)dipendenti[nRand];
                        if (d.comuneNascita != null && d.comuneNascita.EndsWith(ANONIM))
                        {
                            nRand++;
                            continue;
                        }

                        nCognome = _random.Next(1, cognomi.Keys.Max() + 1);
                        nNome = _random.Next(1, nomi.Keys.Max() + 1);
                        nComune = _random.Next(1, comuni.Count);

                        if (!unique.Contains(nCognome + "|" + nNome))
                        {
                            d.cognome = cognomi[nCognome];
                            d.nome = nomi[nNome];
                            d.comuneNascita = ((Comune)comuni[nComune]).denominazione + ANONIM;
                            d.codiceFiscale = CodiceFiscale.calcola(d.nome, d.cognome, (d.dataNascita != null ? (DateTime)d.dataNascita : new DateTime(2021, 01, 01)), (sesso[nNome].CompareTo("M") == 0 ? CodiceFiscale.SessoCF.Maschio : CodiceFiscale.SessoCF.Femmina), comuneDefaultIstat);
                            i_persistence.modifica(d);
                            unique.Add(nCognome + "|" + nNome);
                            nRand++;
                        }
                    }
                }
            }
            catch (Exception e)
            {
                //LOG
                throw e;
            }
        }
    }
}