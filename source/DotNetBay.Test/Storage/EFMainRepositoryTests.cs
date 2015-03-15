using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DotNetBay.Interfaces;
using DotNetBay.Data.EF;
using NUnit.Framework;

namespace DotNetBay.Test.Storage
{
    [Category("Database"),Ignore]
    class EFMainRepositoryTests : MainRepositoryTestBase
    {
        protected override IRepositoryFactory CreateFactory()
        {
            var ensureDLLIsCopied = System.Data.Entity.SqlServer.SqlProviderServices.Instance;
            return new EFMainRepositoryFactory();
        }
    }
}
