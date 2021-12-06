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
            Assert.IsAssignableFrom<IHairstyleRepository>(_repo);
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
                .Select(he => new Hairstyle
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

            var expected = new Hairstyle
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

            fakeList.Remove(selectedHairstyle);
            var expected = fakeList.Select(he => new Hairstyle
                {
                    Id = he.Id, Name = he.Name, EstimatedTime = he.EstimatedTime
                })
                .ToList();
            
            _repo.DeleteById(selectedHairstyle.Id);

            var actual = _repo.FindAll();
            Assert.Equal(expected,actual, new Comparer());
        }

        #endregion

        #region CreateHairstyle

        [Fact]
        public void createHairstyle_CreatesHairstyle()
        {
            Hairstyle hairstyle = new Hairstyle {Name = "gryde", EstimatedTime = 10};
            var fakeList = new List<Hairstyle>();
            fakeList.Add(hairstyle);

            _repo.CreateHairStyle(hairstyle);
            
            Assert.Equal(fakeList, _repo.FindAll(), new Comparer_ignoreID());
        }

        #endregion
        
        #region UpdateHairstyle

        [Fact]
        public void updateHairstyle_UpdatesHairstyle()
        {
            var fakeList = new List<Hairstyle>();
            

            Hairstyle oldHairstyle = _repo.CreateHairStyle(new Hairstyle {Name = "gryde", EstimatedTime = 10});
            Hairstyle hairstyleToUpdate = oldHairstyle;
            
            hairstyleToUpdate.Name = "langt";
            fakeList.Add(hairstyleToUpdate);
            
            _repo.UpdateHairStyle(oldHairstyle.Id, hairstyleToUpdate);
            
            Assert.Equal(fakeList, _repo.FindAll(), new Comparer());
        }

        #endregion
        
        public class Comparer : IEqualityComparer<Hairstyle>
        {
            public bool Equals(Hairstyle x, Hairstyle y)
            {
                if (ReferenceEquals(x, y)) return true;
                if (ReferenceEquals(x, null)) return false;
                if (ReferenceEquals(y, null)) return false;
                if (x.GetType() != y.GetType()) return false;
                return x.Id == y.Id && x.Name == y.Name && x.EstimatedTime == y.EstimatedTime;
            }

            public int GetHashCode(Hairstyle obj)
            {
                return HashCode.Combine(obj.Id, obj.Name, obj.EstimatedTime);
            }
        }
        
        public class Comparer_ignoreID : IEqualityComparer<Hairstyle>
        {
            public bool Equals(Hairstyle x, Hairstyle y)
            {
                if (ReferenceEquals(x, y)) return true;
                if (ReferenceEquals(x, null)) return false;
                if (ReferenceEquals(y, null)) return false;
                if (x.GetType() != y.GetType()) return false;
                return  x.Name == y.Name && x.EstimatedTime == y.EstimatedTime;
            }

            public int GetHashCode(Hairstyle obj)
            {
                return HashCode.Combine(obj.Name, obj.EstimatedTime);
            }
        }
    }
}