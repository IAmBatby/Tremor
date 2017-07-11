using Terraria.ID;
using System;
using Terraria;
using Terraria.ModLoader;

namespace Tremor.Items {
//ported from my tAPI mod because I don't want to make more artwork
public class Eyezor : ModItem
{
    public override void SetDefaults()
    {

        item.damage = 37;
        item.magic = true;
        item.width = 20;
        item.height = 12;
        item.useTime = 6;
        item.useAnimation = 20;
        item.useStyle = 5;
        item.knockBack = 6;
        item.value = Item.buyPrice(0, 5, 0, 0);
        item.rare = 5;
        item.mana = 7;
        item.useStyle = 5;
        item.UseSound = SoundID.Item20;
        item.noMelee = true;
        item.autoReuse = true;
        item.shoot = 606;
        item.shootSpeed = 30f;
    }

    public override void SetStaticDefaults()
    {
      DisplayName.SetDefault("Eyezor");
      Tooltip.SetDefault("");
    }

}}
