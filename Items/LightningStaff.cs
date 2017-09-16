using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Tremor.Items
{
	public class LightningStaff : ModItem
	{
		public override void SetDefaults()
		{

			item.mana = 22;
			item.UseSound = SoundID.Item82;
			item.useStyle = 5;
			item.damage = 180;
			item.useTime = 40;
			item.useAnimation = 40;
			item.width = 36;
			item.height = 40;
			item.shoot = 580;
			item.shootSpeed = 13f;

			item.knockBack = 4.4f;
			Item.staff[item.type] = true;
			item.magic = true;
			item.autoReuse = true;
			item.value = 100000;
			item.rare = 11;
			item.noMelee = true;
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Lightning Staff");
			Tooltip.SetDefault("Sends out huge lightnings");
		}

		public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
		{
			Vector2 vector82 = -Main.player[Main.myPlayer].Center + Main.MouseWorld;
			float ai = Main.rand.Next(100);
			Vector2 vector83 = Vector2.Normalize(vector82) * item.shootSpeed;
			Projectile.NewProjectile(player.Center.X, player.Center.Y, vector83.X, vector83.Y, type, damage, .490f, player.whoAmI, vector82.ToRotation(), ai);
			return false;
		}

	}
}
