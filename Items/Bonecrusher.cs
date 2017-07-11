using Terraria.ID;
using Terraria;
using Terraria.ModLoader;

namespace Tremor.Items
{
	public class Bonecrusher : ModItem
	{
		public override void SetDefaults()
		{
			item.autoReuse = true;
			item.useStyle = 1;

			item.shootSpeed = 8f;
			item.shoot = mod.ProjectileType("BonecrusherPro");
			item.damage = 24;
			item.width = 18;
			item.height = 20;
			item.UseSound = SoundID.Item1;
			item.useAnimation = 14;
			item.useTime = 17;
			item.noUseGraphic = true;
			item.noMelee = true;
			item.value = 6000;
			item.knockBack = 4f;
			item.rare = 3;
			item.thrown = true;
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Bonecrusher");
			Tooltip.SetDefault("");
		}


		public override bool CanUseItem(Player player)
		{
			for (int i = 0; i < 1000; ++i)
			{
				if (Main.projectile[i].active && Main.projectile[i].owner == Main.myPlayer && Main.projectile[i].type == item.shoot)
				{
					return false;
				}
			}
			return true;
		}
	}
}
