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
        /// <param name="obj"></param>
        /// <returns></returns>
        public override bool Equals(System.Object obj)
        {
            if (obj == null)
                return false;

            Dipendente x = obj as Dipendente;
            if ((System.Object)x == null)
                return false;

            return id == x.id;
        }

        /// <summary>
        /// Overriding
        /// </summary>
        /// <returns></returns>
        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        /// <summary>
        /// Overriding
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            string res;
            res = this.cognome + " " + this.nome;
            res += " " + this.codiceFiscale;
            return res;
        }

        /// <summary>
        /// Compara dipendenti sulla base del loro valore stringa
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public virtual int CompareTo(object obj)
        {
            if (obj == null)
                return 0;

            Dipendente x = obj as Dipendente;
            if ((System.Object)x == null)
                return 0;

            return this.ToString().CompareTo(((Dipendente)obj).ToString());
        }

        /// <summary>
        /// Fornisce un elenco complessivo (mediante NHibernate) di tutti i dipendenti presenti in archivio
        /// </summary>
        /// <returns>ArrayList di dipendenti</returns>
        public static ArrayList recuperaListaDipendenti()
        {
            return new ArrayList();
        }
    }
}
