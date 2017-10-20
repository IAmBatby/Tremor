using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Tremor.Items.Invar;

namespace Tremor.Items
{
	[AutoloadEquip(EquipType.Head)]
	public class ChainCoif : ModItem
	{
		public override void SetDefaults()
		{
			item.width = 18;
			item.height = 24;
			item.value = Item.sellPrice(silver: 10);
			item.rare = 1;
			item.defense = 2;
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Chain Coif");
			Tooltip.SetDefault("");
		}

		public override bool IsArmorSet(Item head, Item body, Item legs)
		{
			return body.type == mod.ItemType<Chainmail>() && legs.type == mod.ItemType<ChainGreaves>();
		}

		public override void UpdateArmorSet(Player player)
		{
			player.setBonus = "+1 defense";
			player.statDefense += 1;
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.IronBar, 15);
			recipe.AddIngredient(mod.ItemType<InvarBar>());
			recipe.AddIngredient(ItemID.Chain);
			recipe.AddTile(TileID.Anvils);
			recipe.anyIronBar = true;
			recipe.SetResult(this);
		}
	}
}
