using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using Terraria.GameContent;

namespace AlchemistNPC.Projectiles
{
	public class PortalGunProj : ModProjectile
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Portal Gun Projectile");     //The English name of the projectile
			ProjectileID.Sets.TrailCacheLength[Projectile.type] = 3;    //The length of old position to be recorded
			ProjectileID.Sets.TrailingMode[Projectile.type] = 0;        //The recording mode
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
			Projectile.CloneDefaults(ProjectileID.Bullet);
			Projectile.timeLeft = 25;
			AIType = ProjectileID.Bullet;
		}
		
		public override bool OnTileCollide(Vector2 oldVelocity)
		{
			Projectile.Kill();
			Vector2 vel = new Vector2(0, -1);
			vel *= 0f;
			switch(Main.rand.Next(5))
			{
			case 0:
			Projectile.NewProjectile(Projectile.GetProjectileSource_FromThis(), Projectile.Center.X, Projectile.Center.Y, vel.X, vel.Y, ModContent.ProjectileType<Projectiles.RickPortal1>(), Projectile.damage*2, 0, Main.myPlayer);
			break;
			case 1:
			Projectile.NewProjectile(Projectile.GetProjectileSource_FromThis(), Projectile.Center.X, Projectile.Center.Y, vel.X, vel.Y, ModContent.ProjectileType<Projectiles.RickPortal2>(), Projectile.damage, 0, Main.myPlayer);
			break;
			case 2:
			Projectile.NewProjectile(Projectile.GetProjectileSource_FromThis(), Projectile.Center.X, Projectile.Center.Y, vel.X, vel.Y, ModContent.ProjectileType<Projectiles.RickPortal3>(), Projectile.damage, 0, Main.myPlayer);
			break;
			case 3:
			Projectile.NewProjectile(Projectile.GetProjectileSource_FromThis(), Projectile.Center.X, Projectile.Center.Y, vel.X, vel.Y, ModContent.ProjectileType<Projectiles.RickPortal4>(), Projectile.damage-Projectile.damage/4, 0, Main.myPlayer);
			break;
			case 4:
			Projectile.NewProjectile(Projectile.GetProjectileSource_FromThis(), Projectile.Center.X, Projectile.Center.Y, vel.X, vel.Y, ModContent.ProjectileType<Projectiles.RickPortal5>(), Projectile.damage+Projectile.damage/2, 0, Main.myPlayer);
			break;
			}
			return true;
		}
		
		public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
		{
			Projectile.Kill();
			Vector2 vel = new Vector2(0, -1);
			vel *= 0f;
			switch(Main.rand.Next(5))
			{
			case 0:
			Projectile.NewProjectile(Projectile.GetProjectileSource_FromThis(), Projectile.Center.X, Projectile.Center.Y, vel.X, vel.Y, ModContent.ProjectileType<Projectiles.RickPortal1>(), Projectile.damage*2, 0, Main.myPlayer);
			break;
			case 1:
			Projectile.NewProjectile(Projectile.GetProjectileSource_FromThis(), Projectile.Center.X, Projectile.Center.Y, vel.X, vel.Y, ModContent.ProjectileType<Projectiles.RickPortal2>(), Projectile.damage, 0, Main.myPlayer);
			break;
			case 2:
			Projectile.NewProjectile(Projectile.GetProjectileSource_FromThis(), Projectile.Center.X, Projectile.Center.Y, vel.X, vel.Y, ModContent.ProjectileType<Projectiles.RickPortal3>(), Projectile.damage, 0, Main.myPlayer);
			break;
			case 3:
			Projectile.NewProjectile(Projectile.GetProjectileSource_FromThis(), Projectile.Center.X, Projectile.Center.Y, vel.X, vel.Y, ModContent.ProjectileType<Projectiles.RickPortal4>(), Projectile.damage-Projectile.damage/4, 0, Main.myPlayer);
			break;
			case 4:
			Projectile.NewProjectile(Projectile.GetProjectileSource_FromThis(), Projectile.Center.X, Projectile.Center.Y, vel.X, vel.Y, ModContent.ProjectileType<Projectiles.RickPortal5>(), Projectile.damage+Projectile.damage/2, 0, Main.myPlayer);
			break;
			}
		}
		
		public override bool PreKill(int timeLeft)
		{
			Vector2 vel = new Vector2(0, -1);
			vel *= 0f;
			switch(Main.rand.Next(5))
			{
			case 0:
			Projectile.NewProjectile(Projectile.GetProjectileSource_FromThis(), Projectile.Center.X, Projectile.Center.Y, vel.X, vel.Y, ModContent.ProjectileType<Projectiles.RickPortal1>(), Projectile.damage*2, 0, Main.myPlayer);
			break;
			case 1:
			Projectile.NewProjectile(Projectile.GetProjectileSource_FromThis(), Projectile.Center.X, Projectile.Center.Y, vel.X, vel.Y, ModContent.ProjectileType<Projectiles.RickPortal2>(), Projectile.damage, 0, Main.myPlayer);
			break;
			case 2:
			Projectile.NewProjectile(Projectile.GetProjectileSource_FromThis(), Projectile.Center.X, Projectile.Center.Y, vel.X, vel.Y, ModContent.ProjectileType<Projectiles.RickPortal3>(), Projectile.damage, 0, Main.myPlayer);
			break;
			case 3:
			Projectile.NewProjectile(Projectile.GetProjectileSource_FromThis(), Projectile.Center.X, Projectile.Center.Y, vel.X, vel.Y, ModContent.ProjectileType<Projectiles.RickPortal4>(), Projectile.damage-Projectile.damage/4, 0, Main.myPlayer);
			break;
			case 4:
			Projectile.NewProjectile(Projectile.GetProjectileSource_FromThis(), Projectile.Center.X, Projectile.Center.Y, vel.X, vel.Y, ModContent.ProjectileType<Projectiles.RickPortal5>(), Projectile.damage+Projectile.damage/2, 0, Main.myPlayer);
			break;
			}
			return true;
		}
	}
}
