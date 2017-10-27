using Terraria;
using Terraria.ModLoader;

namespace Tremor.Items
{
	[AutoloadEquip(EquipType.Head)]
	public class MagiumHelmet : ModItem
	{

		public override void SetDefaults()
		{

			item.width = 38;
			item.height = 22;

			item.value = 18000;
			item.rare = 5;
			item.defense = 8;
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Magium Helmet");
			Tooltip.SetDefault("9% increased magic critical strike chance\n" +
"Increases maximum mana by 40");
		}

		public override void UpdateEquip(Player player)
		{
			player.magicCrit += 9;
			player.statManaMax2 += 40;
		}

		public override bool IsArmorSet(Item head, Item body, Item legs)
		{
			return body.type == mod.ItemType("MagiumBreastplate") && legs.type == mod.ItemType("MagiumGreaves");
		}

		public override void UpdateArmorSet(Player p)
		{
			p.setBonus = "25% decreased mana cost";
			p.manaCost -= 0.25f;
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(null, "RuneBar", 8);
			recipe.AddIngredient(null, "MagiumShard", 6);
			recipe.SetResult(this);
			recipe.AddTile(134);
			recipe.AddRecipe();
		}

	}
}
