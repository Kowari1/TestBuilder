using Test_Builder.Services;
using Test_Builder.ViewModels;

namespace Test_Builder.Pages;

public partial class MainPage : ContentPage
{
	public MainPage(MainPageViewModel vm)
	{
		InitializeComponent();
        BindingContext = vm;
    }  
}

