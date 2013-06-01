using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace MetaFolder
{
    /// <summary>
    /// Abstracts the representation of resources in a given system
    /// </summary>
    public interface IRepresentation
    {
        string UriScheme { get; }
        IRepository Open(Uri repositoryUri);
        Uri Identify(IRepository repository, Stream content, int pass);
    }
}
