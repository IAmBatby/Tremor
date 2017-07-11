using Terraria;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using Terraria.DataStructures;

namespace Tremor.Items
{
	public class Skullheart : ModItem
	{
		const int ShootType = 270; // ��� ����५�
		const float ShootRange = 600.0f; // ���쭮��� ����५�
		const float ShootKN = 1.0f; // ����뢠��� 
		const int ShootRate = 40; // ����� ����५� (60 - 1 ᥪ㭤�)
		const int ShootCount = 1; // ����஢ �� ����५
		const float ShootSpeed = 30f; // ������� ����५� (��� ����� - ���쭮���)
		const int spread = 45; // ������
		const float spreadMult = 0.045f; // ����䨪��� ࠧ���

		int TimeToShoot = ShootRate;

		public override void SetDefaults()
		{

			item.width = 36;
			item.height = 36;

			item.value = 2500000;
			item.rare = 11;
			item.accessory = true;
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Skullheart");
			Tooltip.SetDefault("Shoots skulls at nearby enemies");
			Main.RegisterItemAnimation(item.type, new DrawAnimationVertical(8, 4));
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
			return (10 * ((int)Main.player[item.owner].magicDamage + (int)Main.player[item.owner].meleeDamage + (int)Main.player[item.owner].minionDamage + (int)Main.player[item.owner].rangedDamage + (int)Main.player[item.owner].thrownDamage)) + 15;
		}

		void Shoot(int Target, int Damage)
		{
			Vector2 velocity = Helper.VelocityToPoint(Main.player[item.owner].Center, Main.npc[Target].Center, ShootSpeed);
			for (int l = 0; l < ShootCount; l++)
			{
				velocity.X = velocity.X + (float)Main.rand.Next(-spread, spread + 1) * spreadMult;
				velocity.Y = velocity.Y + (float)Main.rand.Next(-spread, spread + 1) * spreadMult;
				int i = Projectile.NewProjectile(Main.player[item.owner].Center.X, Main.player[item.owner].Center.Y, velocity.X, velocity.Y, ShootType, Damage, ShootKN, item.owner);
			}
		}
	}
}
