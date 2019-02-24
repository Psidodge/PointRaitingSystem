using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MainLib.DatabaseServices
{
    public static class DB_AsynWrapper<T>
    {
        public static Task<List<T>> GetDataAsync(Func<List<T>> query)
        {
            return Task.Run<List<T>>(() =>
            {
                return query.Invoke();
            });
        }
    }
}