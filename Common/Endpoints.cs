using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Common
{
	public static class Endpoints
	{
        private const string STORAGE_BASE = "http://localhost:3100";
        //private const string STORAGE_BASE = "http://storage";
		private const string ORDER_BASE = "http://order";

		public  class STORAGE
		{
            public class INTERNAL
            {
				public class PRODUCT
				{
                    public const string GET_PRODUCT = "/get-item";
                    public const string GET_PRODUCTS = "/get-items";
                    public const string GET_DISCOUNTED_PRODUCTS = "/get-discounted-items";
                    public const string GET_PRODUCT_BY_TAG = "/get-item-by-tag";
					public const string POST_ITEM = "/post-item";
					public const string POST_ITEMS = "/post-items";
                    public const string DELETE_ITEM = "/delete-item";
                    public const string DELETE_ITEMS = "/delete-items";
                    public const string UPDATE_ITEM = "/update-items";

                }

                public class USER
				{
					public const string GET_USER = "/get-user";
					public const string GET_USER_SHOPPING_CART = "/get-user-shopping-cart";
					public const string EMPTY_USER_CART = "/empty-user-cart";
					public const string POST_USER = "/post-user";
                    public const string DELETE_ITEM_FROM_USER_CART = "/delete-item-from-user-cart";
                    public const string UPDATE_CART_LIST = "/update-product-list";

                }

				public class ORDER
				{
					public const string GET_UNFINISHED_ORDERS = "/get-unfinished-orders";
					public const string GET_FINISHED_ORDERS = "/get-finished-orders";
					public const string GET_ALL_ORDERS = "/get-all-orders";
					public const string POST_ORDER = "/post-order";
					public const string UPDATE_ORDER = "/update-order";

				}
            }
			public class PRODUCT
			{
                public const string GET_PRODUCT = STORAGE_BASE + INTERNAL.PRODUCT.GET_PRODUCT;
                public const string GET_PRODUCTS = STORAGE_BASE + INTERNAL.PRODUCT.GET_PRODUCTS;
                public const string GET_DISCOUNTED_PRODUCTS = STORAGE_BASE + INTERNAL.PRODUCT.GET_DISCOUNTED_PRODUCTS;
                public const string GET_PRODUCT_BY_TAG = STORAGE_BASE + INTERNAL.PRODUCT.GET_PRODUCT_BY_TAG;
				public const string POST_ITEM = STORAGE_BASE + INTERNAL.PRODUCT.POST_ITEM;
                public const string POST_ITEMS = STORAGE_BASE + INTERNAL.PRODUCT.POST_ITEMS;
				public const string DELETE_ITEM = STORAGE_BASE + INTERNAL.PRODUCT.DELETE_ITEM;
				public const string DELETE_ITEMS = STORAGE_BASE + INTERNAL.PRODUCT.DELETE_ITEMS;
				public const string UPDATE_ITEM = STORAGE_BASE + INTERNAL.PRODUCT.UPDATE_ITEM;

            }

            public class USER
            {
				public const string GET_USER = STORAGE_BASE + INTERNAL.USER.GET_USER;
				public const string GET_USER_SHOPPING_CART = STORAGE_BASE + INTERNAL.USER.GET_USER_SHOPPING_CART;
				public const string EMPTY_USER_CART = STORAGE_BASE + INTERNAL.USER.EMPTY_USER_CART;
				public const string POST_USER = STORAGE_BASE + INTERNAL.USER.POST_USER;
				public const string DELETE_ITEM_FROM_USER_CART = STORAGE_BASE + INTERNAL.USER.DELETE_ITEM_FROM_USER_CART;
				public const string UPDATE_CART_LIST = STORAGE_BASE + INTERNAL.USER.UPDATE_CART_LIST;

            }

			public class ORDER
			{
				public const string GET_UNFINISHED_ORDERS = STORAGE_BASE + INTERNAL.ORDER.GET_UNFINISHED_ORDERS;
				public const string GET_FINISHED_ORDERS = STORAGE_BASE + INTERNAL.ORDER.GET_FINISHED_ORDERS;
				public const string GET_ALL_ORDERS = STORAGE_BASE + INTERNAL.ORDER.GET_ALL_ORDERS;
				public const string POST_ORDER = STORAGE_BASE + INTERNAL.ORDER.POST_ORDER;
				public const string UPDATE_ORDER = STORAGE_BASE + INTERNAL.ORDER.UPDATE_ORDER;

			}
		}


		public class ORDER
		{
			public class INTERNAL 
			{
                public const string SET_INTERVAL = "/set-interval";
                public const string START = "/start";
                public const string STOP = "/stop";
            }

			public const string SET_INTERVAL = ORDER_BASE + INTERNAL.SET_INTERVAL;
			public const string START = ORDER_BASE + INTERNAL.START;
			public const string STOP = ORDER_BASE + INTERNAL.STOP;
		}
	}
}
