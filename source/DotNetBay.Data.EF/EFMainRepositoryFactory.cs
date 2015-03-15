using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DotNetBay.Interfaces;

namespace DotNetBay.Data.EF
{
    class EFMainRepositoryFactory : IRepositoryFactory
    {
        public void Dispose()
        {
        }

        public IMainRepository CreateMainRepository()
        {
            return new EFMainRepository();
        }
    }
}
