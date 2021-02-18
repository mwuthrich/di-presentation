using System;
using System.Collections.Generic;
using System.Text;

namespace MyWebProject
{
    public interface IFinder
    {
        Item GetItem();
    }

    public class ItemFinder : IFinder
    {
        private IDatabase _db;

        public ItemFinder(IDatabase db)
        {
            _db = db;
        }

        public Item GetItem()
        {
            return new Item();
        }
    }
}
