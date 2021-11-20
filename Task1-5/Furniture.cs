using System;
using System.Collections.Generic;

namespace Task1_5
{
	class Table : IParts, ITookKit
	{
		private List<string> _parts;
		private List<string> _tools;

		public Table()
		{
			_parts = new List<string>();
			_tools = new List<string>();
		}

		public Table(List<string> parts, List<string> tools)
		{
			_parts = parts;
			_tools = tools;
		}

		public string[] GetParts()
		{
			if (_parts.Count == 0)
			{
				throw new Exception("Parts can't have zero items");
			}

			return _parts.ToArray();
		}

		public string[] GetTools()
		{
			if (_tools.Count == 0)
			{
				throw new Exception("Tools can't have zero items");
			}

			return _tools.ToArray();
		}
	}

	class Chair : IParts, ITookKit
	{
		private List<string> _parts;
		private List<string> _tools;

		public Chair()
		{
			_parts = new List<string>();
			_tools = new List<string>();
		}

		public Chair(List<string> parts, List<string> tools)
		{
			_parts = parts;
			_tools = tools;
		}

		public string[] GetParts()
		{
			if (_parts.Count == 0)
			{
				throw new Exception("Parts can't have zero items");
			}

			return _parts.ToArray();
		}

		public string[] GetTools()
		{
			if (_tools.Count == 0)
			{
				throw new Exception("Tools can't have zero items");
			}

			return _tools.ToArray();
		}
	}
}