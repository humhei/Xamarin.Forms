using System;
using System.Collections;
using System.Collections.Specialized;

namespace Xamarin.Forms.Platform.UWP
{
	internal class TemplatedGroupItemSourceFactory
	{
		internal static IEnumerable Create(IEnumerable items, GroupDataTemplate groupDataTemplate)
		{
			switch (items)
			{
				case IList list when items is INotifyCollectionChanged:
					return new ObservableGroupItemTemplateCollecton(list, groupDataTemplate);

				default:
					return new GroupItemTemplateEnumerator(items, groupDataTemplate);
			}
		}
	}
}