using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Xamarin.Forms.Platform.UWP
{
	internal class GroupHeaderTemplatePair: List<object>
	{

		public GroupHeaderTemplatePair(object headerContext, IEnumerable items, DataTemplate formsGroupHeaderDataTemplate, DataTemplate formsGroupFooterDataTemplate) 
		{
			HeaderContext = headerContext;
			FormsGroupHeaderDataTemplate = formsGroupHeaderDataTemplate;
			FormsGroupFooterDataTemplate = formsGroupFooterDataTemplate;
			AddRange(items.Cast<object>());
		}


		public object HeaderContext { get; }
		public DataTemplate FormsGroupHeaderDataTemplate { get; }
		public DataTemplate FormsGroupFooterDataTemplate { get; }
	}
}