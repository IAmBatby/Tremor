using Terraria.ID;
using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Tremor.Items {
public class BlackHoleCannon : ModItem
{
    public override void SetDefaults()
    {

        item.damage = 250;
        item.magic = true;
        item.mana = 15;
        item.width = 68;
        item.height = 28;
        item.useTime = 60;
        item.useAnimation = 60;
        item.shoot = 617;
        item.shootSpeed = 15f; 
        item.useStyle = 5;
        item.knockBack = 4;
        item.value = 20000;

        item.rare = 11;
        item.UseSound = SoundID.Item12;
        item.autoReuse = true;
    }

    public override void SetStaticDefaults()
    {
      DisplayName.SetDefault("Blackhole Cannon");
      Tooltip.SetDefault("Shoots deadly black holes");
    }

}}
