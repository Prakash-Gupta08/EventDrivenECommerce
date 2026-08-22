using System.Net;

namespace EventDrivenECommerce.Common
{
    public class ApiResponse
    {
        //public APIResponse()
        //{
        //    ErrorMessages = new List<string>();
        //}

        public string? Result { get; set;  }
        public object? Data { get; set;  }
        public bool isSuccess { get; set; }
        public List<string> ErrorMessages { get; set; }
        public HttpStatusCode StatusCode { get; set; }

    }
}
