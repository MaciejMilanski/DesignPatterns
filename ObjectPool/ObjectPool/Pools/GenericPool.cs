using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObjectPool
{
	public class GenericPool<T>
	{
		private ConcurrentBag<T> _objects;
		private Func<T> _objectGenerator;
		private int _maxCount;
		private int _minCount;
		public GenericPool(Func<T> objectGenerator, int maxCount, int minCount)
		{
			if (objectGenerator == null) throw new ArgumentNullException("objectGenerator");
			_objects = new ConcurrentBag<T>();
			_objectGenerator = objectGenerator;
			_maxCount = maxCount;
			_minCount = minCount;
			if (_objects.Count < 2) 
			{
				Parallel.For(0, 2, (i) => PutObject(objectGenerator()));
			}
		}
		public T GetObject()
		{
			T item;
			if (_objects.TryTake(out item))
			{
				if (_objects.Count <= _minCount)
				{
					Parallel.For(0, 2, (i) => PutObject(_objectGenerator()));
				}
				return item;
			}
			return _objectGenerator();
		}

		public void PutObject(T item)
		{
			if(_objects.Count < _maxCount)
				_objects.Add(item);
		}

		public long GetCount()
		{
			return _objects.Count;
		}
	}

}
