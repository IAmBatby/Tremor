using Terraria.ID;
using Terraria.ModLoader;

namespace Tremor.Items
{
	public class BoneKnife : ModItem
	{
		public override void SetDefaults()
		{

			item.damage = 83;
			item.thrown = true;
			item.width = 26;
			item.noUseGraphic = true;
			item.maxStack = 999;
			item.consumable = true;
			item.height = 30;
			item.useTime = 20;
			item.useAnimation = 20;
			item.shoot = mod.ProjectileType("BoneKnifePro");
			item.shootSpeed = 18f;
			item.useStyle = 1;
			item.knockBack = 4;
			item.value = 7;
			item.rare = 6;
			item.UseSound = SoundID.Item1;
			item.autoReuse = true;
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Bone Knife");
			Tooltip.SetDefault("");
		}

	}
}
