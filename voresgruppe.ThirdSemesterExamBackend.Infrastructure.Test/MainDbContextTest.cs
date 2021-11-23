using EntityFrameworkCore.Testing.Moq;
using Microsoft.EntityFrameworkCore;
using voresgruppe.ThirdSemesterExamBackend.Core.Models;
using voresgruppe.ThirdSemesterExamBackend.DataAccess;
using voresgruppe.ThirdSemesterExamBackend.DataAccess.Entities;
using Xunit;

namespace voresgruppe.ThirdSemesterExamBackend.Infrastructure.Test
{
    public class MainDbContextTest
    {
        private readonly MainDbContext _mock;

        public MainDbContextTest()
        {
            _mock = Create.MockedDbContextFor<MainDbContext>();
        }

        [Fact]
        public void DbContext_WithDbContextOptions_IsAvailable()
        {
            
            Assert.NotNull(_mock);
        }

        [Fact]
        public void DbContext_DbSets_MustHaveDbSetWithHairstyleEntity()
        {
            Assert.True(_mock.Hairstyles is DbSet<HairstyleEntity>);
        }
    }
}