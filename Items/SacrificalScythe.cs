using Terraria.ID;
using System;
using Terraria;
using Terraria.ModLoader;

namespace Tremor.Items {
public class SacrificalScythe : ModItem
{
    public override void SetDefaults()
    {

        item.damage = 16;
        item.melee = true;
        item.width = 42;
        item.height = 42;
        item.useTime = 31;
        item.useAnimation = 21;
        item.useStyle = 1;
        item.knockBack = 10;
        item.value = 26660;
        item.rare = 1;
        item.UseSound = SoundID.Item1;
        item.autoReuse = false;
    }

    public override void SetStaticDefaults()
    {
      DisplayName.SetDefault("Sacrifical Scythe");
      Tooltip.SetDefault("");
    }

}}
