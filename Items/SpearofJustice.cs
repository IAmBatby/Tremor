using Terraria.ID;
using Terraria.ModLoader;

namespace Tremor.Items
{
	public class SpearofJustice : ModItem
	{
		public override void SetDefaults()
		{

			item.value = 1000000;
			item.useStyle = 1;
			item.useAnimation = 20;
			item.useTime = 20;

			item.autoReuse = true;
			item.rare = 11;
			item.width = 42;
			item.height = 42;
			item.UseSound = SoundID.Item8;
			item.damage = 228;
			item.knockBack = 4;
			item.mana = 8;
			item.shoot = mod.ProjectileType("SpearofJusticePro");
			item.shootSpeed = 14f;
			item.noMelee = true; //So that the swing itself doesn't do damage; this weapon is projectile-only
			item.noUseGraphic = true; //No swing animation
			item.magic = true;
			item.crit = 7;
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Spear of Justice");
			Tooltip.SetDefault("'NGAAAAAHHHHHHHHHHHHHHHHH!'");
		}

	}
}
