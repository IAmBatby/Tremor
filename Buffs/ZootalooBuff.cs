using System;
using Terraria;
using Terraria.ModLoader;

namespace Tremor.Buffs
{
	public class ZootalooBuff : ModBuff
	{
		public override void SetDefaults()
		{
			DisplayName.SetDefault("Zootaloo Junior");
			Description.SetDefault("A little Zootaloo is following you");
			Main.buffNoTimeDisplay[Type] = true;
			Main.vanityPet[Type] = true;
		}

		public override void Update(Player player, ref int buffIndex)
		{
			player.buffTime[buffIndex] = 18000;
			TremorPlayer modPlayer = (TremorPlayer)player.GetModPlayer(mod, "TremorPlayer");
			modPlayer.petZootaloo = true;
			bool petProjectileNotSpawned = true;
			if (player.ownedProjectileCounts[mod.ProjectileType("ZootalooPet")] > 0)
			{
				petProjectileNotSpawned = false;
			}
			if (petProjectileNotSpawned && player.whoAmI == Main.myPlayer)
			{
				Projectile.NewProjectile(player.position.X + (float)(player.width / 2), player.position.Y + (float)(player.height / 2), 0f, 0f, mod.ProjectileType("ZootalooPet"), 0, 0f, player.whoAmI, 0f, 0f);
			}
		}
	}
}