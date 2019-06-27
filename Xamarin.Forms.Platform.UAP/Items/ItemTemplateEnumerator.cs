using System.Collections;
using System.Collections.Generic;

namespace Xamarin.Forms.Platform.UWP
{
	internal class ItemTemplateEnumerator : ItemTemplateEnumeratorAbstract
	{
		readonly DataTemplate _formsDataTemplate;

		public ItemTemplateEnumerator(IEnumerable itemsSource, DataTemplate formsDataTemplate): base(itemsSource)
		{
			_formsDataTemplate = formsDataTemplate;
		}

		protected override object CreateItemTemplate(object item)
		{
			return new ItemTemplatePair(_formsDataTemplate, item);
		}
	}
}