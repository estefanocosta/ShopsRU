using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopsRU.Infrastructure.Resources
{
    public interface IResourceService
    {
        string GetResource(string key);
        void LoadResources();
    }
}
