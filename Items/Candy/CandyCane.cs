using Terraria.ID;
using Terraria.ModLoader;

namespace Tremor.Items.Candy
{
	public class CandyCane : ModItem
	{
		public override void SetDefaults()
		{

			item.damage = 14;
			item.melee = true;
			item.width = 32;
			item.height = 28;
			item.useTime = 32;
			item.useAnimation = 22;
			item.useStyle = 1;
			item.knockBack = 7;
			item.value = 2000;
			item.rare = 1;
			item.UseSound = SoundID.Item1;
			item.autoReuse = true;
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Candy Cane");
			Tooltip.SetDefault("");
		}

	}
}
