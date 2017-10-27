using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Tremor.Items
{
	public class Obscuritron : ModItem
	{
		public override void SetDefaults()
		{
			item.autoReuse = true;

			item.useStyle = 1;
			item.useAnimation = 25;
			item.useTime = 25;
			item.knockBack = 5.5f;
			item.width = 40;
			item.height = 40;
			item.damage = 260;
			item.scale = 1.15f;
			item.UseSound = SoundID.Item1;
			item.rare = 11;
			item.value = 430000;
			item.melee = true;
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Obscuritron");
			Tooltip.SetDefault("");
		}

		public override void MeleeEffects(Player player, Rectangle hitbox)
		{
			if (Main.rand.NextBool(3))
			{
				int dust = Dust.NewDust(new Vector2(hitbox.X, hitbox.Y), hitbox.Width, hitbox.Height, mod.DustType<Dusts.NightmareFlame>());
			}
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(null, "NightmareBar", 30);
			recipe.AddIngredient(null, "PhantomSoul", 15);
			recipe.AddIngredient(null, "Phantaplasm", 20);
			recipe.AddIngredient(null, "ConcentratedEther", 25);
			recipe.AddTile(412);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}
