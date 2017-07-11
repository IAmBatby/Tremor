using System;
using Terraria;
using Terraria.ModLoader;

namespace Tremor.Buffs
{
	public class GoldenWhale : ModBuff
	{
		public override void SetDefaults()
		{
			DisplayName.SetDefault("Golden Whale");
			Description.SetDefault("Promote your business!");
			Main.buffNoTimeDisplay[Type] = true;
			Main.vanityPet[Type] = true;
		}

		public override void Update(Player player, ref int buffIndex)
		{
			player.meleeEnchant = 4;

			player.buffTime[buffIndex] = 18000;
			TremorPlayer modPlayer = (TremorPlayer)player.GetModPlayer(mod, "TremorPlayer");
			modPlayer.goldenWhale = true;
			bool petProjectileNotSpawned = true;
			if (player.ownedProjectileCounts[mod.ProjectileType("GoldenWhalePro")] > 0)
			{
				petProjectileNotSpawned = false;
			}
			if (petProjectileNotSpawned && player.whoAmI == Main.myPlayer)
			{
				Projectile.NewProjectile(player.position.X + (float)(player.width / 2), player.position.Y + (float)(player.height / 2), 0f, 0f, mod.ProjectileType("GoldenWhalePro"), 0, 0f, player.whoAmI, 0f, 0f);
			}
		}
	}
}