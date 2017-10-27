using Terraria.ModLoader;

namespace Tremor.ZombieEvent.Items
{
	[AutoloadEquip(EquipType.Head)]
	public class CryptomageSkull : ModItem
	{
		public override void SetDefaults()
		{

			item.width = 26;
			item.height = 24;
			item.rare = 4;
			item.vanity = true;
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Cryptomage Skull");
			Tooltip.SetDefault("");
		}
	}
}
