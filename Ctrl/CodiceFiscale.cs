using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text.RegularExpressions;

using Anonimizzatore.Model;

namespace Anonimizzatore.Ctrl
{
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
        /// <returns></returns>
        public static string calcola(string nome, string cognome, DateTime data, SessoCF sesso, Comune comune)
        {
            return new String('X', 16);
        }        
    }
}
