using System;
using Terraria;
using Terraria.ModLoader;

namespace Tremor.ZombieEvent.Buffs
{
	public class HauntPetBuff : ModBuff
	{
		public override void SetDefaults()
		{
			DisplayName.SetDefault("Haunt Pet Buff");
			Description.SetDefault("Increases summon damage by 10%");
			Main.buffNoTimeDisplay[Type] = true;
			Main.vanityPet[Type] = true;
		}

		public override void Update(Player player, ref int buffIndex)
		{
                        
            player.minionDamage += 0.1f;

			player.buffTime[buffIndex] = 18000;
			TremorPlayer modPlayer = (TremorPlayer)player.GetModPlayer(mod, "TremorPlayer");
			modPlayer.hauntpet = true;
			bool petProjectileNotSpawned = true;
			if (player.ownedProjectileCounts[mod.ProjectileType("TheHauntPro")] > 0)
			{
				petProjectileNotSpawned = false;
			}
			if (petProjectileNotSpawned && player.whoAmI == Main.myPlayer)
			{
				Projectile.NewProjectile(player.position.X + (float)(player.width / 2), player.position.Y + (float)(player.height / 2), 0f, 0f, mod.ProjectileType("TheHauntPro"), 0, 0f, player.whoAmI, 0f, 0f);
			}
		}
	}
}