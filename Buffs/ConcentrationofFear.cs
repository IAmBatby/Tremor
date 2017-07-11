using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Tremor.Buffs
{
    public class ConcentrationofFear : ModBuff
    {

        public override void SetDefaults()
        {
			DisplayName.SetDefault("Concentration of Fear");
            Description.SetDefault("Increased all damage");
            Main.buffNoTimeDisplay[Type] = true;
        }

public override void Update(Player player, ref int buffIndex)
        {
						player.statDefense += 15;
						player.meleeCrit += 5;
						player.meleeDamage += 0.25f;
						player.meleeSpeed += 0.15f;
						player.magicCrit += 5;
						player.magicDamage += 0.25f;
						player.rangedCrit += 5;
						player.rangedDamage += 0.25f;
						player.thrownCrit += 5;
						player.thrownDamage += 0.25f;
						player.minionDamage += 0.25f;
						player.minionKB += 0.5f;
						player.moveSpeed += 0.15f;
        }
    }
}