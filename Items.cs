using Characters;
using RPGTest;
using static System.Net.Mime.MediaTypeNames;

namespace Items
{
	public abstract class Item
	{
		public string Name { get; set; }
		public string Description { get; set; }
		public int value { get; set; }
		public bool deleteOnUse { get; set; }
		public int calidad { get; set; }
		public bool canUse { get; set; }
		public string onUseText { get; set; }

		public Item(string _name, string _description, int _value, bool _deleteOnUse, int _calidad, bool _canUse, string _onUseText)
		{
			Name = _name;
			Description = _description;
			value = _value;
			deleteOnUse = _deleteOnUse;
			calidad = _calidad;
			canUse = _canUse;
			onUseText = _onUseText;
		}
		public abstract void Use(Player player);
	}

	public class Weapon : Item
	{
		public int damage { get; set; }

		public Weapon(string _name = "Sin nombre", string _description = "Sin descripcion", int _value = 1, int _damage = 1, bool _deleteOnUse = true, bool _canUse = true, string _onUseText = "", int _calidad = 0)
			: base(_name, _description, _value, _deleteOnUse, _calidad, _canUse, _onUseText)
		{
			damage = _damage;
			deleteOnUse = _deleteOnUse;
		}

		public override void Use(Player player)
		{
			Console.Clear();
			Console.Write($"Estás usando ");
			Console.ForegroundColor = ConsoleColor.Yellow;
			Console.WriteLine($"\"{Name}\":");
			Console.ForegroundColor = ConsoleColor.Red;
			Console.WriteLine($" > Daño: {damage}");
			Console.ForegroundColor = ConsoleColor.Yellow;
			Console.WriteLine(onUseText);
			Console.ResetColor();
			Console.WriteLine("...");
			Console.ReadKey(true);
			Console.Clear();
		}
	}

	public class Consumables : Item
	{
		public int healing { get; set; }

		public Consumables(string _name = "Sin nombre", string _description = "Sin descripcion", int _value = 1, int _healthChange = 1, bool _deleteOnUse = true, bool _canUse = true, string _onUseText = "", int _calidad = 0)
			: base(_name, _description, _value, _deleteOnUse, _calidad, _canUse, _onUseText)
		{
			healing = _healthChange;
		}

		public override void Use(Player player)
		{
			Console.Clear();
			Console.Write($"Estás usando ");
			Console.ForegroundColor = ConsoleColor.Yellow;
			Console.WriteLine($"\"{Name}\":");

			if (healing >= 0)
			{
				Console.ForegroundColor = ConsoleColor.Green;
				Console.Write(" + ");
			}
			else
			{
				Console.ForegroundColor = ConsoleColor.Red;
				Console.Write(" - ");
			}

			Console.WriteLine($"Cura: {healing}");
			player.health += healing;
			Console.ForegroundColor = ConsoleColor.Yellow;
			Console.WriteLine(onUseText);
			Console.ResetColor();
			Console.Write($"\n > Vida restante:");
			Console.ForegroundColor = ConsoleColor.Red;
			Console.Write($" <3 ");

			if (player.health >= 51)
			{
				Console.ForegroundColor = ConsoleColor.Green;
			}
			else if (player.health <= 50 && player.health >= 1)
			{
				Console.ForegroundColor = ConsoleColor.Yellow;
			}
			else
			{
				Console.ForegroundColor = ConsoleColor.Red;
			}
			Console.Write($"\"{player.health}\"");
			Console.ForegroundColor = ConsoleColor.Red;
			Console.WriteLine($" <3");
			Console.ResetColor();
			Console.WriteLine("...");
			Console.ReadKey(true);
			Console.Clear();
		}
	}

	public class DefaultItem : Item
	{
		public DefaultItem(string _name, string _description, int _value, bool _deleteOnUse, bool _canUse = false, string _onUseText = "", int _calidad = 0)
			: base(_name, _description, _value, _deleteOnUse, _calidad, _canUse, _onUseText)
		{
			canUse = _canUse;
		}

		public override void Use(Player player)
		{
			Console.Clear();
			Console.Write($"Estás usando un/a ");
			Console.ForegroundColor = ConsoleColor.Yellow;
			Console.WriteLine($"\"{Name}\":");
			Console.ForegroundColor = ConsoleColor.Yellow;
			Console.WriteLine(onUseText);
			Console.ResetColor();
			Console.WriteLine("...");
			Console.ReadKey(true);
			Console.Clear();
		}
	}
}