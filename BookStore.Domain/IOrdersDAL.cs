using P0Library.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Domain
{
    public interface IOrdersDAL
    {
        public IEnumerable<Stores> GetStores();
        /// <summary>
        /// Remove order according to input id
        /// </summary>
        /// <param name="id"></param>
        public void Remove(int id);

        /// <summary>
        /// Searches orders by id, return null if not found in database
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Orders FindByID(int id);

        /// <summary>
        /// Returns ienumerable of order count
        /// </summary>
        /// <returns></returns>
        public Task<IEnumerable<Orders>> GetOrds();

        /// <summary>
        /// Adds an order to database
        /// </summary>
        /// <param name="cust"></param>
        /// <returns>id of added order</returns>
        public int Add(Orders ord);

        /// <summary>
        /// Sets order's state to edited
        /// </summary>
        /// <param name="cust"></param>
        public void Edit(Orders ord);

        /// <summary>
        /// Retrieves all orders from db by given search parameter and id
        /// </summary>
        /// <param name="search_param">location/order/customer id/name</param>
        /// <param name="mode">1: orders for a location, 2: orders for a given customer, 3: specific order, default: all orders
        /// </param>
        /// <returns></returns>
        Task<List<Orders>> GetOrders(int mode = 0, params string[] search_param);
    }
}
