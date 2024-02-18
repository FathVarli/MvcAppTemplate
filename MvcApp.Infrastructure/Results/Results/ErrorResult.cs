using System.Net;
using MvcApp.Core.Results.Base;

namespace MvcApp.Core.Results.Results
{
    public class ErrorResult : Result
    {
        public ErrorResult(string message) : base(StatusTypeEnum.Failed, (int)HttpStatusCode.BadRequest, message)
        {
        }

        public ErrorResult() : base(StatusTypeEnum.Failed, (int)HttpStatusCode.BadRequest)
        {
        }
    }
}