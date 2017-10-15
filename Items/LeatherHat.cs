using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Tremor.Items
{
	[AutoloadEquip(EquipType.Head)]
	public class LeatherHat : ModItem
	{
		public override void SetDefaults()
		{
			item.width = 18;
			item.height = 20;
			item.value = 200;
			item.rare = 1;
			item.defense = 1;
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Leather Hat");
			Tooltip.SetDefault("");
		}

		public override bool IsArmorSet(Item head, Item body, Item legs)
		{
			return body.type == mod.ItemType<LeatherShirt>() && legs.type == mod.ItemType<LeatherGreaves>();
		}

		public override void UpdateArmorSet(Player player)
		{
			player.setBonus = "You smell like leather...";
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.Leather, 15);
			recipe.SetResult(this);
		}
	}
}
