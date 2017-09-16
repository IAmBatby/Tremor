using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Tremor.Items
{
	[AutoloadEquip(EquipType.Head)]
	public class MagmoniumHelmet : ModItem
	{

		public override void SetDefaults()
		{

			item.defense = 20;
			item.width = 26;
			item.height = 32;
			item.value = 40000;
			item.rare = 8;
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Magmonium Helmet");
			Tooltip.SetDefault("Inflicts fire damage on attack");
		}

		public override void UpdateEquip(Player player)
		{
			player.magmaStone = true;
		}

		public override bool IsArmorSet(Item head, Item body, Item legs)
		{
			return body.type == mod.ItemType("MagmoniumBreastplate") && legs.type == mod.ItemType("MagmoniumGreaves");
		}

		public override void UpdateArmorSet(Player player)
		{
			player.setBonus = "Provides immunity to lava and fire";
			player.buffImmune[BuffID.OnFire] = true;
			player.buffImmune[BuffID.Burning] = true;
			player.lavaImmune = true;
		}

		public override void ArmorSetShadows(Player player)
		{
			player.armorEffectDrawShadowLokis = true;
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(null, "MagmoniumBar", 15);
			recipe.SetResult(this);
			recipe.AddTile(134);
			recipe.AddRecipe();
		}
	}
}
