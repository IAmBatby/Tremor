using Terraria.ID;
using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Tremor.Items {
public class ToxicRazorknife : ModItem
{
    public override void SetDefaults()
    {

        item.damage = 29;
        item.width = 16;
        item.height = 32;
        item.melee = true;
        item.useTime = 30;
        item.shoot = mod.ProjectileType("ToxicRazorknifePro");
        item.shootSpeed = 12f; 
        item.useAnimation = 25;
        item.useStyle = 5;
        item.knockBack = 5;
        item.value = 100000;
        item.rare = 4;
        item.UseSound = SoundID.Item10;
        item.autoReuse = true;
    }

    public override void SetStaticDefaults()
    {
      DisplayName.SetDefault("Toxic Razorknife");
      Tooltip.SetDefault("");
    }

}}
