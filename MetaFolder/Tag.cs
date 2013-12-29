using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MetaFolder
{
    public interface ITag : IIdentifiable
    {
    }

    public abstract class Tag : Identifiable, ITag
    {
        protected Tag(Uri uri)
            : base(uri)
        {
            if (uri.IsAbsoluteUri)
            {
                throw new ArgumentException("URI should be relative", "uri");
            }
        }
    }
}
