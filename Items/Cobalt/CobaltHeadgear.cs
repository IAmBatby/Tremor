using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Tremor.Items.Cobalt
{
	[AutoloadEquip(EquipType.Head)]
	public class CobaltHeadgear : ModItem
	{

		public override void SetDefaults()
		{

			item.width = 20;
			item.height = 26;

			item.value = 400;
			item.rare = 4;
			item.defense = 3;
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Cobalt Headgear");
			Tooltip.SetDefault("18% increased minion damage");
		}

		public override void UpdateEquip(Player player)
		{
			player.minionDamage += 0.18f;
		}

		public override bool IsArmorSet(Item head, Item body, Item legs)
		{
			return body.type == 374 && legs.type == 375;
		}

		public override void UpdateArmorSet(Player player)
		{
			player.setBonus = "Increases your max number of minions";
			player.maxMinions += 1;
		}

		public override void ArmorSetShadows(Player player)
		{
			player.armorEffectDrawShadow = true;
		}
		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.CobaltBar, 12);
			recipe.SetResult(this);
			recipe.AddTile(16);
			recipe.AddRecipe();
		}
	}
}
