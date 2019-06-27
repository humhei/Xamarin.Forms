using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Data;
using WApp = Windows.UI.Xaml.Application;

namespace Xamarin.Forms.Platform.UWP
{
	public class GroupableItemsViewRender : SelectableItemsViewRenderer
	{
		GroupableItemsView _groupableItemsView;
		protected override void OnElementChanged(ElementChangedEventArgs<CollectionView> args)
		{
			_groupableItemsView = args.NewElement;
			base.OnElementChanged(args);

			if (args.NewElement != null)
			{
				if (_groupableItemsView.IsGrouped)
				{
					UpdateNativeGrouping();
				}
			}

		}

		protected override CollectionViewSource CreateCollectoinViewSource()
		{
			// TODO hartez 2018-05-22 12:59 PM Handle grouping
			var itemsSource = Element.ItemsSource;

			var itemTemplate = Element.ItemTemplate;

			// The ItemContentControls need the actual data item and the template so they can inflate the template
			// and bind the result to the data item.
			// ItemTemplateEnumerator handles pairing them up for the ItemContentControls to consume


			if (_groupableItemsView.IsGrouped)
			{
				var groupDataTemplate =
					new GroupDataTemplate()
					{
						HeaderTemplate = _groupableItemsView.GroupHeaderTemplate,
						FooterTemplate = _groupableItemsView.GroupFooterTemplate,
						ItemTemplate = _groupableItemsView.ItemTemplate
					};

				ICollection<IEnumerable> groupTemplatedItemsSource =
					TemplatedGroupSuperItemSourceFactory.Create(itemsSource, groupDataTemplate);

				return new CollectionViewSource
				{
					Source = groupTemplatedItemsSource,
					IsSourceGrouped = true
				};
			}
			else
			{
				return base.CreateCollectoinViewSource();
			}
		}

		protected override void OnElementPropertyChanged(object sender, PropertyChangedEventArgs changedProperty)
		{
			base.OnElementPropertyChanged(sender, changedProperty);
			if(changedProperty.IsOneOf
				(GroupableItemsView.IsGroupedProperty,
				 GroupableItemsView.GroupHeaderTemplateProperty,
				 GroupableItemsView.GroupFooterTemplateProperty))
			{
				UpdateNativeGrouping();
			}
		}

		void UpdateNativeGrouping()
		{
			ListViewBase.GroupStyle.Clear();
			if (_groupableItemsView.IsGrouped)
			{

				var groupStyle =
					new GroupStyle
					{
						HeaderTemplate = (Windows.UI.Xaml.DataTemplate)WApp.Current.Resources["CollectionViewGroupHeaderDefaultTemplate"]
					};

				ListViewBase.GroupStyle.Add(groupStyle);
			}
			ListViewBase.ItemsSource = CreateCollectoinViewSource().View;
		}
	}
}