using Terraria.ID;
using Terraria.ModLoader;

namespace Tremor.Items.Orcish
{
	public class OrcishBroadsword : ModItem
	{
		public override void SetDefaults()
		{

			item.damage = 20;
			item.melee = true;
			item.width = 48;
			item.height = 48;
			item.useTime = 30;
			item.useAnimation = 20;
			item.useStyle = 1;
			item.knockBack = 2;
			item.value = 2200;
			item.rare = 1;
			item.UseSound = SoundID.Item1;
			item.autoReuse = false;
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Orcish Broadsword");
			Tooltip.SetDefault("");
		}

	}
}
