using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Utilities;
using Tremor.NPCs;

namespace Tremor
{
	/// <summary>
	/// Defines a weighted object, stores the object and the weight (double)
	/// Default weight: 1
	/// </summary>
	public class WeightedObject<T>
	{
		public T Obj;
		public double Weight;

		public static Tuple<T, double> Tuple(T obj, double weight = 1d)
			=> new Tuple<T, double>(obj, weight);

		public Tuple<T, double> Tuple()
			=> Tuple(Obj, Weight);

		public WeightedObject(T obj, double weight = 1d)
		{
			this.Obj = obj;
			this.Weight = weight;
		}
	}

	/// <summary>
	/// Houses a number of utility functions used throughout the code
	/// Utility functions are often used in multiple places, thus it is more efficient to define them once
	/// </summary>
	public static class TremorUtils
	{
		/// <summary>
		/// Tries finding name from constant value: FindNameByConstant(typeof(ItemID), type) => name
		/// Also caches values, taken from Mirsario so credit where due. The caching is a nice feature
		/// </summary>
		private static readonly Dictionary<Type, Dictionary<int, string>> NameFromConstCache = new Dictionary<Type, Dictionary<int, string>>();
		private static readonly Type[] IntTypes = new Type[] { typeof(byte), typeof(sbyte), typeof(ushort), typeof(short), typeof(uint), typeof(int), typeof(ulong), typeof(long) };
		public static string FindNameByConstant(this Type classType, int id)
		{
			Dictionary<int, string> cache;
			if (!NameFromConstCache.ContainsKey(classType))
			{
				FieldInfo[] fields = classType.GetFields(BindingFlags.Public | BindingFlags.Static | BindingFlags.FlattenHierarchy).Where(f => f.IsLiteral && !f.IsInitOnly && IntTypes.Contains(f.FieldType)).ToArray();
				cache = new Dictionary<int, string>();
				for (int i = 0; i < fields.Length; i++)
				{
					int val = Convert.ToInt32(fields[i].GetRawConstantValue());
					string name = fields[i].Name;
					if (name != "Count" && !cache.ContainsKey(val))
					{
						cache.TryAdd(val, name);
					}
				}
				NameFromConstCache[classType] = cache;
			}
			else
			{
				cache = NameFromConstCache[classType];
			}
			string result;
			if (cache.TryGetValue(id, out result))
			{
				return result;
			}
			return "UNDEFINED";
		}

		/// <summary>
		/// MoreLINQ distinct by: .DistinctBy( x => x.prop )
		/// </summary>
		public static IEnumerable<TSource> DistinctBy<TSource, TKey>
			(this IEnumerable<TSource> source, Func<TSource, TKey> keySelector)
		{
			HashSet<TKey> knownKeys = new HashSet<TKey>();
			foreach (TSource element in source)
			{
				if (knownKeys.Add(keySelector(element)))
				{
					yield return element;
				}
			}
		}

		/// <summary>
		/// Adds to dict if not present
		/// </summary>
		public static void TryAdd<T1, T2>(this Dictionary<T1, T2> dict, T1 key, T2 value)
		{
			if (!dict.ContainsKey(key))
			{
				dict.Add(key, value);
			}
		}

		/// <summary>
		///  Does player have buff?  Usable in SetDefaults because of the hacks
		/// </summary>
		public static bool HasBuff(this Player player, int buffType)
		{
			if (player.whoAmI != -1 || buffType < 0 || buffType >= player.buffImmune.Length)
				return false;

			return player.FindBuffIndex(buffType) != -1;
		}

		/// <summary>
		/// Add item to a chest, if an empty slot is present. Returns succession
		/// </summary>
		public static bool AddItem(this Chest chest, int type, int? stack = null)
		{
			foreach (var item in chest.item)
			{
				if (item.IsAir)
				{
					item.SetDefaults(type);
					if (stack.HasValue)
						item.stack = stack.Value;
					return true;
				}
			}
			return false;
		}

		/// <summary>
		/// Transforms namespace to a path, but skips the first segment
		/// </summary>
		public static string NamespaceToPathSkipFirst(this Type type)
		{
			string input = type.NamespaceToPath();
			int i = input.IndexOf('.');
			return i >= 0
				? input.Substring(input.IndexOf('.') + 1)
				: input;
		}

		/// <summary>
		/// Transforms namespace to a path
		/// </summary>
		public static string NamespaceToPath(this Type type)
			=> type.Namespace?.Replace('.', '/');

		/// <summary>
		/// Transforms the given collection of strings, and optional collection of weights, to a collection of Weighted string Objects
		/// </summary>
		public static WeightedObject<string>[] ToWeightedStringCollection(this string[] strings, params double[] weights)
		{
			WeightedObject<string>[] chats = new WeightedObject<string>[strings.Length];
			int weightCount = weights.Length;
			for (int i = 0; i < strings.Length; i++)
			{
				chats[i] = new WeightedObject<string>(strings[i], i < weightCount ? weights[i] : 1d);
			}
			return chats;
		}

