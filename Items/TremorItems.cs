using Terraria.ID;
using Terraria;
using Terraria.ModLoader;

namespace Tremor.Items
{
	public class TremorItems : GlobalItem
	{

		public override void UpdateEquip(Item item, Player player)
		{
			//items damage
			if (item.type == 1865)
			{
				player.GetModPlayer<MPlayer>(mod).alchemistDamage += 0.1f;
			}
			if (item.type == 3110)
			{
				player.GetModPlayer<MPlayer>(mod).alchemistDamage += 0.1f;
			}
			if (item.type == 899)
			{
				player.GetModPlayer<MPlayer>(mod).alchemistDamage += 0.1f;
			}
			if (item.type == 900)
			{
				player.GetModPlayer<MPlayer>(mod).alchemistDamage += 0.1f;
			}
			if (item.type == 935)
			{
				player.GetModPlayer<MPlayer>(mod).alchemistDamage += 0.12f;
			}
			if (item.type == 1301)
			{
				player.GetModPlayer<MPlayer>(mod).alchemistDamage += 0.1f;
			}
			if (item.type == 552)
			{
				player.GetModPlayer<MPlayer>(mod).alchemistDamage += 0.07f;
			}
			if (item.type == 1208)
			{
				player.GetModPlayer<MPlayer>(mod).alchemistDamage += 0.03f;
			}
			if (item.type == 1209)
			{
				player.GetModPlayer<MPlayer>(mod).alchemistDamage += 0.02f;
			}
			if (item.type == 379)
			{
				player.GetModPlayer<MPlayer>(mod).alchemistDamage += 0.05f;
			}
			if (item.type == 403)
			{
				player.GetModPlayer<MPlayer>(mod).alchemistDamage += 0.06f;
			}
			if (item.type == 1218)
			{
				player.GetModPlayer<MPlayer>(mod).alchemistDamage += 0.04f;
			}
			if (item.type == 1219)
			{
				player.GetModPlayer<MPlayer>(mod).alchemistDamage += 0.03f;
			}
			if (item.type == 1004)
			{
				player.GetModPlayer<MPlayer>(mod).alchemistDamage += 0.05f;
			}
			//items crit chance
			if (item.type == 374)
			{
				player.GetModPlayer<MPlayer>(mod).alchemistCrit += 3;
			}
			if (item.type == 1208)
			{
				player.GetModPlayer<MPlayer>(mod).alchemistCrit += 2;
			}
			if (item.type == 1209)
			{
				player.GetModPlayer<MPlayer>(mod).alchemistCrit += 1;
			}
			if (item.type == 380)
			{
				player.GetModPlayer<MPlayer>(mod).alchemistCrit += 5;
			}
			if (item.type == 1213)
			{
				player.GetModPlayer<MPlayer>(mod).alchemistCrit += 6;
			}
			if (item.type == 404)
			{
				player.GetModPlayer<MPlayer>(mod).alchemistCrit += 4;
			}
			if (item.type == 1218)
			{
				player.GetModPlayer<MPlayer>(mod).alchemistCrit += 3;
			}
			if (item.type == 1219)
			{
				player.GetModPlayer<MPlayer>(mod).alchemistCrit += 3;
			}
			if (item.type == 3808)
			{
				player.GetModPlayer<MPlayer>(mod).alchemistCrit += 10;
			}
			if (item.type == 551)
			{
				player.GetModPlayer<MPlayer>(mod).alchemistCrit += 7;
			}
			if (item.type == 1004)
			{
				player.GetModPlayer<MPlayer>(mod).alchemistCrit += 7;
			}
			if (item.type == 1317)
			{
				player.GetModPlayer<MPlayer>(mod).alchemistCrit += 8;
			}
			if (item.type == 3873)
			{
				player.GetModPlayer<MPlayer>(mod).alchemistCrit += 30;
			}
		}

		public override void SetDefaults(Item item)
		{
			if (item.ranged == true && Main.player[Main.myPlayer].active && Main.player[Main.myPlayer].FindBuffIndex(mod.BuffType("ShotSpeedBuff")) != -1)
			{
				item.shootSpeed *= 2f;
			}
			if (item.ranged == true && Main.player[Main.myPlayer].active && Main.player[Main.myPlayer].FindBuffIndex(mod.BuffType("ShotSpeedBuff")) != -1)
			{
				item.shootSpeed *= 2f;
			}
			if (item.type == 2196)
			{
				item.value = 30;
			}
			if (item.type == ItemID.Minishark)
			{
				item.value = 500000;
			}
			if (item.type == 3)
			{

			}
			if (item.type == ItemID.EnchantedSword && Main.player[Main.myPlayer].active && Main.player[Main.myPlayer].FindBuffIndex(mod.BuffType("EnchantedBuff")) != -1)
			{
				item.damage += 5;
			}
			if (item.type == ItemID.EnchantedBoomerang && Main.player[Main.myPlayer].active && Main.player[Main.myPlayer].FindBuffIndex(mod.BuffType("EnchantedBuff")) != -1)
			{
				item.damage += 5;
			}
			if (item.type == ItemID.SlimeStaff)
			{
				item.value = 2000;
			}
		}
	}
}