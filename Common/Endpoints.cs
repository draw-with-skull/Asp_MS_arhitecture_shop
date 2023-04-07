using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common
{
	public static class Endpoints
	{
		public static class STORAGE
		{
			private static readonly string STORAGE_BASE = "http://storage";
			//used to call storage
            public static readonly string GET_ITEM_OUT = STORAGE_BASE + "/get-item";
			public static readonly string GET_ITEMS_OUT = STORAGE_BASE + "/get-items";
			public static readonly string POST_ITEM_OUT = STORAGE_BASE + "/post-item";
			public static readonly string POST_ITEMS_OUT = STORAGE_BASE + "/post-items";
			//used for routing storage 
            public static readonly string GET_ITEM_IN = "/get-item";
            public static readonly string GET_ITEMS_IN = "/get-items";
            public static readonly string POST_ITEM_IN = "/post-item";
            public static readonly string POST_ITEMS_IN = "/post-items";
        }
	}
}
