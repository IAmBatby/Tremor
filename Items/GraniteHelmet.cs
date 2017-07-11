using Terraria.ID;
using Terraria;
using Terraria.ModLoader;

namespace Tremor.Items
{
	[AutoloadEquip(EquipType.Head)]
	public class GraniteHelmet : ModItem
	{


		public override void SetDefaults()
		{

			item.width = 18;
			item.height = 18;
			item.value = 2500;
			item.rare = 1;
			item.defense = 2;
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Granite Helmet");
			Tooltip.SetDefault("");
		}

		public override bool IsArmorSet(Item head, Item body, Item legs)
		{
			return body.type == mod.ItemType("GraniteChestplate") && legs.type == mod.ItemType("GraniteGreaves");
		}

		public override void UpdateArmorSet(Player player)
		{
			player.setBonus = "Increases maximum defense by 3";
			player.statDefense += 3;
			player.moveSpeed -= 0.20f;
		}

		public override void ArmorSetShadows(Player player)
		{
			player.armorEffectDrawShadowSubtle = true;
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.GraniteBlock, 30);
			recipe.AddIngredient(null, "StoneofLife", 1);
			recipe.SetResult(this);
			recipe.AddTile(16);
			recipe.AddRecipe();
		}
	}
}
