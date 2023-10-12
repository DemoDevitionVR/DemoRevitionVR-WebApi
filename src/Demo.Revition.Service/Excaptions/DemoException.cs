namespace Demo.Revition.Service.Excaptions
{
    public class DemoException : Exception
    {
        public int StatusCode { get; set; }

        public DemoException(int statuscode = 500, string titleMessage = "Something went wrong") : base(titleMessage)
        {
            this.StatusCode = statuscode;
        }
    }
}
