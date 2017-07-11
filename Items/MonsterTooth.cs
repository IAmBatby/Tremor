using Terraria.ID;
using Terraria.ModLoader;

namespace Tremor.Items
{
	public class MonsterTooth : ModItem
	{
		public override void SetDefaults()
		{

			item.damage = 15;
			item.thrown = true;
			item.width = 26;
			item.noUseGraphic = true;
			item.maxStack = 999;
			item.consumable = true;
			item.height = 30;
			item.useTime = 20;
			item.useAnimation = 20;
			item.shoot = mod.ProjectileType("MonsterToothPro");
			item.shootSpeed = 22f;
			item.useStyle = 1;
			item.knockBack = 4;
			item.value = 7;
			item.rare = 2;
			item.UseSound = SoundID.Item1;
			item.autoReuse = false;
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Monster Tooth");
			Tooltip.SetDefault("");
		}


	}
}
