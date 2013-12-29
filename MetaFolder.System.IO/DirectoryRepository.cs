using System;
using System.Collections.Generic;
using System.Linq;
using System.Reactive;
using System.Text;

namespace MetaFolder.System.IO
{
    public class DirectoryRepository : Repository, IRepository
    {
        internal DirectoryRepository(Uri uri) : base(uri)
        {

        }

        public override IObservable<IIdentifiable> Get(IEnumerable<Uri> uris)
        {
            throw new NotImplementedException();
        }

        public override IObservable<Unit> Put(IEnumerable<IIdentifiable> uris)
        {
            throw new NotImplementedException();
        }

        public override IObservable<Unit> Patch(IEnumerable<IIdentifiable> uris)
        {
            throw new NotImplementedException();
        }

        public override IObservable<Unit> Delete(IEnumerable<Uri> uris)
        {
            throw new NotImplementedException();
        }
    }
}
