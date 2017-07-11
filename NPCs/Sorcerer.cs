using Terraria.ID;
using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Tremor.NPCs {
[AutoloadHead]
public class Sorcerer : ModNPC
{
		public override string Texture
		{
			get
			{
				return "Tremor/NPCs/Sorcerer";
			}
		}
		
		public override string[] AltTextures
		{
			get
			{
				return new string[] { "Tremor/NPCs/Sorcerer"};
			}
		}		

		public override bool Autoload(ref string name)
		{
			name = "Sorcerer";
			return mod.Properties.Autoload;
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Sorcerer");
			Main.npcFrameCount[npc.type] = 26;
			NPCID.Sets.ExtraFramesCount[npc.type] = 5;
			NPCID.Sets.AttackFrameCount[npc.type] = 5;
			NPCID.Sets.DangerDetectRange[npc.type] = 1000;
			NPCID.Sets.AttackType[npc.type] = 0;
			NPCID.Sets.AttackTime[npc.type] = 30;
			NPCID.Sets.AttackAverageChance[npc.type] = 30;
		}

    public override void SetDefaults()
    {
        npc.townNPC = true;
        npc.friendly = true;
        npc.width = 32;
        npc.height = 54;
        npc.aiStyle = 7;
        npc.damage = 10;
        npc.defense = 15;
        npc.lifeMax = 250;
        npc.HitSound = SoundID.NPCHit1;
        npc.DeathSound = SoundID.NPCDeath1;
        npc.knockBackResist = 0.5f;
        animationType = NPCID.Guide;
    }

    public override bool CanTownNPCSpawn(int numTownNPCs, int money)
    {
                        return true;
    }


    public override string TownNPCName()
    {
        switch(WorldGen.genRand.Next(4))
        {
        case 0:
            return "Merdok";
        case 1:
            return "Avalon";
        case 2:
            return "Aron";
        case 3:
            return "Harry";
        case 4:
            return "Edgar";
        default:
            return "Marco";
        }
    }

    public override string GetChat()
    {
        switch(Main.rand.Next(6))
        {
        case 0:
            return "You'll never find me trapped underground.";
        case 1:
            return "I can share the magic with you for free. Almost free.";
        case 2:
            return "Sorcery is all about control. It's different from magic in that it requires symbols and fetishes.";
        case 3:
            return "Sorry. I don't do parties.";
        case 4:
            return "Don't touch that if you want to keep your hand. It's still quite unstable.";
        default:
            return "I want to get the rabbit out of the hat! You want? Don't want a rabbit? Seriously? Someone in this house will buy my rabbits or not!";
        }
    }

    public override void SetChatButtons(ref string button, ref string button2)
    {
        button = Lang.inter[28].Value;
    }

    public override void OnChatButtonClicked(bool firstButton, ref bool shop)
    {
        if(firstButton)
        {
            shop = true;
        }
    }

    public override void SetupShop(Chest shop, ref int nextSlot)
    {
        shop.item[nextSlot].SetDefaults(mod.ItemType("BurningTome"));
        nextSlot++;
        shop.item[nextSlot].SetDefaults(mod.ItemType("RazorleavesTome"));
        nextSlot++;
        shop.item[nextSlot].SetDefaults(2019);
        nextSlot++;
        shop.item[nextSlot].SetDefaults(mod.ItemType("EnchantedShield"));
        nextSlot++;
        if(NPC.downedBoss1)
        {
            shop.item[nextSlot].SetDefaults(mod.ItemType("StarfallTome"));
            nextSlot++;
            shop.item[nextSlot].SetDefaults(mod.ItemType("GoldenHat"));
            nextSlot++;
            shop.item[nextSlot].SetDefaults(mod.ItemType("GoldenRobe"));
            nextSlot++;
        }
        if(NPC.downedBoss2)
        {
            shop.item[nextSlot].SetDefaults(mod.ItemType("LightningTome"));
            nextSlot++;
            shop.item[nextSlot].SetDefaults(mod.ItemType("Bloomstone"));
            nextSlot++;
        }
        if(Main.hardMode)
        {
            shop.item[nextSlot].SetDefaults(mod.ItemType("ManaDagger"));
            nextSlot++;
        }
    }

    public override void TownNPCAttackStrength(ref int damage, ref float knockback)
    {
        damage = 22;
        knockback = 4f;
    }

    public override void TownNPCAttackCooldown(ref int cooldown, ref int randExtraCooldown)
    {
        cooldown = 10;
        randExtraCooldown = 10;
    }

    public override void TownNPCAttackProj(ref int projType, ref int attackDelay)
    {
        projType = 124;
        attackDelay = 4;
    }

    public override void TownNPCAttackProjSpeed(ref float multiplier, ref float gravityCorrection, ref float randomOffset)
    {
        multiplier = 12f;
        randomOffset = 2f;
    }

    public override void HitEffect(int hitDirection, double damage)
    {
        if(npc.life <= 0)
        {
            for(int k = 0; k < 20; k++)
            {
                Dust.NewDust(npc.position, npc.width, npc.height, 151, 2.5f * (float)hitDirection, -2.5f, 0, default(Color), 0.7f);
            }
            Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/SorcererGore1"), 1f);
            Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/SorcererGore2"), 1f);
            Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/SorcererGore3"), 1f);
        }
}
}}