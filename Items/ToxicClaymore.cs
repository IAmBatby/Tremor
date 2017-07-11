using Terraria.ID;
using Terraria;
using Terraria.ModLoader;

namespace Tremor.Items
{
	public class ToxicClaymore : ModItem
	{
		public override void SetDefaults()
		{

			item.damage = 26;
			item.melee = true;
			item.width = 40;
			item.height = 52;
			item.useTime = 21;
			item.useAnimation = 21;
			item.useStyle = 1;
			item.knockBack = 6;
			item.value = 660;
			item.rare = 1;
			item.UseSound = SoundID.Item1;
			item.autoReuse = true;
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Toxic Claymore");
			Tooltip.SetDefault("");
		}


		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(null, "ToxicHilt", 1);
			recipe.AddIngredient(null, "ToxicBlade", 1);
			recipe.AddIngredient(null, "BottledGlue", 1);
			recipe.SetResult(this);
			recipe.AddTile(null, "GreatAnvilTile");
			recipe.AddRecipe();
		}

		public override void OnHitNPC(Player player, NPC target, int damage, float knockback, bool crit)
		{
			if (Main.rand.Next(3) == 0)
			{
				target.AddBuff(70, 1200);
			}
		}
	}
}
