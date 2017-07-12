using System;
using System.Collections.Generic;
using System.IO;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.DataStructures;
using Terraria.Graphics.Shaders;
using Terraria.ModLoader;

namespace Tremor
{
	public class TremorPlayer : ModPlayer
	{
		public bool heartAmulet;
		public bool ZoneRuins;
		public int healHurt;
		public bool dFear;
		public bool creeperMinion;
		public bool corruptorMinion;
		public bool hungryMinion;
		public bool meteorMinion;
		public bool jellyfishMinion;
		public bool cyberMinion;
		public bool blueSakuraMinion;
		public bool goblinMinion;
		public bool shadowMinion;
		public bool AnnoyingDog;
		public bool vultureMinion;
		public bool skeletonMinion;
		public bool goldenWhale;
		public bool vortexBee;
		public bool nebulaJellyfish;
		public bool solarMeteor;
		public bool stardustSquid;
		public bool mudDoll;
		public bool Irradiated;
		public bool Brutty;
		public bool quetzalcoatlMinion;
		public bool northWind;
		public bool summonerPower;
		public bool gurdPet;
		public bool ancientVision;
		public bool ZoneGranite;
		public bool ZoneComet;
		public bool whiteSakura;
		public bool petZootaloo;
		public bool onHitShadaggers = false;
		public bool LivingTombstone;
		public bool miniCyber;
		public bool cluster;
		public bool ZoneIce;
		public bool ancientPredator;
		public bool starfishMinion;
		public bool hauntpet;
		public bool crabStaff;
		public bool zombatMinion;
		public bool huskyStaff;
		public bool ruinAltar;
		public bool emeraldy;
		public bool hunterMinion;
		public bool birbStaff;
		public bool warkee;
		public bool shadowArmSF;

		public bool zellariumHead;
		public bool zellariumBody;

		public bool ZoneTowerNova;
		public bool NovaMonolith = false;

		public override void UpdateDead()
		{
			zellariumBody = false;
			zellariumHead = false;
		}

