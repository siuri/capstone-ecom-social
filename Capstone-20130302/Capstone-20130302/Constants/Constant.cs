using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Capstone_20130302.Constants
{
    public static class Constant
    {
        public const string ROLE_SELLER = "seller";
        public const string ROLE_BUYER = "buyer";
        public const string ROLE_ADMIN = "admin";
        public const string SESSION_CURRENT_STORE = "SESSION_CURRENT_STORE";

        public const int STATUS_PENDING = 1;
        public const int STATUS_ACTIVE = 2;
        public const int STATUS_INACTIVE = 3;
        public const int STATUS_REJECTED = 4;
        public const int STATUS_BANNED = 5;

        public const int ORDER_STATUS_PENDING = 1;
        public const int ORDER_STATUS_READY = 2;
        public const int ORDER_STATUS_SHIPPED = 3;
        public const int ORDER_STATUS_CANCELLED = 4;
        public const int ORDER_STATUS_HOLD = 5;
    }
}