namespace Hahn.ApplicatonProcess.July2021.Web.Models
{
    public class ErrorDetails
    {
        public int StatusCode { get; set; }
        public string StatusCodeText { get; set; }
        public string[] Messages { get; set; }
    }
}