		public int zellariumHit;
		public int zellariumDash;
		public int zellariumCooldown;
		public override void PostUpdateEquips()
		{
			if (zellariumHead)
			{
				if (zellariumDash > 0)
					zellariumDash--;
				else
					zellariumHit = -1;

				if (zellariumDash > 0 && zellariumHit < 0)
				{
					Rectangle rectangle = new Rectangle((int)(player.position.X + player.velocity.X * 0.5 - 4.0), (int)(player.position.Y + player.velocity.Y * 0.5 - 4.0), player.width + 8, player.height + 8);
					for (int i = 0; i < 200; i++)
					{
						if (Main.npc[i].active && !Main.npc[i].dontTakeDamage && !Main.npc[i].friendly)
						{
							NPC npc = Main.npc[i];
							Rectangle rect = npc.getRect();
							if (rectangle.Intersects(rect) && (npc.noTileCollide || Collision.CanHit(player.position, player.width, player.height, npc.position, npc.width, npc.height)))
							{
								float damage = 2f * player.GetModPlayer<MPlayer>(mod).alchemistDamage;
								float knockback = 3f;
								bool crit = false;

								if (player.kbGlove)
									knockback *= 0f;
								if (player.kbBuff)
									knockback *= 1f;

								if (Main.rand.Next(100) < player.meleeCrit)
									crit = true;

								int hitDirection = player.direction;
								if (player.velocity.X < 0f)
								{
									hitDirection = -1;
								}
								if (player.velocity.X > 0f)
								{
									hitDirection = 1;
								}
								if (player.whoAmI == Main.myPlayer)
								{
									npc.StrikeNPC((int)damage, knockback, hitDirection, crit, false, false);
									if (Main.netMode != 0)
									{
									}
								}

								zellariumDash = 10;
								player.dashDelay = 0;
								player.velocity.X = -(float)hitDirection * 2f;
								player.velocity.Y = -2f;
								player.immune = true;
								player.immuneTime = 7;
								zellariumHit = i;
							}
						}
					}
				}

				if (player.dash <= 0 && player.dashDelay == 0 && !player.mount.Active)
				{
					int num21 = 0;
					bool flag2 = false;
					if (player.dashTime > 0)
						player.dashTime--;
					if (player.dashTime < 0)
						player.dashTime++;

					if (player.controlRight && player.releaseRight)
					{
						if (player.dashTime > 0)
						{
							num21 = 1;
							flag2 = true;
							player.dashTime = 0;
						}
						else
						{
							player.dashTime = 15;
						}
					}
					else if (player.controlLeft && player.releaseLeft)
					{
						if (player.dashTime < 0)
						{
							num21 = -1;
							flag2 = true;
							player.dashTime = 0;
						}
						else
						{
							player.dashTime = -15;
						}
					}

					if (flag2)
					{
						player.velocity.X = 25f * num21;
						Point point3 = (player.Center + new Vector2(num21 * player.width / 2 + 2, player.gravDir * -(float)player.height / 2f + player.gravDir * 2f)).ToTileCoordinates();
						Point point4 = (player.Center + new Vector2(num21 * player.width / 2 + 2, 0f)).ToTileCoordinates();
						if (WorldGen.SolidOrSlopedTile(point3.X, point3.Y) || WorldGen.SolidOrSlopedTile(point4.X, point4.Y))
						{
							player.velocity.X = player.velocity.X / 2f;
						}
						player.dashDelay = -1;
						zellariumDash = 15;
						for (int num22 = 0; num22 < 100; num22++)
						{
							int num23 = Dust.NewDust(new Vector2(player.position.X, player.position.Y), player.width, player.height, 59, 0f, 0f, 100, default(Color), 2f);
							Dust dust3 = Main.dust[num23];
							dust3.position.X = dust3.position.X + Main.rand.Next(-5, 6);
							Dust dust4 = Main.dust[num23];
							dust4.position.Y = dust4.position.Y + Main.rand.Next(-5, 6);
							Main.dust[num23].velocity *= 0.2f;
							Main.dust[num23].scale *= 1f + Main.rand.Next(20) * 0.01f;
							Main.dust[num23].shader = GameShaders.Armor.GetSecondaryShader(player.shield, player);
						}
					}
				}
			}
			if (zellariumDash > 0)
				zellariumDash--;
			if (player.dashDelay < 0)
			{
				for (int l = 0; l < 0; l++)
				{
					int num14;
					if (player.velocity.Y == 0f)
					{
						num14 = Dust.NewDust(new Vector2(player.position.X, player.position.Y + player.height - 4f), player.width, 8, 59, 0f, 0f, 100, default(Color), 1.4f);
					}
					else
					{
						num14 = Dust.NewDust(new Vector2(player.position.X, player.position.Y + (player.height / 2) - 8f), player.width, 16, 59, 0f, 0f, 100, default(Color), 1.4f);
					}
					Main.dust[num14].velocity *= 0.1f;
					Main.dust[num14].scale *= 1f + Main.rand.Next(20) * 0.01f;
					Main.dust[num14].shader = GameShaders.Armor.GetSecondaryShader(player.shoe, player);
				}

				float maxSpeed = Math.Max(player.accRunSpeed, player.maxRunSpeed);

				player.vortexStealthActive = false;
				if (player.velocity.X > 12f || player.velocity.X < -12f)
				{
					player.velocity.X = player.velocity.X * 0.985f;
					return;
				}
				if (player.velocity.X > maxSpeed || player.velocity.X < -maxSpeed)
				{
					player.velocity.X = player.velocity.X * 0.94f;
					return;
				}
				player.dashDelay = 30;
				if (player.velocity.X < 0f)
				{
					player.velocity.X = -maxSpeed;
					return;
				}
				if (player.velocity.X > 0f)
				{
					player.velocity.X = maxSpeed;
				}
			}
		}
		public override bool PreHurt(bool pvp, bool quiet, ref int damage, ref int hitDirection, ref bool crit, ref bool customDamage, ref bool playSound, ref bool genGore, ref PlayerDeathReason damageSource)
		{
			if (zellariumBody && Main.rand.Next(10) == 0)
			{
				return false;
			}
			return base.PreHurt(pvp, quiet, ref damage, ref hitDirection, ref crit, ref customDamage, ref playSound, ref genGore, ref damageSource);
		}
		public override void ResetEffects()
		{
			heartAmulet = false;
			dFear = false;
			healHurt = 0;
			creeperMinion = false;
			corruptorMinion = false;
			hungryMinion = false;
			jellyfishMinion = false;
			meteorMinion = false;
			cyberMinion = false;
			blueSakuraMinion = false;
			goblinMinion = false;
			shadowMinion = false;
			AnnoyingDog = false;
			vultureMinion = false;
			skeletonMinion = false;
			goldenWhale = false;
			vortexBee = false;
			nebulaJellyfish = false;
			solarMeteor = false;
			stardustSquid = false;
			Irradiated = false;
			mudDoll = false;
			Brutty = false;
			quetzalcoatlMinion = false;
			northWind = false;
			summonerPower = false;
			gurdPet = false;
			ancientVision = false;
			whiteSakura = false;
			petZootaloo = false;
			LivingTombstone = false;
			miniCyber = false;
			cluster = false;
			ancientPredator = false;
			starfishMinion = false;
			hauntpet = false;
			crabStaff = false;
			zombatMinion = false;
			huskyStaff = false;
			ruinAltar = false;
			emeraldy = false;
			hunterMinion = false;
			birbStaff = false;
			warkee = false;
			shadowArmSF = false;
		}

