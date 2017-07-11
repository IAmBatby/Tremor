using Terraria;
using Terraria.ModLoader;

namespace Tremor.Buffs
{
	public class Sad : ModBuff
	{
		public override void SetDefaults()
		{
			DisplayName.SetDefault("Sad");
			Description.SetDefault("10% decreased damage");
			Main.debuff[Type] = true;
		}

		public override void Update(NPC npc, ref int buffIndex)
		{
			npc.damage = (int)(npc.damage - 0.1f);
		}
	}
}