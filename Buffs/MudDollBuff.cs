using Terraria;
using Terraria.ModLoader;

namespace Tremor.Buffs
{
	public class MudDollBuff : ModBuff
	{
		public override void SetDefaults()
		{
			DisplayName.SetDefault("Mud Buddy");
			Description.SetDefault("A very muddy friend.");
			Main.buffNoTimeDisplay[Type] = true;
			Main.vanityPet[Type] = true;
		}

		public override void Update(Player player, ref int buffIndex)
		{
			player.buffTime[buffIndex] = 18000;
			TremorPlayer modPlayer = (TremorPlayer)player.GetModPlayer(mod, "TremorPlayer");
			modPlayer.mudDoll = true;
			bool petProjectileNotSpawned = true;
			if (player.ownedProjectileCounts[mod.ProjectileType("MudDoll")] > 0)
			{
				petProjectileNotSpawned = false;
			}
			if (petProjectileNotSpawned && player.whoAmI == Main.myPlayer)
			{
				Projectile.NewProjectile(player.position.X + (float)(player.width / 2), player.position.Y + (float)(player.height / 2), 0f, 0f, mod.ProjectileType("MudDoll"), 0, 0f, player.whoAmI, 0f, 0f);
			}
		}
	}
}