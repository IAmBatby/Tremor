using Terraria.ModLoader;

namespace Tremor.Items.Archer
{
	[AutoloadEquip(EquipType.Body)]
	public class ArcherChainmail : ModItem
	{

		public override void SetDefaults()
		{

			item.width = 26;
			item.height = 18;
			item.value = 1000;
			item.rare = 2;
			item.vanity = true;
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Archer Chainmail");
			Tooltip.SetDefault("");
		}

	}
}
