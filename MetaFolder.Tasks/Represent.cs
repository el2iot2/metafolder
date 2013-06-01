using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reactive.Linq;
using System.Text;
using Microsoft.Build.Framework;
using Ninject;

namespace MetaFolder.Tasks
{
    public class Represent : BaseTask
    {
        public string IntoUri
        {
            get;
            set;
        }

        [Required]
        public ITaskItem[] Items
        {
            get;
            set;
        }

        public override bool Execute()
        {
            Uri intoUri;

            if (!Uri.TryCreate(IntoUri, UriKind.Absolute, out intoUri))
            {
                Log.LogError("Cannot parse IntoUri of {0}", IntoUri);
                return false;
            }

            IKernel kernel = new StandardKernel(new TasksModule());
            kernel.Load("MetaFolder.Representations.*.dll");

            IRepresentation representation = kernel.TryGet<IRepresentation>(intoUri.Scheme);
            if (representation == null)
            {
                Log.LogError("Cannot find representation for {0}", IntoUri);
                return false;
            }

            using (IRepository intoRepository = representation.Open(intoUri))
            {
                Log.LogMessage(MessageImportance.High, "Representing Items Into {0}", intoUri);
                List<Uri> resources = new List<Uri>();

                var uris = Items
                    .ToObservable()
                    .Select(item =>
                    {
                        Log.LogMessage(MessageImportance.Normal, item.ItemSpec);

                        using (Stream stream = File.OpenRead(item.ItemSpec))
                        {
                            return representation.Identify(intoRepository, stream, 0);
                        }
                    })
                    .ToList()
                    .Wait();

                var postedUris = intoRepository
                    .Post(uris)
                    .ToList()
                    .Wait();
            }
            
            return true;
        }
    }
}
