using BaseRestApi.Utility.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BaseRestApi.DTO
{
    /// <summary>
    /// Return type of the API. Note that I can declare type as a generic. I can declase it as "Result<T>" and the data type of the "Data" property is T. I can also declase it as "Result" and the data type of "Data" property is "Object". The JSON result is the same for both "Result" or "Result<T>"
    /// When T is Object it means that we don't care about Data
    /// ErrorNumber is a reference code. When the error occur, the system will generate a unique number as a ErrorNumber. This number will be logged in the file. So, we can use this number to find the exact exception for this error.
    /// </summary>
    public class Result<T>
    {
        public bool Success { get; set; } = false;
        public string Message { get; set; }
        public string TraceId { get; }
        public T Data { get; set; }    //Contains data that clients need.

        public Result(ITrace trace)
        {
            TraceId = trace.GetTraceId();
        }

        public string GetLog()
        {
            string message = string.Empty;

            message += $"Success: [{Success}]";
            message += $"Message: [{Message}]";
            message += $"TraceId: [{TraceId}]";
            message += $"Data: [{Data}]";

            return (message);
        }

        public string GetLogWithNoData()
        {
            string message = string.Empty;

            message += $"Success: [{Success}]";
            message += $"Message: [{Message}]";
            message += $"TraceId: [{TraceId}]";            

            return (message);
        }
    }

    
    //public class Result
    //{
    //    public bool Success { get; set; } = false;
    //    public string Message { get; set; }
    //    public string ErrorNumber { get; set; }
    //    public Object Data { get; set; }
    //}
}
