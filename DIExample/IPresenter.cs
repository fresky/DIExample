namespace DIExample
{
    public interface IPresenter
    {
        void HandleReverse(string text, IView view);
        void SetLogger(ILogger logger);
    }
}