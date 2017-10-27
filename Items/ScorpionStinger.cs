using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Tremor.Items
{
	public class ScorpionStinger : ModItem
	{
		public override void SetDefaults()
		{

			item.damage = 41;
			item.melee = true;
			item.width = 46;
			item.height = 54;

			item.useTime = 22;
			item.useAnimation = 22;
			item.useStyle = 1;
			item.knockBack = 4;
			item.value = 12000;
			item.rare = 4;
			item.UseSound = SoundID.Item1;
			item.autoReuse = true;
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Scorpion Stinger");
			Tooltip.SetDefault("Poisons enemies");
		}

		public override void OnHitNPC(Player player, NPC target, int damage, float knockback, bool crit)
		{
			target.AddBuff(70, 100);
		}
	}
}
