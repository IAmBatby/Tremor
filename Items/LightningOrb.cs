using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Tremor.Items
{
	public class LightningOrb : ModItem
	{
		public override void SetDefaults()
		{

			item.damage = 50;
			item.magic = true;
			item.width = 10;
			item.height = 10;

			item.useTime = 60;
			item.useAnimation = 60;
			item.useStyle = 5;
			item.UseSound = SoundID.Item81;
			item.noMelee = true;
			item.knockBack = 1;
			item.value = 10000;
			item.rare = 5;
			item.autoReuse = false;
			item.shoot = 580;
			item.shootSpeed = 7f;
			item.mana = 30;
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Lightning Orb");
			Tooltip.SetDefault("Creates a divine lightning");
		}

		public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
		{
			Vector2 vector82 = -Main.player[Main.myPlayer].Center + Main.MouseWorld;
			float ai = Main.rand.Next(100);
			Vector2 vector83 = Vector2.Normalize(vector82) * item.shootSpeed;
			Projectile.NewProjectile(player.Center.X, player.Center.Y, vector83.X, vector83.Y, type, damage, .5f, player.whoAmI, vector82.ToRotation(), ai);
			return false;
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.Glass, 30);
			recipe.AddIngredient(null, "AirFragment", 16);
			recipe.AddIngredient(ItemID.SoulofLight, 12);
			recipe.AddIngredient(ItemID.SoulofNight, 12);
			recipe.AddIngredient(ItemID.Diamond, 15);
			recipe.AddIngredient(ItemID.RainCloud, 25);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}
