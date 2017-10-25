using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Tremor.Items
{
	[AutoloadEquip(EquipType.Legs)]
	public class StoneLeggings : ModItem
	{
		public override void SetDefaults()
		{
			item.width = 26;
			item.height = 18;
			item.value = Item.sellPrice(silver: 1);
			item.rare = 1;
			item.defense = 2;
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Stone Leggings");
			Tooltip.SetDefault("10% reduced movement speed\nThe stone protects you, but makes you slower");
		}

		public override void UpdateEquip(Player player)
		{
			player.maxRunSpeed -= 0.10f;
			player.moveSpeed -= 0.10f;
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.StoneBlock, 30);
			recipe.SetResult(this);
			recipe.AddTile(TileID.Anvils);
			recipe.AddRecipe();
		}
	}
}
