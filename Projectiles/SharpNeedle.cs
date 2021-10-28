using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace AlchemistNPC.Projectiles
{
	public class SharpNeedle : ModProjectile
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Sharp Needle");
		}

		public override void SetDefaults()
		{
			Projectile.CloneDefaults(616);
			Projectile.DamageType = DamageClass.Melee;
			Projectile.width = 10;
			Projectile.height = 24;
			AIType = 616;
		}
		
		public override bool OnTileCollide(Vector2 oldVelocity)
		{
			Projectile.Kill();
			Terraria.Audio.SoundEngine.PlaySound(SoundID.DD2_ExplosiveTrapExplode, Projectile.position);
			Terraria.Audio.SoundEngine.PlaySound(SoundID.Item34, Projectile.position);
			for (int h = 0; h < 3; h++)
			{
				Vector2 vel = new Vector2(0, -1);
				float rand = Main.rand.NextFloat() * 6.283f;
				vel = vel.RotatedBy(rand);
				vel *= 1f;
				Projectile.NewProjectile(Projectile.GetProjectileSource_FromThis(), Projectile.Center.X, Projectile.Center.Y, vel.X, vel.Y, ModContent.ProjectileType<Projectiles.L2>(), Projectile.damage/2, 0, Main.myPlayer);
			}
			return true;
		}
		
		public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
		{
			Projectile.Kill();
			Terraria.Audio.SoundEngine.PlaySound(SoundID.DD2_ExplosiveTrapExplode, Projectile.position);
			Terraria.Audio.SoundEngine.PlaySound(SoundID.Item34, Projectile.position);
			for (int g = 0; g < 3; g++)
				{
					Vector2 vel = new Vector2(0, -1);
					float rand = Main.rand.NextFloat() * 6.283f;
					vel = vel.RotatedBy(rand);
					vel *= 1f;
					Projectile.NewProjectile(Projectile.GetProjectileSource_FromThis(), Projectile.Center.X, Projectile.Center.Y, vel.X, vel.Y, ModContent.ProjectileType<Projectiles.L2>(), Projectile.damage/2, 0, Main.myPlayer);
				}
		}
	}
}