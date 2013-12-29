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
    public interface IRepresentation : IIdentifiable
    {
        IRepository Open(Uri repositoryUri);
        Uri Identify(IRepository repository, Stream content, ITypedContent typedContent);
    }

    public abstract class Representation : Identifiable, IRepresentation
    {
        protected Representation(Uri uri)
            : base(uri)
        {
            if (uri.IsAbsoluteUri)
            {
                throw new ArgumentException("URI should be relative", "uri");
            }
        }

        public abstract Uri Identify(IRepository repository, Stream content, ITypedContent typedContent);

        public abstract IRepository Open(Uri repositoryUri);
    }

    public static class RepresentationExtensions
    {
        public static Uri Identify(this IRepresentation representation, IRepository repository, Stream content)
        {
            return representation.Identify(repository, content, null);
        }
    }
}
