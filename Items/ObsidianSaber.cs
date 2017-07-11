using Terraria.ID;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;

namespace Tremor.Items
{
	public class ObsidianSaber : ModItem
	{
		public override void SetDefaults()
		{
			item.CloneDefaults(ItemID.Arkhalis);

			item.shootSpeed *= 0.75f;
			item.damage = 41;

		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Obsidian Saber");
			Tooltip.SetDefault("");
		}


		public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
		{
			type = mod.ProjectileType("ObsidianSaberPro");
			return base.Shoot(player, ref position, ref speedX, ref speedY, ref type, ref damage, ref knockBack);
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.Obsidian, 100);
			recipe.AddIngredient(ItemID.SoulofNight, 15);
			recipe.AddIngredient(ItemID.SoulofLight, 15);
			recipe.SetResult(this);
			recipe.AddTile(null, "GreatAnvilTile");
			recipe.AddRecipe();
		}
	}
}
