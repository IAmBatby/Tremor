using Terraria.ID;
using System;
using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace Tremor.Items
{
	public class ExecutionerAxe : ModItem
	{
		public override void SetDefaults()
		{

			item.damage = 245;
			item.melee = true;
			item.width = 66;
			item.height = 66;
			item.useTime = 45;
			item.useAnimation = 45;
			item.useStyle = 1;
			item.knockBack = 25;
			item.value = 12500;
			item.rare = 11;
			item.UseSound = SoundID.Item71;
			item.autoReuse = false;
			item.useTurn = false;
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Executioner Axe");
			Tooltip.SetDefault("");
		}


		public override void OnHitNPC(Player player, NPC target, int damage, float knockback, bool crit)
		{
			target.AddBuff(39, 120);
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(null, "NightCore", 1);
			recipe.AddIngredient(3467, 6);
			recipe.AddIngredient(null, "MultidimensionalFragment", 8);
			recipe.AddIngredient(null, "ConcentratedEther", 20);
			recipe.SetResult(this);
			recipe.AddTile(412);
			recipe.AddRecipe();
		}
	}
}
