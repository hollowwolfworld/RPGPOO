namespace RPGPOO.Exceptions
{
    [Serializable]
    internal class NotEnoughtGoldException : Exception
    {
        public NotEnoughtGoldException()
        {
        }

        public NotEnoughtGoldException(string? message) : base(message)
        {
        }

        public NotEnoughtGoldException(string? message, Exception? innerException) : base(message, innerException)
        {
        }
    }
}