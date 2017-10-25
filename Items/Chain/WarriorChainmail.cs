using Terraria.ModLoader;

namespace Tremor.Items.Chain
{
	[AutoloadEquip(EquipType.Body)]
	public class WarriorChainmail : ModItem
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
			DisplayName.SetDefault("Warrior Chainmail");
			Tooltip.SetDefault("");
		}

	}
}
