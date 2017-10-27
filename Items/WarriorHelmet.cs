using Terraria.ModLoader;

namespace Tremor.Items
{
	[AutoloadEquip(EquipType.Head)]
	public class WarriorHelmet : ModItem
	{

		public override void SetDefaults()
		{

			item.width = 26;
			item.height = 22;
			item.value = 1000;
			item.rare = 2;
			item.vanity = true;
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Warrior Helmet");
			Tooltip.SetDefault("");
		}

	}
}
