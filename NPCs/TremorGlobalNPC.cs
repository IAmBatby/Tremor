using Terraria;
using Terraria.ModLoader;

using Microsoft.Xna.Framework;

namespace Tremor.NPCs
{
	public class TremorGlobalNPC : GlobalNPC
	{
		public override bool InstancePerEntity => true;

		public bool dFear;
		public bool Irradiated = false;

		public override void ResetEffects(NPC npc)
		{
			dFear = false;
		}

		public override void UpdateLifeRegen(NPC npc, ref int damage)
		{
			if (dFear)
			{
				if (npc.lifeRegen > 0)
					npc.lifeRegen = 0;

				npc.lifeRegen -= 50;
				if (damage < 50)
					damage = 50;
			}
		}

		public override void DrawEffects(NPC npc, ref Color drawColor)
		{
			if (dFear)
			{
				if (Main.rand.Next(4) < 3)
				{
					Dust dust = Main.dust[Dust.NewDust(npc.position - new Vector2(2f, 2f), npc.width + 4, npc.height + 4, mod.DustType<Dusts.NightmareFlame>(), npc.velocity.X * 0.4f, npc.velocity.Y * 0.4f, 100, default(Color), 3.5f)];
					dust.noGravity = true;
					dust.velocity *= 1.8f;
					dust.velocity.Y -= 0.5f;
					if (Main.rand.NextBool(4))
					{
						dust.noGravity = false;
						dust.scale *= 0.5f;
					}
				}
				Lighting.AddLight(npc.position, 0.1f, 0.2f, 0.7f);
			}
		}
	}
}