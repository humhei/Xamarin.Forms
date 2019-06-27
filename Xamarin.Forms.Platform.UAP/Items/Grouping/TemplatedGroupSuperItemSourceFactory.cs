using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;

namespace Xamarin.Forms.Platform.UWP
{
	internal class TemplatedGroupSuperItemSourceFactory
	{
		internal static ICollection<IEnumerable> Create(IEnumerable itemsSource, GroupDataTemplate groupDataTemplate)
		{
			switch (itemsSource)
			{
				case IList list when itemsSource is INotifyCollectionChanged:
					return new ObservableGroupSuperItemTemplateCollection(list, groupDataTemplate);
				default:
					var enumerator = new GroupSuperItemTemplateEnumerator(itemsSource, groupDataTemplate);
					return enumerator.ToList();
			}
		}
	}
}