using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using EntityFrameworkCore.Testing.Moq;
using voresgruppe.ThirdSemesterExamBackend.Core.Models;
using voresgruppe.ThirdSemesterExamBackend.DataAccess;
using voresgruppe.ThirdSemesterExamBackend.DataAccess.Entities;
using voresgruppe.ThirdSemesterExamBackend.DataAccess.Repositories;
using voresgruppe.ThirdSemesterExamBackend.Domain.IRepositories;
using Xunit;

namespace voresgruppe.ThirdSemesterExamBackend.Infrastructure.Test.Repositories
{
    public class HairstyleRepositoryTest
    {
        private readonly MainDbContext _fakeContext;
        private readonly HairstyleRepository _repo;

        #region Repository

        public HairstyleRepositoryTest()
        {
            _fakeContext = Create.MockedDbContextFor<MainDbContext>();
            _repo = new HairstyleRepository(_fakeContext);
            
        }

        [Fact]
        public void HairstyleRepository_IsIHairstyleRepository()
        {
            Assert.IsAssignableFrom<IHairStyleRepository>(_repo);
        }

        [Fact]
        public void HairstyleRepository_WithNullDBContext_ThrowsInvalidDataException()
        {
            var exception = Assert
                .Throws<InvalidDataException>(() => new HairstyleRepository(null));
            Assert.Equal("HairstyleRepository need a DBcontext", exception.Message);
        }
        #endregion

        #region FindAll

        [Fact]
        public void FindAll_GetAllHairstyleEntitiesInDBContext_AsAListOfHairstyles()
        {
            var fakeList = new List<HairstyleEntity>()
            {
                new()
                {
                    Id = 1, Name = "kort", EstimatedTime = 90
                },
                new() {Id = 2, Name = "langt", EstimatedTime = 30}
            };
            _fakeContext.Set<HairstyleEntity>().AddRange(fakeList);
            _fakeContext.SaveChanges();
            var expected = fakeList
                .Select(he => new HairStyle
            {
                Id = he.Id, Name = he.Name, EstimatedTime = he.EstimatedTime
            })
                .ToList();

            var actual = _repo.FindAll();
            Assert.Equal(expected,actual, new Comparer());
        }
        #endregion

        #region ReadByID

        [Fact]
        public void ReadByID_returnsCorrectHairStyle_AsHairstyle()
        {
            var selectedHairstyle = new HairstyleEntity {Id = 3, Name = "gryde", EstimatedTime = 10};
            var fakeList = new List<HairstyleEntity>()
            {
                new()
                {
                    Id = 1, Name = "kort", EstimatedTime = 90
                },
                new() {Id = 2, Name = "langt", EstimatedTime = 30},
            };
            fakeList.Add(selectedHairstyle);
            _fakeContext.Set<HairstyleEntity>().AddRange(fakeList);
            _fakeContext.SaveChanges();

            var expected = new HairStyle
            {
                Id = selectedHairstyle.Id, Name = selectedHairstyle.Name,
                EstimatedTime = selectedHairstyle.EstimatedTime
            };

            var actual = _repo.ReadById(expected.Id);
            Assert.Equal(expected, actual, new Comparer());
        }

        #endregion

        #region DeleteByID
        
        [Fact]
        public void DeleteById_DeletesCorrectHairstyle()
        {
            var selectedHairstyle = new HairstyleEntity {Id = 3, Name = "gryde", EstimatedTime = 10};
            var fakeList = new List<HairstyleEntity>()
            {
                new()
                {
                    Id = 1, Name = "kort", EstimatedTime = 90
                },
                new() {Id = 2, Name = "langt", EstimatedTime = 30},
            };
            fakeList.Add(selectedHairstyle);
            _fakeContext.Set<HairstyleEntity>().AddRange(fakeList);
            _fakeContext.SaveChanges();

            var expected = fakeList.Select(he => new HairStyle
                {
                    Id = he.Id, Name = he.Name, EstimatedTime = he.EstimatedTime
                })
                .ToList();
            
            _repo.DeleteById(selectedHairstyle.Id);

            var actual = _repo.FindAll();
            Assert.Equal(expected,actual, new Comparer());
        }

        #endregion
        
        public class Comparer : IEqualityComparer<HairStyle>
        {
            public bool Equals(HairStyle x, HairStyle y)
            {
                if (ReferenceEquals(x, y)) return true;
                if (ReferenceEquals(x, null)) return false;
                if (ReferenceEquals(y, null)) return false;
                if (x.GetType() != y.GetType()) return false;
                return x.Id == y.Id && x.Name == y.Name && x.EstimatedTime == y.EstimatedTime;
            }

            public int GetHashCode(HairStyle obj)
            {
                return HashCode.Combine(obj.Id, obj.Name, obj.EstimatedTime);
            }
        }
    }
}