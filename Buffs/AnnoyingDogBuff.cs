using Terraria;
using Terraria.ModLoader;

namespace Tremor.Buffs
{
	public class AnnoyingDogBuff : ModBuff
	{
		public override void SetDefaults()
		{
			DisplayName.SetDefault("Annoying Dog");
			Description.SetDefault("It wants to absorb your artifact");
			Main.buffNoTimeDisplay[Type] = true;
			Main.vanityPet[Type] = true;
		}

		public override void Update(Player player, ref int buffIndex)
		{
			player.buffTime[buffIndex] = 18000;
			TremorPlayer modPlayer = (TremorPlayer)player.GetModPlayer(mod, "TremorPlayer");
			modPlayer.AnnoyingDog = true;
			bool petProjectileNotSpawned = true;
			if (player.ownedProjectileCounts[mod.ProjectileType("AnnoyingDog")] > 0)
			{
				petProjectileNotSpawned = false;
			}
			if (petProjectileNotSpawned && player.whoAmI == Main.myPlayer)
			{
				Projectile.NewProjectile(player.position.X + (float)(player.width / 2), player.position.Y + (float)(player.height / 2), 0f, 0f, mod.ProjectileType("AnnoyingDog"), 0, 0f, player.whoAmI, 0f, 0f);
			}
		}
	}
}