		private float _fadeOpacity;
		private float maxDepth;
		private float minDepth;

		public override void OnRespawn(Player player)
		{
			if (heartAmulet)
			{
				player.statLife = (player.statLifeMax2 / 100) * 80;
			}
		}

		private struct LightPillar
		{
			public Vector2 Position;
			public float Depth;
		}
		private LightPillar[] _pillars;
		private Random _random = new Random();

		public static int[] iceWidth = new int[3];
		public static int[] iceHeight = new int[3];
		public static Texture2D[] backgroundTexture = new Texture2D[3];

		public override void UpdateBiomes()
		{
			ZoneRuins = (TremorWorld.RuinsTiles > 50);
			ZoneGranite = (TremorWorld.GraniteTiles > 100);
			ZoneIce = (TremorWorld.IceTiles > 100);
			ZoneComet = (TremorWorld.CometTiles > 30);

			ZoneTowerNova = false;
			if (!player.ZoneTowerSolar && !player.ZoneTowerVortex && !player.ZoneTowerNebula && !player.ZoneTowerStardust)
			{
				for (int i = 0; i < Main.maxNPCs; i++)
				{
					var npc = Main.npc[i];
					if (npc != null && npc.active && npc.type == mod.NPCType("NovaPillar") && player.Distance(npc.Center) <= 4000f)
					{
						ZoneTowerNova = true;
					}
				}
			}
		}

