using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;


namespace Tremor.Invasion {
    public class ParadoxSun : ModNPC
    {
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Forgotten Creature");
			Main.npcFrameCount[npc.type] = 3;
		}
 
        public override void SetDefaults()
        {
            npc.lifeMax = 5750;
            npc.damage = 125;
            npc.defense = 115;
            npc.knockBackResist = 0f;
            npc.width = 34;
            npc.height = 40;
            animationType = 3;
            npc.aiStyle = -1;
            npc.npcSlots = 0.5f;
            npc.HitSound = SoundID.NPCHit1;
            npc.DeathSound = SoundID.NPCDeath1;
            npc.color = Color.White;
        }

        public override float SpawnChance(NPCSpawnInfo spawnInfo)
        {
            Mod mod = ModLoader.GetMod("Tremor");
            CyberWrathInvasion modPlayer = Main.player[Main.myPlayer].GetModPlayer<CyberWrathInvasion>(mod);
            float spawn = 20f;
            if (InvasionWorld.CyberWrath)
                return 10000f;
            else
                return 0f;

            int x = spawnInfo.spawnTileX;
            int y = spawnInfo.spawnTileY;
            int tile = (int)Main.tile[x, y].type;
            return InvasionWorld.CyberWrath && y > Main.worldSurface ? 1f : 0f;
        }

        public override void HitEffect(int hitDirection, double damage)
        {
            if (npc.life <= 0)
            {
                for (int k = 0; k < 10; k++)
                {
                    Dust.NewDust(npc.position, npc.width, npc.height, mod.DustType("CyberDust"), 2.5f * (float)hitDirection, -2.5f, 0, default(Color), 0.7f);
                }

                CyberWrathInvasion modPlayer = Main.player[Main.myPlayer].GetModPlayer<CyberWrathInvasion>(mod);
                if (InvasionWorld.CyberWrath && Main.rand.Next(2) == 1)
                {
                    InvasionWorld.CyberWrathPoints1 += 2;
                    //Main.NewText(("Wave 1: Complete " + TremorWorld.CyberWrathPoints + "%"), 39, 86, 134);
                }
            }

            for (int k = 0; k < damage / npc.lifeMax * 50.0; k++)
            {
                Dust.NewDust(npc.position, npc.width, npc.height, mod.DustType("CyberDust"), (float)hitDirection, -1f, 0, default(Color), 0.7f);
            }
        }

        public override void ScaleExpertStats(int numPlayers, float bossLifeScale)
        {
            npc.lifeMax = (int)(npc.lifeMax * 1);
            npc.damage = (int)(npc.damage * 1);
        }

    public override void OnHitPlayer(Player player, int damage, bool crit)
    {
        if(Main.rand.Next(6) == 0)
        {
            player.AddBuff(31, 1000, true);
        }
    }

