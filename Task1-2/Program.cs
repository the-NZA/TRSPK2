using System;
using System.Collections;
using System.Collections.Generic;

namespace Task1_2
{
	class Node
	{
		public Node[] Children;
		public string Text;

		public Node(string text, params Node[] children)
		{
			Text = text;
			Children = children;
		}

		public static Node AddNodes(string text, params Node[] children)
		{
			return new Node(text, children);
		}

		public override string ToString()
		{
			return Text;
		}
	}


	public enum TreeTraversalType
	{
		Left,
		Right,
		Root,
		Breadth
	}

	class MyGraph
	{
		public Node Root;

		public MyGraph() => Root = null;

		public void Filling(Node root)
		{
			Root = root;
		}

		private delegate Node[] AnyEnumerator(Node root);

		private Node[] Enumerator(Node root, bool reverse, AnyEnumerator method)
		{
			Node[] result = new Node[0];
			int add_index = 0;
			Node[] children = root.Children;
			if (reverse)
				Array.Reverse(children);

			foreach (var node in children)
			{
				Node[] add = method(node);
				int add_len = add.Length;
				Array.Resize(ref result, result.Length + add_len);
				Array.Copy(add, 0, result, add_index, add_len);
				add_index += add_len;
			}

			return result;
		}

		public Node[] RightEnumerator(Node root)
		{
			Node[] result = new Node[1];
			Node[] add = Enumerator(root, true, RightEnumerator);

			int add_len = add.Length;
			Array.Resize(ref result, result.Length + add_len);
			Array.Copy(add, 0, result, 0, add_len);

			result[add_len] = root;

			return result;
		}

		public Node[] RootEnumerator(Node root)
		{
			Node[] result = new Node[1];
			Node[] add = Enumerator(root, false, RootEnumerator);

			result[0] = root;

			int add_len = add.Length;
			Array.Resize(ref result, result.Length + add_len);
			Array.Copy(add, 0, result, 1, add_len);

			return result;
		}

		public Node[] LeftEnumerator(Node root)
		{
			Node[] result = new Node[1];
			Node[] add = Enumerator(root, false, LeftEnumerator);

			int add_len = add.Length;
			Array.Resize(ref result, result.Length + add_len);
			Array.Copy(add, 0, result, 0, add_len);

			result[add_len] = root;

			return result;
		}

		public Node[] BreadthEnumerator(Node root)
		{
			Node[] result = new Node[0];
			Queue<Node> queue = new Queue<Node>();
			queue.Enqueue(root);

			while (queue.Count != 0)
			{
				Node node = queue.Dequeue();
				foreach (var child in node.Children)
					queue.Enqueue(child);
				int len = result.Length;
				Array.Resize(ref result, len + 1);
				result[len] = node;
			}

			return result;
		}

		public IEnumerable TreeTraversal(TreeTraversalType type)
		{
			AnyEnumerator method = LeftEnumerator;
			switch (type)
			{
				case TreeTraversalType.Left:
				{
					method = LeftEnumerator;
					break;
				}
				case TreeTraversalType.Right:
				{
					method = RightEnumerator;
					break;
				}
				case TreeTraversalType.Root:
				{
					method = RootEnumerator;
					break;
				}
				case TreeTraversalType.Breadth:
				{
					method = BreadthEnumerator;
					break;
				}
			}

			foreach (var node in method(Root))
			{
				yield return node;
			}
		}
	}

	class Program
	{
		public static void Main(string[] args)
		{
			MyGraph g = new MyGraph();

			g.Filling(Node.AddNodes("A",
				Node.AddNodes("B",
					Node.AddNodes("C",
						Node.AddNodes("D",
							Node.AddNodes("E"),
							Node.AddNodes("F")
						)
					),
					Node.AddNodes("G",
						Node.AddNodes("H")
					),
					Node.AddNodes("I",
						Node.AddNodes("J"),
						Node.AddNodes("K")
					)
				),
				Node.AddNodes("L"),
				Node.AddNodes("M",
					Node.AddNodes("N",
						Node.AddNodes("O")
					),
					Node.AddNodes("P")
				),
				Node.AddNodes("Q")
			));

			foreach (Node n in g.TreeTraversal(TreeTraversalType.Left))
				Console.Write(n.ToString() + ' ');
			Console.WriteLine(' ');
			foreach (Node n in g.TreeTraversal(TreeTraversalType.Right))
				Console.Write(n.ToString() + ' ');
			Console.WriteLine(' ');
			foreach (Node n in g.TreeTraversal(TreeTraversalType.Root))
				Console.Write(n.ToString() + ' ');
			Console.WriteLine(' ');
			foreach (Node n in g.TreeTraversal(TreeTraversalType.Breadth))
				Console.Write(n.ToString() + ' ');
			Console.WriteLine(' ');
		}
	}
}