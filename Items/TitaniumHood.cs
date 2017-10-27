using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Tremor.Items
{
	[AutoloadEquip(EquipType.Head)]
	public class TitaniumHood : ModItem
	{

		public override void SetDefaults()
		{

			item.width = 24;
			item.height = 24;

			item.value = 400;
			item.rare = 4;
			item.defense = 8;
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Titanium Hood");
			Tooltip.SetDefault("24% increased minion damage");
		}

		public override void UpdateEquip(Player player)
		{
			player.minionDamage += 0.24f;
		}

		public override bool IsArmorSet(Item head, Item body, Item legs)
		{
			return body.type == 1218 && legs.type == 1219;
		}

		public override void UpdateArmorSet(Player player)
		{
			player.setBonus = "Increases your max number of minions and briefly become invulnerable after striking an enemy";
			player.maxMinions += 3;
			player.onHitDodge = true;
		}

		public override void ArmorSetShadows(Player player)
		{
			player.armorEffectDrawOutlines = true;
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.TitaniumBar, 12);
			recipe.SetResult(this);
			recipe.AddTile(134);
			recipe.AddRecipe();
		}
	}
}
