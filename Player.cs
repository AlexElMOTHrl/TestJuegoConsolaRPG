using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ElMothLibs;
using Items;
using Characters;
using RPGTest;
using System.Numerics;

namespace Characters
{
	public class Player
	{
		public string? name { get; set; }
		public List<Item> inventory { get; set; }
		public int health { get; set; }
		public int currentRoom { get; set; }
		public Item? selectedItem { get; set; }

		public Player()
		{
			name = string.Empty;
			inventory = new List<Item>();
			health = 0;
			currentRoom = 0;
			selectedItem = null;
		}

		public void AddItem(Item item, bool _autoSkip = true)
		{
			inventory.Add(item);
			//Console.Clear();
			Console.ForegroundColor = ConsoleColor.Green;
			Console.Write($"+ ");
			Console.ResetColor();
			Console.Write($"Se añadió un/a ");
			switch (item.calidad)
			{
				case 0:
					Console.ForegroundColor = ConsoleColor.White;
					break;
				case 1:
					Console.ForegroundColor = ConsoleColor.Green;
					break;
				case 2:
					Console.ForegroundColor = ConsoleColor.Blue;
					break;
				case 3:
					Console.ForegroundColor = ConsoleColor.Magenta;
					break;
				case 4:
					Console.ForegroundColor = ConsoleColor.DarkYellow;
					break;
				default:
					Console.ForegroundColor = ConsoleColor.Red;
					Console.WriteLine("ERROR (El valor de la calidad no está en rango)");
					Console.ResetColor();
					break;
			}
			Console.Write($"\"{item.Name}\"");
			Console.ResetColor();
			Console.WriteLine($" al inventario... ");
			if (!_autoSkip)
			{
				Console.ReadKey(true);
			}
			
		}

		public void RemoveItem(Item item)
		{

			if (item.deleteOnUse == true)
			{
				inventory.Remove(item);
				Console.Clear();
				Console.ForegroundColor = ConsoleColor.Red;
				Console.Write($"- ");
				Console.ResetColor();
				Console.Write($"Se eliminó un/a ");
				Console.ForegroundColor = ConsoleColor.Yellow;
				Console.Write($"\"{item.Name}\"");
				Console.ResetColor();
				Console.WriteLine($" del inventario... ");
				Console.ReadKey(true);
				Console.Clear();
			}
		}

		public void ViewInventory()
		{
			Console.Clear();
			Console.WriteLine($"Inventario de {name}:");

			if (inventory.Count != 0)
			{
				foreach (Item item in inventory)
				{
					Console.WriteLine(item.Name);
				}
			}
			else { Console.WriteLine(" No hay na. :("); }

			Console.ReadKey();
			Console.Clear();
		}

		public void UseItem(Item item)
		{
			if (inventory.Count <= 0)
			{
				Moth.WriteAndWait("No hay nada que usar...");
				return;
			}
			if (!item.canUse)
			{
				Console.WriteLine($"> Este objeto no se puede usar...");
				return;
			}
			item.Use(RPGTest.Program.player);
			if (item.deleteOnUse == true)
			{
				RemoveItem(item);
			}
		}
	}
}