		const int XOffset = 400;
		const int YOffset = 400;
		public override void PostUpdate()
		{
			bool First = true;
			const int XOffset = 400;
			const int YOffset = 400;

			//CyberWrathInvasion modPlayer = Main.player[Main.myPlayer].GetModPlayer<CyberWrathInvasion>(mod);
			if (ZoneIce)
			{
				player.ZoneSnow = true;
			}
			if (ZoneComet)
			{
				if (Main.rand.Next(310) == 0)
				{
					switch (Main.rand.Next(0, 4))
					{
						case 0:
							NPC.NewNPC((int)player.Center.X + XOffset, (int)player.Center.Y + YOffset, mod.NPCType("CometHead")); break;
						case 1:
							NPC.NewNPC((int)player.Center.X + XOffset, (int)player.Center.Y - YOffset, mod.NPCType("CometHead")); break;
						case 2:
							NPC.NewNPC((int)player.Center.X - XOffset, (int)player.Center.Y + YOffset, mod.NPCType("CometHead")); break;
						case 3:
							NPC.NewNPC((int)player.Center.X - XOffset, (int)player.Center.Y - YOffset, mod.NPCType("CometHead")); break;
					}
				}

				if (Main.rand.Next(700) == 0)
				{
					switch (Main.rand.Next(0, 4))
					{
						case 0:
							NPC.NewNPC((int)player.Center.X + XOffset, (int)player.Center.Y + YOffset, mod.NPCType("Galasquid")); break;
						case 1:
							NPC.NewNPC((int)player.Center.X + XOffset, (int)player.Center.Y - YOffset, mod.NPCType("Galasquid")); break;
						case 2:
							NPC.NewNPC((int)player.Center.X - XOffset, (int)player.Center.Y + YOffset, mod.NPCType("Galasquid")); break;
						case 3:
							NPC.NewNPC((int)player.Center.X - XOffset, (int)player.Center.Y - YOffset, mod.NPCType("Galasquid")); break;
					}
				}

				if (Main.rand.Next(860) == 0)
				{
					switch (Main.rand.Next(0, 4))
					{
						case 0:
							NPC.NewNPC((int)player.Center.X + XOffset, (int)player.Center.Y + YOffset, mod.NPCType("Astrofly")); break;
						case 1:
							NPC.NewNPC((int)player.Center.X + XOffset, (int)player.Center.Y - YOffset, mod.NPCType("Astrofly")); break;
						case 2:
							NPC.NewNPC((int)player.Center.X - XOffset, (int)player.Center.Y + YOffset, mod.NPCType("Astrofly")); break;
						case 3:
							NPC.NewNPC((int)player.Center.X - XOffset, (int)player.Center.Y - YOffset, mod.NPCType("Astrofly")); break;
					}
				}
			}
		}

		public override void SetupStartInventory(IList<Item> items)
		{
			Item item = new Item();
			item.SetDefaults(mod.ItemType("AdventurerSpark"));
			item.stack = 1;
			items.Add(item);
		}

		public override bool CustomBiomesMatch(Player other)
		{
			var modOther = other.GetModPlayer<TremorPlayer>(mod);
			return ZoneTowerNova == modOther.ZoneTowerNova;
		}

		public override void CopyCustomBiomesTo(Player other)
		{
			var modOther = other.GetModPlayer<TremorPlayer>(mod);
			modOther.ZoneTowerNova = ZoneTowerNova;
		}

		public override void SendCustomBiomes(BinaryWriter writer)
		{
			byte flags = 0;
			if (ZoneGranite)
			{
				flags |= 1;
			}
			if (ZoneTowerNova)
			{
				flags |= 2;
			}
			writer.Write(flags);
		}

		public override void ReceiveCustomBiomes(BinaryReader reader)
		{
			byte flags = reader.ReadByte();
			ZoneGranite = ((flags & 1) == 1);
			ZoneTowerNova = ((flags & 2) == 2);
		}

		public void OnHit(float x, float y, Entity victim)
		{
			if (onHitShadaggers && Main.rand.Next(4) == 0)
			{
				player.petalTimer = 20;
				if (x < player.position.X + player.width / 2)
				{
				}
				int direction = player.direction;
				float num = Main.screenPosition.X;
				if (direction < 0)
				{
					num += Main.screenWidth;
				}
				float num2 = Main.screenPosition.Y;
				num2 += Main.rand.Next(Main.screenHeight);
				Vector2 vector = new Vector2(num, num2);
				float num3 = x - vector.X;
				float num4 = y - vector.Y;
				num3 += Main.rand.Next(-50, 51) * 0.1f;
				num4 += Main.rand.Next(-50, 51) * 0.1f;
				int num5 = 24;
				float num6 = (float)Math.Sqrt(num3 * num3 + num4 * num4);
				num6 = num5 / num6;
				num3 *= num6;
				num4 *= num6;
				Projectile.NewProjectile(num, num2, num3, num4, mod.ProjectileType("ParaxydeKnifePro"), 46, 0f, player.whoAmI, 0f, 0f);
			}
		}

