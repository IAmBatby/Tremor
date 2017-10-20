using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Tremor.Items.Invar
{
	public abstract class _InvarGreaves : TremorAbstractItem
	{
		public override string Texture => $"{typeof(_InvarGreaves).NamespaceToPath()}/InvarGreaves";

		protected sealed override void Defaults()
		{
			item.width = 22;
			item.height = 18;
			item.value = Item.sellPrice(silver: 13);
			item.rare = 1;
			item.defense = 2;
		}

		protected sealed override void StaticDefaults()
		{
			DisplayName.SetDefault("Invar Greaves");
			Tooltip.SetDefault("");
		}
	}

	[AutoloadEquip(EquipType.Legs)]
	public class ReinforcedInvarGreaves : _InvarGreaves
	{
		public override void SafeDefaults()
		{
			item.defense += 1;
			item.value = Item.sellPrice(silver: 15);
		}

		public override void SafeStaticDefaults()
		{
			DisplayName.SetDefault("Reinforced Invar Greaves");
			Tooltip.SetDefault("Reinforced to grant +1 defense");
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(mod.ItemType<InvarGreaves>());
			recipe.AddIngredient(mod.ItemType<InvarBar>(), 2);
			recipe.SetResult(this);
			recipe.AddTile(TileID.Anvils);
			recipe.AddRecipe();
		}
	}

	[AutoloadEquip(EquipType.Legs)]
	public class InvarGreaves : _InvarGreaves
	{
		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(mod.ItemType<InvarBar>(), 12);
			recipe.SetResult(this);
			recipe.AddTile(TileID.Anvils);
			recipe.AddRecipe();
		}
	}
}
