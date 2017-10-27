using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Tremor.Items
{
	[AutoloadEquip(EquipType.Head)]
	public class TitaniumHeader : ModItem
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
			DisplayName.SetDefault("Titanium Header");
			Tooltip.SetDefault("24% increased thrown damage");
		}

		public override void UpdateEquip(Player player)
		{
			player.thrownDamage += 0.24f;
		}

		public override bool IsArmorSet(Item head, Item body, Item legs)
		{
			return body.type == 1218 && legs.type == 1219;
		}

		public override void UpdateArmorSet(Player player)
		{
			player.setBonus = "Increases thrown weapon velocity and briefly become invulnerable after striking an enemy";
			player.thrownVelocity += 0.25f;
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
