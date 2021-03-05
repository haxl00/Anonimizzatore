using System;
using System.ComponentModel;
using System.Collections;

namespace Anonimizzatore.Model
{
	public class Dipendente
    {
        public enum Sesso { ND = 0, Maschio = 1, Femmina = 2 }

        public virtual int id { get; private set; } 
		public virtual int version { get; private set; } 
		[Description("CRYPT*NN*Len:50")]
        public virtual string cognome { get; set; }
		[Description("CRYPT*NN*Len:50")]
        public virtual string nome { get; set; }
		[Description("CRYPT*NN*Len:16")]
        public virtual string codiceFiscale { get; set; }
        [Description("DAT*Len:10")]
        public virtual DateTime? dataNascita { get; set; }
        [Description("Len:1")]
        public virtual Sesso sesso { get; set; }
		[Description("CRYPT*Len:50")]
        public virtual string comuneNascita { get; set; }
		[Description("Len:2")]
		public virtual string provinciaNascita { get; set; }
		[Description("Len:50")]
		public virtual string statoNascita { get; set; }
        [Description("Len:50")]
        public virtual string nazionalita { get; set; }

        /// <summary>
        /// Overriding
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return this.cognome + " " + this.nome + " [" + this.codiceFiscale + "]";
        }

        /// <summary>
        /// Fornisce un elenco complessivo (mediante NHibernate) di tutti i dipendenti presenti in archivio
        /// </summary>
        /// <returns>ArrayList di elementi [Dipendente]</returns>
        public static ArrayList recuperaListaDipendenti()
        {
            return new ArrayList();
        }
    }
}
