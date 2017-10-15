using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Tremor.ZombieEvent.Items
{
	public class RupicideRepeater : ModItem
	{
		public override void SetDefaults()
		{

			item.ranged = true;
			item.width = 36;
			item.height = 24;

			item.useTime = 15;
			item.useAnimation = 15;
			item.shoot = 1;
			item.useAmmo = AmmoID.Arrow;
			item.shootSpeed = 30f;
			item.useStyle = 5;
			item.damage = 26;
			item.knockBack = 4;
			item.value = 30000;
			item.rare = 5;
			item.UseSound = SoundID.Item5;
			item.autoReuse = true;
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Rupicide Repeater");
			Tooltip.SetDefault("Quickly launches arrows\n" +
	  "20% to shoot a fiery burst");
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(null, "BowBlueprint", 1);
			recipe.AddIngredient(null, "RupicideBar", 8);
			recipe.AddIngredient(null, "RuneBar", 8);
			recipe.AddIngredient(null, "CryptStone", 3);
			recipe.AddTile(null, "NecromaniacWorkbenchTile");
			recipe.SetResult(this);
			recipe.AddRecipe();
		}

		public override Vector2? HoldoutOffset()
		{
			return new Vector2(-18, -4);
		}

		public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
		{
			type = 1;

			if (Main.rand.Next(5) == 0)
			{
				int proj = Projectile.NewProjectile(position.X, position.Y, speedX, speedY, 686, damage, knockBack, Main.myPlayer);
				Main.projectile[proj].hostile = false;
				Main.projectile[proj].friendly = true;
				return false;
			}

			return base.Shoot(player, ref position, ref speedX, ref speedY, ref type, ref damage, ref knockBack);
		}
	}
}
