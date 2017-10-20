using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Tremor.Items.Invar;

namespace Tremor.Items
{
	[AutoloadEquip(EquipType.Legs)]
	public class ChainGreaves : ModItem
	{
		public override void SetDefaults()
		{
			item.width = 22;
			item.height = 14;
			item.value = Item.sellPrice(silver: 6);
			item.rare = 1;
			item.defense = 2;
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Chain Greaves");
			Tooltip.SetDefault("");
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.IronBar, 20);
			recipe.AddIngredient(mod.ItemType<InvarBar>());
			recipe.AddIngredient(ItemID.Chain);
			recipe.AddTile(TileID.Anvils);
			recipe.anyIronBar = true;
			recipe.SetResult(this);
		}
	}
}
