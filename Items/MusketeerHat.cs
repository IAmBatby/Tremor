using Terraria.ModLoader;

namespace Tremor.Items
{
	[AutoloadEquip(EquipType.Head)]
	public class MusketeerHat : ModItem
	{

		public override void SetDefaults()
		{

			item.width = 26;
			item.height = 24;
			item.value = 2500;
			item.rare = 1;
			item.defense = 3;
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Muskeeter Hat");
			Tooltip.SetDefault("");
		}

	}
}
