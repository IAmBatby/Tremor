using Terraria.ID;
using Terraria;
using Terraria.ModLoader;

namespace Tremor.Items
{
	public class VultureStaff : ModItem
	{
		public override void SetDefaults()
		{

			item.damage = 14;
			item.summon = true;
			item.mana = 12;
			item.width = 30;
			item.height = 28;

			item.useTime = 36;
			item.useAnimation = 36;
			item.useStyle = 1;
			item.noMelee = true;
			item.knockBack = 3;
			item.value = Item.buyPrice(0, 1, 2, 0);
			item.rare = 2;
			item.UseSound = SoundID.Item44;
			item.shoot = mod.ProjectileType("VultureStaffPro");
			item.shootSpeed = 1f;
			item.buffType = mod.BuffType("VultureBuff");
			item.buffTime = 3600;
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Vulture Staff");
			Tooltip.SetDefault("Summons a vulture to fight for you.");
		}

	}
}
