using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace Tremor.Items.Souls
{
	public class PhantomSoul : ModItem
	{
		public override void SetDefaults()
		{

			item.width = 32;
			item.height = 58;
			item.maxStack = 99;
			item.value = 100;
			item.rare = 2;
			ItemID.Sets.ItemNoGravity[item.type] = true;
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Phantom Soul");
			Tooltip.SetDefault("");
			Main.RegisterItemAnimation(item.type, new DrawAnimationVertical(10, 4));
		}

	}
}
