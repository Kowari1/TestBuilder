using CommunityToolkit.Mvvm.Messaging;
using System.ComponentModel;
using Test_Builder.Messages;
using Test_Builder.Services;
using Test_Builder.ViewModels;

namespace Test_Builder.Pages;

public partial class CreateTestPage : ContentPage
{
	public CreateTestPage(CreateTestPageViewModel vm)
	{
		InitializeComponent();
        BindingContext = vm;
	}
}