using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Tremor.Items.Ancient
{
	public class AncientVisionStaff : ModItem
	{
		public override void SetDefaults()
		{

			item.damage = 80;
			item.summon = true;
			item.mana = 12;
			item.width = 26;
			item.height = 28;

			item.useTime = 36;
			item.useAnimation = 36;
			item.useStyle = 1;
			item.noMelee = true;
			item.knockBack = 3;
			item.value = Item.buyPrice(0, 2, 0, 0);
			item.rare = 10;
			item.UseSound = SoundID.Item44;
			item.shoot = mod.ProjectileType("AncientVisionPro");
			item.shootSpeed = 1f;
			item.buffType = mod.BuffType("AncientVisionBuff");
			item.buffTime = 3600;
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Ancient Vision Staff");
			Tooltip.SetDefault("Summons an ancient vision to fight for you.");
		}

		public override bool AltFunctionUse(Player player)
		{
			return true;
		}

		public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
		{
			return player.altFunctionUse != 2;
		}

		public override bool UseItem(Player player)
		{
			if (player.altFunctionUse == 2)
			{
				player.MinionNPCTargetAim();
			}
			return base.UseItem(player);
		}
	}
}
