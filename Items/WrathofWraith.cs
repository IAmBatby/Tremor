using Terraria.ID;
using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Tremor.Items {
public class WrathofWraith : ModItem
{
    public override void SetDefaults()
    {

        item.damage = 40;
        item.magic = true;
        item.mana = 8;
        item.width = 40;
        item.height = 40;
        item.useTime = 28;
        item.useAnimation = 28;
        item.useStyle = 5;
        item.noMelee = true;
        item.knockBack = 3;
        item.value = 13800;
        item.rare = 4;
        item.UseSound = SoundID.Item43;
        item.autoReuse = false;
        Item.staff[item.type] = true; //this makes the useStyle animate as a staff instead of as a gun
        item.shoot = mod.ProjectileType("WraithWrathPro");
        item.shootSpeed = 15f;
    }

    public override void SetStaticDefaults()
    {
      DisplayName.SetDefault("Wrath of Wraith");
      Tooltip.SetDefault("");
    }


}}
