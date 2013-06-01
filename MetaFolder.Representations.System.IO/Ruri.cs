using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MetaFolder.Representations.System.IO
{
    /// <summary>
    /// Extensions and defaults for the mfs3 scheme
    /// </summary>
    public static class Ruri
    {
        public static readonly string Scheme = "mffs";
        public static readonly int DefaultPort = 80;
        /// <summary>
        /// 
        /// </summary>
        private class Parser : FileStyleUriParser
        {
            static Parser()
            {
                UriParser.Register(new Parser(), Scheme, DefaultPort);
            }
            
            private Parser()
                : base()
            {
            }
        }
    }
}