		public override void UpdateBadLifeRegen()
		{
			if (dFear)
			{
				if (player.lifeRegen > 0)
				{
					player.lifeRegen = 0;
				}
				player.lifeRegenTime = 0;
				player.lifeRegen -= 10;
			}
			if (healHurt > 0)
			{
				if (player.lifeRegen > 0)
				{
					player.lifeRegen = 0;
				}
				player.lifeRegenTime = 0;
				player.lifeRegen -= 120 * healHurt;
			}
		}
		public override void UpdateBiomeVisuals()
		{
			TremorPlayer modPlayer = Main.player[Main.myPlayer].GetModPlayer<TremorPlayer>(mod);
			bool UseEffects = modPlayer.ZoneIce;
			player.ManageSpecialBiomeVisuals("Tremor:Ice", UseEffects);
			//player.ManageSpecialBiomeVisuals("Blizzard", UseEffects);
			player.ManageSpecialBiomeVisuals("Tremor:CogLord", NPC.AnyNPCs(mod.NPCType("CogLord")));
			bool useNova = ZoneTowerNova || NovaMonolith;
			player.ManageSpecialBiomeVisuals("Tremor:Nova", useNova);
		}

		public override void CatchFish(Item fishingRod, Item bait, int power, int liquidType, int poolSize, int worldLayer, int questFish, ref int caughtType, ref bool junk)
		{
			if (junk)
			{
				return;
			}
			if (questFish == mod.ItemType("CornFish") && Main.rand.Next(10) == 0)
			{
				caughtType = mod.ItemType("CornFish");
			}
			if (questFish == mod.ItemType("SunflowerFish") && Main.rand.Next(10) == 0)
			{
				caughtType = mod.ItemType("SunflowerFish");
			}
			if (questFish == mod.ItemType("PumpfishFish") && Main.rand.Next(10) == 0)
			{
				caughtType = mod.ItemType("PumpfishFish");
			}
			if (questFish == mod.ItemType("ParrotFish") && Main.rand.Next(10) == 0)
			{
				caughtType = mod.ItemType("ParrotFish");
			}
			if (questFish == mod.ItemType("CrateFish") && Main.rand.Next(10) == 0)
			{
				caughtType = mod.ItemType("CrateFish");
			}
			if (questFish == mod.ItemType("ForkFish") && Main.rand.Next(10) == 0)
			{
				caughtType = mod.ItemType("ForkFish");
			}
			if (questFish == mod.ItemType("GlassFish") && Main.rand.Next(10) == 0)
			{
				caughtType = mod.ItemType("GlassFish");
			}
			if (questFish == mod.ItemType("JawFish") && Main.rand.Next(10) == 0)
			{
				caughtType = mod.ItemType("JawFish");
			}
			if (questFish == mod.ItemType("CoalFish") && Main.rand.Next(10) == 0)
			{
				caughtType = mod.ItemType("CoalFish");
			}
			if (questFish == mod.ItemType("CultistFish") && Main.rand.Next(10) == 0)
			{
				caughtType = mod.ItemType("CultistFish");
			}
			if (questFish == mod.ItemType("AlienFish") && Main.rand.Next(10) == 0)
			{
				caughtType = mod.ItemType("AlienFish");
			}
			if (questFish == mod.ItemType("LunarSquid") && Main.rand.Next(10) == 0)
			{
				caughtType = mod.ItemType("LunarSquid");
			}
			if (questFish == mod.ItemType("WoodenPiranha") && player.ZoneJungle && Main.rand.Next(10) == 0)
			{
				caughtType = mod.ItemType("WoodenPiranha");
			}
			if (questFish == mod.ItemType("KeyFish") && player.ZoneDungeon && Main.rand.Next(10) == 0)
			{
				caughtType = mod.ItemType("KeyFish");
			}

			if (Main.hardMode && Main.rand.Next(20) == 0)
			{
				caughtType = mod.ItemType("GreenPuzzleFragment");
			}
		}
	}
}