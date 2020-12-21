using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;

namespace Utility.Helper
{
    public static class GlobalConstant
    {
        
        //-------------------For Common Response--------------------------
        public static string RESPONSE_CODE_SUCCESS = "200";
        public static string RESPONSE_CODE_NOTFOUND = "404";
        public static string RESPONSE_CODE_SERVER_ERROR = "500";
        public static string RESPONSE_CODE_BAD_REQUEST = "400";
        public static string RESPONSE_MESSAGE_SUCCESS = "Success";
        public static string RESPONSE_MESSAGE_NOTFOUND = "Not found";
        public static string RESPONSE_MESSAGE_SERVER_ERROR = "Server Error";
        public static string RESPONSE_MESSAGE_BAD_REQUEST = "Bad Request";
        //-------------------For Common Response--------------------------


        //-------------------For Logical Operation--------------------------
        public static string OPERATION_SUCCESS = "Success";
        public static string OPERATION_ERROR = "Error";
        public static string OPERATION_TIMEOUT = "Timeout";
        public static string OPERATION_DATA_NOT_FOUND = "Data Not Found";

        //-------------------For Constant Value--------------------------
        public static string ADMIN_NAME = "Admin";

    }
}
