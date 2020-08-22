using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Xunit;

using Server.Models;
using Server.Services;
using Server.Controllers;

namespace Server.tests
{
    public class CustomerControllerTest
    {
        CustomerController _controller;
        ICustomerService _service;

        public CustomerControllerTest()
        {
            _service = new CustomerServiceMock();
            _controller = new CustomerController(_service);
        }

        [Fact]
        public async void GetCustomer_WhenCalled_ReturnsOneCustome()
        {
            var result = await _controller.GetCustomer(0);
            Assert.IsType<ActionResult<Customer>>(result);
        }

        [Fact]
        public async void GetCustomers_WhenCalled_ReturnsAllCustomers()
        {
            var result = await _controller.GetCustomers();
            Assert.IsType<ActionResult<IEnumerable<Customer>>>(result);
        }

        [Fact]
        public async void PostCustomer_WhenCalled_CreatesNewCustomer()
        {
            var customer = new Customer
            {
                Name = "Test Customer",
                Cpf = "98765432191",
                Age = 20,
                Phone = "(11) 9 1234-4321",
                Email = "test@mail.com",
                Address = "Test Street, 1",
                Dependents = new List<Dependent>
                {
                    new Dependent
                    {
                        Name = "Test Depenent",
                        Cpf = "78998745612",
                        Age = 4,
                        Relationship = "Child"
                    }
                }
            };
            var result = await _controller.PostCustomer(customer);
            var actionResult = (CreatedAtActionResult)result.Result;
            var newCustomer = (Customer)actionResult.Value;
            Assert.Equal("Test Customer", newCustomer.Name);
        }

        [Fact]
        public async void PutCustomer_WhenCalled_UpdatesCustomer()
        {
            var newPhone = "(99) 9 9999-9999";

            var customer = (await _controller.GetCustomer(1)).Value;
            customer.Phone = newPhone;
            await _controller.PutCustomer(customer.Id, customer);

            var retrieved = await _controller.GetCustomer(customer.Id);
            Assert.Equal(newPhone, retrieved.Value.Phone);
        }

        [Fact]
        public async void DeleteCustomer_WhenCalled_DeletesCustomer()
        {
            var customer = (await _controller.GetCustomer(1)).Value;
            await _controller.DeleteCustomer(customer.Id);

            var result = await _controller.GetCustomer(customer.Id);
            var customerAgain = result.Value;
            Assert.Equal(null, customerAgain);
        }
    }
}
