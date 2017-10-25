using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Tremor.Items.Harpy
{
	[AutoloadEquip(EquipType.Head)]
	public class HarpyMask : ModItem
	{

		public override void SetDefaults()
		{

			item.width = 24;
			item.height = 26;

			item.value = 100;
			item.rare = 2;
			item.defense = 3;
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Harpy Mask");
			Tooltip.SetDefault("10% increased ranged damage");
		}

		public override void UpdateEquip(Player player)
		{
			player.rangedDamage += 0.1f;
		}

		public override bool IsArmorSet(Item head, Item body, Item legs)
		{
			return body.type == mod.ItemType("HarpyChestplate") && legs.type == mod.ItemType("HarpyLeggings");
		}

		public override void UpdateArmorSet(Player player)
		{
			player.setBonus = "Allows you to fall slowly";
			player.slowFall = true;
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.Silk, 8);
			recipe.AddIngredient(ItemID.Feather, 4);
			recipe.SetResult(this);
			recipe.AddTile(18);
			recipe.AddRecipe();
		}

	}
}
