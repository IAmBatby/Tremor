using Terraria;
using Terraria.ModLoader;

namespace Tremor.Items
{
	[AutoloadEquip(EquipType.Head)]
	public class BronzeHelmet : ModItem
	{

		public override void SetDefaults()
		{

			item.width = 32;
			item.height = 26;

			item.value = 400;
			item.rare = 1;
			item.defense = 4;
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Bronze Helmet");
			Tooltip.SetDefault("6% increased melee critical strike chance");
		}

		public override void UpdateEquip(Player player)
		{
			player.meleeCrit += 6;
		}

		public override bool IsArmorSet(Item head, Item body, Item legs)
		{
			return body.type == mod.ItemType("BronzeChestplate") && legs.type == mod.ItemType("BronzeGreaves");
		}

		public override void UpdateArmorSet(Player player)
		{
			player.setBonus = "8% increased damage";
			player.meleeDamage += 0.08f;
			player.magicDamage += 0.08f;
			player.rangedDamage += 0.08f;
		}

		public override void ArmorSetShadows(Player player)
		{
			player.armorEffectDrawShadowSubtle = true;
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(null, "BronzeBar", 13);
			recipe.SetResult(this);
			recipe.AddTile(16);
			recipe.AddRecipe();
		}
	}
}