		/// <summary>
		/// Transforms the given collection of Weighted string Objects to a WeightedRandom
		/// </summary>
		public static WeightedRandom<string> ToWeightedCollection(this WeightedObject<string>[] strings)
			=> new WeightedRandom<string>(strings.Select(x => new Tuple<string, double>(x.Obj, x.Weight)).ToArray());

		/// <summary>
		/// Transforms the given string collection to a WeightedRandom
		/// Parses the weight given in the string in the format: string:weight
		/// Weight defaults to 1
		/// </summary>
		public static WeightedRandom<string> ToWeightedCollectionWithWeight(this string[] strings)
		{
			WeightedRandom<string> weightedCollection = new WeightedRandom<string>();
			for (int i = 0; i < strings.Length; i++)
			{
				string str = strings[i];
				string[] split = str.Split(':');
				double weight = split.Length > 1 ? Double.Parse(split[1]) : 1d;
				weightedCollection.Add(split[0], weight);
			}
			return weightedCollection;
		}

		/// <summary>
		/// Transforms the given string collection to a WeightedRandom
		/// The weight defaults to 1 and is not modifiable in this utility function
		/// </summary>
		public static WeightedRandom<string> ToWeightedCollection(this string[] strings)
			=> new WeightedRandom<string>(strings.Select(x => x.ToWeightedTuple()).ToArray());

		/// <summary>
		/// Transforms the given string to a WeightedTuple, holding the string and its weight
		/// </summary>
		public static Tuple<string, double> ToWeightedTuple(this string message, double weight = 1d)
			=> WeightedObject<string>.Tuple(message, weight);

		/// <summary>
		/// Spawns a new NPC on the given ModItem's position, and returns the instance
		/// </summary>
		public static NPC NewNPC(this ModItem item, int type, float ai0 = 0f, float ai1 = 0f, float ai2 = 0f, float ai3 = 0f, int target = 255, int start = 0, float offsetX = 0f, float offsetY = 0f)
			=> NewNPC(item.item, type, ai0, ai1, ai2, ai3, target, start, offsetX, offsetY);

		/// <summary>
		/// Spawns a new NPC on the given ModPlayer's position, and returns the instance
		/// </summary>
		public static NPC NewNPC(this ModPlayer plr, int type, float ai0 = 0f, float ai1 = 0f, float ai2 = 0f, float ai3 = 0f, int target = 255, int start = 0, float offsetX = 0f, float offsetY = 0f)
			=> NewNPC(plr.player, type, ai0, ai1, ai2, ai3, target, start, offsetX, offsetY);

		/// <summary>
		/// Spawns a new NPC on the given ModProjectile's position, and returns the instance
		/// </summary>
		public static NPC NewNPC(this ModProjectile proj, int type, float ai0 = 0f, float ai1 = 0f, float ai2 = 0f, float ai3 = 0f, int target = 255, int start = 0, float offsetX = 0f, float offsetY = 0f)
			=> NewNPC(proj.projectile, type, ai0, ai1, ai2, ai3, target, start, offsetX, offsetY);

		/// <summary>
		/// Spawns a new NPC on the given ModNPC's position, and returns the instance
		/// </summary>
		public static NPC NewNPC(this ModNPC npc, int type, float ai0 = 0f, float ai1 = 0f, float ai2 = 0f, float ai3 = 0f, int target = 255, int start = 0, float offsetX = 0f, float offsetY = 0f)
			=> NewNPC(npc.npc, type, ai0, ai1, ai2, ai3, target, start, offsetX, offsetY);

		/// <summary>
		/// Spawns a new NPC on the given Entity's position, and returns the instance
		/// </summary>
		public static NPC NewNPC(this Entity entity, int type, float ai0 = 0f, float ai1 = 0f, float ai2 = 0f, float ai3 = 0f, int target = 255, int start = 0, float offsetX = 0f, float offsetY = 0f)
			=> Main.npc[NPC.NewNPC((int)(entity.position.X + offsetX), (int)(entity.position.Y + offsetY), type, ai0: ai0, ai1: ai1, ai2: ai2, ai3: ai3, Target: target, Start: start)];

		/// <summary>
		/// Adds the given item to the chest, if the item is not present yet
		/// Returns succession
		/// </summary>
		public static bool AddUniqueItem(this Chest shop, ref int nextSlot, int type)
		{
			if (shop.item.Any(x => x.type == type))
				return false;

			shop.item[nextSlot].SetDefaults(type);
			nextSlot++;
			return true;
		}

		public static T Get<T>(this T[] source)
			=> source[Main.rand.Next(source.Length)];

