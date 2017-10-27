using Terraria;
using Terraria.ModLoader;

namespace Tremor.Items
{
	[AutoloadEquip(EquipType.Head)]
	public class GuardianHelmet : ModItem
	{

		public override void SetDefaults()
		{

			item.defense = 50;
			item.width = 26;
			item.height = 32;
			item.value = 25000;
			item.rare = 10;
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Guardian Helmet");
			Tooltip.SetDefault("");
		}

		public override bool IsArmorSet(Item head, Item body, Item legs)
		{
			return body.type == mod.ItemType("GuardianBreastplate") && legs.type == mod.ItemType("GuardianGreaves");
		}

		public override void UpdateArmorSet(Player player)
		{
			player.setBonus = "Decreases movement speed";
			player.moveSpeed -= 0.3f;
		}

		public override void ArmorSetShadows(Player player)
		{
			player.armorEffectDrawShadowLokis = true;
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(null, "AncientArmorPlate", 12);
			recipe.AddIngredient(null, "Squorb", 1);
			recipe.SetResult(this);
			recipe.AddTile(412);
			recipe.AddRecipe();
		}
	}
}
