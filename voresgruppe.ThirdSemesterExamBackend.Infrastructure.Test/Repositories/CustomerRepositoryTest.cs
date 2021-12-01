using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using EntityFrameworkCore.Testing.Moq;
using Newtonsoft.Json;
using voresgruppe.ThirdSemesterExamBackend.Core.Models;
using voresgruppe.ThirdSemesterExamBackend.DataAccess;
using voresgruppe.ThirdSemesterExamBackend.DataAccess.Entities;
using voresgruppe.ThirdSemesterExamBackend.DataAccess.Repositories;
using voresgruppe.ThirdSemesterExamBackend.Domain.IRepositories;
using Xunit;

namespace voresgruppe.ThirdSemesterExamBackend.Infrastructure.Test.Repositories
{
    public class CustomerRepositoryTest
    {
        private MainDbContext _fakeContext;
        private CustomerRepository _repository;
        private List<CustomerEntity> _list;


        #region Helpers

        private void SetupArrangeFakeDB()
        {
            
            
            //Arrange
            _fakeContext = Create.MockedDbContextFor<MainDbContext>();
            _repository = new CustomerRepository(_fakeContext);
            _list = new List<CustomerEntity>
            {
                new CustomerEntity {Id = 1, Name = "Per", Email = "postmandper@hotmail.com", PhoneNumber = "22334422"},
                new CustomerEntity {Id = 2, Name = "Birgit", Email = "boomerbirgit@boomermail.com", PhoneNumber = "12341234"},
                new CustomerEntity {Id = 3, Name = "Frederik", Email = "prinsen@gmail.com", PhoneNumber = "11111111"}
            };
            _fakeContext.Set<CustomerEntity>().AddRange(_list);
            _fakeContext.SaveChanges();
        }

        #endregion
        

        #region Repository

         
        [Fact]
        public void CustomerRepository_IsICustomerRepository()
        {
            var fakeContext = Create.MockedDbContextFor<MainDbContext>();
            CustomerRepository repo = new CustomerRepository(fakeContext);
            Assert.IsAssignableFrom<ICustomerRepository>(repo);
        }

        [Fact]
        public void CustomerRepository_WithNullDBContext_ThrowsInvalidDataException()
        {
            InvalidDataException exception = Assert.Throws<InvalidDataException>(() => new CustomerRepository(null));
            Assert.Equal("Customer Repository must have a DBContext", exception.Message);
        }

        #endregion
       

        #region FindAll

        [Fact]
        public void FindAll_GetAllCustomersEntitiesInDBContext_AsAListOfCustomers()
        {
            SetupArrangeFakeDB();
            List<Customer> expectedList = _list.Select(pe => new Customer
                {
                    Id = pe.Id,
                    Name = pe.Name,
                    Email = pe.Email,
                    PhoneNumber = pe.PhoneNumber
                })
                .ToList();
            //Act
            var actualResult = _repository.FindAll();
            
            //Assert
            Assert.Equal(expectedList,actualResult, new Comparer());
        }

        #endregion
        

        #region FindById

        
        [Fact]
        public void FindById_TooHighId_ThrowsInvalidDataException()
        {
            SetupArrangeFakeDB();
            //Act
            InvalidDataException exception = Assert.Throws<InvalidDataException>(() => _repository.FindById(4));
            //Assert
            Assert.Equal("Id is too high", exception.Message);
        }

        [Theory]
        [InlineData(1, "Per", "postmandper@hotmail.com", "22334422")]
        [InlineData(2,"Birgit", "boomerbirgit@boomermail.com", "12341234")]
        [InlineData(3,"Frederik", "prinsen@gmail.com", "11111111")]
        public void FindById_Tests(int id, string name, string email, string phoneNumber)
        {
            SetupArrangeFakeDB();
            
            string expected = JsonConvert.SerializeObject(new Customer {Id = id, Name = name, Email = email, PhoneNumber = phoneNumber});
            
            string actual = JsonConvert.SerializeObject(_repository.FindById(id));
            
            Assert.Equal(expected,actual);
        }

        #endregion

        #region Delete

        [Fact]
        public void DeleteById_DeleteValidCustomer()
        {
            List<Customer> expectedList = new List<Customer>
            {
                new Customer {Id = 2, Name = "Birgit", Email = "boomerbirgit@boomermail.com", PhoneNumber = "12341234"},
                new Customer {Id = 3, Name = "Frederik", Email = "prinsen@gmail.com", PhoneNumber = "11111111"}
            };
            int removeCustomerWithThisId = 1;
            SetupArrangeFakeDB();
            _repository.DeleteById(removeCustomerWithThisId);
            var actualResult = _repository.FindAll();
            Assert.Equal(expectedList,actualResult, new Comparer());
        }

        #endregion

        #region Update

        /*public void UpdateNameByIdTest(int id, Customer c)
        {
            SetupArrangeFakeDB();

            Customer newCustomer = new Customer {Id = id, Name = c.Name, Email = c.Email, PhoneNumber = c.PhoneNumber};

            string expected = JsonConvert.SerializeObject(newCustomer);

            string actual = JsonConvert.SerializeObject(_repository.UpdateCustomer(id,newCustomer));
            Assert.Equal(expected, actual);
        }*/

        #endregion
        
    }
    
    public class Comparer: IEqualityComparer<Customer>
    {
        public bool Equals(Customer x, Customer y)
        {
            if (ReferenceEquals(x, y)) return true;
            if (ReferenceEquals(x, null)) return false;
            if (ReferenceEquals(y, null)) return false;
            if (x.GetType() != y.GetType()) return false;
            return x.Id == y.Id && x.Name == y.Name && x.PhoneNumber == y.PhoneNumber && x.Email == y.Email;
        }

        public int GetHashCode(Customer obj)
        {
            return HashCode.Combine(obj.Id, obj.Name, obj.PhoneNumber, obj.Email);
        }
    }
}