using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Tremor.Items.Adamantite
{
	[AutoloadEquip(EquipType.Head)]
	public class AdamantiteHat : ModItem
	{
		public override void SetDefaults()
		{

			item.width = 20;
			item.height = 26;

			item.value = 400;
			item.rare = 4;
			item.defense = 7;
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Adamantite Hat");
			Tooltip.SetDefault("24% increased minion damage");
		}

		public override void UpdateEquip(Player player)
		{
			player.minionDamage += 0.24f;
		}

		public override bool IsArmorSet(Item head, Item body, Item legs)
		{
			return body.type == 403 && legs.type == 404;
		}

		public override void UpdateArmorSet(Player player)
		{
			player.setBonus = "Increases your max number of minions";
			player.maxMinions += 3;
		}

		public override void ArmorSetShadows(Player player)
		{
			player.armorEffectDrawOutlines = true;
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.AdamantiteBar, 12);
			recipe.SetResult(this);
			recipe.AddTile(134);
			recipe.AddRecipe();
		}
	}
}
