using Terraria.ModLoader;

namespace Tremor
{
	public class MPlayer : ModPlayer
	{
		// Our alchemist damage modifier. Every damage that is alchemist damage will be multiplied by this value,
		// so if a weapon for example does 60 damage and we have 50% alchemist damage increase, it will be:
		// 60 * 1.5 = 90 damage.
		public float alchemistDamage;
		public int alchemistCrit;
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
			alchemistDamage = 1;
			alchemistCrit = 0;
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
	}
}
