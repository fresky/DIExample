﻿using System.Windows;
using System.Windows.Controls;
using Microsoft.Practices.Unity;

namespace DIExample
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window, IView
    {
        private readonly IPresenter m_Controller;

        public MainWindow(IPresenter controller)
        {
            m_Controller = controller;
            InitializeComponent();
            loggerType.Items.Add(LoggerFactory.ConsoleLoggerName);
            loggerType.Items.Add(LoggerFactory.MessageboxLoggerName);
            loggerType.SelectedIndex = 0;
        }

        private void loggerTypeChanged(object sender, SelectionChangedEventArgs e)
        {
            //m_Controller.SetLogger(getLoggerByHand());
            //m_Controller.SetLogger(getLoggerByStructureMap());
            m_Controller.SetLogger(getLoggerByUnity());
        }

        private ILogger getLoggerByUnity()
        {
            return App.UnityContainer.Resolve<ILogger>(loggerType.SelectedItem.ToString());
        }

        private ILogger getLoggerByStructureMap()
        {
            return App.StructureMapContainer.GetInstance<ILogger>(loggerType.SelectedItem.ToString());
        }

        private ILogger getLoggerByHand()
        {
            return LoggerFactory.CreateLogger(loggerType.SelectedItem.ToString());
        }

        private void reverseButtonClick(object sender, RoutedEventArgs e)
        {
            m_Controller.HandleReverse(userInput.Text, this);
        }

        public void DisplayResult(string result)
        {
            userInput.Text = result;
        }
    }
}
