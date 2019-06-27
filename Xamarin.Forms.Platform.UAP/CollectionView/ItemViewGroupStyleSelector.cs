using System;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using WApp = Windows.UI.Xaml.Application;


namespace Xamarin.Forms.Platform.UWP
{
	internal class ItemViewGroupStyleSelector: GroupStyleSelector
	{
		Windows.UI.Xaml.DataTemplate _groupHeaderTemplate;

		public ItemViewGroupStyleSelector()
		{
			_groupHeaderTemplate = (Windows.UI.Xaml.DataTemplate)WApp.Current.Resources["ContactDataTemplateContainer"];
		}

		protected override GroupStyle SelectGroupStyleCore(object group, uint level)
		{
			return new GroupStyle
			{
				HeaderTemplate = _groupHeaderTemplate
			};
		}
	}

}