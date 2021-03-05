using System.Data;
using System.Collections;

namespace Anonimizzatore.Persistence
{
    /// <summary>
    /// Gestore di persistenza RAW - Non utilizza ORM
    /// </summary>
    public class DbRawManager
    {
        /// <summary>
        /// Esegue sul database di lavoro una query RAW (senza ORM intermedi)
        /// </summary>
        /// <param name="querySql">Query RAW da eseguire sul db senza ORM intermedi</param>
        /// <param name="connectionStringElement">Se presente, modifica alcuni elementi della connection string</param>
        /// <returns></returns>
        public static DataTable eseguiRawQuery(string querySql, Hashtable connectionStringElement = null)
        {
            return new DataTable();
        }
    }
}
