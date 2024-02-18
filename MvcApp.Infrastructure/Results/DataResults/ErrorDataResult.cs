﻿using System.Net;
using MvcApp.Core.Results.Base;

namespace MvcApp.Core.Results.DataResults
{
    public class ErrorDataResult<T> : DataResult<T>
    {
        public ErrorDataResult(T data, string message) : base(data, StatusTypeEnum.Failed,
            (int)HttpStatusCode.BadRequest, message)
        {
        }

        public ErrorDataResult(T data) : base(data, StatusTypeEnum.Failed, (int)HttpStatusCode.BadRequest)
        {
        }

        public ErrorDataResult(string message) : base(default, StatusTypeEnum.Failed, (int)HttpStatusCode.BadRequest,
            message)
        {
        }

        public ErrorDataResult() : base(default, StatusTypeEnum.Failed, (int)HttpStatusCode.BadRequest)
        {
        }
    }
}