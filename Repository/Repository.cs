using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiWeb.Repository
{
    public class Repository <TEntity> : IRepository<TEntity>, IDisposable where TEntity : class, new()
    {

    }
}
