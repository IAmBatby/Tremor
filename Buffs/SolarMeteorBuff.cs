using Terraria;
using Terraria.ModLoader;

namespace Tremor.Buffs
{
	public class SolarMeteorBuff : ModBuff
	{
		public override void SetDefaults()
		{
			DisplayName.SetDefault("Solar Meteor");
			Description.SetDefault("A  solar meteor is following you");
			Main.buffNoTimeDisplay[Type] = true;
			Main.vanityPet[Type] = true;
		}

		public override void Update(Player player, ref int buffIndex)
		{
			player.buffTime[buffIndex] = 18000;
			TremorPlayer modPlayer = (TremorPlayer)player.GetModPlayer(mod, "TremorPlayer");
			modPlayer.solarMeteor = true;
			bool petProjectileNotSpawned = true;
			if (player.ownedProjectileCounts[mod.ProjectileType("SolarMeteor")] > 0)
			{
				petProjectileNotSpawned = false;
			}
			if (petProjectileNotSpawned && player.whoAmI == Main.myPlayer)
			{
				Projectile.NewProjectile(player.position.X + player.width / 2, player.position.Y + player.height / 2, 0f, 0f, mod.ProjectileType("SolarMeteor"), 0, 0f, player.whoAmI, 0f, 0f);
			}
		}
	}
}