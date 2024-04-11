using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastruct
{
    public interface IUpdate<E>
    {
        E Update(E? entity);
    }
}
