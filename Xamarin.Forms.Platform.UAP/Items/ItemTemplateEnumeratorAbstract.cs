using System.Collections;
using System.Collections.Generic;
namespace Xamarin.Forms.Platform.UWP
{
	internal abstract class ItemTemplateEnumeratorAbstract : IEnumerable, IEnumerator
	{
		readonly IEnumerator _innerEnumerator;

		public ItemTemplateEnumeratorAbstract(IEnumerable items)
		{
			_innerEnumerator = items.GetEnumerator();
		}
		public IEnumerator GetEnumerator()
		{
			return this;
		}

		public bool MoveNext()
		{
			var moveNext = _innerEnumerator.MoveNext();

			if (moveNext)
			{
				Current = CreateItemTemplate(_innerEnumerator.Current);
			}

			return moveNext;
		}

		protected abstract object CreateItemTemplate(object item);

		public void Reset()
		{
			_innerEnumerator.Reset();
		}

		public object Current { get; private set; }
	}

}