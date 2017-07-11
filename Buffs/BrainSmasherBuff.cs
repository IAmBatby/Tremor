using Terraria;
using Terraria.ModLoader;

namespace Tremor.Buffs
{
	public class BrainSmasherBuff : ModBuff
    {
        int MinionType = -1;
        int MinionID = -1;

        const int Damage = 90;
        const float KB = 1;

        public override void SetDefaults()
		{
			Main.buffNoTimeDisplay[Type] = true;
			DisplayName.SetDefault("Brain Smasher");
		}

		public override void Update(Player player, ref int buffIndex)
		{
            if (MinionType == -1)
                MinionType = mod.ProjectileType("BrainSmasherPro");
            if (MinionID == -1 || Main.projectile[MinionID].type != MinionType || !Main.projectile[MinionID].active || Main.projectile[MinionID].owner != player.whoAmI)
                MinionID = Projectile.NewProjectile(player.Center.X, player.Center.Y, 0, 0, MinionType, (int)(Damage * player.meleeDamage), KB, player.whoAmI);
            else
                Main.projectile[MinionID].timeLeft = 6;
        }
	}
}