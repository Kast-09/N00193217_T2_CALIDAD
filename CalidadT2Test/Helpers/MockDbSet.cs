using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Moq;

namespace CalidadT2Test.Helpers
{
    public class MockDbSet<T> : Mock<DbSet<T>> where T : class
    {
        public MockDbSet(IQueryable<T> data)
        {
            base.As<IQueryable<T>>().Setup(o => o.Provider).Returns(data.Provider);
            base.As<IQueryable<T>>().Setup(o => o.Expression).Returns(data.Expression);
            base.As<IQueryable<T>>().Setup(o => o.ElementType).Returns(data.ElementType);
            base.As<IQueryable<T>>().Setup(o => o.GetEnumerator()).Returns(data.GetEnumerator());
        }
    }
}
