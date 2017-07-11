using Terraria.ID;
using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Tremor.NPCs {

[AutoloadHead]
public class Witch : ModNPC
{
		public override string Texture
		{
			get
			{
				return "Tremor/NPCs/Witch";
			}
		}
		
		public override string[] AltTextures
		{
			get
			{
				return new string[] { "Tremor/NPCs/Witch"};
			}
		}		

		public override bool Autoload(ref string name)
		{
			name = "Witch";
			return mod.Properties.Autoload;
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Witch");
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
        for(int k = 0; k < 255; k++)
        {
            Player player = Main.player[k];
            if(player.active)
            {
                for(int j = 0; j < player.inventory.Length; j++)
                {
                    if(player.inventory[j].type == 1774)
                    {
                        return true;
                    }
                }
            }
        }
        return false;
    }


    public override string TownNPCName()
    {
        switch(WorldGen.genRand.Next(4))
        {
        case 0:
            return "Circe";
        case 1:
            return "Kikimora";
        case 2:
            return "Morgana";
        default:
            return "Hecate";
        }
    }

    public override string GetChat()
    {
        switch(Main.rand.Next(6))
        {
        case 0:
            return "<cackle> Welcome dearies! I hope you don't mind the body parts. I was cleaning.";
        case 1:
            return "Eye of a newt! Tongue of a cat! Blood of a dryad... a little more blood.";
        case 2:
            return "Don't pull my nose! It's not a mask!";
        case 3:
            return "The moon has a secret dearies! One that you'll know soon enough!";
        case 4:
            return "This is halloween! Or isn't it?";
        default:
            return "Blood for the blood moon! Skulls for the skull cap...or was it something else?";
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
        shop.item[nextSlot].SetDefaults(mod.ItemType("PlagueMask"));
        nextSlot++;
        shop.item[nextSlot].SetDefaults(mod.ItemType("PlagueRobe"));
        nextSlot++;
        shop.item[nextSlot].SetDefaults(mod.ItemType("SacrificalScythe"));
        nextSlot++;
        shop.item[nextSlot].SetDefaults(mod.ItemType("Scarecrow"));
        nextSlot++;
        if(NPC.downedBoss1)
        {
            shop.item[nextSlot].SetDefaults(mod.ItemType("BoomSpear"));
            nextSlot++;
        }
        if(NPC.downedBoss2)
        {
            shop.item[nextSlot].SetDefaults(mod.ItemType("BlackRose"));
            nextSlot++;
        }
        if(NPC.downedBoss3)
        {
            shop.item[nextSlot].SetDefaults(mod.ItemType("Pumpspell"));
            nextSlot++;
        }
    }

    public override void TownNPCAttackStrength(ref int damage, ref float knockback)
    {
        damage = 25;
        knockback = 4f;
    }

    public override void TownNPCAttackCooldown(ref int cooldown, ref int randExtraCooldown)
    {
        cooldown = 10;
        randExtraCooldown = 10;
    }

    public override void TownNPCAttackProj(ref int projType, ref int attackDelay)
    {
        projType = mod.ProjectileType("PumpkinPro");
        attackDelay = 2;
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
            Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/WitchGore1"), 1f);
            Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/WitchGore2"), 1f);
            Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/WitchGore3"), 1f);
        }
}
}}