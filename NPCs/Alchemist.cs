using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

using Microsoft.Xna.Framework;

using Tremor.Items;
using Tremor.Projectiles.Alchemic;

namespace Tremor.NPCs
{
	[AutoloadHead]
	public class Alchemist : ModNPC
	{
		public override string Texture => "Tremor/NPCs/Alchemist";

		public override string[] AltTextures => new[] { "Tremor/NPCs/Alchemist" };

		public override bool Autoload(ref string name)
		{
			name = "Alchemist";
			return mod.Properties.Autoload;
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Alchemist");
			Main.npcFrameCount[npc.type] = 25;
			NPCID.Sets.ExtraFramesCount[npc.type] = 5;
			NPCID.Sets.AttackFrameCount[npc.type] = 4;
			NPCID.Sets.DangerDetectRange[npc.type] = 1000;
			NPCID.Sets.AttackType[npc.type] = 0;
			NPCID.Sets.AttackTime[npc.type] = 30;
			NPCID.Sets.AttackAverageChance[npc.type] = 30;
		}

		public override void SetDefaults()
		{
			npc.townNPC = true;
			npc.friendly = true;
			npc.width = 30;
			npc.height = 44;
			npc.aiStyle = 7;
			npc.damage = 10;
			npc.defense = 15;
			npc.lifeMax = 250;
			npc.HitSound = SoundID.NPCHit1;
			npc.DeathSound = SoundID.NPCDeath1;
			npc.knockBackResist = 0.5f;
			animationType = NPCID.GoblinTinkerer;
		}

		public override bool CanTownNPCSpawn(int numTownNPCs, int money) 
			=> NPC.downedBoss1;

		public override string TownNPCName()
		{
			string[] names =
			{
				"Rizo",
				"Albert",
				"Bernando",
				"Seefeld",
				"Raymond",
				"Paracelsus",
				"Nerxius"
			};
			return names.TakeRandom();
		}

		public override string GetChat()
		{
			// weighted chats?
			string[] chats =
			{
				"Love is just a chain of chemical reactions. So that you know.",
				"If you wanna know, it was hard to press these gel cubes.",
				"Wanna try something new? I think you may be interested in... BOOM FLASKS!",
				"The man who passes the sentence should throw the flask...",
				"I'm gonna have to throw EVERY SINGLE FLASK in this house!",
				"What? You don't like my hairstyle? Your isn't better.",
				"If you think that I'm a terrorist just because I sell exploding flasks? You're wrong. There are even worse people who sell worse things."
			};
			return chats.TakeRandom();
		}

		public override void SetChatButtons(ref string button, ref string button2)
		{
			button = Lang.inter[28].Value;
		}

		public override void OnChatButtonClicked(bool firstButton, ref bool shop)
		{
			shop = firstButton;
		}

		public override void SetupShop(Chest shop, ref int nextSlot)
		{
			shop.AddUniqueItem(ref nextSlot, mod.ItemType<BasicFlask>());
			shop.AddUniqueItem(ref nextSlot, mod.ItemType<HazardousChemicals>());
			shop.AddUniqueItem(ref nextSlot, ItemID.StinkPotion);
			shop.AddUniqueItem(ref nextSlot, ItemID.LovePotion);

			if (TremorWorld.Boss.Alchemaster.IsDowned())
				shop.AddUniqueItem(ref nextSlot, mod.ItemType<Pyro>());

			if (Main.hardMode)
			{
				if(Main.dayTime)
					shop.AddUniqueItem(ref nextSlot, mod.ItemType<BigHealingFlack>());
				else
					shop.AddUniqueItem(ref nextSlot, mod.ItemType<BigManaFlask>());

				shop.AddUniqueItem(ref nextSlot, mod.ItemType<BlackCauldron>());
				shop.AddUniqueItem(ref nextSlot, mod.ItemType<LesserVenomFlask>());
				shop.AddUniqueItem(ref nextSlot, mod.ItemType<ConcentratedTincture>());
			}
			else
			{
				if (Main.dayTime)
						shop.AddUniqueItem(ref nextSlot, mod.ItemType<LesserHealingFlack>());
				else
					shop.AddUniqueItem(ref nextSlot, mod.ItemType<LesserManaFlask>());
			}
			
			shop.AddUniqueItem(ref nextSlot, mod.ItemType<HealthSupportFlask>());
			shop.AddUniqueItem(ref nextSlot, mod.ItemType<ManaSupportFlask>());

			if (Main.player[Main.myPlayer].ZoneSnow)
				shop.AddUniqueItem(ref nextSlot, mod.ItemType<FreezeFlask>());
			if (Main.player[Main.myPlayer].ZoneJungle)
				shop.AddUniqueItem(ref nextSlot, mod.ItemType<LesserPoisonFlask>());

			if (NPC.downedBoss1)
				shop.AddUniqueItem(ref nextSlot, mod.ItemType<BoomFlask>());
			if (NPC.downedBoss2)
			{
				shop.AddUniqueItem(ref nextSlot, mod.ItemType<Nitro>());
				shop.AddUniqueItem(ref nextSlot, mod.ItemType<BurningFlask>());
			}
			if (NPC.downedBoss3)
				shop.AddUniqueItem(ref nextSlot, mod.ItemType<GoldFlask>());

			if (NPC.downedGolemBoss)
				shop.AddUniqueItem(ref nextSlot, mod.ItemType<CthulhuBlood>());

			if (NPC.downedPlantBoss && Main.bloodMoon)
				shop.AddUniqueItem(ref nextSlot, mod.ItemType<AlchemistGlove>());
		}

		public override void TownNPCAttackStrength(ref int damage, ref float knockback)
		{
			damage = 20;
			knockback = 4f;
		}

		public override void TownNPCAttackCooldown(ref int cooldown, ref int randExtraCooldown)
		{
			cooldown = 10;
			randExtraCooldown = 10;
		}

		public override void TownNPCAttackProj(ref int projType, ref int attackDelay)
		{
			projType = mod.ProjectileType<BasicFlaskPro>();
			attackDelay = 5;
		}

		public override void TownNPCAttackProjSpeed(ref float multiplier, ref float gravityCorrection, ref float randomOffset)
		{
			multiplier = 12f;
			randomOffset = 2f;
		}

		public override void HitEffect(int hitDirection, double damage)
		{
			if (npc.life <= 0)
			{
				for (int k = 0; k < 20; k++)
					Dust.NewDust(npc.position, npc.width, npc.height, 151, 2.5f * hitDirection, -2.5f, 0, default(Color), 0.7f);

				for(int i = 0; i < 3; ++i)
					Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot($"Gores/AlchemistGore{i+1}"), 1f);
			}
		}
	}
}