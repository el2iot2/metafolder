using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MetaFolder
{
    public interface IIndex : IIdentifiable
    {
    }

    public abstract class Index : Identifiable, IIndex
    {
        protected Index(Uri uri) : base(uri)
        {
            if (uri.IsAbsoluteUri)
            {
                throw new ArgumentException("URI should be relative", "uri");
            }
        }
    }
}
