using System.Net;
using System.Text.Json.Serialization;

namespace CollisionsEventRestAPI.Application.DTOs
{
    public class BaseDTO<T>
    {
        private int _statusCode;

        public int GetStatusCode()
        {
            return _statusCode;
        }

        public void SetStatusCode(HttpStatusCode statusCode) 
        {
            _statusCode = (int)statusCode;
        }

        [JsonIgnore]
        public T? Id { get; set; }

        public BaseDTO()
        {
            Id = default(T?);
        }

        public BaseDTO(T? id, HttpStatusCode statusCode)
        {
            Id = id;
            _statusCode = (int)statusCode;
        }
    }
}
