namespace EC.Framework.Common.Entities
{
    public class Response : ResponseBase
    {
        public static Response Create(string message)
        {
            var response = new Response();

            response.Error(message);

            return response;
        }

        public static Response Create(string name, string message)
        {
            var response = new Response();

            response.Error(name, message);

            return response;
        }
    }
}
