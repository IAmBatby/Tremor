using Terraria.ID;
using System;
using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Tremor.Items
{
[AutoloadEquip(EquipType.Head)]
    public class HallowedVisage : ModItem
    {

        public override void SetDefaults()
        {

            item.width = 26;
            item.height = 20;

            item.value = 50000;
            item.rare = 5;
            item.defense = 10;
        }

    public override void SetStaticDefaults()
    {
      DisplayName.SetDefault("Hallowed Visage");
      Tooltip.SetDefault("Increases alchemic damage by 27%");
    }


        public override void UpdateEquip(Player player)
        {
            player.GetModPlayer<MPlayer>(mod).alchemistDamage += 0.27f;
        }

        public override bool IsArmorSet(Item head, Item body, Item legs)
        {
            return body.type == 551 && legs.type == 552;
        }

        public override void UpdateArmorSet(Player player)
        {
            player.setBonus = "Increases alchemic critical chance by 23%";
            player.GetModPlayer<MPlayer>(mod).alchemistCrit += 23;
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
