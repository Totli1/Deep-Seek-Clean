#Deep seek clean#
##простое Xamarin приложение написанное на C# для демонстрации моей возможности создания apk файлов
Deepseek использует язык разметки Markdown, и из-за этого при копирования на телефоне тест будет выглядеть следующим образом:
![image](https://github.com/user-attachments/assets/c03803de-b7cf-49b1-932a-0a36bde650fd)
Deep seek clean преобразует текст из Markdown в обычный
![image](https://github.com/user-attachments/assets/51cbcd47-1bb8-4efd-8e16-99e466ef6b99)
![image](https://github.com/user-attachments/assets/a830ac72-acac-4370-97f4-6602006d6bba)
#Библиотеки
Для приложения был использован **Markdig** и **Xamarin.CommunityToolkit**
#Код
##MainPage
```csarp
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
```
##MainActivity
```csarp
[assembly: ExportRenderer(typeof(Editor), typeof(SelectAllEditorRenderer))]
namespace deepSeekClean.Droid
{
    [Activity(Label = "deepSeekClean", Icon = "@mipmap/icon", Theme = "@style/MainTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation | ConfigChanges.UiMode | ConfigChanges.ScreenLayout | ConfigChanges.SmallestScreenSize )]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            global::Xamarin.Forms.Forms.Init(this, savedInstanceState);
            LoadApplication(new App());
            
        }
        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }
    }

    public class SelectAllEditorRenderer : EditorRenderer
    {
        public SelectAllEditorRenderer(Context context) : base(context)
        {
        }

        protected override void OnElementChanged(ElementChangedEventArgs<Editor> e)
        {
            base.OnElementChanged(e);

            if (Control != null)
            {
                Control.SetSelectAllOnFocus(true);
            }
        }
    }

}
```
