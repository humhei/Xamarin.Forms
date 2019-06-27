using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Xamarin.Forms.Platform.UWP
{
	internal class GroupItemTemplateEnumerator: ItemTemplateEnumeratorAbstract
	{
		readonly GroupDataTemplate _groupDataTemplate;
		public DataTemplate FormsGroupHeaderDataTemplate => _groupDataTemplate.HeaderTemplate;
		public DataTemplate FormsGroupFooterDataTemplate => _groupDataTemplate.FooterTemplate;


		public IEnumerable FormsDataContext { get;  }

		public GroupItemTemplateEnumerator(IEnumerable items, GroupDataTemplate groupDataTemplate) : base(items) 
		{
			_groupDataTemplate = groupDataTemplate;
			FormsDataContext = items;
		}

		protected override object CreateItemTemplate(object item)
		{
			return _groupDataTemplate.ItemTemplate == null ? item : new ItemTemplatePair(_groupDataTemplate.ItemTemplate, item);
		}
	}
}