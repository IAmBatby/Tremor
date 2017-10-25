using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Tremor.Items
{
	[AutoloadEquip(EquipType.Head)]
	public class StoneHelmet : ModItem
	{
		public override void SetDefaults()
		{
			item.width = 22;
			item.height = 26;
			item.value = Item.sellPrice(silver: 1);
			item.rare = 1;
			item.defense = 2;
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Stone Helmet");
			Tooltip.SetDefault("`Your neck starts to ache`");
		}

		public override bool IsArmorSet(Item head, Item body, Item legs)
		{
			return body.type == mod.ItemType("StoneChestplate") && legs.type == mod.ItemType("StoneLeggings");
		}

		public override void UpdateArmorSet(Player player)
		{
			player.setBonus = "Increases maximum defense by 2";
			player.statDefense += 2;
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.StoneBlock, 25);
			recipe.SetResult(this);
			recipe.AddTile(TileID.Anvils);
			recipe.AddRecipe();
		}
	}
}
