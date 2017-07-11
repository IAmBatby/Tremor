using Terraria.ID;
using Terraria;
using Terraria.ModLoader;

namespace Tremor.Items
{
	public class RoundBlast : ModItem
	{
		public override bool CanEquipAccessory(Player player, int slot)
		{
			for (int i = 0; i < player.armor.Length; i++)
			{
				MPlayer modPlayer = (MPlayer)player.GetModPlayer(mod, "MPlayer");
				if (modPlayer.pyro == true)
				{
					return false;
				}
			}
			return true;
		}

		public override void SetDefaults()
		{

			item.width = 22;
			item.height = 44;

			item.value = 300000;
			item.rare = 6;
			item.accessory = true;
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Round Blast");
			Tooltip.SetDefault("Alchemical projectiles leave explosions in the shape of round");
		}


		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.ExplosivePowder, 25);
			recipe.AddIngredient(null, "Chemikaze", 1);
			recipe.AddIngredient(null, "ChaosBar", 25);
			recipe.AddIngredient(ItemID.SoulofSight, 3);
			recipe.SetResult(this);
			recipe.AddTile(114);
			recipe.AddRecipe();
		}

		public override void UpdateAccessory(Player player, bool hideVisual)
		{
			MPlayer modPlayer = (MPlayer)player.GetModPlayer(mod, "MPlayer");
			player.AddBuff(mod.BuffType("RoundBlastBuff"), 2);
			modPlayer.pyro = true;
		}
	}
}
