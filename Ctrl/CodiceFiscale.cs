using System;

using Anonimizzatore.Model;

namespace Anonimizzatore.Ctrl
{
    /// <summary>
    /// Classe per la gestione (produzione/verifica) dei Codici fiscali secondo la codifica italiana
    /// </summary>
    class CodiceFiscale
    {
        public enum SessoCF { Maschio, Femmina }

        /// <summary>
        /// Calcola il codice fiscale a partire dai parametri inseriti
        /// </summary>
        /// <param name="nome"></param>
        /// <param name="cognome"></param>
        /// <param name="data"></param>
        /// <param name="sesso"></param>
        /// <param name="comune"></param>
        /// <returns>Restituisce la stringa del Codice fiscale calcolato sulla base dei parametri inseriti</returns>
        public static string calcola(string nome, string cognome, DateTime data, SessoCF sesso, Comune comune)
        {
            return new String('X', 16);
        }        
    }
}
