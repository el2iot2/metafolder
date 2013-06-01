using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MetaFolder.FileSystem
{
    /// <summary>
    /// Extensions and defaults for the mfs3 scheme
    /// </summary>
    public static class Ruri
    {
        public static readonly string Scheme = "mfs3";
        public static readonly int DefaultPort = 80;
        /// <summary>
        /// 
        /// </summary>
        private class Parser : GenericUriParser
        {
            static Parser()
            {
                UriParser.Register(new Parser(), Scheme, DefaultPort);
            }

            private Parser()
                : base(GenericUriParserOptions.NoUserInfo | GenericUriParserOptions.NoQuery | GenericUriParserOptions.NoFragment)
            {
            }
        }

        public static string GetBucketName(this Uri uri)
        {
            return uri.DnsSafeHost;
        }
    }
}
