using Terraria;
using Terraria.ModLoader;

namespace Tremor.Buffs
{
	public class GurdPetBuff : ModBuff
	{
		public override void SetDefaults()
		{
			DisplayName.SetDefault("Gurd Pet");
			Description.SetDefault("20% increased alchemical damage");
			Main.buffNoTimeDisplay[Type] = true;
			Main.vanityPet[Type] = true;
		}

		public override void Update(Player player, ref int buffIndex)
		{
			player.GetModPlayer<MPlayer>(mod).alchemicalCrit += 20;
			player.buffTime[buffIndex] = 18000;
			TremorPlayer modPlayer = (TremorPlayer)player.GetModPlayer(mod, "TremorPlayer");
			modPlayer.gurdPet = true;
			bool petProjectileNotSpawned = true;
			if (player.ownedProjectileCounts[mod.ProjectileType("GurdPet")] > 0)
			{
				petProjectileNotSpawned = false;
			}
			if (petProjectileNotSpawned && player.whoAmI == Main.myPlayer)
			{
				Projectile.NewProjectile(player.position.X + player.width / 2, player.position.Y + player.height / 2, 0f, 0f, mod.ProjectileType("GurdPet"), 0, 0f, player.whoAmI, 0f, 0f);
			}
		}
	}
}