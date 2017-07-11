using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Tremor.Items
{

	public class Vindicator : ModItem
	{

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Vindicator");
			Tooltip.SetDefault("");
		}

		public override void SetDefaults()
		{
			item.damage = 200;
			item.ranged = true;
			item.width = 76;
			item.height = 26;
			item.useTime = 9;
			item.useAnimation = 9;
			item.channel = true;
			item.noUseGraphic = true;
			item.noMelee = true;
			item.useStyle = 5;
			item.knockBack = 6;
			item.value = Item.buyPrice(15, 00);
			item.rare = 11;
			//item.UseSound = SoundID.Item23;
			item.autoReuse = true;
			item.shoot = mod.ProjectileType("VindicatorProj");
			item.shootSpeed = 45f;
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(null, "CarbonSteel", 15);
			recipe.AddIngredient(null, "NightmareBar", 18);
			recipe.AddIngredient(ItemID.IllegalGunParts, 3);
			recipe.AddIngredient(ItemID.LaserMachinegun, 1);
			recipe.AddIngredient(ItemID.SoulofNight, 8);
			recipe.AddIngredient(null, "MultidimensionalFragment", 9);
			recipe.SetResult(this);
			recipe.AddTile(412);
			recipe.AddRecipe();
		}

		public override Vector2? HoldoutOffset()
		{
			return new Vector2(-12, -7);
		}

		public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
		{
			Projectile.NewProjectile(position.X, position.Y, speedX, speedY, type, damage, knockBack, player.whoAmI, 0.0f, 0.0f);
			return false;
		}
	}
}