namespace pockerpoker
{
    public partial class MainPage : ContentPage
    {
        int count = 0;

        public MainPage()
        {
            InitializeComponent();

            Console.WriteLine("Main Page has loaded");
            BindingContext = new MainPageViewModel();
        }
    }

}
