using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Tremor.Items
{
	public class Boonerang : ModItem
	{
		public override void SetDefaults()
		{

			item.damage = 24;
			item.thrown = true;
			item.width = 48;
			item.height = 48;
			item.useTime = 14;
			item.shootSpeed = 12f;
			item.useAnimation = 14;
			item.useStyle = 1;
			item.knockBack = 3f;
			item.shoot = mod.ProjectileType("BoonerangPro");
			item.value = 27600;
			item.rare = 4;
			item.noUseGraphic = true;
			item.UseSound = SoundID.Item1;
			item.autoReuse = false;
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Boonerang");
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

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.Bone, 45);
			recipe.AddIngredient(null, "CursedSoul", 1);
			recipe.SetResult(this);
			recipe.AddTile(134);
			recipe.AddRecipe();
		}

	}
}
