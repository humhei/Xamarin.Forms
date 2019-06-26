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
					UpdateNativeGroupStyleSelector();
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
				var allItemsSource = itemsSource.Cast<object>().Select(items => 
				{
					var typedItems = (IEnumerable)items;
					
					var typedItems2 = 
						itemTemplate == null 
						? typedItems 
						: (IEnumerable)TemplatedItemSourceFactory.Create(typedItems, itemTemplate);


					return _groupableItemsView.GroupHeaderTemplate == null 
						? typedItems2 
						: new GroupHeaderTemplatePair(items,typedItems2,_groupableItemsView.GroupHeaderTemplate,_groupableItemsView.GroupFooterTemplate);
				});

				return new CollectionViewSource
				{
					Source = allItemsSource,
					IsSourceGrouped = true
				};
			}

			return new CollectionViewSource
			{
				Source = itemTemplate == null ? itemsSource : (IEnumerable)TemplatedItemSourceFactory.Create(itemsSource, itemTemplate),
				IsSourceGrouped = false
			};
		}

		protected override void OnElementPropertyChanged(object sender, PropertyChangedEventArgs changedProperty)
		{
			base.OnElementPropertyChanged(sender, changedProperty);
			if(changedProperty.IsOneOf
				(GroupableItemsView.IsGroupedProperty,
				 GroupableItemsView.GroupHeaderTemplateProperty,
				 GroupableItemsView.GroupFooterTemplateProperty))
			{
				UpdateNativeGroupStyleSelector();
			}
		}

		void UpdateNativeGroupStyleSelector()
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