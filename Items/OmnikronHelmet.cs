using Terraria.ID;
using System;
using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Microsoft.Xna.Framework;
using System.Collections.Generic;

namespace Tremor.Items { [AutoloadEquip(EquipType.Head)]
public class OmnikronHelmet : ModItem
{


    public override void SetDefaults()
    {

        item.width = 38;
        item.height = 22;

        item.value = 0;
        item.rare = 0;
        item.defense = 22;
    }

    public override void SetStaticDefaults()
    {
      DisplayName.SetDefault("Omnikron Helmet");
      Tooltip.SetDefault("Increased all critical strike chances by 25%");
    }

	
	    public override void ModifyTooltips(System.Collections.Generic.List<TooltipLine> tooltips)
        {
            tooltips[0].overrideColor = new Color(238, 194, 73);
        }
    public override bool IsArmorSet(Item head, Item body, Item legs)
    {
return body.type == mod.ItemType("OmnikronBreastplate") && legs.type == mod.ItemType("OmnikronGreaves");
    }

        public override void UpdateArmorSet(Player player)
        {
            player.setBonus = "Calls ancient soul to protect you";
            player.AddBuff(mod.BuffType("Omnibuff"), 2);
    if(Math.Abs(player.velocity.X) + Math.Abs(player.velocity.Y) > 1f && !player.rocketFrame) // Makes sure the player is actually moving
    {
        for (int k = 0; k < 2; k++)
        {
            int index= Dust.NewDust(new Vector2(player.position.X - player.velocity.X * 2f, player.position.Y - 2f - player.velocity.Y * 2f), player.width, player.height, 60, 0f, 0f, 100, default(Color), 2f);
            Main.dust[index].noGravity = true;
            Main.dust[index].noLight = true;
            Dust dust = Main.dust[index];
            dust.velocity.X = dust.velocity.X - player.velocity.X * 0.5f;
            dust.velocity.Y = dust.velocity.Y - player.velocity.Y * 0.5f;
        }
    }
        }

		public override void UpdateEquip(Player player)
		{
	    player.meleeCrit += 25;
	    player.magicCrit += 25;
	    player.rangedCrit += 25;
	    player.thrownCrit += 25;
	    player.GetModPlayer<MPlayer>(mod).alchemistCrit += 25;
		}

		public override void ArmorSetShadows(Player player)
		{
			        player.armorEffectDrawOutlines=true;
		}



    public override void AddRecipes()
    {
        ModRecipe recipe = new ModRecipe(mod);
        recipe.AddIngredient(null, "OmnikronBar", 15);
        recipe.SetResult(this);
        recipe.AddTile(412);
        recipe.AddRecipe();
    }
}}
