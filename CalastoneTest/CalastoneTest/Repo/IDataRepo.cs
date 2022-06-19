using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalastoneTest.Repo
{
    public interface IDataRepo
    {
        IEnumerable<string> GetData();
    }
}
