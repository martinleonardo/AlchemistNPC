using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using Terraria.GameContent;

namespace AlchemistNPC.Projectiles
{
	public class Nyx : ModProjectile
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Nyx");     //The English name of the projectile
			ProjectileID.Sets.TrailCacheLength[Projectile.type] = 10;
			ProjectileID.Sets.TrailingMode[Projectile.type] = 0;
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

		public override void SetDefaults()
		{
			Projectile.CloneDefaults(ProjectileID.MoonlordBullet);
			AIType = ProjectileID.MoonlordBullet;
		}
		
		public override void AI()
		{
		Lighting.AddLight(Projectile.Center, ((255 - Projectile.alpha) * 0.9f) / 255f, ((255 - Projectile.alpha) * 0.1f) / 255f, ((255 - Projectile.alpha) * 0.3f) / 255f);
		}
		
		public override bool OnTileCollide(Vector2 oldVelocity)
		{
			Terraria.Audio.SoundEngine.PlaySound(2, (int)Projectile.position.X, (int)Projectile.position.Y, 62);
			Vector2 vel = new Vector2(0, -1);
			vel *= 0f;
			Projectile.NewProjectile(Projectile.GetProjectileSource_FromThis(), Projectile.Center.X, Projectile.Center.Y, vel.X, vel.Y, ModContent.ProjectileType<Projectiles.ExplosionNyx>(), Projectile.damage/6, 0, Main.myPlayer);
		return true;
		}
		
		public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
		{
			target.immune[Projectile.owner] = 3;
			Terraria.Audio.SoundEngine.PlaySound(2, (int)Projectile.position.X, (int)Projectile.position.Y, 62);
			Vector2 vel = new Vector2(0, -1);
			vel *= 0f;
			Projectile.NewProjectile(Projectile.GetProjectileSource_FromThis(), Projectile.Center.X, Projectile.Center.Y, vel.X, vel.Y, ModContent.ProjectileType<Projectiles.ExplosionNyx>(), Projectile.damage/6, 0, Main.myPlayer);
		}
	}
}
