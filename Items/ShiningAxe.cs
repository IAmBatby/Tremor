using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Tremor.Items
{
	public class ShiningAxe : ModItem
	{
		public override void SetDefaults()
		{
			item.autoReuse = true;
			item.useStyle = 1;

			item.shootSpeed = 8f;
			item.shoot = mod.ProjectileType("ShiningAxePro");
			item.damage = 234;
			item.width = 18;
			item.height = 20;
			item.UseSound = SoundID.Item1;
			item.useAnimation = 14;
			item.useTime = 17;
			item.noUseGraphic = true;
			item.noMelee = true;
			item.value = 6000;

			item.knockBack = 4f;
			item.melee = true;
			item.rare = 3;
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Shining Axe");
			Tooltip.SetDefault("Magical throwing axe!");
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


		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.PossessedHatchet, 1);
			recipe.AddIngredient(null, "WhiteGoldBar", 15);
			recipe.SetResult(this);
			recipe.AddTile(null, "DivineForgeTile");
			recipe.AddRecipe();
		}
	}
}
