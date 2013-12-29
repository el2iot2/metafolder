using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Reactive.Linq;
using System.Reactive;

namespace MetaFolder
{
    /// <summary>
    /// Abstracts the representation of resources in a given system
    /// </summary>
    public interface IRepository : IIdentifiable
    {
        IObservable<IIdentifiable> Get(IEnumerable<Uri> uris);
        IObservable<Unit> Put(IEnumerable<IIdentifiable> uris);
        IObservable<Unit> Patch(IEnumerable<IIdentifiable> uris);
        IObservable<Unit> Delete(IEnumerable<Uri> uris);
    }

    public abstract class Repository : Identifiable, IRepository
    {
        protected Repository(Uri uri) : base(uri)
        {
            if (!uri.IsAbsoluteUri)
            {
                throw new ArgumentException("URI should be absolute", "uri");
            }
        }

        public abstract IObservable<IIdentifiable> Get(IEnumerable<Uri> uris);

        public abstract IObservable<Unit> Put(IEnumerable<IIdentifiable> uris);

        public abstract IObservable<Unit> Patch(IEnumerable<IIdentifiable> uris);

        public abstract IObservable<Unit> Delete(IEnumerable<Uri> uris);
    }
}
