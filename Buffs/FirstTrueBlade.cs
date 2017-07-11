using Terraria;
using Terraria.ModLoader;

namespace Tremor.Buffs
{
	public class FirstTrueBlade : ModBuff
    {
        int MinionType = -1;
        int MinionID = -1;

        const int Damage = 100;
        const float KB = 1;

        public override void SetDefaults()
		{
			Description.SetDefault("One out of three blades is protecting you");			
			Main.buffNoTimeDisplay[Type] = true;
			DisplayName.SetDefault("First True Blade");
		}

		public override void Update(Player player, ref int buffIndex)
		{
            if (MinionType == -1)
                MinionType = mod.ProjectileType("TrueBladeOne");
            if (MinionID == -1 || Main.projectile[MinionID].type != MinionType || !Main.projectile[MinionID].active || Main.projectile[MinionID].owner != player.whoAmI)
                MinionID = Projectile.NewProjectile(player.Center.X, player.Center.Y, 0, 0, MinionType, (int)(Damage * player.meleeDamage), KB, player.whoAmI);
            else
                Main.projectile[MinionID].timeLeft = 6;
        }
	}
}