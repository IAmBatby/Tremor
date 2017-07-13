using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Tremor.NovaPillar.Items.Weapons
{
	public class NovaFlask : AlchemistItem
	{

		public override void SetDefaults()
		{
			item.damage = 46;
			item.width = 18;
			item.noUseGraphic = true;
			item.maxStack = 999;
			item.height = 28;
			item.useTime = 11;
			item.useAnimation = 11;
			item.shoot = mod.ProjectileType("NovaFlask_Proj");
			item.shootSpeed = 13f;
			item.useStyle = 1;
			item.knockBack = 1;
			item.UseSound = SoundID.Item106;
			item.value = 30;
			item.rare = 10;
			item.crit = 12;
			item.autoReuse = false;
			item.consumable = true;
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Nova Flask");
			Tooltip.SetDefault("Shoots out a nova flask that explodes into two balls\nBalls explode into flames after some time or when they hit enemy\nFlames explode into damagin bursts after some time or when they hit enemy");
		}


		public override void UpdateInventory(Player player)
		{
			MPlayer modPlayer = player.GetModPlayer<MPlayer>(mod);
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
				item.shootSpeed = 15f;
			}
			if (player.FindBuffIndex(mod.BuffType("LongFuseBuff")) < 1)
			{
				item.shootSpeed = 13f;
			}
			if (player.FindBuffIndex(mod.BuffType("FlaskCoreBuff")) != -1)
			{
				item.autoReuse = true;
			}
			if (player.FindBuffIndex(mod.BuffType("FlaskCoreBuff")) < 1)
			{
				item.autoReuse = false;
			}
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(null, "NovaFragment", 3);
			recipe.AddIngredient(null, "BasicFlask", 1);
			recipe.SetResult(this, 111);
			recipe.AddTile(412);
			recipe.AddRecipe();
		}
	}
}
