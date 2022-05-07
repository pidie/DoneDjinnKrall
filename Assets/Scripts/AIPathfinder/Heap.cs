using System;

namespace AIPathfinder
{
	public class Heap<T> where T : IHeapElement<T>
	{
		private readonly T[] _elements;

		public Heap(int maxHeapSize)
		{
			_elements = new T[maxHeapSize];
		}

		public void Add(T element)
		{
			element.HeapIndex = Count;
			_elements[Count] = element;
			SortUp(element);
			Count++;
		}

		public T RemoveFirst()
		{
			var first = _elements[0];
			Count--;
			_elements[0] = _elements[Count];
			_elements[0].HeapIndex = 0;
			SortDown(_elements[0]);
			return first;
		}

		public void UpdateElement(T element)
		{
			SortUp(element);
		}

		public int Count { get; private set; }

		public bool Contains(T element)
		{
			return Equals(_elements[element.HeapIndex], element);
		}

		public T GetElement(int index)
		{
			return _elements[index];
		}

		private void SortUp(T element)
		{
			var parentIndex = (element.HeapIndex - 1) / 2;

			while (true)
			{
				var parentElement = _elements[parentIndex];
				if (element.CompareTo(parentElement) > 0)
					Swap(element, parentElement);
				else
					break;
			}
		}

		private void SortDown(T element)
		{
			while (true)
			{
				var leftIndex = element.HeapIndex * 2 + 1;
				var rightIndex = element.HeapIndex * 2 + 2;

				if (leftIndex < Count)
				{
					var swapIndex = leftIndex;

					if (rightIndex < Count)
					{
						if (_elements[leftIndex].CompareTo(_elements[rightIndex]) < 0)
						{
							swapIndex = rightIndex;
						}
					}

					if (element.CompareTo(_elements[swapIndex]) < 0)
						Swap(element, _elements[swapIndex]);
					else return;
				}
				else return;
			}
		}

		private void Swap(T first, T second)
		{
			_elements[first.HeapIndex] = second;
			_elements[second.HeapIndex] = first;

			var temp = first.HeapIndex;
			first.HeapIndex = second.HeapIndex;
			second.HeapIndex = temp;
		}
	}
}

public interface IHeapElement<in T> : IComparable<T>
{
	int HeapIndex { get; set; }
}