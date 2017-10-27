using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Tremor.NPCs.Bosses.Motherboard
{
	public class Clamper2 : ModNPC
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Clamper");
			Main.npcFrameCount[npc.type] = 3;
		}

		public override void SetDefaults()
		{
			npc.noTileCollide = true;
			npc.noGravity = true;
			npc.lifeMax = 2400;
			npc.damage = 30;
			npc.defense = 6;
			npc.knockBackResist = 0f;
			npc.width = 36;
			npc.height = 33;
			npc.aiStyle = 2;
			npc.HitSound = SoundID.NPCHit4;
			npc.DeathSound = SoundID.NPCDeath14;
			animationType = 2;
		}

		public override void AI()
		{
			npc.position += npc.velocity;
			Lighting.AddLight(npc.Center, Color.OrangeRed.ToVector3() * 0.01333f);
		}
	}
}