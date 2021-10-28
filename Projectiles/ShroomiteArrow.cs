using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace AlchemistNPC.Projectiles
{
	public class ShroomiteArrow : ModProjectile
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Shroomite Arrow");
		}

		public override void SetDefaults()
		{
			Projectile.CloneDefaults(ProjectileID.IchorArrow);
			AIType = ProjectileID.IchorArrow;
		}

		public override void AI()
		{
			Projectile.velocity *= 1.02f;
			if (Main.rand.Next(2) == 0)
				{
					Dust dust = Dust.NewDustDirect(Projectile.position, Projectile.height, Projectile.width, ModContent.DustType<Dusts.JustitiaPale>(),
						Projectile.velocity.X * .2f, Projectile.velocity.Y * .2f, 200, Scale: 1.2f);
					dust.noGravity = true;
					dust.velocity += Projectile.velocity * 0.3f;
					dust.velocity *= 0.2f;
				}
		}
		
		public override bool OnTileCollide(Vector2 oldVelocity)
		{
			Projectile.penetrate--;
			if (Projectile.penetrate <= 0)
			{
			Projectile.Kill();
			Terraria.Audio.SoundEngine.PlaySound(SoundID.Item94.WithVolume(.9f), Projectile.position);
			Vector2 vel = new Vector2(0, 0);
			vel *= 0f;
			Projectile.NewProjectile(Projectile.GetProjectileSource_FromThis(), Projectile.Center.X, Projectile.Center.Y, vel.X, vel.Y, ModContent.ProjectileType<Projectiles.ExplosionShroom>(), Projectile.damage, 0, Main.myPlayer);
			}
			return false;
		}
		
		public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
		{
			target.AddBuff(189, 600);
			Terraria.Audio.SoundEngine.PlaySound(SoundID.Item94.WithVolume(.9f), Projectile.position);
			Vector2 vel = new Vector2(0, 0);
			vel *= 0f;
			Projectile.NewProjectile(Projectile.GetProjectileSource_FromThis(), Projectile.Center.X, Projectile.Center.Y, vel.X, vel.Y, ModContent.ProjectileType<Projectiles.ExplosionShroom>(), Projectile.damage, 0, Main.myPlayer);
		}
	}
}