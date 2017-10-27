using Terraria.ID;
using Terraria.ModLoader;

namespace Tremor.Items
{
	public class Spearaxe : ModItem
	{
		public override void SetDefaults()
		{

			item.damage = 66;
			item.melee = true;
			item.width = 56;
			item.height = 56;
			item.useTime = 26;
			item.useAnimation = 26;
			item.useStyle = 1;
			item.knockBack = 3;
			item.value = 125500;
			item.axe = 22;
			item.rare = 6;
			item.UseSound = SoundID.Item1;
			item.autoReuse = true;
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Spearaxe");
			Tooltip.SetDefault("");
		}

	}
}
