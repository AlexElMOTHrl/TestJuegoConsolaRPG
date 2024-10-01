// © 2024 AlexElMOTH
// Todos los derechos reservados.
//
// Este código es propiedad exclusiva de AlexElMOTH.
// Queda prohibida la redistribución y uso de este código en forma de fuente y binario
// sin el permiso explícito por escrito del autor.
//
// El código se proporciona "tal cual", sin garantía de ningún tipo, expresa o implícita,
// incluyendo

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

#if DEBUG
		#region Load Debug Weapons

		#region Weapons
		public static Weapon pollon = new Weapon("Pollón", ":D", 183719, 999, false, true, "¡TOMA POLLAZO!", 4);
		#endregion Weapons

		#region Consumables
		public static Consumables cojones = new Consumables("Par de cojones", "De lo pesados que son sus cojones, por cada paso que da, cae un edificio.", 1000, -99, true, true, "Vale, pero por qué.", 4);
		public static Consumables mujer = new Consumables("Mujer", "Pues eso, una tia..", 2, -1, true, true, "Illo, ¿qué?, no te la comas :(", 3);
		public static Consumables healingPotion = new Consumables("Poción de curación", "Cura 50 de vida.", 100, 50, true, true, "Fentanilo rojo? líquido!!??!!?", 1);
		#endregion Consumables

		#region DefaultItems
		public static DefaultItem funtoy = new DefaultItem("PEDAZO de dildo", "Nunca sabes cuando lo vas a necesitar. 10 minutos?... 5 minutos??? Ni idea.", 5, false, true, "BzzzZzzZZzzzzzZZZZzzz...", 2);
		#endregion DefaultItems

		#endregion Load Debug Weapons
