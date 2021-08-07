using Regions.Services;
using Microsoft.Web.WebView2.Core;
using Microsoft.Web.WebView2.Wpf;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Regions.Services.NewDelegation;

namespace Regions.Controls
{
    /// <summary>
    /// Logika interakcji dla klasy WebViewEx.xaml
    /// </summary>
    public partial class WebViewEx : WebView2, IJavaScriptExecutor
    {
        public delegate void ContentLoadedEventHandler(object sender, ContentLoadedEventArgs e);

        public event ContentLoadedEventHandler ContentLoaded

        {

            add { AddHandler(ContentLoadedEvent, value); }

            remove { RemoveHandler(ContentLoadedEvent, value); }

        }

        public static readonly RoutedEvent ContentLoadedEvent = EventManager.RegisterRoutedEvent(
        "ContentLoaded", RoutingStrategy.Bubble, typeof(ContentLoadedEventHandler), typeof(WebViewEx));

        // Provide CLR accessors for the event

        void RaiseContentLoadedEvent()
        {
            ContentLoadedEventArgs newEventArgs = new ContentLoadedEventArgs(WebViewEx.ContentLoadedEvent, this.CoreWebView2.DocumentTitle);
            RaiseEvent(newEventArgs);
        }



        public delegate void DownloadEndedEventHandler(object sender, DownloadEndedEventArgs e);

        public event DownloadEndedEventHandler DownloadEnded
        {
            add { AddHandler(DownloadEndedEvent, value); }
            remove { RemoveHandler(DownloadEndedEvent, value); }
        }

        public static readonly RoutedEvent DownloadEndedEvent = EventManager.RegisterRoutedEvent(
        "DownloadEnded", RoutingStrategy.Bubble, typeof(DownloadEndedEventHandler), typeof(WebViewEx));

        // Provide CLR accessors for the event

        void RaiseDownloadEndedEvent(CoreWebView2DownloadState state, string fileName)
        {
            DownloadEndedEventArgs newEventArgs = new DownloadEndedEventArgs(WebViewEx.DownloadEndedEvent,state, fileName);
            RaiseEvent(newEventArgs);
        }


        public IJavaScriptExecutor JSExecute
        {

            get { return (IJavaScriptExecutor)this.GetValue(JSExecuteProperty); }
            set { this.SetValue(JSExecuteProperty, value); }

        }

        public static readonly DependencyProperty JSExecuteProperty = DependencyProperty.Register(
          "JSExecute", typeof(IJavaScriptExecutor), typeof(WebViewEx), new PropertyMetadata(null));


        public WebViewEx() : base()
        {
           
          
            CoreWebView2InitializationCompleted += WebViewEx2_CoreWebView2InitializationCompleted;

        }

        private void WebViewEx2_CoreWebView2InitializationCompleted(object sender, Microsoft.Web.WebView2.Core.CoreWebView2InitializationCompletedEventArgs e)
        {
            CoreWebView2.DOMContentLoaded += CoreWebView2_DOMContentLoaded;
            CoreWebView2.DownloadStarting += CoreWebView2_DownloadStarting;
            JSExecute = this;
        }

        private void CoreWebView2_DownloadStarting(object sender, CoreWebView2DownloadStartingEventArgs e)
        {
            e.DownloadOperation.StateChanged += DownloadOperation_StateChanged;
           
        }

        private void DownloadOperation_StateChanged(object sender, object e)
        {
            CoreWebView2DownloadOperation DownloadOperation = (CoreWebView2DownloadOperation)sender;
            CoreWebView2DownloadState DownloadState = ((CoreWebView2DownloadOperation)sender).State;
            if(DownloadState == CoreWebView2DownloadState.Completed)
            {
                RaiseDownloadEndedEvent(DownloadState, DownloadOperation.ResultFilePath);
            }
        }

        private void CoreWebView2_DOMContentLoaded(object sender, Microsoft.Web.WebView2.Core.CoreWebView2DOMContentLoadedEventArgs e)
        {
            RaiseContentLoadedEvent();
            
        }

   

        public async Task<string> ExecuteScript(string script)
        {
           return  await ExecuteScriptAsync(script);
        }
    }

    public class ContentLoadedEventArgs:RoutedEventArgs, IContentPageNameWriter 
    {
        public ContentLoadedEventArgs(RoutedEvent routedEvent, string _pageName) :base(routedEvent)
        {
            pageName = _pageName;
        }
        private readonly string pageName;
        public string PageName
        {
            get { return pageName; }
        }

        public string GetPageName()
        {
            return PageName;
        }


    }

    public class DownloadEndedEventArgs:RoutedEventArgs, IDownloadedDocument
    {
        private readonly CoreWebView2DownloadState state;
        public CoreWebView2DownloadState State
        {
            get { return state; }
        }

        private readonly string fileName;
        public string FileName
        {
            get { return fileName; }
        }
        public DownloadEndedEventArgs(RoutedEvent routedEvent, CoreWebView2DownloadState _state, string _fileName ):base(routedEvent)
        {
            state = _state;
            fileName = _fileName;
        }

        public string GetFile()
        {
            return FileName;
        }
    }



}
