using System;
using System.Collections;
using System.Collections.ObjectModel;
using System.Collections.Specialized;

namespace Xamarin.Forms.Platform.UWP
{
	internal class ObservableItemTemplateCollection : ObservableItemTemplateCollectionAbstract<ItemTemplatePair, DataTemplate>
	{

		public ObservableItemTemplateCollection(IList itemsSource, DataTemplate itemTemplate) : base(itemsSource, itemTemplate)
		{
		}

		protected override ItemTemplatePair CreateItemTemplatePair(object item, DataTemplate formsDataTemplate)
		{
			return new ItemTemplatePair(formsDataTemplate, item);
		}
	}
}