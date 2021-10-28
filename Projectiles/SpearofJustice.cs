using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using System;
using AlchemistNPC.Items.Weapons;
using Terraria.GameContent;

namespace AlchemistNPC.Projectiles
{
	public class SpearofJustice : ModProjectile
	{
		public override void SetDefaults()
		{
			Projectile.width = 14;
			Projectile.height = 14;
			Projectile.friendly = true;
			Projectile.aiStyle = 113;
			Projectile.DamageType = DamageClass.Throwing;
			Projectile.penetrate = 1;
			Projectile.timeLeft = 1200;
			ProjectileID.Sets.TrailCacheLength[Projectile.type] = 5;
			ProjectileID.Sets.TrailingMode[Projectile.type] = 2;
			AIType = 636;
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("SpearofJustice");
			ProjectileID.Sets.TrailCacheLength[Projectile.type] = 1;
			ProjectileID.Sets.TrailingMode[Projectile.type] = 0; 

		}
		
		public override void AI()
		{
			if (Main.rand.Next(2) == 0)
				{
					Dust dust = Dust.NewDustDirect(Projectile.position, Projectile.height, Projectile.width, ModContent.DustType<Dusts.RainbowDust>(),
						Projectile.velocity.X * .2f, Projectile.velocity.Y * .2f, 200, Scale: 1.2f);
					dust.velocity += Projectile.velocity * 0.3f;
					dust.velocity *= 0.2f;
					dust.noGravity = true;
				}
		}
		
		public override bool PreDraw(ref Color lightColor) {
            
            Vector2 drawOrigin = new Vector2(TextureAssets.Projectile[Projectile.type].Value.Width * 0.5f, Projectile.height * 0.5f);
            for (int i = 0; i < Projectile.oldPos.Length; i++) {
                Vector2 drawPos = Projectile.oldPos[i] - Main.screenPosition + drawOrigin + new Vector2(0f, Projectile.gfxOffY);
                Color color = Projectile.GetAlpha(lightColor) * ((float)(Projectile.oldPos.Length - i) / (float)Projectile.oldPos.Length);
                Main.EntitySpriteDraw(TextureAssets.Projectile[Projectile.type].Value, drawPos, new Rectangle(0, Projectile.frame * TextureAssets.Projectile[Projectile.type].Value.Height / Main.projFrames[Projectile.type], TextureAssets.Projectile[Projectile.type].Value.Width, TextureAssets.Projectile[Projectile.type].Value.Height / Main.projFrames[Projectile.type]), color, Projectile.rotation, drawOrigin, Projectile.scale, SpriteEffects.None, 0);
            }
            return true;
        }
		
		public override bool OnTileCollide(Vector2 oldVelocity)
		{
			Projectile.penetrate--;
			if (Projectile.penetrate <= 0)
			{
				Projectile.Kill();
				Terraria.Audio.SoundEngine.PlaySound(2, (int)Projectile.position.X, (int)Projectile.position.Y, 62);
				Vector2 vel = new Vector2(0, -1);
				vel *= 0f;
				Projectile.NewProjectile(Projectile.GetProjectileSource_FromThis(), Projectile.Center.X, Projectile.Center.Y, vel.X, vel.Y, ModContent.ProjectileType<Projectiles.ExplosionSOJ>(), Projectile.damage, 0, Main.myPlayer);
			}
			return false;
		}
		
		public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
		{
			Projectile.penetrate--;
			if (Projectile.penetrate <= 0)
			{
				Projectile.Kill();
				Terraria.Audio.SoundEngine.PlaySound(2, (int)Projectile.position.X, (int)Projectile.position.Y, 62);
				Vector2 vel = new Vector2(0, -1);
				vel *= 0f;
				Projectile.NewProjectile(Projectile.GetProjectileSource_FromThis(), Projectile.Center.X, Projectile.Center.Y, vel.X, vel.Y, ModContent.ProjectileType<Projectiles.ExplosionSOJ>(), Projectile.damage, 0, Main.myPlayer);
			}
			Vector2 vel1 = new Vector2(-1, -1);
			vel1 *= 4f;
			Projectile.NewProjectile(Projectile.GetProjectileSource_FromThis(), target.position.X+150, target.position.Y+150, vel1.X, vel1.Y, ModContent.ProjectileType<Projectiles.SpearofJusticeB>(), Projectile.damage/2, 0, Main.myPlayer);
			Vector2 vel2 = new Vector2(1, 1);
			vel2 *= 4f;
			Projectile.NewProjectile(Projectile.GetProjectileSource_FromThis(), target.position.X-150, target.position.Y-150, vel2.X, vel2.Y, ModContent.ProjectileType<Projectiles.SpearofJusticeB>(), Projectile.damage/2, 0, Main.myPlayer);
			Vector2 vel3 = new Vector2(1, -1);
			vel3 *= 4f;
			Projectile.NewProjectile(Projectile.GetProjectileSource_FromThis(), target.position.X-150, target.position.Y+150, vel3.X, vel3.Y, ModContent.ProjectileType<Projectiles.SpearofJusticeB>(), Projectile.damage/2, 0, Main.myPlayer);
			Vector2 vel4 = new Vector2(-1, 1);
			vel4 *= 4f;
			Projectile.NewProjectile(Projectile.GetProjectileSource_FromThis(), target.position.X+150, target.position.Y-150, vel4.X, vel4.Y, ModContent.ProjectileType<Projectiles.SpearofJusticeB>(), Projectile.damage/2, 0, Main.myPlayer);
			Vector2 vel5 = new Vector2(0, -1);
			vel5 *= 4f;
			Projectile.NewProjectile(Projectile.GetProjectileSource_FromThis(), target.position.X, target.position.Y+150, vel5.X, vel5.Y, ModContent.ProjectileType<Projectiles.SpearofJusticeB>(), Projectile.damage/2, 0, Main.myPlayer);
			Vector2 vel6 = new Vector2(0, 1);
			vel6 *= 4f;
			Projectile.NewProjectile(Projectile.GetProjectileSource_FromThis(), target.position.X, target.position.Y-150, vel6.X, vel6.Y, ModContent.ProjectileType<Projectiles.SpearofJusticeB>(), Projectile.damage/2, 0, Main.myPlayer);
			Vector2 vel7 = new Vector2(1, 0);
			vel7 *= 4f;
			Projectile.NewProjectile(Projectile.GetProjectileSource_FromThis(), target.position.X-150, target.position.Y, vel7.X, vel7.Y, ModContent.ProjectileType<Projectiles.SpearofJusticeB>(), Projectile.damage/2, 0, Main.myPlayer);
			Vector2 vel8 = new Vector2(-1, 0);
			vel8 *= 4f;
			Projectile.NewProjectile(Projectile.GetProjectileSource_FromThis(), target.position.X+150, target.position.Y, vel8.X, vel8.Y, ModContent.ProjectileType<Projectiles.SpearofJusticeB>(), Projectile.damage/2, 0, Main.myPlayer);
		}
	}
}
