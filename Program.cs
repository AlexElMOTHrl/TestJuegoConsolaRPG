using Items;
using Menus;
using Characters;
using ElMothLibs;
using static Menus.Menu;

namespace RPGTest
{
	internal class Program
	{
		public static Player player = new Player();

		#region Load Weapons

		#region Weapons
		public static Weapon pollon = new Weapon("Pollón", "Esto que ves es la grandiosa polla del creador...", 183719, 999, false, true, "¡TOMA POLLAZO!", 4);
		#endregion Weapons

		#region Consumables
		public static Consumables cojones = new Consumables("Par de cojones", "De lo pesados que son sus cojones, por cada paso que da se cambia la zona horaria por 1 hora.", 1000, -99, true, true, "Vale, pero por qué.", 4);
		public static Consumables mujer = new Consumables("Mujer", "Un chocho con patas.", 2, -1, true, true, "Illo qué, no te la comas :(", 3);
		public static Consumables healingPotion = new Consumables("Poción de curación", "Cura 50 de vida.", 100, 50, true, true, "Fentanilo rojo... y LÍQUIDO?!!??!!?", 1);
		#endregion Consumables

		#region DefaultItems
		public static DefaultItem funtoy = new DefaultItem("PEDAZO de dildo", "Nunca sabes cuando lo vas a necesitar. 10 minutos?... 5 minutos??? Ni idea.", 5, false, true, "BzzzZzzZZzzzzzZZZZzzz...", 2);
		#endregion DefaultItems

		#endregion Load Weapons

		private static void Main(string[] args)
		{
			bool gameRunning = true;

			player.name = null;
			player.health = 100;
			player.currentRoom = 0;

			Console.WriteLine("Escribe tu nombre :D");

			while (player.name == null)
			{
				player.name = Console.ReadLine();
			}

			Console.Clear();
			Moth.WriteAndWait($"Bienvenido {player.name}\n > Pulsa cualquier tecla para continuar...");
			Console.Clear();

			Console.Clear();
			player.AddItem(pollon);
			player.AddItem(cojones);
			player.AddItem(healingPotion);
			player.AddItem(mujer);
			player.AddItem(funtoy, false);
			Console.Clear();

			Moth.WriteAndWait("De regalo <3");

			//player.RemoveItem(mujer);
			//Moth.WriteAndWait("):");

			//player.UseItem(pollon);
			//player.UseItem(cojones);
			//player.UseItem(healingPotion);
			//player.UseItem(mujer);
			//player.UseItem(funtoy);

			Menu menu = new Menu();

			while (gameRunning)
			{
				int choice = menu.SelectOption("menu");
				MenuOptions selectedOption = (MenuOptions)choice;

				switch (selectedOption)
				{
					case MenuOptions.Inventory:
						Console.WriteLine("Mostrando inventario...");
						menu.SelectOption("inv", player.inventory);
						//player.ViewInventory();

						break;
					case MenuOptions.Move:
						Console.WriteLine("Moviéndose a otra habitación...");
						break;
					case MenuOptions.Use:
						Console.WriteLine("Usando ítem...");
						break;
					case MenuOptions.Quit:
						gameRunning = false;
						Console.WriteLine("Saliendo del juego...");
						break;
				}

				if (gameRunning)
				{
					Moth.WriteAndWait("Pulsa cualquier tecla para volver...");
				}
			}
		}
	}
}