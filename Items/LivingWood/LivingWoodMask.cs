using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Tremor.Items.LivingWood
{
	[AutoloadEquip(EquipType.Head)]
	public class LivingWoodMask : ModItem
	{

		public override void SetDefaults()
		{

			item.width = 34;
			item.height = 26;

			item.value = 200;
			item.rare = 1;
			item.defense = 1;
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Living Wood Mask");
			Tooltip.SetDefault("4% increased minion damage");
		}

		public override void UpdateEquip(Player player)
		{
			player.minionDamage += 0.04f;
		}

		public override bool IsArmorSet(Item head, Item body, Item legs)
		{
			return body.type == mod.ItemType("LivingWoodBreastplate") && legs.type == mod.ItemType("LivingWoodGreaves");
		}

		public override void UpdateArmorSet(Player player)
		{
			player.setBonus = "Increases your max number of minions";
			player.maxMinions += 1;
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.Wood, 20);
			recipe.SetResult(this);
			recipe.AddTile(304);
			recipe.AddRecipe();
		}

	}
}
