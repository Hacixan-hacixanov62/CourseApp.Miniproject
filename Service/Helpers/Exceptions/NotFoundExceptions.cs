namespace Service.Helpers.Exceptions
{
    public class NotFoundExceptions : Exception
    {
        public NotFoundExceptions()
        {
        }

        public NotFoundExceptions(string message) : base(message) { }

    }
}
