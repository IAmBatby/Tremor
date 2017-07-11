using Terraria.ID;
using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Tremor.Items {
public class SDL : ModItem
{
    public override void SetDefaults()
    {

        item.damage = 70;
        item.ranged = true;
        item.width = 40;
        item.height = 40;

        item.useTime = 30;
        item.useAnimation = 30;
        item.shoot = 135; 
        item.shootSpeed =  25f; 
        item.useAmmo = AmmoID.Rocket;
        item.useStyle = 5;
        item.knockBack = 4;
        item.value = 60000;
        item.rare = 11;
        item.UseSound = SoundID.Item11;
        item.autoReuse = true;
    }

    public override void SetStaticDefaults()
    {
      DisplayName.SetDefault("S.D.L.");
      Tooltip.SetDefault("Uses rockets as ammo");
    }

}}
