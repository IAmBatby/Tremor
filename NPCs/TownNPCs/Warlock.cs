using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

using Microsoft.Xna.Framework;

using Tremor.Items;

<<<<<<< HEAD:NPCs/Warlock.cs
namespace Tremor.NPCs
=======
namespace Tremor.NPCs.TownNPCs
>>>>>>> 8a3d4a60999e67c80df4daede405453dd106fc9d:NPCs/TownNPCs/Warlock.cs
{
	[AutoloadHead]
	public class Warlock : ModNPC
	{
		public override string Texture => "Tremor/NPCs/TownNPCs/Warlock";

		public override string[] AltTextures => new[] { "Tremor/NPCs/TownNPCs/Warlock" };

		public override bool Autoload(ref string name)
		{
			name = "Warlock";
			return mod.Properties.Autoload;
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Warlock");
			Main.npcFrameCount[npc.type] = 26;
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
			npc.width = 40;
			npc.height = 52;
			npc.aiStyle = 7;
			npc.damage = 10;
			npc.defense = 15;
			npc.lifeMax = 250;
			npc.HitSound = SoundID.NPCHit2;
			npc.DeathSound = SoundID.NPCDeath2;
			npc.knockBackResist = 0.5f;
			animationType = NPCID.Guide;
		}

		public override bool CanTownNPCSpawn(int numTownNPCs, int money)
			=> NPC.downedBoss2;

		public override string TownNPCName()
		{
			string[] names =
			{
				"Azazel",
				"Baphomet",
				"Vaal",
				"Dis",
				"Nisroke",
				"Sabnak"
			};
			return names.TakeRandom();
		}

		public override string GetChat()
		{
			switch (Main.rand.Next(6))
			{
				default:
					return "...";
			}
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
			shop.AddUniqueItem(ref nextSlot, mod.ItemType<StrongBelt>());

			if (NPC.downedBoss3)
				shop.AddUniqueItem(ref nextSlot, mod.ItemType<BallnChain>());

			if (WorldGen.crimson)
			{
				shop.AddUniqueItem(ref nextSlot, mod.ItemType<ViciousHelmet>());
				shop.AddUniqueItem(ref nextSlot, mod.ItemType<ViciousChestplate>());
				shop.AddUniqueItem(ref nextSlot, mod.ItemType<ViciousLeggings>());
			}
			else
			{
				shop.AddUniqueItem(ref nextSlot, mod.ItemType<VileHelmet>());
				shop.AddUniqueItem(ref nextSlot, mod.ItemType<VileChestplate>());
				shop.AddUniqueItem(ref nextSlot, mod.ItemType<VileLeggings>());
			}

			if (Main.hardMode)
			{
				shop.AddUniqueItem(ref nextSlot, mod.ItemType<Necronomicon>());
				shop.AddUniqueItem(ref nextSlot, mod.ItemType<Zephyrhorn>());
			}

			if (NPC.downedMechBoss1 && NPC.downedMechBoss2 && NPC.downedMechBoss3)
				shop.AddUniqueItem(ref nextSlot, mod.ItemType<NecroWarhammer>());
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
			projType = 270;
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

				for (int i = 0; i < 3; i++)
					Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot($"Gores/WarlockGore{i + 1}"), 1f);
			}
		}
	}
}