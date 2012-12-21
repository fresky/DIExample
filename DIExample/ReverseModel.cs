using System.Linq;

namespace DIExample
{
    internal class ReverseModel : IModel
    {
        public string Reverse(string text)
        {
            return new string(text.ToCharArray().Reverse().ToArray());
        }
    }
}