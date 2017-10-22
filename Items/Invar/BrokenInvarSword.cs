using System.Reflection;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Tremor.Items.Invar
{
	// for legacy loading
	public class MeltedInvarSword : ModItem
	{
		public override string Texture => $"{typeof(BrokenInvarSword).NamespaceToPath()}/BrokenInvarSword";

		public override void SetDefaults()
		{
			item.CloneDefaults(mod.ItemType<BrokenInvarSword>());
			item.type = mod.ItemType<BrokenInvarSword>();
			item.netID = item.type;
			typeof(Item).GetField("modItem", BindingFlags.Instance | BindingFlags.NonPublic)?.SetValue(item, new BrokenInvarSword());
			typeof(ModItem).GetField("item", BindingFlags.Instance | BindingFlags.NonPublic)?.SetValue(item.modItem, item);
		}
	}

	public class BrokenInvarSword : ModItem
	{
		//public override string Texture => $"{typeof(BrokenInvarSword).NamespaceToPath()}/BrokenInvarSword";

		//public override bool Autoload(ref string name)
		//{
		//	name = "MeltedInvarSword";
		//	return mod.Properties.Autoload;
		//}

		public override void SetDefaults()
		{
			item.width = 28;
			item.height = 30;
			item.maxStack = 990;
			item.value = Item.sellPrice(silver: 1);
			item.rare = 1;
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Broken Invar Sword");
			Tooltip.SetDefault("Broken and useless... But its materials could be reused");
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(this);
			recipe.SetResult(mod.ItemType<InvarBar>());
			recipe.AddTile(TileID.Furnaces);
			recipe.AddRecipe();
		}
	}
}
