using System;

namespace Anonimizzatore.Persistence
{
    /// <summary>
    /// Gestore di persistenza ORM - Utilizza NHibernate
    /// </summary>
    public class PersistenceManager : IDisposable
    {
        /// <summary>
        /// Interfaccia IDisposable
        /// </summary>
        public void Dispose()
        {
            return;
        }

        /// <summary>
        /// Esegue aggiornamento di un oggetto su database mediante ORM
        /// </summary>
        /// <param name="oggetto">Oggetto generico da aggiornare - UPDATE</param>
        public void modifica(Object oggetto)
        {
            return;
        }
    }
}
