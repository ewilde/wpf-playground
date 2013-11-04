using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace basic_wpf.Data
{
    public interface IRepository<out T>
    {
        IEnumerable<T> GetAll();
    }
}
