using Terraria;
using Terraria.ModLoader;

namespace Tremor
{
	// Todo: transfer more to a general class
	public class MPlayer : ModPlayer
	{
		public static MPlayer GetModPlayer(Player player)
			=> player.GetModPlayer<MPlayer>();

		// Buffs and debuffs
		public bool fragileContiion;

		// Alchemist
		public float alchemicalDamage;
		public float alchemicalKbAddition;
		public float alchemicalKbMult;
		public int alchemicalCrit;

		// Undocumented
		public bool pyro;
		public bool nitro;
		public bool spirit;
		public bool enchanted;
		public bool glove;
		public bool core;
		public bool novaAura;
		public bool novaSet;
		public bool novaHelmet;
		public bool novaChestplate;

		public override void ResetEffects()
		{
			// Buffs and debuffs
			fragileContiion = false;

			// Alchemist
			alchemicalDamage = 1f;
			alchemicalKbAddition = 0f;
			alchemicalKbMult = 1f;
			alchemicalCrit = 0;

			// Undocumented
			pyro = false;
			nitro = false;
			spirit = false;
			enchanted = false;
			glove = false;
			core = false;
			novaAura = false;
			novaSet = false;
			novaHelmet = false;
			novaChestplate = false;
		}

		public override void PostUpdateMiscEffects()
		{
			// Reset conditions
			if (fragileContiion)
				player.statDefense = 0;
		}
	}
}
