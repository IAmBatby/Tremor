using Terraria;
using Terraria.ModLoader;

namespace Tremor.Items
{
	[AutoloadEquip(EquipType.Head)]
	public class BerserkerHelmet : ModItem
	{

		public override void SetDefaults()
		{

			item.width = 32;
			item.height = 26;

			item.value = 400;
			item.rare = 2;
			item.defense = 5;
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Berserker Helmet");
			Tooltip.SetDefault("15% increased melee speed");
		}

		public override void UpdateEquip(Player player)
		{
			player.meleeSpeed += 0.15f;
		}

		public override bool IsArmorSet(Item head, Item body, Item legs)
		{
			return body.type == mod.ItemType("BerserkerChestplate") && legs.type == mod.ItemType("BerserkerGreaves");
		}

		public override void UpdateArmorSet(Player player)
		{
			player.setBonus = "Summons a protective rotating sword!";
			player.AddBuff(mod.BuffType("BerserkerBuff"), 2);
		}

		public override void ArmorSetShadows(Player player)
		{
			player.armorEffectDrawOutlines = true;
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(null, "SteelBar", 16);
			recipe.AddIngredient(null, "MinotaurHorn", 1);
			recipe.AddIngredient(null, "EarthFragment", 8);
			recipe.SetResult(this);
			recipe.AddTile(16);
			recipe.AddRecipe();
		}
	}
}
