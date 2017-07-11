using Terraria.ID;
using System;
using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Tremor.Items
{ 
[AutoloadEquip(EquipType.Head)]
    public class AdamantiteVisage : ModItem
    {
        public override void SetDefaults()
        {

            item.width = 22;
            item.height = 24;

            item.value = 400;
            item.rare = 4;
            item.defense = 8;
        }

    public override void SetStaticDefaults()
    {
      DisplayName.SetDefault("Adamantite Visage");
      Tooltip.SetDefault("Increases alchemic damage by 24%");
    }


        public override void UpdateEquip(Player player)
        {
            player.GetModPlayer<MPlayer>(mod).alchemistDamage += 0.24f;
        }

        public override bool IsArmorSet(Item head, Item body, Item legs)
        {
            return body.type == 403 && legs.type == 404;
        }

        public override void UpdateArmorSet(Player player)
        {
            player.setBonus = "Increases alchemic critical strike chance by 20%";
            player.GetModPlayer<MPlayer>(mod).alchemistCrit += 20;
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.AdamantiteBar, 10);
            recipe.SetResult(this);
            recipe.AddTile(134);
            recipe.AddRecipe();
        }
    }
}
