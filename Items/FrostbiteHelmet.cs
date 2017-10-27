using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Tremor.Items
{
	[AutoloadEquip(EquipType.Head)]
	public class FrostbiteHelmet : ModItem
	{
		public override void SetDefaults()
		{
			item.width = 32;
			item.height = 26;
			item.value = 100;
			item.rare = 1;
			item.defense = 1;
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Frostbite Helmet");
			Tooltip.SetDefault("");
		}

		public override bool IsArmorSet(Item head, Item body, Item legs)
		{
			return body.type == mod.ItemType("FrostbiteChestplate") && legs.type == mod.ItemType("FrostbiteGreaves");
		}

		public override void UpdateArmorSet(Player p)
		{
			p.setBonus = "Grants immunity to frozen effect and to ice breaking";
			p.buffImmune[44] = true;
			p.iceSkate = true;
			p.statDefense += 2;
			p.moveSpeed -= 0.21f;
		}

		public override void ArmorSetShadows(Player player)
		{
			player.armorEffectDrawShadow = true;
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.IceBlock, 45);
			recipe.SetResult(this);
			recipe.AddTile(16);
			recipe.AddRecipe();
		}
	}
}
