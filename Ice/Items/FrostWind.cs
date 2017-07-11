using Terraria.ID;
using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;

namespace Tremor.Ice.Items {
public class FrostWind : ModItem
{
    public override void SetDefaults()
    {

        item.damage = 20;
        item.melee = true;
        item.width = 46;
        item.height = 46;
        item.useTime = 25;
        item.useAnimation = 25;
        item.useStyle = 1;
        item.knockBack = 5;
        item.value = 15000;
        item.rare = 2;
        item.UseSound = SoundID.Item71;
        item.autoReuse = false;
        item.shoot = mod.ProjectileType("FrostwindPro");
        item.shootSpeed = 12f;
    }

    public override void SetStaticDefaults()
    {
      DisplayName.SetDefault("Frost Wind");
      Tooltip.SetDefault("");
    }

}}
