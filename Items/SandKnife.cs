using Terraria.ID;
using Terraria.ModLoader;

namespace Tremor.Items
{
	public class SandKnife : ModItem
	{
		public override void SetDefaults()
		{

			item.damage = 22;
			item.melee = true;
			item.width = 32;
			item.height = 32;
			item.useTime = 12;
			item.useAnimation = 12;
			item.useStyle = 3;
			item.useTurn = false;
			item.knockBack = 6f;
			item.scale = 0.9f;
			item.value = 2890;
			item.rare = 2;
			item.UseSound = SoundID.Item1;
			item.autoReuse = false;
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Barkhan");
			Tooltip.SetDefault("");
		}

	}
}
