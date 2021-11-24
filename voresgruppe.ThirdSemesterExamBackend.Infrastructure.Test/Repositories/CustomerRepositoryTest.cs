using System;
using System.Collections;
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
    public class CustomerRepositoryTest
    {

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

        [Fact]
        public void FindAll_GetAllCustomersEntitiesInDBContext_AsAListOfCustomers()
        {
            //Arrange
            MainDbContext fakeContext = Create.MockedDbContextFor<MainDbContext>();
            CustomerRepository repository = new CustomerRepository(fakeContext);
            List<CustomerEntity> list = new List<CustomerEntity>
            {
                new CustomerEntity {Id = 1, Name = "Per", Email = "postmandper@hotmail.com", PhoneNumber = "22334422"},
                new CustomerEntity {Id = 2, Name = "Birgit", Email = "boomerbirgit@boomermail.com", PhoneNumber = "12341234"},
                new CustomerEntity {Id = 3, Name = "Frederik", Email = "prinsen@gmail.com", PhoneNumber = "11111111"}
            };
            fakeContext.Set<CustomerEntity>().AddRange(list);
            fakeContext.SaveChanges();
            List<Customer> expectedList = list.Select(pe => new Customer
                {
                    Id = pe.Id,
                    Name = pe.Name,
                    Email = pe.Email,
                    PhoneNumber = pe.PhoneNumber
                })
                .ToList();
            //Act
            var actualResult = repository.FindAll();
            
            //Assert
            Assert.Equal(expectedList,actualResult, new Comparer());
        }
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