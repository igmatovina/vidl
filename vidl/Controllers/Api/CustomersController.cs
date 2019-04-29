using AutoMapper;
using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Linq;
using System.Net;
using System.Data.Entity;
using System.Net.Http;
using System.Web.Http;
using vidl.Dtos;
using vidl.Models;

namespace vidl.Controllers.Api
{
    public class CustomersController : ApiController
    {
        private ApplicationDbContext _context;
        public CustomersController()
        {
            _context = new ApplicationDbContext();
        }
        //get/api/customer
        public IHttpActionResult GetCustomers()
        {
            var customerDtos= _context.Customers
                .Include(c => c.MembershipType)
                .ToList()
                .Select(Mapper.Map<Customer,CustomerDto>);

            return Ok(customerDtos);
        }
        //get/api/customer/1
        public IHttpActionResult GetCustomer(int id)
        {
            var customer = _context.Customers.SingleOrDefault(c => c.Id == id);
            if (customer == null) throw new HttpResponseException(HttpStatusCode.NotFound);
            return Ok(Mapper.Map<Customer, CustomerDto>(customer));
        }

        //post/api/customer
        [HttpPost]
        public IHttpActionResult CreateCustomer(CustomerDto customerDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();
            var customer = Mapper.Map<CustomerDto, Customer>(customerDto);
            _context.Customers.Add(customer);
            try
            {
                _context.SaveChanges();
            }

            catch (DbEntityValidationException e)
            {
                Console.WriteLine(e);
            }

            customerDto.Id = customer.Id;
            return Created(new Uri(Request.RequestUri + "/" + customer.Id),customerDto);
        }

        //put/api/customers/1
        [HttpPut]
        public void UpdateCustomer(int id, CustomerDto customerDto)
        {
            if (!ModelState.IsValid)
                throw new HttpResponseException(HttpStatusCode.BadRequest);
            var CustomerInDb = _context.Customers.SingleOrDefault(c => c.Id == id);
            if (CustomerInDb == null) throw new HttpResponseException(HttpStatusCode.NotFound);
            Mapper.Map<CustomerDto, Customer>(customerDto,CustomerInDb);

            _context.SaveChanges();
        }

        //delete/api/customers/1

        public void DeleteCustomer(int id)
        {
            var CustomerInDb = _context.Customers.SingleOrDefault(c => c.Id == id);
            if (CustomerInDb == null) throw new HttpResponseException(HttpStatusCode.NotFound);
            _context.Customers.Remove(CustomerInDb);
            _context.SaveChanges();
        }

    }
}
