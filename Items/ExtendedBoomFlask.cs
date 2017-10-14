using System.Linq;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Tremor.Items
{
	public class ExtendedBoomFlask : AlchemistItem
	{
		public override void SetDefaults()
		{
			item.crit = 4;
			item.damage = 54;
			//item.thrown = true;
			item.width = 26;
			item.noUseGraphic = true;
			item.maxStack = 999;
			item.consumable = true;
			item.height = 30;
			item.useTime = 40;
			item.useAnimation = 40;
			item.shoot = mod.ProjectileType("BoomFlaskPro");
			item.shootSpeed = 10f;
			item.useStyle = 1;
			item.knockBack = 1;
			item.UseSound = SoundID.Item106;
			item.value = 145;
			item.rare = 2;
			item.autoReuse = false;
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Extended Boom Flask");
			Tooltip.SetDefault("A vial of exploding chemicals");
		}

		public override void UpdateInventory(Player player)
		{
			if (player.HasBuff(mod.BuffType("LongFuseBuff")))
			{
				item.shootSpeed = 11f;
			}
			else
			{
				item.shootSpeed = 8f;
			}

			item.autoReuse = MPlayer.GetModPlayer(player).core;
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(null, "BoomFlask", 25);
			recipe.AddIngredient(1347, 1);
			recipe.AddIngredient(ItemID.SoulofNight, 1);
			recipe.AddIngredient(null, "GelCube", 1);
			recipe.SetResult(this, 20);
			recipe.AddRecipe();
		}
	}
}
