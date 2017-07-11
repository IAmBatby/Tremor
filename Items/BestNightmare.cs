using Terraria.ID;
using System;
using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Microsoft.Xna.Framework;
using Terraria.DataStructures;

namespace Tremor.Items {
public class BestNightmare : ModItem
{
    public override void SetDefaults()
    {

        item.damage = 260;
        item.thrown = true;
        item.width = 48;
        item.height = 48;
        item.useTime = 50;
        item.shootSpeed = 30f;
        item.useAnimation = 50;
        item.useStyle = 1;
        item.knockBack = 9f;
        item.shoot = mod.ProjectileType("BestNightmarePro");
        item.value = 27600;
        item.rare = 0;
        item.noUseGraphic = true;
        item.UseSound = SoundID.Item1;
        item.autoReuse = true;
    }

    public override void SetStaticDefaults()
    {
      DisplayName.SetDefault("Best Nightmare");
      Tooltip.SetDefault("");
    }


	public override void ModifyTooltips(System.Collections.Generic.List<TooltipLine> tooltips)
        {
            tooltips[0].overrideColor = new Color(238, 194, 73);
        }

}}
