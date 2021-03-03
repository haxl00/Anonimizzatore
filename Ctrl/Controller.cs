using System.Collections.Generic;
using System.Collections;
using System.Data;
using System;

using Anonimizzatore.Persistence;
using Anonimizzatore.Model;
using System.Linq;

namespace Anonimizzatore.Ctrl
{
    class Controller
    {
        public static void anonimizzaAnagraficheDipendenti()
        {
            const string ANONIM = "ZX";
            const string DB_COGNOMI_NOMI = "cognominomi";

            Hashtable connectionStringElement;
            DataTable tables;
            Dictionary<int, string> cognomi;
            Dictionary<int, string> nomi;
            Dictionary<int, string> sesso;
            Dictionary<string, string> unique;

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
                unique = new Dictionary<string, string>();

                connectionStringElement = new Hashtable();
                connectionStringElement["Database"] = DB_COGNOMI_NOMI;

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

                        if (!unique.Keys.Contains<string>(nCognome + "|" + nNome))
                        {
                            d.cognome = cognomi[nCognome];
                            d.nome = nomi[nNome];
                            d.comuneNascita = ((Comune)comuni[nComune]).denominazione + ANONIM;
                            d.codiceFiscale = CodiceFiscale.calcola(d.nome, d.cognome, (d.dataNascita != null ? (DateTime)d.dataNascita : new DateTime(2021, 01, 01)), (sesso[nNome].CompareTo("M") == 0 ? CodiceFiscale.SessoCF.Maschio : CodiceFiscale.SessoCF.Femmina), comuneDefaultIstat);
                            i_persistence.modifica(d);
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