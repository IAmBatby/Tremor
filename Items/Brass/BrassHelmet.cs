using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Tremor.Items.Brass
{
	[AutoloadEquip(EquipType.Head)]
	public class BrassHelmet : ModItem
	{

		public override void SetDefaults()
		{

			item.width = 20;
			item.height = 20;

			item.value = 400;
			item.rare = 5;
			item.defense = 8;
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Brass Helmet");
			Tooltip.SetDefault("10% increased melee damage\n" +
"Increases melee critical strike chance by 8");
		}

		public override void UpdateEquip(Player player)
		{
			player.meleeCrit += 8;
			player.meleeDamage += 0.1f;
		}

		public override bool IsArmorSet(Item head, Item body, Item legs)
		{
			return body.type == mod.ItemType("BrassChestplate") && legs.type == mod.ItemType("BrassGreaves");
		}

		public override void UpdateArmorSet(Player player)
		{
			player.AddBuff(mod.BuffType("buffSteampunkProbe"), 4);
			player.AddBuff(mod.BuffType("SteamSwordBuff"), 4);
			player.setBonus = "Summons a Steampunk Drone to fight for you and increases damage of Brass Chain Repeater";
		}

		public override void ArmorSetShadows(Player player)
		{
			player.armorEffectDrawOutlines = true;
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(null, "BrassBar", 13);
			recipe.AddIngredient(ItemID.Cog, 12);
			recipe.AddIngredient(ItemID.Glass, 6);
			recipe.SetResult(this);
			recipe.AddTile(134);
			recipe.AddRecipe();
		}
	}
}
