using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace $safeprojectname$
{
    interface CommonMethods<T> where T : class
    {
        DataTable Select();

        bool İnsert(T entity);

        bool Delete(T entity);

        bool Update(T entity);
    }
}
