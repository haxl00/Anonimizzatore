using System.ComponentModel;
using System.Collections;

namespace Anonimizzatore.Model
{
    public class Comune
    {
        public virtual int id { get; private set; }
        public virtual int version { get; private set; }
        [Description("NN*Len:50")]
        public virtual string denominazione { get; set; }
        [Description("NN*Len:2")]
        public virtual string provincia { get; set; }
        [Description("NN*Len:4")]
        public virtual string codiceIstat { get; set; }

        /// <summary>
        /// Fornisce un elenco complessivo (mediante NHibernate) di tutti i comuni presenti in archivio
        /// </summary>
        /// <returns>ArrayList di elementi [Comune]</returns>
        public static ArrayList recuperaListaComuni()
        {
            return new ArrayList();
        }
    }
}
