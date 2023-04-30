using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common
{
	public static class Endpoints
	{
		private const string STORAGE_BASE = "http://storage";
		private const string ORDER_BASE = "http://order";
		public class STORAGE_INTERNAL
        {
			public const string GET_ITEM = "/get-item";
			public const string GET_ITEMS = "/get-items";
			public const string GET_DISCOUNTED_ITEMS = "/get-discounted-items";
			public const string GET_ITEM_BY_TAG = "/get-item-by-tag";

			public const string GET_USER = "/get-user";
			public const string GET_USER_SHOPPING_CART = "/get-user-shopping-cart";
			public const string EMPTY_USER_CART = "/empty-user-cart";

			public const string GET_UNFINISHED_ORDERS = "/get-unifinished-orders";

			public const string POST_ITEM = "/post-item";
			public const string POST_ITEMS = "/post-items";

			public const string POST_USER = "/post-user";

			public const string POST_ORDER = "/post-order";

			public const string DELETE_ITEM = "/delete-item";
			public const string DELETE_ITEMS = "/delete-items";
			public const string DELETE_ITEM_FROM_USER_CART = "/delete-item-from-user-cart";
			
			public const string UPDATE_ITEM = "/update-items";
			public const string UPDATE_CART_LIST = "/update-product-list";
			public const string UPDATE_ORDER = "/update-order";


        }
		public  class STORAGE
		{
			public const string GET_ITEM = STORAGE_BASE + STORAGE_INTERNAL.GET_ITEM;
			public const string GET_ITEMS = STORAGE_BASE + STORAGE_INTERNAL.GET_ITEMS;
			public const string GET_DISCOUNTED_ITEMS = STORAGE_BASE + STORAGE_INTERNAL.GET_DISCOUNTED_ITEMS;
			public const string GET_ITEM_BY_TAG = STORAGE_BASE + STORAGE_INTERNAL.GET_ITEM_BY_TAG;
			public const string GET_USER = STORAGE_BASE + STORAGE_INTERNAL.GET_USER;
			public const string GET_USER_SHOPPING_CART = STORAGE_BASE + STORAGE_INTERNAL.GET_USER_SHOPPING_CART;
			public const string GET_UNFINISHED_ORDERS = STORAGE_BASE + STORAGE_INTERNAL.GET_UNFINISHED_ORDERS;
			public const string EMPTY_USER_CART = STORAGE_BASE + STORAGE_INTERNAL.EMPTY_USER_CART;

			public const string POST_ITEM = STORAGE_BASE + STORAGE_INTERNAL.POST_ITEM;
			public const string POST_ITEMS = STORAGE_BASE + STORAGE_INTERNAL.POST_ITEMS;
			public const string POST_USER = STORAGE_BASE + STORAGE_INTERNAL.POST_USER;
			public const string POST_ORDER = STORAGE_BASE + STORAGE_INTERNAL.POST_ORDER;

			public const string DELETE_ITEM = STORAGE_BASE + STORAGE_INTERNAL.DELETE_ITEM;
			public const string DELETE_ITEMS = STORAGE_BASE + STORAGE_INTERNAL.DELETE_ITEMS;
			public const string DELETE_ITEM_FROM_USER_CART = STORAGE_BASE + STORAGE_INTERNAL.DELETE_ITEM_FROM_USER_CART;

			public const string UPDATE_ITEM = STORAGE_BASE + STORAGE_INTERNAL.UPDATE_ITEM;
			public const string UPDATE_CART_LIST = STORAGE_BASE + STORAGE_INTERNAL.UPDATE_CART_LIST;
			public const string UPDATE_ORDER = STORAGE_BASE + STORAGE_INTERNAL.UPDATE_ORDER;

		}

		public class ORDER_INTERNAL
		{
			public const string SET_INTERVAL = "/set-interval";
		}

		public class ORDER
		{
			public const string SET_INTERVAL = ORDER_BASE + ORDER_INTERNAL.SET_INTERVAL;
		}
	}
}
