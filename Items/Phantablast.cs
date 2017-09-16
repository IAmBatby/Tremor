using System;
using System.Runtime.InteropServices;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Tremor.Items
{
	public class Phantablast : ModItem
	{
		public override void SetDefaults()
		{
			item.damage = 83;
			item.ranged = true;
			item.width = 20;
			item.height = 12;
			item.useTime = 12;
			item.useAnimation = 20;
			item.useStyle = 5;
			item.knockBack = 6;
			item.value = 210000;
			item.rare = AmmoID.Bullet;
			item.useStyle = 5;
			item.UseSound = SoundID.Item36;
			item.noMelee = true;
			item.autoReuse = true;
			item.shoot = 10;
			item.shootSpeed = 23f;
			item.useAmmo = AmmoID.Bullet;
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Phantablast");
			Tooltip.SetDefault("Fires your ammo in a blast\n50% chance to not consume ammo");
		}

		public override Vector2? HoldoutOffset()
		{
			return new Vector2(-18, -4);
		}

		public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
		{
			for (int i = 1; i < 6; i++)
			{
				// Randomize speed
				float lowerSpeed = 0.75f - i / 100f; // how low of a speed multiplier can we generate? in our example, 25% slower and lower
				float higherSpeed = 1.25f + i / 100f; // how high of a speed multiplier can we generate? in our example, 25% faster and higher
				Vector2 velocity = new Vector2(speedX, speedY) * Main.rand.NextFloat(lowerSpeed, higherSpeed); // our speed multiplied
				// Randomize the angle
				// float spread = MathHelper.ToRadians(7.5f); // convert this many degrees to radians, radians are measured in 'pi' units, 1 rad = 1 pi, a full circle is 2 pi
				// MathHelper also has helpers for pi, so say we want a spread to be as big as a quarter circle, we know 1 pi is half a circle (because 2 pi is a full circle)
				// so for a quarter circle, we need a fourth of pi, MathHelper covers PiOver2 (half of pi) and PiOver4 (quarter of pi)
				float spread = MathHelper.PiOver4; // we set our spread to a quarter of pi, which is a quarter circle, which is equivalent to 90° (a full circle is 360°, so half is 180°, so a quarter is 90°)
				spread /= 4; // you can manipulate the spread however you want, we make it quarter to end up with a 25° spread
				float magnitude = velocity.LengthSquared(); // length is the x*x+y*y, we want the length squared, this is often refered to as its magnitude
				double baseAngle = velocity.ToRotation(); // our base angle is the angle of velocity: atan2 of speedY, speedX
				// here we generate a random double from 0 to 1, 
				// but we subtract 0.5 to add the possibility for it to become negative
				// (imagine rolling 0, you will have -0.5, imagine rolling 1 and you will have +0.5)
				// by multiplying the end result with 2 we can generate a random from -1 to +1, which we then multiply the spread with
				double randomAngle = (Main.rand.NextDouble() - 0.5) * 2 * spread; 
				double newAngle = baseAngle + randomAngle; // add the random angle to the angle we add
				velocity = ((float)newAngle).ToRotationVector2() * magnitude; // make the new velocity based on our offset angle
				// ToRotationVector2 makes a Vector2 from our angle using cosine (X) and sine (Y)
				Projectile.NewProjectile(position.X, position.Y, velocity.X, velocity.Y, type, damage, knockBack, Main.myPlayer);

				// If you decide to just shoot one projectile like normal, you can choose to simply change speedX and speedY, and return true;
				// An alternative to this is using the .RotatedBy() or .RotatedByRandom() helpers for Vector2s, but it is important to know how it manipulates the velocity, which is showcased here
				// Vector2 rotatedVelocity = new Vector2(speedX, speedY).RotatedBy(MathHelper.PiOver4/4); // strictly rotates it by 25 degrees
				// Vector2 rotatedVelocity = new Vector2(speedX, speedY).RotatedByRandom(MathHelper.PiOver4/4); // rotates it randomly by -25 or +25 degrees
			}
			return false;
		}

		public override bool ConsumeAmmo(Player p)
			=> Main.rand.NextBool();

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(null, "AncientTechnology", 1);
			recipe.AddIngredient(3456, 30);
			recipe.AddIngredient(null, "AirFragment", 25);
			recipe.SetResult(this);
			recipe.AddTile(412);
			recipe.AddRecipe();
		}
	}
}
