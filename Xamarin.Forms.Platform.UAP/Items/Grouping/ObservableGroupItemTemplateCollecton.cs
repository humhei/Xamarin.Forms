using System.Collections;

namespace Xamarin.Forms.Platform.UWP
{
	internal class ObservableGroupItemTemplateCollecton : ObservableItemTemplateCollectionAbstract<object, DataTemplate>
	{
		public ObservableGroupItemTemplateCollecton(IList items, GroupDataTemplate dataTemplate) : base(items, dataTemplate.ItemTemplate)
		{
		}

		protected override object CreateItemTemplatePair(object item, DataTemplate itemTemplate)
		{
			return itemTemplate == null ? item : new ItemTemplatePair(itemTemplate, item);
		}
	}
}