using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.CommunityToolkit.UI.Views;
using Xamarin.Essentials;
using Xamarin.CommunityToolkit.Extensions;
using Plugin.Toast;
using Markdig;
using Xamarin.CommunityToolkit.UI.Views.Options;



namespace deepSeekClean
{
    public partial class MainPage : ContentPage 
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private void ClearTextButton_Clicked(object sender, EventArgs e)
        {
            var pipeline = new MarkdownPipelineBuilder().Build();
            var clearText = Markdown.ToPlainText(notClearText.Text, pipeline);
            notClearText.Text = clearText;
            CopyText(clearText);
        }

        async void CopyText(string text)
        {
            await Clipboard.SetTextAsync(text);
            await Application.Current.MainPage.DisplayToastAsync("Текст был скопирован в буфер обмена");
        }
    }
   
}
