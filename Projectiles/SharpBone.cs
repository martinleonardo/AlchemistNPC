using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using System;
using Terraria.GameContent;

namespace AlchemistNPC.Projectiles
{
	public class SharpBone : ModProjectile
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Sharp Bone");
			ProjectileID.Sets.TrailCacheLength[Projectile.type] = 3;
			ProjectileID.Sets.TrailingMode[Projectile.type] = 0;
		}
		
		public override void SetDefaults()
		{
			Projectile.CloneDefaults(ProjectileID.Bullet);
			Projectile.DamageType = DamageClass.Summon;
			Projectile.tileCollide = false;
			Projectile.timeLeft = 120;
			AIType = ProjectileID.Bullet;
		}

		public override void AI()
		{
			Projectile.velocity *= 1.01f;
			if (Projectile.localAI[0] == 0f)
			{
				AdjustMagnitude(ref Projectile.velocity);
				Projectile.localAI[0] = 1f;
			}
			Vector2 move = Vector2.Zero;
			float distance = 600f;
			bool target = false;
			for (int k = 0; k < 100; k++)
			{
				if (Main.npc[k].active && !Main.npc[k].dontTakeDamage && !Main.npc[k].friendly && Main.npc[k].lifeMax > 5)
				{
					Vector2 newMove = Main.npc[k].Center - Projectile.Center;
					float distanceTo = (float)Math.Sqrt(newMove.X * newMove.X + newMove.Y * newMove.Y);
					if (distanceTo < distance)
					{
						move = newMove;
						distance = distanceTo;
						target = true;
					}
				}
			}
			if (target)
			{
				AdjustMagnitude(ref move);
				Projectile.velocity = (10 * Projectile.velocity + move) / 5f;
				AdjustMagnitude(ref Projectile.velocity);
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
		
		private void AdjustMagnitude(ref Vector2 vector)
		{
			float magnitude = (float)Math.Sqrt(vector.X * vector.X + vector.Y * vector.Y);
			if (magnitude > 6f)
			{
				vector *= 9f / magnitude;
			}
		}
		
		public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
		{
			Projectile.penetrate--;
			if (Projectile.penetrate <= 0)
			{
				Projectile.Kill();
				Vector2 vel = new Vector2(0, -1);
				vel *= 0f;
				Projectile.NewProjectile(Projectile.GetProjectileSource_FromThis(), Projectile.Center.X, Projectile.Center.Y, vel.X, vel.Y, ModContent.ProjectileType<Projectiles.ExplosionDummySB>(), Projectile.damage/2, 0, Main.myPlayer);
			}
		}
		
		public Color GetColor()
		{
		return new Color(0, 0, 200);
		}
	}
}