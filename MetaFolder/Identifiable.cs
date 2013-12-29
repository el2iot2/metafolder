using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace MetaFolder
{
    public interface IIdentifiable
    {
        Uri Uri { get; }
    }

    public abstract class Identifiable : IIdentifiable
    {
        readonly Uri _Uri;
        public Identifiable(Uri uri)
        {
            if (uri == null)
            {
                throw new ArgumentNullException("uri");
            }
            _Uri = uri;
        }

        public Uri Uri
        {
            get { return _Uri; }
        }
    }

    public static class IIdentifiableExtensions
    {
        public static bool EqualTo(this IIdentifiable first, IIdentifiable second)
        {
            if (first == null)
            {
                throw new ArgumentNullException("first");
            }

            if (second == null)
            {
                return false;
            }

            return first.Uri.Equals(second.Uri);
        }
    }
}
