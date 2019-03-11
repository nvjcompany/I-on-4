using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interfaces
{
    public interface IMaintanable<T>
    {
        Task<T> Find(T obj);
        Task<bool> Create(T obj);
        Task<bool> Update(T obj);
        Task<bool> Delete(T obj);
    }
}
