using Terraria.ID;
using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Tremor.Items {
public class ThrowingWrench : ModItem
{
    public override void SetDefaults()
    {

        item.damage = 25;
        item.thrown = true;
        item.width = 28;
        item.noUseGraphic = true;
        item.maxStack = 999;
        item.consumable = true;
        item.height = 30;
        item.useTime = 20;
        item.useAnimation = 20;
        item.shoot = 582;
        item.shootSpeed = 14f; 
        item.useStyle = 1;
        item.knockBack = 4;
        item.value = 60;
        item.rare = 4;
        item.UseSound = SoundID.Item1;
        item.autoReuse = false;
    }

    public override void SetStaticDefaults()
    {
      DisplayName.SetDefault("Throwing Wrench");
      Tooltip.SetDefault("");
    }

}}
