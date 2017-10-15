using System.ComponentModel.Design.Serialization;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Tremor.Items
{
	public abstract class _InvarBreastPlate : TremorAbstractItem
	{
		public override string Texture => $"{typeof(_InvarBreastPlate).NamespaceToPath()}/InvarBreastplate";

		protected sealed override void Defaults()
		{
			item.width = 26;
			item.height = 18;
			item.value = Item.sellPrice(silver: 19);
			item.rare = 1;
			item.defense = 3;
		}

		protected sealed override void StaticDefaults()
		{
			DisplayName.SetDefault("Invar Breastplate");
		}
	}


	[AutoloadEquip(EquipType.Body)]
	public class InvarBreastplate : _InvarBreastPlate
	{
		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(mod.ItemType<InvarBar>(), 18);
			recipe.SetResult(this);
			recipe.AddTile(TileID.Furnaces);
			recipe.AddRecipe();
		}
	}

	[AutoloadEquip(EquipType.Body)]
	public class ReinforcedInvarBreastplate : _InvarBreastPlate
	{
		public sealed override void SafeDefaults()
		{
			item.defense += 1;
		}

		public sealed override void SafeStaticDefaults()
		{
			DisplayName.SetDefault("Reinforced Invar Breastplate");
			Tooltip.SetDefault("Reinforced to grant +1 defense");
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(mod.ItemType<InvarBreastplate>());
			recipe.AddIngredient(mod.ItemType<InvarBar>(), 2);
			recipe.SetResult(this);
			recipe.AddTile(TileID.Anvils);
			recipe.AddRecipe();
		}
	}
}