#endif


		#region Load Weapons

		#region Weapons
		public static Weapon espadaLarga = new Weapon(
			_name: "Mandoble",
			_description: "Una espada larga y afilada",
			_value: 150,
			_damage: 25,
			_deleteOnUse: false,
			_canUse: true,
			_onUseText: "Usaste el mandoble y atacaste al enemigo",
			_calidad: 3
		);

		public static Weapon arco = new Weapon(
			_name: "Arco de madera",
			_description: "Un arco con flechas",
			_value: 120,
			_damage: 18,
			_deleteOnUse: false,
			_canUse: true,
			_onUseText: "Usaste tu Arco y disparaste una flecha",
			_calidad: 2
		);

		public static Weapon hachaDeGuerra = new Weapon(
			_name: "Hacha de Guerra",
			_description: "Un hacha pesada.",
			_value: 200,
			_damage: 35,
			_deleteOnUse: false,
			_canUse: true,
			_onUseText: "Usaste el Hacha de Guerra y golpeaste al enemigo",
			_calidad: 4
		);
		#endregion Weapons

		#region Consumables
		public static Consumables pocionDeVida = new Consumables(
			_name: "Poción de Vida",
			_description: "Una poción que restaura 50 de salud.",
			_value: 100,
			_healthChange: 50,
			_deleteOnUse: true,
			_canUse: true,
			_onUseText: "Bebiste la Poción y recuperastes salud.",
			_calidad: 3
		);

		public static Consumables agua = new Consumables(
			_name: "Botella de agua",
			_description: "Por si te da sed.",
			_value: 20,
			_healthChange: 10,
			_deleteOnUse: true,
			_canUse: true,
			_onUseText: "Bebiste agua y recuperaste un poco de salud",
			_calidad: 2
		);

		public static Consumables pan = new Consumables(
			_name: "Pan",
			_description: "Un pan casero que restaura una pequeña cantidad de salud",
			_value: 10,
			_healthChange: 15,
			_deleteOnUse: true,
			_canUse: true,
			_onUseText: "Comiste Pan y recuperaste un poco de salud",
			_calidad: 2
		);

		public static Consumables manzanaDorada = new Consumables(
			_name: "Manzana Dorada",
			_description: "Una manzana dorada que restaura mucha salud",
			_value: 230,
			_healthChange: 90,
			_deleteOnUse: true,
			_canUse: true,
			_onUseText: "Comiste una Manzana Dorada y recuperaste mucha salud",
			_calidad: 4
		);

		public static Consumables bebidaEnergetica = new Consumables(
			_name: "Bebida Energética",
			_description: "Una bebida que te da un impulso de energía.",
			_value: 25,
			_healthChange: 15,
			_deleteOnUse: true,
			_canUse: true,
			_onUseText: "Bebiste la Bebida Energética y te sientes lleno de energía.",
			_calidad: 1
		);
		#endregion Consumables

		#region DefaultItems
		public static DefaultItem piedra = new DefaultItem(
			_name: "Piedra",
			_description: "Una piedra",
			_value: 2,
			_deleteOnUse: false,
			_canUse: true,
			_onUseText: "Observaste la detenidamente, pero no hace nada",
			_calidad: 1
);
		#endregion DefaultItems

		#endregion Load Weapons


		private static void Main(string[] args)
		{
			Console.CursorVisible = false;

			bool gameRunning = true;

			player.name = null;
			player.health = 100;
			player.currentRoom = 0;

			player.inventory.Add(new DefaultItem("Atrás", "Volver al menú anterior", 0, false, true));

#if DEBUGDELAYS
			Moth.WritingAnimation("Esto es un texto animado.\nEsto es un segundo de delay con un punto...\nY esto es el delay de la coma, kill, your, self.\nAhora esto es un delay custom de 3 segundos.ª3000\nY este de 5 segundos.ª5000\n:3\n");
			Moth.WritingAnimation("Aquí me suda la polla el delay...................,,,,,,,,,,,,,,........,,,,,,,,,.,.,.,.,.,.,.ª3000\n", false, false, useCustomDelay: false);
			Moth.WritingAnimation("Ahora el delay entre caracteres es mas grande.\n", false, true, 75);
#endif

			Console.CursorVisible = true;

#if DEBUG
			player.name = "AlexElMOTH";
#endif

			while (player.name == null || player.name == "")
			{
				Moth.WritingAnimation("Como quieres llamarte...\nª500 > Nombre: ", false, false, 25, true);
				Console.ForegroundColor = ConsoleColor.Yellow;
				player.name = Console.ReadLine();
				Console.ResetColor();
				Console.Clear();
			}
			Console.CursorVisible = false;

			Moth.WritingAnimation($"Bienvenido ", false);
			Console.ForegroundColor = ConsoleColor.Yellow;
			Moth.WritingAnimation(player.name, false);
			Console.ResetColor();
			Moth.WritingAnimation($"\n> Pulsa cualquier tecla para empezar a jugar...", true, false);

			Console.Clear();

#if DEBUG
			Console.Clear();
			player.AddItem(pollon);
			player.AddItem(cojones);
			player.AddItem(healingPotion);
			player.AddItem(mujer);
			player.AddItem(funtoy);
			Console.Clear();
			Moth.WriteAndWait("De regalo <3");
#endif

			player.AddItem(espadaLarga);
			player.AddItem(arco);
			player.AddItem(hachaDeGuerra);
			player.AddItem(pocionDeVida);
			player.AddItem(pan);
			player.AddItem(manzanaDorada);
			player.AddItem(bebidaEnergetica);
			player.AddItem(piedra, false);

			Menu menu = new Menu();

			while (gameRunning)
			{
				int choice = menu.SelectOption("menu");
				MenuOptions selectedOption = (MenuOptions)choice;

				switch (selectedOption)
				{
					case MenuOptions.Inventory:
						Console.WriteLine("Mostrando inventario...");
						player.UseItem(player.inventory[menu.SelectOption("inv", player.inventory)]);
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

				//if (gameRunning)
				//{
				//	Moth.WriteAndWait("Pulsa cualquier tecla para volver...");
				//}
			}
		}
	}
}
