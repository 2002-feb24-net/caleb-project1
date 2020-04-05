using P0Library.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace BookStore.Domain
{
    public interface IStoresDAL
    {
        /// <summary>
        /// Updates inventory quantity in database
        /// </summary>
        /// <param name="id">product id</param>
        /// <param name="qty">quantity to decrease by</param>
        void UpdateInventory(int id, int qty);

        /// <summary>
        /// Retrieves inventory quantity of item
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        int GetQty(int id);

        /// <summary>
        /// Retrieves inventory of a store
        /// </summary>
        /// <param name="id">location id or name</param>
        /// <returns>list of items</returns>
        List<Inventory> GetInventory(int id);
    }
}
