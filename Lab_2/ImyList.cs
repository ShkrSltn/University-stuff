namespace СК_список
{
	public interface ImyList
	{
		int Add(object dataToAdd, object data);
		void Remove(object data);
		bool Contains(object data);
		object[] ToArray();
		int Count { get; }
		void MoveNext();
		object CurrentData();
		void RemoveCurrent();
	}
}