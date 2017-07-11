using Terraria.ID;
using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Tremor.Items {
public class CornJavelin : ModItem
{
    public override void SetDefaults()
    {

        item.damage = 22;
        item.thrown = true;
        item.width = 26;
        item.noUseGraphic = true;
        item.maxStack = 999;
        item.consumable = true;
        item.height = 30;
        item.useTime = 17;
        item.useAnimation = 17;
        item.shoot = mod.ProjectileType("CornJavelinPro");
        item.shootSpeed = 22f; 
        item.useStyle = 1;
        item.knockBack = 4;
        item.value = 7;
        item.rare = 1;
        item.UseSound = SoundID.Item1;
        item.autoReuse = false;
    }

    public override void SetStaticDefaults()
    {
      DisplayName.SetDefault("Corn Javelin");
      Tooltip.SetDefault("");
    }


}}
