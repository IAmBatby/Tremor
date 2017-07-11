using Terraria.ID;
using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Tremor.Items {
public class BoomSpear : ModItem
{
    public override void SetDefaults()
    {

        item.damage = 18;
        item.thrown = true;
        item.width = 18;
        item.noUseGraphic = true;
        item.maxStack = 999;
        item.consumable = true;
        item.height = 38;
        item.useTime = 20;
        item.useAnimation = 20;
        item.shoot = 246;
        item.shootSpeed = 8f; 
        item.useStyle = 1;
        item.knockBack = 4;
        item.value = 80;
        item.rare = 2;
        item.UseSound = SoundID.Item1;
        item.autoReuse = false;
    }

    public override void SetStaticDefaults()
    {
      DisplayName.SetDefault("Boom Javelin");
      Tooltip.SetDefault("");
    }

}}
