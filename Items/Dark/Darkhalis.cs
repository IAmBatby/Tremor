using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Tremor.Items.Dark
{
	public class Darkhalis : ModItem
	{
		public override void SetDefaults()
		{
			item.CloneDefaults(ItemID.Arkhalis);

			item.damage = 90;

		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Darkhalis");
			Tooltip.SetDefault("'It came from the deep abyss...'");
		}

		public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
		{
			type = mod.ProjectileType("DarkhalisPro");
			return base.Shoot(player, ref position, ref speedX, ref speedY, ref type, ref damage, ref knockBack);
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.Arkhalis, 1);
			recipe.AddIngredient(null, "NightmareBar", 22);
			recipe.AddIngredient(null, "Doomstone", 15);
			recipe.AddIngredient(null, "Phantaplasm", 12);
			recipe.SetResult(this);
			recipe.AddTile(412);
			recipe.AddRecipe();
		}
	}
}
