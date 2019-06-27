using System;
using System.Collections;
using System.Collections.ObjectModel;
using System.Collections.Specialized;

namespace Xamarin.Forms.Platform.UWP
{
	internal class ObservableGroupSuperItemTemplateCollection : ObservableItemTemplateCollectionAbstract<IEnumerable, GroupDataTemplate>
	{
		public ObservableGroupSuperItemTemplateCollection(IList itemsSource, GroupDataTemplate groupDataTemplate) : base(itemsSource, groupDataTemplate)
		{

		}

		protected override IEnumerable CreateItemTemplatePair(object item, GroupDataTemplate groupDataTemplate)
		{
			return
				TemplatedGroupItemSourceFactory.Create((IEnumerable)item, groupDataTemplate);
		}
	}
}