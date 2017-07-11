using Terraria.ID;
using Terraria;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;

namespace Tremor.NPCs
{
    public class Clamper2 : ModNPC
    {
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Clamper");
			Main.npcFrameCount[npc.type] = 3;
		}
 
        const int SpeedMulti = 2; // Множитель скорости

        public override void SetDefaults()
        {
            npc.noTileCollide = true;
            npc.noGravity = true;
            npc.lifeMax = 2400;
            npc.damage = 30;
            npc.defense = 6;
            npc.knockBackResist = 0.1f;
            npc.width = 36;
            npc.height = 33;
            npc.aiStyle = 2;
            npc.HitSound = SoundID.NPCHit4;
            npc.DeathSound = SoundID.NPCDeath14;
            animationType = 2;
        }

        public override void AI()
        {
            npc.knockBackResist = 0f;
            npc.position += npc.velocity * (SpeedMulti - 1);
            Lighting.AddLight(npc.Center, new Vector3(Color.OrangeRed.R / 75, Color.OrangeRed.G / 75, Color.OrangeRed.B / 75));
        }
    }
}