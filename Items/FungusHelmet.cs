using Terraria.ID;
using System;
using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Tremor.Items
{
[AutoloadEquip(EquipType.Head)]
	public class FungusHelmet : ModItem
	{

		public override void SetDefaults()
		{

			item.width = 18;
			item.height = 18;
			item.value = 40000;

			item.rare = 3;
			item.defense = 7;
		}

    public override void SetStaticDefaults()
    {
      DisplayName.SetDefault("Fungus Helmet");
      Tooltip.SetDefault("");
    }


		public override void UpdateEquip(Player player)
		{
		}

		public override bool IsArmorSet(Item head, Item body, Item legs)
		{
			return body.type == mod.ItemType("FungusBreastplate") && legs.type == mod.ItemType("FungusGreaves");
		}

        public override void UpdateArmorSet(Player player)
        {
            player.setBonus = "Increases maximum health by 25 and grants Nature's Blessing";
            player.statLifeMax2 += 25;
            player.AddBuff(165, 2);
        }
	
		public override void ArmorSetShadows(Player player)
		{
			player.armorEffectDrawOutlines = true; //�।��� ����஢����
			player.armorEffectDrawShadowLokis = true; //�����쪨� ⥭�
		}

    public override void AddRecipes()
    {
        ModRecipe recipe = new ModRecipe(mod);
        recipe.AddIngredient(null, "FungusElement", 16);
        recipe.AddIngredient(ItemID.GlowingMushroom, 14);
        recipe.AddIngredient(ItemID.GoldHelmet, 1);
        recipe.SetResult(this);
        recipe.AddTile(16);
        recipe.AddRecipe();

        recipe = new ModRecipe(mod);
        recipe.AddIngredient(null, "FungusElement", 16);
        recipe.AddIngredient(ItemID.GlowingMushroom, 14);
        recipe.AddIngredient(ItemID.PlatinumHelmet, 1);
        recipe.SetResult(this);
        recipe.AddTile(16);
        recipe.AddRecipe();
    }
	}
}
