using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Tremor.Items
{
	public class MagiumRod : ModItem
	{
		public override void SetDefaults()
		{

			item.damage = 42;
			item.magic = true;
			item.mana = 6;
			item.width = 40;
			item.height = 40;
			item.useTime = 16;
			item.useAnimation = 16;
			item.useStyle = 5;
			item.noMelee = true;
			item.knockBack = 3;
			item.value = 13800;
			item.rare = 5;
			item.UseSound = SoundID.Item43;
			item.autoReuse = false;
			Item.staff[item.type] = true;
			item.shoot = mod.ProjectileType("MagiumRodPro");
			item.shootSpeed = 15f;
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Magium Rod");
			Tooltip.SetDefault("");
		}

		public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
		{
			int i = Main.myPlayer;
			float num72 = item.shootSpeed;
			int num73 = item.damage;
			float num74 = item.knockBack;
			num74 = player.GetWeaponKnockback(item, num74);
			player.itemTime = item.useTime;
			Vector2 vector2 = player.RotatedRelativePoint(player.MountedCenter, true);
			Vector2 value = Vector2.UnitX.RotatedBy(player.fullRotation, default(Vector2));
			Vector2 vector3 = Main.MouseWorld - vector2;
			float num78 = Main.mouseX + Main.screenPosition.X - vector2.X;
			float num79 = Main.mouseY + Main.screenPosition.Y - vector2.Y;
			if (player.gravDir == -1f)
			{
				num79 = Main.screenPosition.Y + Main.screenHeight - Main.mouseY - vector2.Y;
			}
			float num80 = (float)Math.Sqrt(num78 * num78 + num79 * num79);
			float num81 = num80;
			if ((float.IsNaN(num78) && float.IsNaN(num79)) || (num78 == 0f && num79 == 0f))
			{
				num78 = player.direction;
				num79 = 0f;
				num80 = num72;
			}
			else
			{
				num80 = num72 / num80;
			}
			num78 *= num80;
			num79 *= num80;
			int num146 = 4;
			if (Main.rand.NextBool(2))
			{
				num146++;
			}
			if (Main.rand.NextBool(4))
			{
				num146++;
			}
			if (Main.rand.NextBool(8))
			{
				num146++;
			}
			if (Main.rand.Next(16) == 0)
			{
				num146++;
			}
			for (int num147 = 0; num147 < num146; num147++)
			{
				float num148 = num78;
				float num149 = num79;
				float num150 = 0.05f * num147;
				num148 += Main.rand.Next(-35, 36) * num150;
				num149 += Main.rand.Next(-35, 36) * num150;
				num80 = (float)Math.Sqrt(num148 * num148 + num149 * num149);
				num80 = num72 / num80;
				num148 *= num80;
				num149 *= num80;
				float x4 = vector2.X;
				float y4 = vector2.Y;
				Projectile.NewProjectile(x4, y4, num148, num149, mod.ProjectileType("MagiumRodPro"), num73, num74, i, 0f, 0f);
			}
			return false;
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(null, "RuneBar", 12);
			recipe.AddIngredient(null, "Gloomstone", 15);
			recipe.AddIngredient(null, "MagiumShard", 8);
			recipe.SetResult(this);
			recipe.AddTile(134);
			recipe.AddRecipe();
		}
	}
}
