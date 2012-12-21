namespace DIExample
{
    static internal class ModelFactory
    {
        private static readonly ReverseModel ReverseModel = new ReverseModel();

        public static ReverseModel CreateModel()
        {
            return ReverseModel;
        }
    }
}