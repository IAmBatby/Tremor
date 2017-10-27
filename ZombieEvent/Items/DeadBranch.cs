using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Tremor.ZombieEvent.Items
{
	public class DeadBranch : ModItem
	{
		public override void SetDefaults()
		{

			item.damage = 16;
			item.width = 40;
			item.height = 20;
			item.useTime = 15;
			item.useAnimation = 15;
			item.useStyle = 5;
			item.magic = true;
			item.mana = 7;
			item.noMelee = true;

			item.knockBack = 6;
			item.value = 10000;
			item.rare = 3;
			item.UseSound = SoundID.Item43;
			item.autoReuse = true;
			item.shoot = 10;
			item.shootSpeed = 20f;
			Item.staff[item.type] = true;
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Dead Branch");
			Tooltip.SetDefault("Shoots shadow bolts");
		}

		public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
		{
			int proj = Projectile.NewProjectile(position.X, position.Y, speedX, speedY, 671, damage, knockBack, Main.myPlayer);
			Main.projectile[proj].hostile = false;
			Main.projectile[proj].friendly = true;
			return false;
		}
	}
}