		/// <summary>
		/// Sets the boss' downed state, defaults to true
		/// </summary>
		public static void Downed(this TremorWorld.Boss boss, bool state = true)
			=> TremorWorld.downedBoss[boss] = state;

		/// <summary>
		/// Returns if the boss is downed
		/// </summary>
		public static bool IsDowned(this TremorWorld.Boss boss)
			=> TremorWorld.downedBoss[boss];

		/// <summary>
		/// Spawns an item on the given ModPlayer's position, and returns the instance
		/// </summary>
		public static Item NewItem(this ModPlayer plr, int type, int stack = 1)
			=> NewItem(plr.player, type, stack);

		/// <summary>
		/// Spawns an item on the given ModProjectile's position, and returns the instance
		/// </summary>
		public static Item NewItem(this ModProjectile proj, int type, int stack = 1)
			=> NewItem(proj.projectile, type, stack);

		/// <summary>
		/// Spawns an item on the given ModNPC's position, and returns the instance
		/// </summary>
		public static Item NewItem(this ModNPC npc, int type, int stack = 1)
			=> NewItem(npc.npc, type, stack);

		/// <summary>
		/// Spawns an item on the given Entity's position, and returns the instance
		/// </summary>
		public static Item NewItem(this Entity entity, int type, int stack = 1)
			=> Main.item[Item.NewItem((int)entity.position.X, (int)entity.position.Y, entity.width, entity.height, type, stack)];

		/// <summary>
		/// Spawns an item on the given position, and returns the instance
		/// </summary>
		public static Item NewItem(Vector2 position, Vector2 size, int type, int stack = 1)
			=> Main.item[Item.NewItem((int)position.X, (int)position.Y, (int)size.X, (int)size.Y, type, stack)];

		/// <summary>
		/// Get an ID for a sound name, thanks Skiphs for helping
		/// </summary>
		public static int GetIdForSoundName(string soundName)
		{
			for (int i = 0; i < SoundID.TrackableLegacySoundCount; i++)
				if (SoundID.GetTrackableLegacySoundPath(i).EndsWith(soundName))
					return i;
			return 0;
		}

		/// <summary>
		/// Returns if the next random value is equal to 0
		/// </summary>
		public static bool NextBool(this UnifiedRandom rand, int total)
			=> rand.Next(total) == 0;

		/// <summary>
		/// Returns if the next random value is below or equal to the chance
		/// </summary>
		public static bool NextBool(this UnifiedRandom rand, int chance, int total)
			=> rand.Next(total) <= chance;

		/// <summary>
		/// Draws an NPC glowmask
		/// </summary>
		public static void DrawNPCGlowMask(SpriteBatch spriteBatch, NPC npc, Texture2D texture)
		{
			var effects = npc.direction == -1 ? SpriteEffects.None : SpriteEffects.FlipHorizontally;
			spriteBatch.Draw(texture, npc.Center - Main.screenPosition + new Vector2(0, npc.gfxOffY), npc.frame,
							 Color.White, npc.rotation, npc.frame.Size() / 2, npc.scale, effects, 0);
		}

		/// <summary>
		/// Draws an armor glowmask for a player, used in PlayerLayers
		/// </summary>
		public static void DrawArmorGlowMask(EquipType type, Texture2D texture, PlayerDrawInfo info)
		{
			switch (type)
			{
				case EquipType.Head:
					{
						//Add if(!drawPlayer.invis) ?
						DrawData drawData = new DrawData(texture, new Vector2((int)(info.position.X - Main.screenPosition.X) + ((info.drawPlayer.width - info.drawPlayer.bodyFrame.Width) / 2), (int)(info.position.Y - Main.screenPosition.Y) + info.drawPlayer.height - info.drawPlayer.bodyFrame.Height + 4) + info.drawPlayer.headPosition + info.headOrigin, info.drawPlayer.bodyFrame, info.headGlowMaskColor, info.drawPlayer.headRotation, info.headOrigin, 1f, info.spriteEffects, 0);
						drawData.shader = info.headArmorShader;
						Main.playerDrawData.Add(drawData);
					}
					return;
				case EquipType.Body:
					{
						int num2 = 0;//Add in backAcc stuff later
						Rectangle bodyFrame = info.drawPlayer.bodyFrame;
						int num123 = num2;
						bodyFrame.X += num123;
						bodyFrame.Width -= num123;
						if (info.drawPlayer.direction == -1)
						{
							num123 = 0;
						}
						if (!info.drawPlayer.invis)
						{
							DrawData drawData = new DrawData(texture, new Vector2((int)(info.position.X - Main.screenPosition.X - (info.drawPlayer.bodyFrame.Width / 2) + (info.drawPlayer.width / 2) + num123), ((int)(info.position.Y - Main.screenPosition.Y + info.drawPlayer.height - info.drawPlayer.bodyFrame.Height + 4))) + info.drawPlayer.bodyPosition + new Vector2(info.drawPlayer.bodyFrame.Width / 2, info.drawPlayer.bodyFrame.Height / 2), bodyFrame, info.bodyGlowMaskColor, info.drawPlayer.bodyRotation, info.bodyOrigin, 1f, info.spriteEffects, 0);
							drawData.shader = info.bodyArmorShader;
							Main.playerDrawData.Add(drawData);
						}
					}
					return;
				case EquipType.Legs:
					{
						if (info.drawPlayer.shoe != 15 || info.drawPlayer.wearsRobe)
						{
							if (!info.drawPlayer.invis)
							{
								DrawData drawData = new DrawData(texture, new Vector2((int)(info.position.X - Main.screenPosition.X - (info.drawPlayer.legFrame.Width / 2) + (info.drawPlayer.width / 2)), (int)(info.position.Y - Main.screenPosition.Y + info.drawPlayer.height - info.drawPlayer.legFrame.Height + 4)) + info.drawPlayer.legPosition + info.legOrigin, info.drawPlayer.legFrame, info.legGlowMaskColor, info.drawPlayer.legRotation, info.legOrigin, 1f, info.spriteEffects, 0);
								drawData.shader = info.legArmorShader;
								Main.playerDrawData.Add(drawData);
							}
						}
					}
					return;
			}
		}

