using Terraria.ID;
using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Tremor.Items {
public class SandShuriken : ModItem
{
    public override void SetDefaults()
    {


        item.damage = 27;
        item.thrown = true;
        item.width = 26;
        item.noUseGraphic = true;
        item.maxStack = 1;
        item.height = 30;
        item.useTime = 20;
        item.useAnimation = 20;
        item.shoot = mod.ProjectileType("SandShuriken");
        item.shootSpeed = 27f; 
        item.useStyle = 1;
        item.knockBack = 4;
        item.value = 50000;
        item.rare = 5;
        item.UseSound = SoundID.Item1;
        item.autoReuse = false;
    }

    public override void SetStaticDefaults()
    {
      DisplayName.SetDefault("Sand Shuriken");
      Tooltip.SetDefault("Can be used infinitely");
    }

}}
