using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;

namespace Tremor.Items
{
	public class WallOfShadowsFlask : ModItem
	{
		const float ShootRange = 600.0f;
		const float ShootKN = 1.0f;
		const int ShootRate = 180;
		int ShootCount = 3;
		const float ShootSpeed = 8f;
		const int spread = 45;
		const float spreadMult = 0.045f;
		int TimeToShoot = ShootRate;

		public override void SetDefaults()
		{

			item.damage = 70;
			item.knockBack = 3;
			item.width = 26;
			item.height = 30;

			item.value = 00250000;
			item.rare = 9;
			item.expert = true;
			item.accessory = true;
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Flask of Shadows");
			Tooltip.SetDefault("Casts shadow flask at nearby enemies \nThe less health, the more count of flasks");
		}


		public override void UpdateAccessory(Player player, bool hideVisual)
		{
			if (--TimeToShoot <= 0)
			{
				TimeToShoot = ShootRate;
				int Target = GetTarget();
				if (Target != -1) Shoot(Target, GetDamage());
			}
		}

		int GetTarget()
		{
			int Target = -1;
			for (int k = 0; k < Main.npc.Length; k++)
			{
				if (Main.npc[k].active && Main.npc[k].lifeMax > 5 && !Main.npc[k].dontTakeDamage && !Main.npc[k].friendly && Main.npc[k].Distance(Main.player[item.owner].Center) <= ShootRange && Collision.CanHitLine(Main.player[item.owner].Center, 4, 4, Main.npc[k].Center, 4, 4))
				{
					Target = k;
					break;
				}
			}
			return Target;
		}

		int GetDamage()
		{
			return (10 * (int)Main.player[item.owner].GetModPlayer<MPlayer>(mod).alchemistDamage) + 50;
		}

		void Shoot(int Target, int Damage)
		{
			if (Main.player[item.owner].statLife < 50)
			{
				ShootCount = 7;
			}
			if (Main.player[item.owner].statLife < 100)
			{
				ShootCount = 6;
			}
			if (Main.player[item.owner].statLife < 200)
			{
				ShootCount = 5;
			}
			if (Main.player[item.owner].statLife < 300)
			{
				ShootCount = 4;
			}

			Vector2 velocity = Helper.VelocityToPoint(Main.player[item.owner].Center, Main.npc[Target].Center, ShootSpeed);
			for (int l = 0; l < ShootCount; l++)
			{
				velocity.X = velocity.X + Main.rand.Next(-spread, spread + 1) * spreadMult;
				velocity.Y = velocity.Y + Main.rand.Next(-spread, spread + 1) * spreadMult;
				int i = Projectile.NewProjectile(Main.player[item.owner].Center.X, Main.player[item.owner].Center.Y, velocity.X, velocity.Y, mod.ProjectileType("WallOfShadowsFlask_Proj"), Damage, ShootKN, item.owner);
			}
		}
	}
}
