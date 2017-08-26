using Terraria;
using Terraria.DataStructures;
using Terraria.ModLoader;

namespace Tremor.Items
{
	public class BlackCauldron : ModItem
	{
		public override void SetDefaults()
		{

			item.width = 22;
			item.height = 44;


			item.value = 100000;
			item.rare = 4;
			item.accessory = true;
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Black Cauldron");
			Tooltip.SetDefault("Increased alchemic damage by 12%\nAlchemical weapons confuse your enemies");
			Main.RegisterItemAnimation(item.type, new DrawAnimationVertical(8, 4));
		}


		public override void UpdateAccessory(Player player, bool hideVisual)
		{
			player.GetModPlayer<MPlayer>(mod).alchemicalDamage += 0.12f;
			player.AddBuff(mod.BuffType("CursedCloudBuff"), 2);
		}
	}
}
