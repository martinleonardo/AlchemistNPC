using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using Terraria.Audio;

namespace AlchemistNPC.Projectiles
{
	public class ChromovariaArrow : ModProjectile
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Chromovaria Arrow");
		}

		public override void SetDefaults()
		{
			Projectile.CloneDefaults(ProjectileID.IchorArrow);
			AIType = ProjectileID.IchorArrow;
		}

		public override void AI()
		{
			if (Main.rand.Next(3) == 0)
				{
					Dust dust = Dust.NewDustDirect(Projectile.position, Projectile.height, Projectile.width, ModContent.DustType<Dusts.JustitiaPale>(),
						Projectile.velocity.X * .2f, Projectile.velocity.Y * .2f, 200, Scale: 1.2f);
					dust.velocity += Projectile.velocity * 0.3f;
					dust.velocity *= 0.2f;
				}
		}
		
		public override bool OnTileCollide(Vector2 oldVelocity)
		{
			Projectile.Kill();
			Terraria.Audio.SoundEngine.PlaySound(SoundID.Item12, Projectile.position);
			Vector2 vel = new Vector2(-1, -1);
			vel *= 3f;
			Projectile.NewProjectile(Projectile.GetProjectileSource_FromThis(), Projectile.Center.X, Projectile.Center.Y, vel.X, vel.Y, ModContent.ProjectileType<Projectiles.CAE>(), Projectile.damage/3, 0, Main.myPlayer);
			Vector2 vel2 = new Vector2(1, 1);
			vel2 *= 3f;
			Projectile.NewProjectile(Projectile.GetProjectileSource_FromThis(), Projectile.Center.X, Projectile.Center.Y, vel2.X, vel2.Y, ModContent.ProjectileType<Projectiles.CAE>(), Projectile.damage/3, 0, Main.myPlayer);
			Vector2 vel3 = new Vector2(1, -1);
			vel3 *= 3f;
			Projectile.NewProjectile(Projectile.GetProjectileSource_FromThis(), Projectile.Center.X, Projectile.Center.Y, vel3.X, vel3.Y, ModContent.ProjectileType<Projectiles.CAE>(), Projectile.damage/3, 0, Main.myPlayer);
			Vector2 vel4 = new Vector2(-1, 1);
			vel4 *= 3f;
			Projectile.NewProjectile(Projectile.GetProjectileSource_FromThis(), Projectile.Center.X, Projectile.Center.Y, vel4.X, vel4.Y, ModContent.ProjectileType<Projectiles.CAE>(), Projectile.damage/3, 0, Main.myPlayer);
			return false;
		}
		
		public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
		{
			target.AddBuff(189, 600);
			Terraria.Audio.SoundEngine.PlaySound(SoundID.Item12, Projectile.position);
			Vector2 vel = new Vector2(-1, -1);
			vel *= 3f;
			Projectile.NewProjectile(Projectile.GetProjectileSource_FromThis(), Projectile.Center.X, Projectile.Center.Y, vel.X, vel.Y, ModContent.ProjectileType<Projectiles.CAE>(), Projectile.damage/3, 0, Main.myPlayer);
			Vector2 vel2 = new Vector2(1, 1);
			vel2 *= 3f;
			Projectile.NewProjectile(Projectile.GetProjectileSource_FromThis(), Projectile.Center.X, Projectile.Center.Y, vel2.X, vel2.Y, ModContent.ProjectileType<Projectiles.CAE>(), Projectile.damage/3, 0, Main.myPlayer);
			Vector2 vel3 = new Vector2(1, -1);
			vel3 *= 3f;
			Projectile.NewProjectile(Projectile.GetProjectileSource_FromThis(), Projectile.Center.X, Projectile.Center.Y, vel3.X, vel3.Y, ModContent.ProjectileType<Projectiles.CAE>(), Projectile.damage/3, 0, Main.myPlayer);
			Vector2 vel4 = new Vector2(-1, 1);
			vel4 *= 3f;
			Projectile.NewProjectile(Projectile.GetProjectileSource_FromThis(), Projectile.Center.X, Projectile.Center.Y, vel4.X, vel4.Y, ModContent.ProjectileType<Projectiles.CAE>(), Projectile.damage/3, 0, Main.myPlayer);
		}
	}
}