        public override void AI()
        {
				if (Main.rand.Next(320) == 5)
                {
                    do
                    {
                        npc.position.X = (Main.player[npc.target].position.X - 500) + Main.rand.Next(1000);
                        npc.position.Y = (Main.player[npc.target].position.Y - 500) + Main.rand.Next(1000);
                    } while (npc.Distance(Main.player[npc.target].position) < 40);
                }

                int num5 = 60;
                bool flag2 = false;
                bool flag3 = true;

                if (npc.velocity.Y == 0f && ((npc.velocity.X > 0f && npc.direction < 0) || (npc.velocity.X < 0f && npc.direction > 0)))
                {
                    flag2 = true;
                }
                if (npc.position.X == npc.oldPosition.X || npc.ai[3] >= (float)num5 || flag2)
                {
                    npc.ai[3] += 1f;
                }
                else
                {
                    if ((double)Math.Abs(npc.velocity.X) > 0.9 && npc.ai[3] > 0f)
                    {
                        npc.ai[3] -= 1f;
                    }
                }
                if (npc.ai[3] > (float)(num5 * 10))
                {
                    npc.ai[3] = 0f;
                }
                if (npc.justHit)
                {
                    npc.ai[3] = 0f;
                }
                if (npc.ai[3] == (float)num5)
                {
                    npc.netUpdate = true;
                }

                if (npc.ai[3] < (float)num5)
                {
                    npc.TargetClosest(true);
                }
                else
                {
                    if (npc.velocity.X == 0f)
                    {
                        if (npc.velocity.Y == 0f)
                        {
                            npc.ai[0] += 1f;
                            if (npc.ai[0] >= 2f)
                            {
                                npc.direction *= -1;
                                npc.spriteDirection = npc.direction;
                                npc.ai[0] = 0f;
                            }
                        }
                    }
                    else
                    {
                        npc.ai[0] = 0f;
                    }
                    if (npc.direction == 0)
                    {
                        npc.direction = 1;
                    }
                }

                if (npc.velocity.X < -3f || npc.velocity.X > 3f)
                {
                    if (npc.velocity.Y == 0f)
                    {
                        npc.velocity *= 0.8f;
                    }
                }
                else
                {
                    if (npc.velocity.X < 3f && npc.direction == 1)
                    {
                        npc.velocity.X = npc.velocity.X + 0.1f;
                        if (npc.velocity.X > 3f)
                        {
                            npc.velocity.X = 3f;
                        }
                    }
                    else
                    {
                        if (npc.velocity.X > -3f && npc.direction == -1)
                        {
                            npc.velocity.X = npc.velocity.X - 0.1f;
                            if (npc.velocity.X < -3f)
                            {
                                npc.velocity.X = -3f;
                            }
                        }
                    }
                }

                bool flag4 = false;
                if (npc.velocity.Y == 0f)
                {
                    int num29 = (int)(npc.position.Y + (float)npc.height + 8f) / 16;
                    int num30 = (int)npc.position.X / 16;
                    int num31 = (int)(npc.position.X + (float)npc.width) / 16;
                    for (int l = num30; l <= num31; l++)
                    {
                        if (Main.tile[l, num29] == null)
                        {
                            return;
                        }
                        if (Main.tile[l, num29].active() && Main.tileSolid[(int)Main.tile[l, num29].type])
                        {
                            flag4 = true;
                            break;
                        }
                    }
                }

                if (flag4)
                {
                    int num32 = (int)((npc.position.X + (float)(npc.width / 2) + (float)((npc.width / 2 + 6) * npc.direction)) / 16f);
                    int num33 = (int)((npc.position.Y + (float)npc.height - 15f) / 16f);
                    if (Main.tile[num32, num33] == null)
                    {
                        Main.tile[num32, num33] = new Tile();
                    }
                    if (Main.tile[num32, num33 - 1] == null)
                    {
                        Main.tile[num32, num33 - 1] = new Tile();
                    }
                    if (Main.tile[num32, num33 - 2] == null)
                    {
                        Main.tile[num32, num33 - 2] = new Tile();
                    }
                    if (Main.tile[num32, num33 - 3] == null)
                    {
                        Main.tile[num32, num33 - 3] = new Tile();
                    }
                    if (Main.tile[num32, num33 + 1] == null)
                    {
                        Main.tile[num32, num33 + 1] = new Tile();
                    }
                    if (Main.tile[num32 + npc.direction, num33 - 1] == null)
                    {
                        Main.tile[num32 + npc.direction, num33 - 1] = new Tile();
                    }
                    if (Main.tile[num32 + npc.direction, num33 + 1] == null)
                    {
                        Main.tile[num32 + npc.direction, num33 + 1] = new Tile();
                    }

                    if (Main.tile[num32, num33 - 1].active() && Main.tile[num32, num33 - 1].type == 10 && flag3)
                    {
                        npc.ai[2] += 1f;
                        npc.ai[3] = 0f;
                        if (npc.ai[2] >= 60f)
                        {
                            npc.velocity.X = 0.5f * (float)(-(float)npc.direction);
                            npc.ai[1] += 1f;
                            npc.ai[2] = 0f;
                            bool flag5 = false;
                            if (npc.ai[1] >= 10f)
                            {
                                flag5 = true;
                                npc.ai[1] = 10f;
                            }
                            WorldGen.KillTile(num32, num33 - 1, true, false, false);
                            if ((Main.netMode != 1 || !flag5) && flag5 && Main.netMode != 1)
                            {
                                bool flag6 = WorldGen.OpenDoor(num32, num33, npc.direction);
                                if (!flag6)
                                {
                                    npc.ai[3] = (float)num5;
                                    npc.netUpdate = true;
                                }
                                //if (Main.netMode == 2 && flag6)
                                //{
                                    //NetMessage.SendData(19, -1, -1, "", 0, (float)num32, (float)num33, (float)npc.direction, 0);
                                //}
                            }
                        }
                    }

                    if ((npc.velocity.X < 0f && npc.spriteDirection == -1) || (npc.velocity.X > 0f && npc.spriteDirection == 1))
                    {
                        if (Main.tile[num32, num33 - 2].active() && Main.tileSolid[(int)Main.tile[num32, num33 - 2].type])
                        {
                            if ((Main.tile[num32, num33 - 3].active() && Main.tileSolid[(int)Main.tile[num32, num33 - 3].type]))
                            {
                                npc.velocity.Y = -8f;
                                npc.netUpdate = true;
                            }
                            else
                            {
                                npc.velocity.Y = -7f;
                                npc.netUpdate = true;
                            }
                        }
                        else
                        {
                            if (Main.tile[num32, num33 - 1].active() && Main.tileSolid[(int)Main.tile[num32, num33 - 1].type])
                            {
                                npc.velocity.Y = -6f;
                                npc.netUpdate = true;
                            }
                            else
                            {
                                if (Main.tile[num32, num33].active() && Main.tileSolid[(int)Main.tile[num32, num33].type])
                                {
                                    npc.velocity.Y = -5f;
                                    npc.netUpdate = true;
                                }
                                else
                                {
                                    if (npc.directionY < 0 && (!Main.tile[num32, num33 + 1].active() || !Main.tileSolid[(int)Main.tile[num32, num33 + 1].type]) && (!Main.tile[num32 + npc.direction, num33 + 1].active() || !Main.tileSolid[(int)Main.tile[num32 + npc.direction, num33 + 1].type]))
                                    {
                                        npc.velocity.Y = -8f;
                                        npc.velocity.X = npc.velocity.X * 1.5f;
                                        npc.netUpdate = true;
                                    }
                                    else
                                    {
                                        if (flag3)
                                        {
                                            npc.ai[1] = 0f;
                                            npc.ai[2] = 0f;
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
                else
                {
                    if (flag3)
                    {
                        npc.ai[1] = 0f;
                        npc.ai[2] = 0f;
                    }
                }          
        }
		
		public override void NPCLoot()
		{
			if (Main.rand.Next(20) == 0)
			{
				Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("ClockofTime"));
			}
		}
    }
}