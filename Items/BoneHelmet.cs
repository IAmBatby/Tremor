using Terraria.ID;
using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace Tremor.Items { [AutoloadEquip(EquipType.Head)]
public class BoneHelmet : ModItem
{

        public override void SetDefaults()
        {


            item.defense = 5;
            item.width = 26;
            item.height = 22;
            item.value = 2500;
            item.rare = 4;
        }

    public override void SetStaticDefaults()
    {
      DisplayName.SetDefault("Bone Helmet");
      Tooltip.SetDefault("25% increased throwing velocity");
    }


        public override void UpdateEquip(Player p)
        {
            p.thrownVelocity += 0.25f;
        }

    public override bool IsArmorSet(Item head, Item body, Item legs)
    {
            return body.type == mod.ItemType("BoneShell") && legs.type == mod.ItemType("BoneGreaves");
    }

    public override void UpdateArmorSet(Player player)
    {
        player.setBonus = "Increases defense by 6";
        player.boneArmor = true;
        player.statDefense += 6;


    if(Math.Abs(player.velocity.X) + Math.Abs(player.velocity.Y) > 1f && !player.rocketFrame) // Makes sure the player is actually moving
    {
        for (int k = 0; k < 2; k++)
        {
            int index= Dust.NewDust(new Vector2(player.position.X - player.velocity.X * 2f, player.position.Y - 2f - player.velocity.Y * 2f), player.width, player.height, 26, 0f, 0f, 100, default(Color), 2f);
            Main.dust[index].noGravity = true;
            Main.dust[index].noLight = true;
            Dust dust = Main.dust[index];
            dust.velocity.X = dust.velocity.X - player.velocity.X * 0.5f;
            dust.velocity.Y = dust.velocity.Y - player.velocity.Y * 0.5f;
        }
    }
    }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(151, 1);
            recipe.AddIngredient(3374, 1);
        recipe.AddIngredient(null, "CursedSoul", 1);
        recipe.AddIngredient(ItemID.SoulofNight, 3);
        recipe.AddIngredient(null, "SharpenedTooth", 3);
        recipe.AddIngredient(null, "TheRib", 3);
            recipe.SetResult(this);
            recipe.AddTile(16);
            recipe.AddRecipe();
        }
    }
}
