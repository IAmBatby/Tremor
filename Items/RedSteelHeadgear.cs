using Terraria;
using Terraria.ModLoader;

namespace Tremor.Items
{
	[AutoloadEquip(EquipType.Head)]
	public class RedSteelHeadgear : ModItem
	{


		public override void SetDefaults()
		{

			item.width = 26;
			item.height = 20;
			item.value = 200;
			item.rare = 1;

			item.defense = 8;
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Red Steel Headgear");
			Tooltip.SetDefault("10% increased melee damage");
		}


		public override void UpdateEquip(Player player)
		{
			player.meleeDamage += 0.1f;
		}


		public override bool IsArmorSet(Item head, Item body, Item legs)
		{
			return body.type == mod.ItemType("RedSteelChestplate") && legs.type == mod.ItemType("RedSteelGreaves");
		}

		public override void UpdateArmorSet(Player p)
		{
			p.setBonus = "Grants chance to dodge attack";
			p.blackBelt = true;
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(null, "RedSteelArmorPiece", 5);
			recipe.AddIngredient(null, "RedSteelBar", 7);
			recipe.SetResult(this);
			recipe.AddTile(16);
			recipe.AddRecipe();
		}
	}
}
