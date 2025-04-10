namespace Tami.Pago.Core
{
    public class JWKResource
    {
        public string Kty { get; set; } = "oct";
        public string Use { get; set; } = "sig";
        public string Kid { get; set; }
        public string K { get; set; }
        public string Alg { get; set; } = "HS512";

        public JWKResource() { }

        public JWKResource(string kid, string k)
        {
            Kid = kid;
            K = k;
        }
    }
}
