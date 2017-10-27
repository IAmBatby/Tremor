using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Tremor.Items.Desert
{
	public class DesertClaymore : ModItem
	{
		public override void SetDefaults()
		{

			item.width = 30;
			item.height = 60;
			item.rare = 9;
			item.expert = true;
			item.damage = 23;
			item.magic = true;
			item.mana = 20;

			item.useTime = 8;
			item.useAnimation = 8;
			item.useStyle = 5;
			item.noMelee = true;
			item.knockBack = 1;
			item.value = 270000;
			item.UseSound = SoundID.Item20;
			item.autoReuse = false;
			item.noUseGraphic = true;
			item.shoot = mod.ProjectileType("DesertClaymorePro");
			item.shootSpeed = 0f;
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Desert Claymore");
			Tooltip.SetDefault("");
		}

		public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
		{
			Projectile.NewProjectile(position.X, position.Y, 0, 0, type, damage, knockBack, player.whoAmI, player.direction);
			return false;
		}

		public override bool CanUseItem(Player player)
		{
			for (int i = 0; i < Main.projectile.Length; i++)
			{
				if (Main.projectile[i].type == mod.ProjectileType("DesertClaymorePro") && Main.projectile[i].owner == item.owner && Main.projectile[i].active)
				{
					Main.projectile[i].aiStyle = 3;
					return false;
				}
			}
			return true;
		}

	}
}
