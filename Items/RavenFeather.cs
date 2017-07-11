using Terraria.ID;
using System;
using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Tremor.Items {
public class RavenFeather : ModItem
{
		public override void SetDefaults()
		{

			item.width = 18;
			item.height = 18;
			item.rare = 4;
                        item.maxStack = 999;
		}

    public override void SetStaticDefaults()
    {
      DisplayName.SetDefault("Raven Feather");
      Tooltip.SetDefault("");
    }

}}
