using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;

namespace Tremor.Projectiles
{
	public class projManaDagger : ModProjectile
	{
		const int ManaPerHit = 2; // Маны за удар по мобу
		int Mana; // Сколько маны уже собрано
		int Hits = 3; // Лимит ударов с кражей маны
		bool NeedAddMana = true; // Системная переменная

		public override void SetDefaults()
		{

			projectile.width = 14;
			projectile.height = 28;
			projectile.aiStyle = 1;
			projectile.friendly = true;
			projectile.magic = true;
			projectile.penetrate = -1;
			projectile.timeLeft = 3600;
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Mana Dagger");

		}

		public override void AI()
		{
			float Light = 0.635f * (3 - (Hits - 1));
			Lighting.AddLight(projectile.Center, new Vector3(0.0f, Light, Light));
			if (projectile.Distance(Main.player[projectile.owner].Center) > 1000f)
				ReturnToPlayer();
			if (projectile.Distance(Main.player[projectile.owner].Center) < 25f && NeedAddMana && projectile.aiStyle == 3)
			{
				NeedAddMana = false;
				Main.player[projectile.owner].statMana += Mana;
				if (Mana > 0)
					Main.player[projectile.owner].ManaEffect(Mana);
			}
		}

		public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
		{
			if (Hits > 0)
			{
				Mana += ManaPerHit;
				--Hits;
			}
			else
				ReturnToPlayer();
		}

		public override void OnHitPlayer(Player target, int damage, bool crit)
		{
			if (Hits > 0)
			{
				Mana += ManaPerHit;
				--Hits;
			}
			else
				ReturnToPlayer();
		}

		public override void OnHitPvp(Player target, int damage, bool crit)
		{
			if (Hits > 0)
			{
				Mana += ManaPerHit;
				--Hits;
			}
			else
				ReturnToPlayer();
		}

		public override bool OnTileCollide(Vector2 oldVelocity)
		{
			ReturnToPlayer();
			return false;
		}

		void ReturnToPlayer()
		{
			projectile.tileCollide = false;
			projectile.damage /= 2;
			projectile.aiStyle = 3;
		}
	}
}
