using Terraria.ID;
using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Tremor.Items {
public class BurningHammer : ModItem
{
    public override void SetDefaults()
    {

        item.damage = 18;
        item.thrown = true;
        item.width = 26;
        item.noUseGraphic = true;
        item.maxStack = 999;
        item.consumable = true;
        item.height = 30;
        item.useTime = 20;
        item.useAnimation = 20;
        item.shoot = mod.ProjectileType("BurningHammerPro");
        item.shootSpeed = 10f; 
        item.useStyle = 1;
        item.knockBack = 4;
        item.value = 7;
        item.rare = 3;
        item.UseSound = SoundID.Item1;
        item.autoReuse = false;
    }

    public override void SetStaticDefaults()
    {
      DisplayName.SetDefault("Burning Hammer");
      Tooltip.SetDefault("");
    }

}}
