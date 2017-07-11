using System;
using Terraria;
using Terraria.ModLoader;

namespace Tremor.Invasion
{
	public class Light : ModBuff
	{
		public override void SetDefaults()
		{
			DisplayName.SetDefault("Light Spell");
			Description.SetDefault("");
			Main.buffNoSave[Type] = true;
			Main.buffNoTimeDisplay[Type] = false;
		}

		public override void Update(Player player, ref int buffIndex)
		{
            player.meleeSpeed += 0.03f;
            player.detectCreature = true;
            player.findTreasure = true;
            player.meleeDamage += 0.03f;
            player.rangedDamage += 0.03f;
            player.thrownDamage += 0.03f;
            player.minionDamage += 0.03f;
            player.magicDamage += 0.03f;
            player.moveSpeed += 0.2f;
            player.rangedCrit += 2;
            player.meleeCrit += 2;
            player.magicCrit += 2;
            player.thrownCrit += 2;
            player.jumpSpeedBoost += 0.2f;
        }
	}
}