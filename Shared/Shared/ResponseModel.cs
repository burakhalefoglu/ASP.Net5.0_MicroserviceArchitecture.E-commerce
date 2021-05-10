using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace Shared
{
    public class ResponseModel<T>
    {

        public T Data { get; private set; }

        [JsonIgnore]
        public int StatuseCode { get; private set; }

        [JsonIgnore]
        public bool IsSuccess { get; private set; }

        public List<string> ErrorList { get; set; }
        public string SingleError { get; set; }

        public static ResponseModel<T> Success(T data, int statuseCode)
        {
            return new ResponseModel<T>
            {

                IsSuccess = true,
                Data = data,
                StatuseCode = statuseCode


            };
        }

        public static ResponseModel<T> Success(int statuseCode)
        {
            return new ResponseModel<T>
            {

                IsSuccess = true,
                Data = default(T),
                StatuseCode = statuseCode


            };
        }


        public static ResponseModel<T> Error(List<string> errorList, int statuseCode)
        {
            return new ResponseModel<T>
            {

                IsSuccess = false,
                StatuseCode = statuseCode,
                ErrorList = errorList


            };
        }

        public static ResponseModel<T> Error(string error, int statuseCode)
        {
            return new ResponseModel<T>
            {

                IsSuccess = false,
                StatuseCode = statuseCode,
                SingleError = error


            };
        }
    }
}
