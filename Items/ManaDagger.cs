using Terraria.ID;
using Terraria;
using Terraria.ModLoader;

namespace Tremor.Items
{
	public class ManaDagger : ModItem
	{
		public override void SetDefaults()
		{

			item.width = 14;
			item.height = 28;
			item.rare = 7;
			item.damage = 30;
			item.magic = true;
			item.mana = 12;


			item.useTime = 8;
			item.useAnimation = 8;
			item.useStyle = 5;
			item.noMelee = true;
			item.knockBack = 1;
			item.value = 270000;
			item.UseSound = SoundID.Item20;
			item.autoReuse = false;
			item.shoot = mod.ProjectileType("projManaDagger");
			item.shootSpeed = 15f;
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Mana Dagger");
			Tooltip.SetDefault("A magical returning dagger\nGives mana after hitting an enemy and returning");
		}

	}
}
