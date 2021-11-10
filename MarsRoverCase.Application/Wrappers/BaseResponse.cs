namespace MarsRoverCase.Application.Wrappers
{
    public class BaseResponse
    {
        public string Message { get; set; }
        public bool IsSuccess { get; set; }
        public object Data { get; set; }

        public BaseResponse(string message = null, object data = null, bool isSuccess = false)
        {
            Data = data;
            Message = message;
            IsSuccess = isSuccess;
        }

        public static BaseResponse ReturnAsSuccess(object data = null, string message = null)
        {
            return new BaseResponse(message, data, true);
        }

        public static BaseResponse ReturnAsError(object data = null, string message = null)
        {
            return new BaseResponse(message, data, false);
        }
    }
}
