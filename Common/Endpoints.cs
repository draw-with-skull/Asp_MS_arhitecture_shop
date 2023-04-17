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
        public  class STORAGE_INTERNAL
        {
			public const string GET_ITEM = "/get-item";
			public const string GET_ITEMS = "/get-items";

			public const string POST_ITEM = "/post-item";
			public const string POST_ITEMS = "/post-items";
			
			public const string DELETE_ITEM = "/delete-item";
			public const string DELETE_ITEMS = "/delete-items";
			
			public const string UPDATE_ITEM = "/update-items";

			public const string POST_USER = "/post-user";
			public const string GET_USER = "/get-user";
        }
		public  class STORAGE
		{
			public const string GET_ITEM = STORAGE_BASE + STORAGE_INTERNAL.GET_ITEM;
			public const string GET_ITEMS = STORAGE_BASE + STORAGE_INTERNAL.GET_ITEMS;
			
			public const string POST_ITEM = STORAGE_BASE + STORAGE_INTERNAL.POST_ITEM;
			public const string POST_ITEMS = STORAGE_BASE + STORAGE_INTERNAL.POST_ITEMS;

			public const string DELETE_ITEM = STORAGE_BASE + STORAGE_INTERNAL.DELETE_ITEM;
			public const string DELETE_ITEMS = STORAGE_BASE + STORAGE_INTERNAL.DELETE_ITEMS;

			public const string UPDATE_ITEM = STORAGE_BASE + STORAGE_INTERNAL.UPDATE_ITEM;

			public const string POST_USER = STORAGE_BASE + STORAGE_INTERNAL.POST_USER;
			public const string GET_USER = STORAGE_BASE + STORAGE_INTERNAL.GET_USER;
        }
	}
}
