namespace ��_�����������_������
{
	/// <summary>
	/// Summary description for Node.
	/// </summary>
	public class Node
	{
		private object data;
		private Node next;

		public Node()
		{
			this.data = this.next = null;
		}

		public Node(object data, Node next)
		{
			this.data = data;
			this.next = next;
		}

		/// <summary>
		/// ������ �� ��������� �������
		/// </summary>
		public Node Next
		{
			get { return this.next; }
			set { this.next = value; }
		}
		/// <summary>
		/// ������ ����
		/// </summary>
		public object Data
		{
			get { return this.data; }
			set { this.data = value; }
		}
	}
}