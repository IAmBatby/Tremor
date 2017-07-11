using Terraria;
using Terraria.ModLoader;

namespace Tremor.Buffs
{
	public class GoldenGlowingRingBuff : ModBuff
	{
		int MinionType = -1;
		int MinionID = -1;

		int MinionType1 = -1;
		int MinionID1 = -1;

		const int Damage = 26;
		const float KB = 1;

		public override void SetDefaults()
		{
			Main.buffNoTimeDisplay[Type] = true;
			DisplayName.SetDefault("Fungus Blades");
			Description.SetDefault("Summons two blades to protect you");
		}

		public override void Update(Player player, ref int buffIndex)
		{
			if (MinionType == -1)
				MinionType = mod.ProjectileType("FungusBlueSword");
			if (MinionID == -1 || Main.projectile[MinionID].type != MinionType || !Main.projectile[MinionID].active || Main.projectile[MinionID].owner != player.whoAmI)
				MinionID = Projectile.NewProjectile(player.Center.X, player.Center.Y, 0, 0, MinionType, (int)(Damage * player.meleeDamage), KB, player.whoAmI);
			else
				Main.projectile[MinionID].timeLeft = 6;

			if (MinionType1 == -1)
				MinionType1 = mod.ProjectileType("FungusYellowSword");
			if (MinionID1 == -1 || Main.projectile[MinionID1].type != MinionType1 || !Main.projectile[MinionID1].active || Main.projectile[MinionID1].owner != player.whoAmI)
				MinionID1 = Projectile.NewProjectile(player.Center.X, player.Center.Y, 0, 0, MinionType1, (int)(Damage * player.meleeDamage), KB, player.whoAmI);
			else
				Main.projectile[MinionID1].timeLeft = 6;
		}
	}
}