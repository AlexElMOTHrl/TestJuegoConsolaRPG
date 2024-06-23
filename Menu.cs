using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Items;
using Characters;

namespace Menus
{
	public class Menu
	{
		public enum MenuOptions
		{
			Inventory,
			Move,
			Use,
			Quit
		}

		public void ShowMenu(int selectedOption)
		{
			Console.Clear();
			Console.WriteLine("Use las flechas para navegar y Enter para seleccionar:");

			foreach (MenuOptions option in Enum.GetValues(typeof(MenuOptions)))
			{
				int optionIndex = (int)option;
				if (optionIndex == selectedOption)
				{
					Console.ForegroundColor = ConsoleColor.Yellow;
					Console.WriteLine($"> {option}");
					Console.ResetColor();
				}
				else
				{
					Console.WriteLine($"  {option}");
				}
			}
		}

		public void ShowItemsListMenu(int selectedOption, List<Item> items)
		{
			Console.Clear();
			Console.WriteLine("Use las flechas para navegar y Enter para seleccionar:");

			foreach (Item item in items)
			{
				int itemIndex = items.IndexOf(item);
				if (itemIndex == selectedOption)
				{
					Console.ForegroundColor = ConsoleColor.Yellow;
					Console.WriteLine($"> {item.Name}");
					Console.ForegroundColor = ConsoleColor.DarkYellow;
					Console.WriteLine($"  Descripcion: {item.Description}");
					Console.ResetColor();
				}
				else
				{
					Console.WriteLine($"  {item.Name}");
				}
			}
		}

		public int SelectOption(string menuType, List<Item>? items = null)
		{
			int option = 0;
			bool enumMode = true;
			ConsoleKeyInfo key;

			while (true)
			{
				switch (menuType)
				{
					case "menu":
						enumMode = true;
						ShowMenu(option);
						break;
					case "inv":
						enumMode = false;
						if (items == null) { Console.WriteLine("items es Null"); break; }
						ShowItemsListMenu(option, items);
						break;
					default: Console.WriteLine("Menu no encontrado"); break;
				}
				//Console.WriteLine(option);
				key = Console.ReadKey(true);

				switch (key.Key)
				{
					case ConsoleKey.UpArrow:
						option--;
						if (option < 0)
						{
							if (enumMode)
							{
								option = Enum.GetValues(typeof(MenuOptions)).Length - 1;
							}
							else
							{
								option = (items != null ? items.Count : 0) - 1;
							}
						}
						break;
					case ConsoleKey.DownArrow:
						option++;
						if (option > (enumMode ? Enum.GetValues(typeof(MenuOptions)).Length - 1 : (items != null ? items.Count - 1 : 0)))
						{
							if (enumMode)
							{
								option = 0;
							}
							else
							{
								option = 0;
							}
						}
						break;
					case ConsoleKey.Enter:
						return option;
				}
			}
		}
	}
}
