﻿using InstallmentApp_Front.Pages;

namespace InstallmentApp_Front;

public partial class AppShell : Shell
{
	public AppShell()
	{
		InitializeComponent();

        Routing.RegisterRoute(nameof(DetailsPage), typeof(DetailsPage));
		Routing.RegisterRoute(nameof(CardAdd), typeof(CardAdd));
    }
}
