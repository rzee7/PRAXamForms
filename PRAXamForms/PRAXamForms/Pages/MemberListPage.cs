﻿using PRAXamForms.Cell;
using PRAXamForms.Core;
using PRAXamForms.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace PRAXamForms
{
	public class MemberListPage : ContentPage
	{
		#region View Model

		public MemberViewModel ViewModel { get { return BindingContext as MemberViewModel; } }

		#endregion

		#region Constructor

		public MemberListPage()
		{
			BackgroundImage = "backImage.png";
			BindingContext = new MemberViewModel();
			var list = new ListView() { BackgroundColor = Color.Red };
			list.ItemTemplate = new DataTemplate(typeof(MemberCell));
			list.ItemsSource = ViewModel.Items;
			list.ItemSelected += list_ItemSelected;
			Content = list;
		}

		void list_ItemSelected(object sender, SelectedItemChangedEventArgs e)
		{
			ViewModel.SelectedItem = e.SelectedItem as MemberInfo;
		}

		#endregion
	}
}
