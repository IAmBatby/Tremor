using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Tremor.Items
{
	[AutoloadEquip(EquipType.Body)]
	public class StoneChestplate : ModItem
	{
		public override void SetDefaults()
		{
			item.width = 34;
			item.height = 22;
			item.value = Item.sellPrice(silver: 1);
			item.rare = 1;
			item.defense = 3;
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Stone Chestplate");
			Tooltip.SetDefault("10% reduced melee speed\nThe stone protects you, but makes you slower");
		}

		public override void UpdateEquip(Player player)
		{
			player.meleeSpeed -= 0.1f;
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.StoneBlock, 45);
			recipe.SetResult(this);
			recipe.AddTile(TileID.Anvils);
			recipe.AddRecipe();
		}

	}
}
