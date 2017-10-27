using Terraria;
using Terraria.ModLoader;

namespace Tremor.Items
{
	public class Popcorn : ModItem
	{
		const int Heal = 1; // Хилл в 1 хп
		const float grabRangeMulti = 0.0f; // Множитель дистанции подбирания предмета (1.0f - 100%)

		public override void SetDefaults()
		{

			item.maxStack = 0;
			item.width = 22;
			item.height = 22;
			item.rare = -1;
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Popcorn");
			Tooltip.SetDefault("");
		}

		public override void GrabRange(Player player, ref int grabRange)
		{
			grabRange = (int)(grabRange * grabRangeMulti);
			base.GrabRange(player, ref grabRange);
		}

		public override bool OnPickup(Player player)
		{
			player.HealEffect(Heal);
			player.statLife += Heal;
			item.active = false;
			return true;
		}
	}
}
