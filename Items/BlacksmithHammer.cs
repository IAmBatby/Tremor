using Terraria.ID;
using Terraria.ModLoader;

namespace Tremor.Items
{
	public class BlacksmithHammer : ModItem
	{
		public override void SetDefaults()
		{

			item.damage = 27;
			item.melee = true;
			item.width = 56;
			item.height = 56;
			item.useTime = 22;
			item.useAnimation = 45;
			item.useStyle = 1;
			item.knockBack = 3;
			item.value = 15000;
			item.rare = 3;
			item.UseSound = SoundID.Item1;
			item.autoReuse = false;
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Blacksmith Hammer");
			Tooltip.SetDefault("");
		}

	}
}
