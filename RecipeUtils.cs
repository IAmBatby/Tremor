using System;
using System.Collections.Generic;
using System.Linq;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Tremor.Items;
using Tremor.Items.Souls;
using Tremor.NPCs.Bosses.NovaPillar.Items;
using Tremor.Tiles;
using SandstonePlatform = Tremor.Items.Sandstone.SandstonePlatform;

namespace Tremor
{
	// Our recipe related utilities
	public sealed class RecipeUtils
	{
		// A helper method we can use in the future
		private static void QuickRecipe(Mod mod, short resultType, int[,] ingredients, short? reqTileType = null)
		{
			var recipe = new ModRecipe(mod);
			recipe.SetResult(resultType);
			for (int i = 0; i < ingredients.GetUpperBound(0); i++)
			{
				recipe.AddIngredient(ingredients[i, 0], ingredients[i, 1]);
			}
			if (reqTileType.HasValue)
				recipe.AddTile(reqTileType.Value);
			recipe.AddRecipe();
		}

		public static void AddRecipes(Mod mod)
		{
			#region AddRecipes

			// Quick Recipe example. Too lazy to change all
			// Ideally, there is separation between what holds data and what processes it
			QuickRecipe(mod, ItemID.MagicMirror,
				new int[,]
				{
					{ItemID.SilverBar, 15}, 
					{ItemID.Glass, 5},
					{ItemID.ManaCrystal, 2},
				});

			ModRecipe recipe = new ModRecipe(mod);
			recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.Wood, 8);
			recipe.AddIngredient(ItemID.GoldBar, 2);
			recipe.SetResult(ItemID.GoldChest);
			recipe.AddTile(18);
			recipe.AddRecipe();

			recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.Wood, 8);
			recipe.AddIngredient(ItemID.PlatinumBar, 2);
			recipe.SetResult(ItemID.GoldChest);
			recipe.AddTile(18);
			recipe.AddRecipe();

			recipe = new ModRecipe(mod);
			recipe.AddIngredient(mod.ItemType<Band>());
			recipe.AddIngredient(ItemID.ManaCrystal, 2);
			recipe.SetResult(111);
			recipe.AddTile(16);
			recipe.AddRecipe();

			recipe = new ModRecipe(mod);
			recipe.AddIngredient(mod.ItemType<Band>());
			recipe.AddIngredient(ItemID.LifeCrystal, 2);
			recipe.SetResult(49);
			recipe.AddTile(16);
			recipe.AddRecipe();

			recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.TinBar, 5);
			recipe.AddIngredient(ItemID.Wood);
			recipe.SetResult(ItemID.Aglet);
			recipe.AddTile(16);
			recipe.AddRecipe();

			recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.CopperBar, 5);
			recipe.AddIngredient(ItemID.Wood);
			recipe.SetResult(ItemID.Aglet);
			recipe.AddTile(16);
			recipe.AddRecipe();

			recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.Wood, 10);
			recipe.AddIngredient(ItemID.Gel, 25);
			recipe.SetResult(ItemID.SlimeStaff);
			recipe.AddTile(304);
			recipe.AddRecipe();

			recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.CopperOre, 3);
			recipe.SetResult(ItemID.TinOre, 2);
			recipe.AddTile(mod.TileType<Tiles.MineralTransmutator>());
			recipe.AddRecipe();

			recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.TinOre, 3);
			recipe.SetResult(ItemID.CopperOre, 2);
			recipe.AddTile(mod.TileType<Tiles.MineralTransmutator>());
			recipe.AddRecipe();

			recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.IronOre, 3);
			recipe.SetResult(ItemID.LeadOre, 2);
			recipe.AddTile(mod.TileType<Tiles.MineralTransmutator>());
			recipe.AddRecipe();

			recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.LeadOre, 3);
			recipe.SetResult(ItemID.IronOre, 2);
			recipe.AddTile(mod.TileType<Tiles.MineralTransmutator>());
			recipe.AddRecipe();

			recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.SilverOre, 3);
			recipe.SetResult(ItemID.TungstenOre, 2);
			recipe.AddTile(mod.TileType<Tiles.MineralTransmutator>());
			recipe.AddRecipe();

			recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.TungstenOre, 3);
			recipe.SetResult(ItemID.SilverOre, 2);
			recipe.AddTile(mod.TileType<Tiles.MineralTransmutator>());
			recipe.AddRecipe();

			recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.GoldOre, 3);
			recipe.SetResult(ItemID.PlatinumOre, 2);
			recipe.AddTile(mod.TileType<Tiles.MineralTransmutator>());
			recipe.AddRecipe();

			recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.PlatinumOre, 3);
			recipe.SetResult(ItemID.GoldOre, 2);
			recipe.AddTile(mod.TileType<Tiles.MineralTransmutator>());
			recipe.AddRecipe();

			recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.DemoniteOre, 5);
			recipe.SetResult(ItemID.CrimtaneOre, 3);
			recipe.AddTile(mod.TileType<Tiles.MineralTransmutator>());
			recipe.AddRecipe();

			recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.CrimtaneOre, 5);
			recipe.SetResult(ItemID.DemoniteOre, 3);
			recipe.AddTile(mod.TileType<Tiles.MineralTransmutator>());
			recipe.AddRecipe();

			recipe = new ModRecipe(mod);
			recipe.AddIngredient(mod.ItemType<TrueBloodCarnage>());
			recipe.AddIngredient(674);
			recipe.AddTile(134);
			recipe.SetResult(757);
			recipe.AddRecipe();

			recipe = new ModRecipe(mod);
			recipe.AddIngredient(mod.ItemType<SoulofMind>(), 20);
			recipe.AddIngredient(ItemID.SharkFin, 5);
			recipe.AddIngredient(ItemID.IllegalGunParts);
			recipe.AddIngredient(ItemID.Minishark);
			recipe.SetResult(533);
			recipe.AddTile(134);
			recipe.AddRecipe();

			recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.HallowedBar, 4);
			recipe.AddIngredient(ItemID.SoulofLight, 3);
			recipe.AddIngredient(mod.ItemType<SoulofMind>(), 5);
			recipe.SetResult(561);
			recipe.AddTile(134);
			recipe.AddRecipe();

			recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.HallowedBar, 18);
			recipe.AddIngredient(ItemID.SoulofFright);
			recipe.AddIngredient(mod.ItemType<SoulofMind>());
			recipe.AddIngredient(ItemID.SoulofSight);
			recipe.SetResult(579);
			recipe.AddTile(134);
			recipe.AddRecipe();

			recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.HallowedBar, 18);
			recipe.AddIngredient(ItemID.SoulofFright);
			recipe.AddIngredient(mod.ItemType<SoulofMind>());
			recipe.AddIngredient(ItemID.SoulofSight);
			recipe.SetResult(990);
			recipe.AddTile(134);
			recipe.AddRecipe();

			recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.WarriorEmblem);
			recipe.AddIngredient(ItemID.SoulofFright, 5);
			recipe.AddIngredient(mod.ItemType<SoulofMind>(), 5);
			recipe.AddIngredient(ItemID.SoulofSight, 5);
			recipe.SetResult(935);
			recipe.AddTile(134);
			recipe.AddRecipe();

			recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.SummonerEmblem);
			recipe.AddIngredient(ItemID.SoulofFright, 5);
			recipe.AddIngredient(mod.ItemType<SoulofMind>(), 5);
			recipe.AddIngredient(ItemID.SoulofSight, 5);
			recipe.SetResult(935);
			recipe.AddTile(134);
			recipe.AddRecipe();

			recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.RangerEmblem);
			recipe.AddIngredient(ItemID.SoulofFright, 5);
			recipe.AddIngredient(mod.ItemType<SoulofMind>(), 5);
			recipe.AddIngredient(ItemID.SoulofSight, 5);
			recipe.SetResult(935);
			recipe.AddTile(134);
			recipe.AddRecipe();

			recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.SorcererEmblem);
			recipe.AddIngredient(ItemID.SoulofFright, 5);
			recipe.AddIngredient(mod.ItemType<SoulofMind>(), 5);
			recipe.AddIngredient(ItemID.SoulofSight, 5);
			recipe.SetResult(935);
			recipe.AddTile(134);
			recipe.AddRecipe();

			recipe = new ModRecipe(mod);
			recipe.AddIngredient(mod.ItemType<SharpenedTooth>(), 5);
			recipe.AddIngredient(ItemID.TissueSample, 5);
			recipe.AddIngredient(ItemID.Chain, 2);
			recipe.SetResult(3212);
			recipe.AddRecipe();

			recipe = new ModRecipe(mod);
			recipe.AddIngredient(mod.ItemType<SharpenedTooth>(), 5);
			recipe.AddIngredient(ItemID.ShadowScale, 5);
			recipe.AddIngredient(ItemID.Chain, 2);
			recipe.SetResult(3212);
			recipe.AddRecipe();

			recipe = new ModRecipe(mod);
			recipe.AddIngredient(mod.ItemType<SandstonePlatform>(), 2);
			recipe.SetResult(607);
			recipe.AddRecipe();

			recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.PalladiumOre, 3);
			recipe.SetResult(ItemID.CobaltOre, 2);
			recipe.AddTile(mod.TileType<RecyclerofMatterTile>());
			recipe.AddRecipe();

			recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.CobaltOre, 3);
			recipe.SetResult(ItemID.PalladiumOre, 2);
			recipe.AddTile(mod.TileType<RecyclerofMatterTile>());
			recipe.AddRecipe();

			recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.MythrilOre, 3);
			recipe.SetResult(ItemID.OrichalcumOre, 2);
			recipe.AddTile(mod.TileType<RecyclerofMatterTile>());
			recipe.AddRecipe();

			recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.OrichalcumOre, 3);
			recipe.SetResult(ItemID.MythrilOre, 2);
			recipe.AddTile(mod.TileType<RecyclerofMatterTile>());
			recipe.AddRecipe();

			recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.TitaniumOre, 3);
			recipe.SetResult(ItemID.AdamantiteOre, 2);
			recipe.AddTile(mod.TileType<RecyclerofMatterTile>());
			recipe.AddRecipe();

			recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.AdamantiteOre, 3);
			recipe.SetResult(ItemID.TitaniumOre, 2);
			recipe.AddTile(mod.TileType<RecyclerofMatterTile>());
			recipe.AddRecipe();

			recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.TurtleShell);
			recipe.AddIngredient(ItemID.ChlorophyteBar, 15);
			recipe.AddIngredient(ItemID.JungleSpores, 20);
			recipe.AddIngredient(ItemID.Stinger, 18);
			recipe.AddIngredient(mod.ItemType<KeyMold>());
			recipe.SetResult(ItemID.JungleKey);
			recipe.AddTile(mod.TileType<MagicWorkbenchTile>());
			recipe.AddRecipe();

			recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.DemoniteBar, 25);
			recipe.AddIngredient(ItemID.ShadowScale, 25);
			recipe.AddIngredient(ItemID.EbonstoneBlock, 25);
			recipe.AddIngredient(ItemID.VilePowder, 25);
			recipe.AddIngredient(mod.ItemType<KeyMold>());
			recipe.SetResult(ItemID.CorruptionKey);
			recipe.AddTile(mod.TileType<MagicWorkbenchTile>());
			recipe.AddRecipe();

			recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.CrimtaneBar, 25);
			recipe.AddIngredient(ItemID.TissueSample, 25);
			recipe.AddIngredient(ItemID.CrimstoneBlock, 25);
			recipe.AddIngredient(ItemID.ViciousPowder, 25);
			recipe.AddIngredient(mod.ItemType<KeyMold>());
			recipe.SetResult(ItemID.CrimsonKey);
			recipe.AddTile(mod.TileType<MagicWorkbenchTile>());
			recipe.AddRecipe();

			recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.HallowedBar, 15);
			recipe.AddIngredient(ItemID.SoulofLight, 10);
			recipe.AddIngredient(ItemID.SoulofNight, 10);
			recipe.AddIngredient(ItemID.PurificationPowder, 25);
			recipe.AddIngredient(mod.ItemType<KeyMold>());
			recipe.SetResult(ItemID.HallowedKey);
			recipe.AddTile(mod.TileType<MagicWorkbenchTile>());
			recipe.AddRecipe();

			recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.FrostCore, 2);
			recipe.AddIngredient(ItemID.SnowBlock, 30);
			recipe.AddIngredient(ItemID.IceBlock, 30);
			recipe.AddIngredient(mod.ItemType<KeyMold>());
			recipe.SetResult(ItemID.FrozenKey);
			recipe.AddTile(mod.TileType<MagicWorkbenchTile>());
			recipe.AddRecipe();

			recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.Bone, 80);
			recipe.SetResult(1320);
			recipe.AddTile(300);
			recipe.AddRecipe();

			recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.Wood, 10);
			recipe.AddIngredient(ItemID.Torch, 5);
			recipe.SetResult(3069);
			recipe.AddTile(16);
			recipe.AddRecipe();

			recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.CobaltBar, 12);
			recipe.AddIngredient(ItemID.SnowBlock, 25);
			recipe.AddIngredient(ItemID.IceBlock, 25);
			recipe.AddIngredient(ItemID.SoulofLight, 6);
			recipe.AddIngredient(ItemID.SoulofNight, 6);
			recipe.AddIngredient(ItemID.Glass, 15);
			recipe.SetResult(602);
			recipe.AddTile(26);
			recipe.AddRecipe();

			recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.PalladiumBar, 12);
			recipe.AddIngredient(ItemID.SnowBlock, 25);
			recipe.AddIngredient(ItemID.IceBlock, 25);
			recipe.AddIngredient(ItemID.SoulofLight, 6);
			recipe.AddIngredient(ItemID.SoulofNight, 6);
			recipe.AddIngredient(ItemID.Glass, 15);
			recipe.SetResult(602);
			recipe.AddTile(26);
			recipe.AddRecipe();

			recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.Wood, 30);
			recipe.SetResult(2196);
			recipe.AddTile(191);
			recipe.AddRecipe();

			recipe = new ModRecipe(mod);
			recipe.AddIngredient(2766);
			recipe.SetResult(1261, 75);
			recipe.AddTile(134);
			recipe.AddRecipe();

			recipe = new ModRecipe(mod);
			recipe.AddIngredient(2766);
			recipe.SetResult(1261, 75);
			recipe.AddTile(134);
			recipe.AddRecipe();

			recipe = new ModRecipe(mod);
			recipe.AddIngredient(2766, 15);
			recipe.AddIngredient(ItemID.ChlorophyteBar, 3);
			recipe.AddIngredient(mod.ItemType<EssenseofJungle>());
			recipe.SetResult(1293);
			recipe.AddTile(134);
			recipe.AddRecipe();
			#endregion
		}

		// Adapt certain vanilla recipes to our own 'pillar recipes'
		// For Night's Edge there is Blood Carnage, for Mechanical Worm there is Mechanical Brain
		public static void AdaptToNovaRecipes(Mod mod)
		{
			//Night's Edge can't be crafted with Blood Butcherer
			//Mechanical Worm can't be crafted with Vertebrae

			// Search night's edge
			var rFinder = new RecipeFinder();
			rFinder.SetResult(ItemID.NightsEdge);
			rFinder.AddIngredient(ItemID.BloodButcherer);
			// Add to found recipes
			var foundRecipes = rFinder.SearchRecipes();

			// Search mech worm
			rFinder = new RecipeFinder();
			rFinder.SetResult(ItemID.MechanicalWorm);
			rFinder.AddIngredient(ItemID.Vertebrae);
			// Add to found recipes
			foundRecipes = foundRecipes.Concat(rFinder.SearchRecipes()).ToList();

			// For all found recipes, delete them
			foundRecipes.ForEach(recipe =>
			{
				var rEditor = new RecipeEditor(recipe);
				rEditor.DeleteRecipe();
			});

			//The following recipes (with result of this type) require Nova Fragments for crafting
			foreach (short resultType in new short[]
			{
				ItemID.SuperHealingPotion,
				ItemID.CelestialSigil,
				ItemID.FragmentVortex,
				ItemID.FragmentNebula,
				ItemID.FragmentSolar,
				ItemID.FragmentStardust
			})
			{
				rFinder = new RecipeFinder();
				rFinder.SetResult(resultType);
				rFinder.SearchRecipes().ForEach(recipe =>
				{
					var rEditor = new RecipeEditor(recipe);
					rEditor.AddIngredient(mod.ItemType<NovaFragment>(), resultType == ItemID.CelestialSigil ? 20 : 1); // 20 frags for sigil, 1 for others
				});
			}
		}
	}
}
