using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Tremor.Items
{
	[AutoloadEquip(EquipType.Head)]
	public class OrichalcumHeader : ModItem
	{

		public override void SetDefaults()
		{

			item.width = 22;
			item.height = 26;

			item.value = 400;
			item.rare = 4;
			item.defense = 6;
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Orichalcum Header");
			Tooltip.SetDefault("20% increased thrown damage");
		}

		public override void UpdateEquip(Player player)
		{
			player.thrownDamage += 0.20f;
		}

		public override bool IsArmorSet(Item head, Item body, Item legs)
		{
			return body.type == 1213 && legs.type == 1214;
		}

		public override void UpdateArmorSet(Player player)
		{
			player.setBonus = "Increases thrown weapon velocity and flower petals will fall on your target for extra damage";
			player.thrownVelocity += 0.25f;
			player.onHitPetal = true;
		}

		public override void ArmorSetShadows(Player player)
		{
			player.armorEffectDrawShadowSubtle = true;
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.OrichalcumBar, 12);
			recipe.SetResult(this);
			recipe.AddTile(134);
			recipe.AddRecipe();
		}
	}
}
