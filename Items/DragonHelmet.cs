using Terraria;
using Terraria.ModLoader;

namespace Tremor.Items
{
	[AutoloadEquip(EquipType.Head)]
	public class DragonHelmet : ModItem
	{

		public override void SetDefaults()
		{

			item.width = 32;
			item.height = 22;

			item.value = 38000;
			item.rare = 11;
			item.defense = 31;
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Dragon Helmet");
			Tooltip.SetDefault("Increases arrow speed and damage");
		}

		public override void UpdateEquip(Player player)
		{
			player.archery = true;
		}

		public override bool IsArmorSet(Item head, Item body, Item legs)
		{
			return body.type == mod.ItemType("DragonBreastplate") && legs.type == mod.ItemType("DragonGreaves");
		}

		public override void UpdateArmorSet(Player p)
		{
			p.setBonus = "Allows you to detect enemies and increases ranged critical strike chance by 25";
			p.rangedCrit += 25;
			p.detectCreature = true;
		}

		public override void ArmorSetShadows(Player player)
		{
			player.armorEffectDrawOutlines = true;
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(null, "DragonCapsule", 14);
			recipe.AddIngredient(null, "EarthFragment", 10);
			recipe.AddTile(412);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}
