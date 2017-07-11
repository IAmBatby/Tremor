using System;
using System.Linq;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.ModLoader.IO;
using Terraria.UI.Chat;

namespace Tremor.NovaPillar
{
	public class NovaHandler : ModWorld
	{
		public static int TowerX = -1;
		public static int TowerY = -1;
		public static bool TowerActive;
		public static int ShieldStrength;
		
		public static bool LunarApocalypseLastTick;
		
		public override void Initialize()
		{
			LunarApocalypseLastTick = NPC.LunarApocalypseIsUp;
			ShieldStrength = NPC.ShieldStrengthTowerMax;
            TowerX = -1;
            TowerY = -1;
        }
		
		public override void PreUpdate()
		{
			TowerActive = NPC.AnyNPCs(mod.NPCType("NovaPillar"));
		}
		
		public override TagCompound Save()
		{
			var tag = new TagCompound
			{
				{"NovaActive", TowerActive}
			};
			if(TowerX != -1)
			{
				tag.Add("NovaX", TowerX);
				tag.Add("NovaY", TowerY);
			}
			return tag;
		}
		
		public override void Load(TagCompound tag)
		{
			TowerActive = tag.GetBool("NovaActive");
			if(tag.ContainsKey("NovaX"))
			{
				TowerX = tag.GetInt("NovaX");
				TowerY = tag.GetInt("NovaY");
				NPC.NewNPC(TowerX, TowerY, mod.NPCType("NovaPillar"));
			}
		}
		
		public override void PostUpdate()
		{
			if(NPC.LunarApocalypseIsUp && !LunarApocalypseLastTick)
			{
                Tremor.Log("Moving pillars...");
                var towers = new int[5];
				
				foreach(var npc in Main.npc)
				{
					if(npc == null) continue;
					if(npc.type == NPCID.LunarTowerNebula)	 towers[0] = npc.whoAmI;
					if(npc.type == NPCID.LunarTowerSolar)	 towers[1] = npc.whoAmI;
					if(npc.type == NPCID.LunarTowerStardust) towers[2] = npc.whoAmI;
					if(npc.type == NPCID.LunarTowerVortex)	 towers[3] = npc.whoAmI;
				}
				towers[4] = -1;
				towers = towers.OrderBy(x => Main.rand.Next()).ToArray();
				
				for(int i = 0; i < 5; i++)
				{
					MovePillar(i, towers[i]);
				}
			}
			else if(!NPC.LunarApocalypseIsUp && LunarApocalypseLastTick && TowerActive)
			{
				for(int i = Main.chatLine.Length - 1; i >= 0; i--)
				{
					if(Main.chatLine[i].text.StartsWith("Impending doom"))
					{
						Main.chatLine[i].parsedText = new []
						{
							new TextSnippet("Your hands are shaking...", new Color(175, 75, 255))
						};
						break;
					}
				}
				NPC.MoonLordCountdown = 0;
			}
			
			LunarApocalypseLastTick = NPC.LunarApocalypseIsUp;
		}
		
		void MovePillar(int position, int whoAmI)
		{
            if (whoAmI == -1)
            {
                Tremor.Log("Spawning Nova Pillar");
            }
            //else
            //{
                //Tremor.Log("Moving " + Main.npc[whoAmI].displayName);
           // }

            int x = Main.maxTilesX / 6 * (1 + position);
			var spawnPos = new Vector2(x * 16, (float)(Main.worldSurface - 40) * 16);
			
			bool success = false;
			for (int attempts = 0; attempts < 30; attempts++)
			{
				int offsetX = Main.rand.Next(-100, 101);
				for (int y = (int)Main.worldSurface; y > 100; y--)
				{
					if (!Collision.SolidTiles(x + offsetX - 10, x + offsetX + 10, y - 20, y + 15) && !WorldGen.PlayerLOS(x + offsetX - 10, y) && !WorldGen.PlayerLOS(x + offsetX + 10, y) && !WorldGen.PlayerLOS(x + offsetX - 10, y - 20) && !WorldGen.PlayerLOS(x + offsetX + 10, y - 20))
					{
						spawnPos = new Vector2((x + offsetX) * 16, y * 16);
						success = true;
						break;
					}
				}
				if (success)
				{
					break;
				}
			}
			
			if(whoAmI == -1)
			{
				whoAmI = NPC.NewNPC((int)spawnPos.X, (int)spawnPos.Y, mod.NPCType("NovaPillar"));
                NovaHandler.TowerX = (int)spawnPos.X;
                NovaHandler.TowerY = (int)spawnPos.Y;
            }
			else
			{
				Main.npc[whoAmI].Center = spawnPos;
				ShieldStrength = NPC.ShieldStrengthTowerMax;
				TowerActive = true;
			}
			if (Main.netMode == 2 && whoAmI < 200)
			{
				NetMessage.SendData(MessageID.SyncNPC, number: whoAmI);
			}
		}
		
		static readonly string[] NovaNPCs =
		{
			"NovaAlchemist",
            "Varki",
            "Youwarkee",
            "Deadling",
            "NovaFlier"
		};
		
		public class AuroraGlobalNPC : GlobalNPC
		{
            public override void EditSpawnRate(Player player, ref int spawnRate, ref int maxSpawns)
            {
                if (player.GetModPlayer<TremorPlayer>(mod).ZoneTowerNova)
                {
                    spawnRate = (int)(spawnRate * 0.14f);
                    maxSpawns = (int)(maxSpawns * 5f);
                }
            } 
        }
	}
}
