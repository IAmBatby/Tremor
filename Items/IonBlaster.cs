using Terraria.ID;
using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Tremor.Items {
public class IonBlaster : ModItem
{
    public override void SetDefaults()
    {

        item.damage = 20;
        item.ranged = true;
        item.width = 68;
        item.height = 28;
        item.useTime = 30;
        item.useAnimation = 30;
        item.shoot = 440;
        item.shootSpeed = 14f; 
        item.useStyle = 5;
        item.knockBack = 4;
        item.value = 20000;
        item.rare = 2;
        item.UseSound = SoundID.Item12;
        item.autoReuse = true;
    }

    public override void SetStaticDefaults()
    {
      DisplayName.SetDefault("Ion Blaster");
      Tooltip.SetDefault("");
    }

}}
