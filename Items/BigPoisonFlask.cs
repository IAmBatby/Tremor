using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Tremor.Items
{
	public class BigPoisonFlask : AlchemistItem
	{

		public override void SetDefaults()
		{
			item.crit = 4;
			item.damage = 40;
			//item.thrown = true;
			item.width = 26;
			item.noUseGraphic = true;
			item.maxStack = 999;
			item.consumable = true;
			item.height = 30;
			item.useTime = 20;
			item.useAnimation = 20;
			item.shoot = mod.ProjectileType("BigPoisonFlaskPro");
			item.shootSpeed = 8f;
			item.useStyle = 1;
			item.knockBack = 1;
			item.UseSound = SoundID.Item106;
			item.value = 200;
			item.rare = 4;
			item.autoReuse = false;

			item.ammo = mod.ItemType("BoomFlask");
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Big Poison Flask");
			Tooltip.SetDefault("Throws a flask that explodes into poison clouds\n" +
"Clouds deal damage to enemies and poisons them");
		}

		public override void PickAmmo(Player player, ref int type, ref float speed, ref int damage, ref float knockback)
		{
			type = mod.ProjectileType("PoisonCloudPro");
		}

		public override void UpdateInventory(Player player)
		{
			MPlayer modPlayer = MPlayer.GetModPlayer(player);
			if (modPlayer.novaHelmet)
			{
				item.autoReuse = true;
			}
			if (!modPlayer.novaHelmet)
			{
				item.autoReuse = false;
			}

			if (player.FindBuffIndex(mod.BuffType("LongFuseBuff")) != -1)
			{
				item.shootSpeed = 11f;
			}
			if (player.FindBuffIndex(mod.BuffType("LongFuseBuff")) < 1)
			{
				item.shootSpeed = 8f;
			}
			if (modPlayer.core)
			{
				item.autoReuse = true;
			}
			if (!modPlayer.core)
			{
				item.autoReuse = false;
			}
		}
		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(null, "LesserPoisonFlask", 45);
			recipe.AddIngredient(ItemID.Vine, 2);
			recipe.AddIngredient(ItemID.SoulofLight, 3);
			recipe.SetResult(this, 30);
			recipe.AddRecipe();
		}

	}
}
