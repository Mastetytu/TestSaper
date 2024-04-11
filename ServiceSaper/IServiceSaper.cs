using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SaperModel;
namespace ServiceSaper
{
    public interface IServiceSaper
    {
        Saper? AddDisease(Saper disease);
        IEnumerable<Saper> getDisease();
        
    }
}
