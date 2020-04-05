using P0Library.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Domain
{
    public interface ICustomersDAL
    {
        /// <summary>
        /// Removes custs by id
        /// </summary>
        /// <param name="id"></param>
        public void Remove(int id);

        /// <summary>
        /// Searches custs by id, return null if not found in database
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Customers FindByID(int id);

        /// <summary>
        /// Returns ienumerable of cust count
        /// </summary>
        /// <returns></returns>
        public Task<IEnumerable<Customers>> GetCusts();

        /// <summary>
        /// Add customer to database
        /// </summary>
        /// <param name="cust"></param>
        public int Add(Customers cust);

        /// <summary>
        /// Set customer as edited
        /// </summary>
        /// <param name="cust"></param>
        public void Edit(Customers cust);

        /// <summary>
        /// Search customers by given parameter
        /// </summary>
        /// <param name="mode">Search mode: 1 - By name, 2 - By username</param>
        /// <param name="search_param">name/username to search by</param>
        /// <returns></returns>
        IEnumerable<Customers> SearchCust(int mode = 0, params string[] search_param);

        //Retrieves actual pwd of customer returns id of matching username
        /// <summary>
        /// Verifies existing username and assigns id if found
        /// </summary>
        /// <param name="username"></param>
        /// <param name="id">id holder for invoker</param>
        /// <returns>actual password of customer</returns>
        string VerifyCustomer(string username, out int id);
    }
}
