using System.Collections.Generic;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.DataStructures;
using Terraria.ModLoader;
using Tremor.Invasion;

//using Terraria.Content.Fonts;

namespace Tremor
{
	public class CyberWrathInvasion : ModPlayer
	{
		public override void UpdateDead()
		{

		}

		public static readonly PlayerLayer MiscEffects = new PlayerLayer("Tremor", "MiscEffects", PlayerLayer.MiscEffectsFront, delegate (PlayerDrawInfo drawInfo)
		{
			Player drawPlayer = drawInfo.drawPlayer;
			Mod mod = ModLoader.GetMod("Tremor");
			CyberWrathInvasion modPlayer = drawPlayer.GetModPlayer<CyberWrathInvasion>(mod);

			Texture2D CyberWrathI = mod.GetTexture("Invasion/System/System1");
			Texture2D CyberWrathI1 = mod.GetTexture("Invasion/System/System2");
			Texture2D CyberWrathI2 = mod.GetTexture("Invasion/System/System3");
			Texture2D CyberWrathI3 = mod.GetTexture("Invasion/System/System4");
			Texture2D CyberWrathI4 = mod.GetTexture("Invasion/System/System5");
			Texture2D CyberWrathI5 = mod.GetTexture("Invasion/System/System6");
			Texture2D CyberWrathI6 = mod.GetTexture("Invasion/System/System7");
			Texture2D CyberWrathI7 = mod.GetTexture("Invasion/System/System8");
			Texture2D CyberWrathI8 = mod.GetTexture("Invasion/System/System9");
			Texture2D CyberWrathI9 = mod.GetTexture("Invasion/System/System10");
			Texture2D texture1 = mod.GetTexture("Invasion/System/System");
			SpriteBatch sb1 = Main.spriteBatch;

			int iH1 = texture1.Height;
			int iW1 = texture1.Width;

			int sX1 = 37;
			int sY1 = 30;

			int eH = CyberWrathI.Height;
			int eW = CyberWrathI.Width;

			int XX1 = ((24 - iW1) / 2) + Main.screenWidth - sX1;
			int YY1 = ((24 - iH1) / 2) + sY1 + (int)(280 * 1.4) + (24 - iW1) * (-1) + 20;

			int eX = XX1 - 333;
			int eY = YY1 - 430 + (24 - eW) * (-1);

			bool _number = true;
			int number = 1;
		});

		public override void ModifyDrawLayers(List<PlayerLayer> layers)
		{
			MiscEffects.visible = true;
			layers.Add(MiscEffects);
			layers.Insert(0, MiscEffects);
		}

		public override void PostUpdateBuffs()
		{

		}

