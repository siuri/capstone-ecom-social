﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Web.WebPages.OAuth;
using Capstone_20130302.Models;

namespace Capstone_20130302
{
    public static class AuthConfig
    {
        public static void RegisterAuth()
        {
            // To let users of this site log in using their accounts from other sites such as Microsoft, Facebook, and Twitter,
            // you must update this site. For more information visit http://go.microsoft.com/fwlink/?LinkID=252166

            //OAuthWebSecurity.RegisterMicrosoftClient(
            //    clientId: "",
            //    clientSecret: "");

            //OAuthWebSecurity.RegisterTwitterClient(
            //    consumerKey: "",
            //    consumerSecret: "");

            OAuthWebSecurity.RegisterFacebookClient(
                appId: "541295582548776",
                appSecret: "bd4ee84ce81e70abe259401a7357392a");
                //appId: "541295582548776",
               // appSecret: "bd4ee84ce81e70abe259401a7357392a"); 

            //OAuthWebSecurity.RegisterGoogleClient();
        }
    }
}
