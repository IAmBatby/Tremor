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
		public bool pyro = false;
		public bool nitro = false;
		public bool spirit = false;
		public bool enchanted = false;
		public bool glove = false;
		public bool core = false;
		public bool novaAura = false;
		public bool novaSet = false;
		public bool novaHelmet = false;
		public bool novaChestplate = false;

		public override void ResetEffects()
		{
			this.alchemistDamage = 1;
			this.alchemistCrit = 0;
			this.pyro = false;
			this.nitro = false;
			this.spirit = false;
			this.enchanted = false;
			this.glove = false;
			this.core = false;
			this.novaAura = false;
			this.novaSet = false;
			this.novaHelmet = false;
			this.novaChestplate = false;
		}
	}
}
