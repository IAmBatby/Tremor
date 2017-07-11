using Terraria.ID;
using System;
using System.IO;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Tremor.NPCs
{

	public class Cybermite : ModNPC
	{

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Cybermite");
		}

		public override void SetDefaults()
		{
			npc.aiStyle = 63;
			npc.lifeMax = 600;
			npc.damage = 70;
			npc.defense = 25;
			npc.knockBackResist = 0f;
			npc.width = 74;
			npc.height = 74;
			npc.lavaImmune = true;
			npc.noGravity = true;
			npc.noTileCollide = true;
			npc.HitSound = SoundID.NPCHit4;
			npc.DeathSound = SoundID.NPCDeath6;
		}

		public override void HitEffect(int hitDirection, double damage)
		{
			if (npc.life <= 0)
			{
				Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/CybermiteGore"), 1f);
			}
		}

		public Vector2 bossCenter
		{
			get { return npc.Center; }
			set { npc.position = value - new Vector2(npc.width / 2, npc.height / 2); }
		}

		public override void ScaleExpertStats(int numPlayers, float bossLifeScale)
		{
			npc.lifeMax = (int)(npc.lifeMax * 0.625f * bossLifeScale);
			npc.damage = (int)(npc.damage * 0.6f);
		}

		public override void AI()
		{
			Lighting.AddLight(bossCenter, 1f, 0.3f, 0.3f);
		}
	}
}