		/// <summary>
		/// Draws an item glowmask for the item a player is holding, used in PlayerLayers
		/// </summary>
		public static void DrawItemGlowMask(Texture2D texture, PlayerDrawInfo info)
		{
			Item item=info.drawPlayer.HeldItem;
			if(info.shadow!=0f||info.drawPlayer.frozen||((info.drawPlayer.itemAnimation<=0||item.useStyle==0)&&(item.holdStyle<=0||info.drawPlayer.pulley))/*||item.type<=0*/||info.drawPlayer.dead||item.noUseGraphic||(info.drawPlayer.wet&&item.noWet))
			{
				return;
			}
			Vector2 offset=new Vector2();
			float rotOffset=0;
			Vector2 origin=new Vector2();
			if(item.useStyle==5)
			{
				if(Item.staff[item.type])
				{
					rotOffset=0.785f*info.drawPlayer.direction;
					if(info.drawPlayer.gravDir==-1f){rotOffset-=1.57f*info.drawPlayer.direction;}
					origin=new Vector2(texture.Width*0.5f*(1-info.drawPlayer.direction),(info.drawPlayer.gravDir==-1f)?0:texture.Height);
					int num86=-(int)origin.X;
					ItemLoader.HoldoutOrigin(info.drawPlayer,ref origin);
					offset=new Vector2(origin.X+num86,0);
				}
				else
				{
					offset=new Vector2(10,texture.Height/2);
					ItemLoader.HoldoutOffset(info.drawPlayer.gravDir,item.type,ref offset);
					origin=new Vector2(-offset.X,texture.Height/2);
					if(info.drawPlayer.direction==-1)
					{
						origin.X=texture.Width+offset.X;
					}
					offset=new Vector2(texture.Width/2,offset.Y);
				}
			}
			else
			{
				origin=new Vector2(texture.Width*0.5f*(1-info.drawPlayer.direction),(info.drawPlayer.gravDir==-1f)?0:texture.Height);
			}
			Main.playerDrawData.Add
			(
				new DrawData
				(
					texture,
					info.itemLocation-Main.screenPosition+offset,
					texture.Bounds,
					new Color(250,250,250,item.alpha),
					info.drawPlayer.itemRotation+rotOffset,
					origin,
					item.scale,info.spriteEffects,0
				)
			);
		}

		/// <summary>
		/// Draws an item glowmask that is in the world
		/// </summary>
		public static void DrawItemGlowMaskWorld(SpriteBatch spriteBatch, Item item, Texture2D texture, float rotation, float scale)
		{
			Main.spriteBatch.Draw
			(
				texture,
				new Vector2
				(
					item.position.X - Main.screenPosition.X + item.width / 2,
					item.position.Y - Main.screenPosition.Y + item.height - (texture.Height / 2) + 2f
				),
				new Rectangle(0, 0, texture.Width, texture.Height),
				new Color(250, 250, 250, item.alpha), rotation,
				new Vector2(texture.Width / 2, texture.Height / 2),
				scale, SpriteEffects.None, 0f
			);
		}

		// DO NOT remove this method
		// The trick here is to reference System.Core is some way, in any class
		// This is a trick to get the mod to compile with extension methods
		// Normally you would get an error, this is a workaround trick for now
		public static void RedundantFunc()
		{
			var something = Enumerable.Range(1, 10);
		}
	}
}
