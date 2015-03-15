using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DotNetBay.Interfaces;

namespace DotNetBay.Data.EF
{
    public class EFMainRepositoryFactory : IRepositoryFactory
    {
        private IList<EFMainRepository> repositories = new List<EFMainRepository>();
        public void Dispose()
        {
            this.repositories.Clear();
        }

        public IMainRepository CreateMainRepository()
        {
            EFMainRepository repo = new EFMainRepository();
            this.repositories.Add(repo);
            return repo;
        }
    }
}
