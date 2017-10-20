using Terraria.ModLoader;

namespace Tremor.Items.RedSteel
{
	public class FaultyRedSteelShield : ModItem
	{
		public override void SetDefaults()
		{
			item.width = 30;
			item.height = 28;
			item.maxStack = 99;
			item.value = 50;
			item.rare = 1;
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Faulty Red Steel Shield");
			Tooltip.SetDefault("");
		}
	}
}
