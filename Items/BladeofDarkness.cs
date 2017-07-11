using Terraria.ID;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;

namespace Tremor.Items
{
	public class BladeofDarkness : ModItem
	{
		public override void SetDefaults()
		{

			item.damage = 75;
			item.melee = true;
			item.width = 50;
			item.height = 52;
			item.useTime = 25;
			item.useAnimation = 25;
			item.useStyle = 1;
			item.shoot = mod.ProjectileType("GloomSphere");
			item.shootSpeed = 10f;
			item.knockBack = 4;
			item.value = 10000;
			item.rare = 8;
			item.UseSound = SoundID.Item71;
			item.autoReuse = false;
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Blade of Darkness");
			Tooltip.SetDefault("");
		}


		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.SoulofNight, 12);
			recipe.AddIngredient(ItemID.Amethyst, 10);
			recipe.AddIngredient(ItemID.BoneSword);
			recipe.SetResult(this);
			recipe.AddTile(16);
			recipe.AddRecipe();
		}


		public override void MeleeEffects(Player player, Rectangle hitbox)
		{
			int dust = Dust.NewDust(new Vector2(hitbox.X, hitbox.Y), hitbox.Width, hitbox.Height, 27);
		}
	}
}
