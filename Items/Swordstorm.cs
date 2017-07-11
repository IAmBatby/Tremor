using Terraria.ID;
using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Tremor.Items {
public class Swordstorm: ModItem
{
    public override void SetDefaults()
    {

        item.damage = 19;
        item.magic = true;
        item.mana = 5;
        item.width = 40;
        item.height = 40;
        item.useTime = 21;
        item.useAnimation = 21;
        item.useStyle = 5;
        item.noMelee = true;
        item.knockBack = 6;
        item.value = 3000;
        item.rare = 2;
        item.UseSound = SoundID.Item43;
        item.autoReuse = true;
        Item.staff[item.type] = true; //this makes the useStyle animate as a staff instead of as a gun
        item.shoot = mod.ProjectileType("SwordstormPro");
        item.shootSpeed = 18f;
    }

    public override void SetStaticDefaults()
    {
      DisplayName.SetDefault("Swordstorm");
      Tooltip.SetDefault("");
    }

}}
