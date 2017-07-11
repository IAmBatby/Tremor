using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Tremor;
using Tremor.NPCs;

namespace Tremor.Buffs
{
	public class DeathFear : ModBuff
	{
		public override void SetDefaults()
		{
			DisplayName.SetDefault("Death Fear");
			Description.SetDefault("Frightened, the victim loses his life");
			Main.debuff[Type] = true;
			Main.pvpBuff[Type] = true;
			Main.buffNoSave[Type] = true;
			longerExpertDebuff = true;
		}

		public override void Update(Player player, ref int buffIndex)
		{
			player.GetModPlayer<TremorPlayer>(mod).dFear = true;
		}

		public override void Update(NPC npc, ref int buffIndex)
		{
			npc.GetGlobalNPC<TremorGlobalNPC>(mod).dFear = true;
		}

	}
}
