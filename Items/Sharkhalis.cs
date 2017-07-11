using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Tremor.Items
{
	public class Sharkhalis : ModItem
	{
		public override void SetDefaults()
		{
			item.CloneDefaults(ItemID.Arkhalis);

			item.damage = 30;

		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Sharkhalis");
			Tooltip.SetDefault("");
		}


		public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
		{
			type = mod.ProjectileType("SharkhalisPro");
			return base.Shoot(player, ref position, ref speedX, ref speedY, ref type, ref damage, ref knockBack);
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.Arkhalis, 1);
			recipe.AddIngredient(ItemID.SharkFin, 3);
			recipe.AddIngredient(null, "SharpenedTooth", 6);
			recipe.SetResult(this);
			recipe.AddTile(null, "AltarofEnchantmentsTile");
			recipe.AddRecipe();
		}
	}
}
