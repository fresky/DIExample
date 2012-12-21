namespace DIExample
{
    class Presenter : IPresenter
    {
        private ILogger m_Logger;
        private readonly IModel m_Model;

        public Presenter(ILogger logger, IModel model)
        {
            m_Logger = logger;
            m_Model = model;
        }

        public void HandleReverse(string text, IView view)
        {
            string reverse = m_Model.Reverse(text);
            view.DisplayResult(reverse);
            m_Logger.LogMessage(string.Format("{0} -> {1}", text, reverse));
        }

        public void SetLogger(ILogger logger)
        {
            m_Logger = logger;
        }
    }
}