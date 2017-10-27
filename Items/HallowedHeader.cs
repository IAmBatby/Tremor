using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Tremor.Items
{
	[AutoloadEquip(EquipType.Head)]
	public class HallowedHeader : ModItem
	{

		public override void SetDefaults()
		{

			item.width = 24;
			item.height = 24;

			item.value = 400;
			item.rare = 4;
			item.defense = 9;
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Hallowed Header");
			Tooltip.SetDefault("26% increased thrown damage");
		}

		public override void UpdateEquip(Player player)
		{
			player.thrownDamage += 0.26f;
		}

		public override bool IsArmorSet(Item head, Item body, Item legs)
		{
			return body.type == 551 && legs.type == 552;
		}

		public override void UpdateArmorSet(Player player)
		{
			player.setBonus = "Increases thrown weapon velocity";
			player.thrownVelocity += 0.25f;
		}

		public override void ArmorSetShadows(Player player)
		{
			player.armorEffectDrawOutlines = true;
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.HallowedBar, 12);
			recipe.SetResult(this);
			recipe.AddTile(134);
			recipe.AddRecipe();
		}
	}
}
