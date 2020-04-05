using BookStore.Domain;
using Microsoft.EntityFrameworkCore;
using P0Library.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Infrastructure
{
    public class CustomersDAL : ICustomersDAL
    {
        readonly BookStoreContext context;

        public CustomersDAL(BookStoreContext context)
        {
            this.context = context;
        }

        public CustomersDAL()
        {
            context = new BookStoreContext();
        }

        public void Remove(int id)
        {
            var toRemove = context.Customers.Find(id);
            context.Customers.Remove(toRemove);
            context.SaveChanges();

        }

        public Customers FindByID(int id)
        {
            return context.Customers.Find(id);
        }

        public async Task<IEnumerable<Customers>> GetCusts()
        {
            return await context.Customers.ToListAsync();
        }

        /// <summary>
        /// Adds a customer to database
        /// </summary>
        /// <param name="cust"></param>
        public int Add(Customers cust)
        {
            context.Customers.Add(cust);
            context.SaveChanges();
            context.Entry(cust).Reload();
            return cust.Id;
        }

        /// <summary>
        /// Sets customer's state to edited
        /// </summary>
        /// <param name="cust"></param>
        public void Edit(Customers cust)
        {
            var old = FindByID(cust.Id);
            context.Entry(old).State = EntityState.Detached;
            context.Set<Customers>().Attach(cust);
            context.Entry(cust).State = EntityState.Modified;
            context.SaveChanges();
        }

        //Searches customers by either name or username
        //modes:
        //  1: Search by name
        //  2: username
        //  default: lastname
        public IEnumerable<Customers> SearchCust(int mode = 0, params string[] search_param)
        {
            if (mode == 1)
            {
                return context.Customers.Where(cust => cust.FirstName == search_param[0] && cust.LastName == search_param[1]);
            }
            else if (mode == 2)
            {
                return context.Customers.Where(cust => cust.Username == search_param[0]);
            }
            else
            {
                return context.Customers.Where(cust => cust.LastName == search_param[0]);
            }
        }

        //assigns id of verified customer -1 if does not exist/invalid etc.
        //returns actual pwd of customer
        public string VerifyCustomer(string username, out int id)
        {
            var cust = context.Customers.FirstOrDefault(cust => cust.Username == username);
            if (cust == null)
            {
                id = -1;
            }
            else
            {
                id = cust.Id;
                return cust.Password;
            }
            return "";

        }
    }
}
