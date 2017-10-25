using Terraria.ID;
using Terraria.ModLoader;

namespace Tremor.Items.Orcish
{
	public class OrcishKnife : ModItem
	{
		public override void SetDefaults()
		{

			item.damage = 12;
			item.melee = true;
			item.width = 32;
			item.height = 32;
			item.useTime = 28;
			item.useAnimation = 9;
			item.useStyle = 3;
			item.knockBack = 2;
			item.value = 2200;
			item.rare = 1;
			item.UseSound = SoundID.Item1;
			item.autoReuse = false;
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Orcish Knife");
			Tooltip.SetDefault("");
		}

	}
}
