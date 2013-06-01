using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Reactive.Linq;

namespace MetaFolder
{
    /// <summary>
    /// Abstracts the representation of resources in a given system
    /// </summary>
    public interface IRepository : IDisposable
    {
        Uri BaseUri { get; }

        IQbservable<Uri> Resources { get; }
        IQbservable<string> Tags { get; }
        IQbservable<IIndex> Indices { get; }

        IObservable<IResource> Get(IEnumerable<Uri> resources);
        IObservable<Uri> Post(IEnumerable<Uri> resources);
        IObservable<Uri> Post(IEnumerable<IResource> resources);
        IObservable<Uri> Delete(IEnumerable<Uri> resources);
    }
}
