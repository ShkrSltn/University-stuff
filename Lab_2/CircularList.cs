using СК_список;

namespace СК_циклический_список
{
	/// <summary>
	/// Summary description for CircularList.
	/// </summary>
	public class CircularList : ImyList
	{
		private int count;
		private Node current;

		public CircularList()
		{
			this.count = 0;
			this.current = null;
		}

		public int Add(object dataToAdd, object data)
		{
			int i=0;
			Node cur;
			Node newnode = new Node();
			newnode.Data = dataToAdd;
			if (this.count == 0) {
				this.current = newnode;
				newnode.Next = newnode;
			} else {
				for (i=1,cur = current; i++ < this.count; cur = cur.Next) {
					if (cur.Data.Equals(data)) {
						break;
					}
				}
				newnode.Next = cur.Next;
				cur.Next = newnode;
			}
			this.count++;
			return i;
		}

		public void Remove(object data)
		{
			if (this.count == 0) {
				return;
			}
			if (this.count == 1 && current.Data.Equals(data)) {
				this.count = 0;
				this.current = null;
			} else {
				Node cur = this.current;
				for (int i = 1; i < count; cur = cur.Next) {
					if (cur.Next.Data.Equals(data)) {
						cur.Next = cur.Next.Next;
						this.count--;
						break;
					}
				}
			}
		}

		public bool Contains(object data)
		{
			int i;
			Node cur;
			for (i = 0,cur = current; i < this.count; cur = cur.Next, i++) {
				if (cur.Data.Equals(data)) {
					return true;
				}
			}
			return false;
		}

		public object[] ToArray()
		{
			if (this.count == 0) {
				return null;
			}
			object[] buf = new object[this.count];
			int i;
			Node cur;
			for (i = 0,cur = current; i < this.count; cur = cur.Next, i++) {
				buf[i] = cur.Data;
			}
			return buf;
		}

		public int Count
		{
			get { return this.count; }
		}

		public void MoveNext()
		{
			this.current = current.Next;
		}

		public object CurrentData()
		{
			return current.Data;
		}

		public void RemoveCurrent()
		{
			if (this.count == 0) {
				return;
			}
			if (this.count == 1) {
				this.count = 0;
				this.current = null;
			} else {
				Node prev = current.Next;
				for (int i = 1; i < count; i++) {
					prev = prev.Next;
				}
				prev.Next = current.Next;
				current=current.Next;
				this.count--;
			}
		}
	}
}