		public override void PostUpdate()
		{
			bool First = true;
			const int XOffset = 400;
			const int YOffset = 400;

			CyberWrathInvasion modPlayer = player.GetModPlayer<CyberWrathInvasion>(mod);
			if (!InvasionWorld.CyberWrath)
			{
				InvasionWorld.CyberWrathPoints1 = 0;
			}

			if (InvasionWorld.CyberWrath)
			{
				//Main.spriteBatch.Draw(Main.blackTileTexture, new Rectangle(0, 0, Main.screenWidth, Main.screenHeight), new Color(200, 200, 200) * 0.5f);
				if (Main.rand.Next(700) == 1)
					NPC.NewNPC((int)player.Center.X + XOffset, (int)player.Center.Y, mod.NPCType("InvisibleSoul"));
				if (Main.rand.Next(700) == 1)
					NPC.NewNPC((int)player.Center.X - XOffset, (int)player.Center.Y, mod.NPCType("InvisibleSoul"));

				if (Main.rand.Next(150) == 1)
					NPC.NewNPC((int)player.Center.X + XOffset, (int)player.Center.Y + YOffset, mod.NPCType("CyberBat"));
				if (Main.rand.Next(150) == 1)
					NPC.NewNPC((int)player.Center.X - XOffset, (int)player.Center.Y - YOffset, mod.NPCType("CyberBat"));

				if (Main.rand.Next(500) == 1)
					NPC.NewNPC((int)player.Center.X + XOffset, (int)player.Center.Y + YOffset, mod.NPCType("ParadoxSun"));
				if (Main.rand.Next(500) == 1)
					NPC.NewNPC((int)player.Center.X - XOffset, (int)player.Center.Y - YOffset, mod.NPCType("ParadoxSun"));
			}

			InvasionWorld.CyberWrathPoints = InvasionWorld.CyberWrathPoints1;


			if (InvasionWorld.CyberWrathPoints1 == 15)
			{
				NPC.NewNPC((int)player.Center.X, (int)player.Center.Y - YOffset, mod.NPCType("Violeum"));
				InvasionWorld.CyberWrathPoints1 = 16;
			}

			if (InvasionWorld.CyberWrathPoints1 == 35)
			{
				NPC.NewNPC((int)player.Center.X, (int)player.Center.Y - YOffset, mod.NPCType("Violeum"));
				InvasionWorld.CyberWrathPoints1 = 36;
			}

			if (InvasionWorld.CyberWrathPoints1 == 50)
			{
				NPC.NewNPC((int)player.Center.X, (int)player.Center.Y - YOffset, mod.NPCType("Violeum"));
				InvasionWorld.CyberWrathPoints1 = 51;
			}

			if (InvasionWorld.CyberWrathPoints1 == 85)
			{
				NPC.NewNPC((int)player.Center.X, (int)player.Center.Y - YOffset, mod.NPCType("Violeum"));
				InvasionWorld.CyberWrathPoints1 = 86;
			}

			if (InvasionWorld.CyberWrathPoints1 >= 100 && !NPC.AnyNPCs(mod.NPCType("Titan")))
			{
				//Main.NewText("Wave 1: Complete!", 255, 255, 0);
				//Main.NewText("Wave 2: Complete 0%", 0, 255, 255);
				InvasionWorld.CyberWrath = false;
			}

			if (InvasionWorld.CyberWrathPoints1 > 100 && !NPC.AnyNPCs(mod.NPCType("Titan")))
			{
				InvasionWorld.CyberWrathPoints1 = 100;
			}

			if (InvasionWorld.CyberWrathPoints1 > 98 && NPC.AnyNPCs(mod.NPCType("Titan")))
			{
				InvasionWorld.CyberWrathPoints1 = 98;
			}

			if (NPC.AnyNPCs(mod.NPCType("Titan_")) && InvasionWorld.CyberWrathPoints1 == 98)
			{
				InvasionWorld.CyberWrathPoints1 = 98;
			}

			if (NPC.AnyNPCs(mod.NPCType("Titan")) && InvasionWorld.CyberWrathPoints1 == 98)
			{
				InvasionWorld.CyberWrathPoints1 = 98;
			}

			if (!NPC.AnyNPCs(mod.NPCType("Titan_")) && InvasionWorld.CyberWrath && InvasionWorld.CyberWrathPoints1 < 98)
			{
				NPC.NewNPC((int)player.Center.X, (int)player.Center.Y - 200, mod.NPCType("Titan_"));
			}

			/*if (modPlayer.CyberWrathPoints1 == 94)
			{
				NPC.NewNPC((int)player.position.X, (int)player.position.Y - 200, mod.NPCType("Titan"));
				Main.NewText("Your life happens?", Color.Red.R, Color.Orange.G, Color.Red.B);
				modPlayer.CyberWrathPoints1 = 95;
			} */

			if (NPC.AnyNPCs(mod.NPCType("Titan")) && InvasionWorld.CyberWrathPoints1 > 98)
			{
				InvasionWorld.CyberWrathPoints1 = 98;
			}

			if (NPC.AnyNPCs(mod.NPCType("Zerokk")) && InvasionWorld.CyberWrathPoints1 == 98)
			{
				InvasionWorld.CyberWrathPoints1 = 98;
			}

			if (NPC.AnyNPCs(mod.NPCType("Titan_")) && InvasionWorld.CyberWrathPoints1 > 98)
			{
				InvasionWorld.CyberWrathPoints1 = 98;
			}

			if (NPC.AnyNPCs(mod.NPCType("Zerokk")) && InvasionWorld.CyberWrathPoints1 > 98)
			{
				InvasionWorld.CyberWrathPoints1 = 98;
			}


			if (InvasionWorld.CyberWrathPoints1 == 100 && !NPC.AnyNPCs(mod.NPCType("Titan_")) && !NPC.AnyNPCs(mod.NPCType("Titan")))
			{
				Main.NewText("Paradox Cohort has been defeated!", 39, 86, 134);
				InvasionWorld.CyberWrathPoints1 = 0;
			}
		}

		public override bool PreKill(double damage, int hitDirection, bool pvp, ref bool playSound, ref bool genGore, ref PlayerDeathReason damageSource)
		{
			return true;
		}

		public override void UpdateBiomeVisuals()
		{
			bool usePurity = InvasionWorld.CyberWrath;
			player.ManageSpecialBiomeVisuals("Tremor:Invasion", usePurity);
		}
	}
}
