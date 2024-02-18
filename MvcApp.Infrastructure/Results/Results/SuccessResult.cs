using System.Net;
using MvcApp.Core.Results.Base;

namespace MvcApp.Core.Results.Results
{
    public class SuccessResult : Result
    {
        public SuccessResult(string message) : base(StatusTypeEnum.Success, (int)HttpStatusCode.OK, message)
        {
        }

        public SuccessResult() : base(StatusTypeEnum.Success, (int)HttpStatusCode.OK)
        {
        }
    }
}