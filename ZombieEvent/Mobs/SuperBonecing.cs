using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Tremor.ZombieEvent.Mobs  {
  
public class SuperBonecing : ModNPC
{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Bonecing");
			Main.npcFrameCount[npc.type] = 3;
		}
 
    public override void SetDefaults()
    {
        npc.lifeMax =  320;
        npc.damage = 160;
        npc.defense = 40;
        npc.knockBackResist = 0.0f;
        npc.width = 58;
        npc.height = 44;
        animationType = 177;
        aiType = 177;
        npc.aiStyle = 41;
        npc.npcSlots = 0.2f;
        npc.HitSound = SoundID.NPCHit2;
        npc.DeathSound = SoundID.NPCDeath2;
        npc.value = Item.buyPrice(0, 0, 9, 9);
        banner = npc.type;
        bannerItem = mod.ItemType("BigCorpseBanner");
    }

        public override void AI()
        {
if(!NPC.AnyNPCs(mod.NPCType("Cryptomage")))
{
npc.Transform(mod.NPCType("Bonecing"));
}
        }
}}