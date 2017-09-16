using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Tremor.Items
{
	public class DangerBlade : ModItem
	{
		public override void SetDefaults()
		{
			item.CloneDefaults(ItemID.Starfury);

			item.shootSpeed *= 0.75f;

			item.useTime = 6;
			item.useAnimation = 30;
			item.autoReuse = true;
			item.rare = 0;
			item.damage = 255;
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Danger Blade");
		}

		public override void ModifyTooltips(List<TooltipLine> tooltips)
		{
			tooltips[0].overrideColor = new Color(238, 194, 73);
		}

		public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
		{
			type = mod.ProjectileType("DangerBladePro");
			return base.Shoot(player, ref position, ref speedX, ref speedY, ref type, ref damage, ref knockBack);
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(null, "CollapsiumBar", 16);
			recipe.AddIngredient(null, "ClusterShard", 16);
			recipe.AddIngredient(null, "AngryShard", 5);
			recipe.AddIngredient(null, "TrueEssense", 3);
			recipe.AddIngredient(null, "GoldenClaw", 3);
			recipe.SetResult(this);
			recipe.AddTile(null, "DivineForgeTile");
			recipe.AddRecipe();
		}
	}
}
