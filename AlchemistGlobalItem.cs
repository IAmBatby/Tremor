using Terraria;
using Terraria.ModLoader;

namespace Tremor
{
	public class AlchemistGlobalItem : GlobalItem
	{
		public override bool ConsumeItem(Item item, Player player)
		{
			MPlayer modPlayer = player.GetModPlayer<MPlayer>(mod);
			if (modPlayer.novaChestplate)
			{
				if (player.FindBuffIndex(mod.BuffType("SuperFlask")) != -1)
				{
					if ((item.type == mod.ItemType("LesserManaFlask") || item.type == mod.ItemType("BurningFlask") || item.type == mod.ItemType("BoomFlask") || item.type == mod.ItemType("BigVenomFlask") || item.type == mod.ItemType("BigPoisonFlask") || item.type == mod.ItemType("BigManaFlask") ||
								item.type == mod.ItemType("BigHealingFlack") || item.type == mod.ItemType("BasicFlask") || item.type == mod.ItemType("FreezeFlask") ||
								item.type == mod.ItemType("DepressionFlask") || item.type == mod.ItemType("CrystalFlask") || item.type == mod.ItemType("ClusterFlask") ||
								item.type == mod.ItemType("GoldFlask") || item.type == mod.ItemType("ExtendedFreezeFlask") || item.type == mod.ItemType("ExtendedBurningFlask") ||
								item.type == mod.ItemType("ExtendedBoomFlask") || item.type == mod.ItemType("HealthSupportFlask") || item.type == mod.ItemType("ManaSupportFlask") ||
								item.type == mod.ItemType("LesserVenomFlask") || item.type == mod.ItemType("LesserPoisonFlask") || item.type == mod.ItemType("LesserHealingFlack") ||
								item.type == mod.ItemType("PlagueFlask") || item.type == mod.ItemType("PhantomFlask") || item.type == mod.ItemType("MoonDustFlask") ||
								item.type == mod.ItemType("SparkingFlask") || item.type == mod.ItemType("SuperManaFlask") || item.type == mod.ItemType("SuperHealingFlask") || item.type == mod.ItemType("NovaFlask")) && Main.rand.NextFloat() < 0.65f)
					{
						return false;
					}
				}
				if (player.FindBuffIndex(mod.BuffType("SuperFlaskBig")) != -1)
				{
					if ((item.type == mod.ItemType("LesserManaFlask") || item.type == mod.ItemType("BurningFlask") || item.type == mod.ItemType("BoomFlask") || item.type == mod.ItemType("BigVenomFlask") || item.type == mod.ItemType("BigPoisonFlask") || item.type == mod.ItemType("BigManaFlask") ||
								item.type == mod.ItemType("BigHealingFlack") || item.type == mod.ItemType("BasicFlask") || item.type == mod.ItemType("FreezeFlask") ||
								item.type == mod.ItemType("DepressionFlask") || item.type == mod.ItemType("CrystalFlask") || item.type == mod.ItemType("ClusterFlask") ||
								item.type == mod.ItemType("GoldFlask") || item.type == mod.ItemType("ExtendedFreezeFlask") || item.type == mod.ItemType("ExtendedBurningFlask") ||
								item.type == mod.ItemType("ExtendedBoomFlask") || item.type == mod.ItemType("HealthSupportFlask") || item.type == mod.ItemType("ManaSupportFlask") ||
								item.type == mod.ItemType("LesserVenomFlask") || item.type == mod.ItemType("LesserPoisonFlask") || item.type == mod.ItemType("LesserHealingFlack") ||
								item.type == mod.ItemType("PlagueFlask") || item.type == mod.ItemType("PhantomFlask") || item.type == mod.ItemType("MoonDustFlask") ||
								item.type == mod.ItemType("SparkingFlask") || item.type == mod.ItemType("SuperManaFlask") || item.type == mod.ItemType("SuperHealingFlask") || item.type == mod.ItemType("NovaFlask")) && Main.rand.NextFloat() < 0.85f)
					{
						return false;
					}
				}
				if (player.FindBuffIndex(mod.BuffType("SuperFlaskBig")) < 1 && player.FindBuffIndex(mod.BuffType("SuperFlaskBig")) < 1)
				{
					if ((item.type == mod.ItemType("LesserManaFlask") || item.type == mod.ItemType("BurningFlask") || item.type == mod.ItemType("BoomFlask") || item.type == mod.ItemType("BigVenomFlask") || item.type == mod.ItemType("BigPoisonFlask") || item.type == mod.ItemType("BigManaFlask") ||
								item.type == mod.ItemType("BigHealingFlack") || item.type == mod.ItemType("BasicFlask") || item.type == mod.ItemType("FreezeFlask") ||
								item.type == mod.ItemType("DepressionFlask") || item.type == mod.ItemType("CrystalFlask") || item.type == mod.ItemType("ClusterFlask") ||
								item.type == mod.ItemType("GoldFlask") || item.type == mod.ItemType("ExtendedFreezeFlask") || item.type == mod.ItemType("ExtendedBurningFlask") ||
								item.type == mod.ItemType("ExtendedBoomFlask") || item.type == mod.ItemType("HealthSupportFlask") || item.type == mod.ItemType("ManaSupportFlask") ||
								item.type == mod.ItemType("LesserVenomFlask") || item.type == mod.ItemType("LesserPoisonFlask") || item.type == mod.ItemType("LesserHealingFlack") ||
								item.type == mod.ItemType("PlagueFlask") || item.type == mod.ItemType("PhantomFlask") || item.type == mod.ItemType("MoonDustFlask") ||
								item.type == mod.ItemType("SparkingFlask") || item.type == mod.ItemType("SuperManaFlask") || item.type == mod.ItemType("SuperHealingFlask") || item.type == mod.ItemType("NovaFlask")) && Main.rand.NextFloat() < 0.4f)
					{
						return false;
					}
				}
			}
			if (player.FindBuffIndex(mod.BuffType("SuperFlask")) != -1)
			{
				if ((item.type == mod.ItemType("LesserManaFlask") || item.type == mod.ItemType("BurningFlask") || item.type == mod.ItemType("BoomFlask") || item.type == mod.ItemType("BigVenomFlask") || item.type == mod.ItemType("BigPoisonFlask") || item.type == mod.ItemType("BigManaFlask") ||
							item.type == mod.ItemType("BigHealingFlack") || item.type == mod.ItemType("BasicFlask") || item.type == mod.ItemType("FreezeFlask") ||
							item.type == mod.ItemType("DepressionFlask") || item.type == mod.ItemType("CrystalFlask") || item.type == mod.ItemType("ClusterFlask") ||
							item.type == mod.ItemType("GoldFlask") || item.type == mod.ItemType("ExtendedFreezeFlask") || item.type == mod.ItemType("ExtendedBurningFlask") ||
							item.type == mod.ItemType("ExtendedBoomFlask") || item.type == mod.ItemType("HealthSupportFlask") || item.type == mod.ItemType("ManaSupportFlask") ||
							item.type == mod.ItemType("LesserVenomFlask") || item.type == mod.ItemType("LesserPoisonFlask") || item.type == mod.ItemType("LesserHealingFlack") ||
							item.type == mod.ItemType("PlagueFlask") || item.type == mod.ItemType("PhantomFlask") || item.type == mod.ItemType("MoonDustFlask") ||
							item.type == mod.ItemType("SparkingFlask") || item.type == mod.ItemType("SuperManaFlask") || item.type == mod.ItemType("SuperHealingFlask") || item.type == mod.ItemType("NovaFlask")) && Main.rand.NextFloat() < 0.25f)
				{
					return false;
				}
			}
			if (player.FindBuffIndex(mod.BuffType("SuperFlaskBig")) != -1 && modPlayer.novaAura)
			{
				if ((item.type == mod.ItemType("LesserManaFlask") || item.type == mod.ItemType("BurningFlask") || item.type == mod.ItemType("BoomFlask") || item.type == mod.ItemType("BigVenomFlask") || item.type == mod.ItemType("BigPoisonFlask") || item.type == mod.ItemType("BigManaFlask") ||
							item.type == mod.ItemType("BigHealingFlack") || item.type == mod.ItemType("BasicFlask") || item.type == mod.ItemType("FreezeFlask") ||
							item.type == mod.ItemType("DepressionFlask") || item.type == mod.ItemType("CrystalFlask") || item.type == mod.ItemType("ClusterFlask") ||
							item.type == mod.ItemType("GoldFlask") || item.type == mod.ItemType("ExtendedFreezeFlask") || item.type == mod.ItemType("ExtendedBurningFlask") ||
							item.type == mod.ItemType("ExtendedBoomFlask") || item.type == mod.ItemType("HealthSupportFlask") || item.type == mod.ItemType("ManaSupportFlask") ||
							item.type == mod.ItemType("LesserVenomFlask") || item.type == mod.ItemType("LesserPoisonFlask") || item.type == mod.ItemType("LesserHealingFlack") ||
							item.type == mod.ItemType("PlagueFlask") || item.type == mod.ItemType("PhantomFlask") || item.type == mod.ItemType("MoonDustFlask") ||
							item.type == mod.ItemType("SparkingFlask") || item.type == mod.ItemType("SuperManaFlask") || item.type == mod.ItemType("SuperHealingFlask") || item.type == mod.ItemType("NovaFlask")) && Main.rand.NextFloat() < 0.45f)
				{
					return false;
				}
			}
			return base.ConsumeItem(item, player);
		}
	}
}