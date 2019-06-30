using System.Collections;
using System.Collections.Generic;

namespace Xamarin.Forms.Platform.UWP
{
	internal class GroupSuperItemTemplateEnumerator : ItemTemplateEnumeratorAbstract , IEnumerable<IEnumerable>, IEnumerator<IEnumerable>
	{
		readonly GroupDataTemplate _groupDataTemplate;

		public GroupSuperItemTemplateEnumerator(IEnumerable itemsSource,GroupDataTemplate groupDataTemplate): base(itemsSource)
		{
			_groupDataTemplate = groupDataTemplate;
		}

		IEnumerable IEnumerator<IEnumerable>.Current => (IEnumerable)Current;

		public void Dispose()
		{
			
		}

		protected override object CreateItemTemplate(object item)
		{
			return 
				new GroupItemTemplateEnumerator ((IEnumerable)item, _groupDataTemplate);
		}

		IEnumerator<IEnumerable> IEnumerable<IEnumerable>.GetEnumerator()
		{
			return this;
		}
	}
}