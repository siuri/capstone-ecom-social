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

        public const int STATUS_INACTIVE = 1;
        public const int STATUS_ACTIVE = 2;
        public const int STATUS_BANNED = 3;

        public const int ORDER_STATUS_PENDING = 1;
        public const int ORDER_STATUS_READY = 2;
        public const int ORDER_STATUS_SHIPPED = 3;
        public const int ORDER_STATUS_CANCELLED = 4;
        public const int ORDER_STATUS_HOLD = 5;


        public const int PAGE_SIZE = 30;

        public const string ST_OK = "OK";
        public const string ST_NG = "NG";

        public const int MESSAGE_TYPE_FOLLOW = 1;
        public const int MESSAGE_TYPE_COMMENT = 2;
        public const int MESSAGE_TYPE_LIKE = 3;
        public const int MESSAGE_TYPE_ORDER = 4;
        public const int MESSAGE_TYPE_NEW_PRODUCT = 5;

        public const int PRONOUN_TYPE_USER = 1;
        public const int PRONOUN_TYPE_CATEGORY = 2;
        public const int PRONOUN_TYPE_STORE = 3;
        public const int PRONOUN_TYPE_PRODUCT = 4;
    }
}