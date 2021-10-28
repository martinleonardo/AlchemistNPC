using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using Terraria.GameContent;

namespace AlchemistNPC.Projectiles
{
	public class CrystalDust : ModProjectile
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("CrystalBullet2");
			ProjectileID.Sets.TrailCacheLength[Projectile.type] = 3;    //The length of old position to be recorded
			ProjectileID.Sets.TrailingMode[Projectile.type] = 0;        //The recording mode
		}
		
		public override void SetDefaults()
		{
			Projectile.CloneDefaults(ProjectileID.CrystalBullet);
			Projectile.damage = 10;
			AIType = ProjectileID.CrystalBullet;
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
				for (int h = 0; h < 3; h++)
				{
					Vector2 vel = new Vector2(0, -1);
					float rand = Main.rand.NextFloat() * 6.283f;
					vel = vel.RotatedBy(rand);
					vel *= 5f;
					Projectile.NewProjectile(Projectile.GetProjectileSource_FromThis(), Projectile.Center.X, Projectile.Center.Y, vel.X, vel.Y, ProjectileID.CrystalBullet, Projectile.damage/3, 0, Main.myPlayer);
				}
			}
			return false;
		}
		
		public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
		{
			Projectile.penetrate--;
			if (Projectile.penetrate <= 0)
			{
				Projectile.Kill();
				Terraria.Audio.SoundEngine.PlaySound(2, (int)Projectile.position.X, (int)Projectile.position.Y, 10);
				for (int h = 0; h < 3; h++)
				{
					Vector2 vel = new Vector2(0, -1);
					float rand = Main.rand.NextFloat() * 6.283f;
					vel = vel.RotatedBy(rand);
					vel *= 5f;
					Projectile.NewProjectile(Projectile.GetProjectileSource_FromThis(), (Projectile.Center.X - 30) + Main.rand.Next(60), (Projectile.Center.Y - 30) + Main.rand.Next(60), vel.X, vel.Y, ProjectileID.CrystalBullet, Projectile.damage/3, 0, Main.myPlayer);
				}
			
			}
		}
	}
}