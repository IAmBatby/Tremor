using Terraria;
using Terraria.ModLoader;

namespace Tremor.Items
{
	public class ParatrooperLens : ModItem
	{

		public override void SetDefaults()
		{

			item.width = 27;
			item.height = 26;
			item.rare = 11;
			item.value = 3000000;

			item.accessory = true;
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Paratrooper's Lens");
			Tooltip.SetDefault("Increases projectile's speed twice");
		}


		public override void UpdateAccessory(Player player, bool hideVisual)
		{
			player.AddBuff(mod.BuffType("ShootSpeedBuff2"), 2);
		}
	}
}
