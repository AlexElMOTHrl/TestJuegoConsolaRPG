using Items;
using System.Xml.Linq;

namespace Rooms
{
	internal class Room
	{
		public string? name { get; set; }
		public string? description { get; set; }
		public List<Item> inventory { get; set; }
		public int roomID { get; set; }

		public Room()
		{
			name = string.Empty;
			description = string.Empty;
			inventory = new List<Item>();
			roomID = 0;
		}

		public void Describe()
		{
			Console.WriteLine($"Estás en {name}. {description}");
			if (inventory.Count > 0)
			{
				Console.WriteLine("Puedes ver los siguientes ítems:");
				foreach (var item in inventory)
				{
					Console.WriteLine($"- {item.Name}");
				}
			}
			else
			{
				Console.WriteLine("No hay ítems aquí.");
			}
		}

	}
}
