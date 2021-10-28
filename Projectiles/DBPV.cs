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
	public class DBPV : ModProjectile
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("DBPV");
			ProjectileID.Sets.TrailCacheLength[Projectile.type] = 4;
			ProjectileID.Sets.TrailingMode[Projectile.type] = 0;
		}

		public override void SetDefaults()
		{
			Projectile.CloneDefaults(ProjectileID.Bullet);
			Projectile.DamageType = DamageClass.Ranged;
			Projectile.width = 60;
			Projectile.height = 34;
			Projectile.penetrate = 10;
			Projectile.timeLeft = 300;
			Projectile.tileCollide = false;
			AIType = ProjectileID.Bullet;
		}
		
		public override bool PreDraw(ref Color lightColor)
        {
            Vector2 drawOrigin = new Vector2(TextureAssets.Projectile[Projectile.type].Value.Width * 0.5f, Projectile.height * 0.5f);
            for (int k = 0; k < Projectile.oldPos.Length; k++)
            {
                Vector2 drawPos = Projectile.oldPos[k] - Main.screenPosition + drawOrigin + new Vector2(0f, Projectile.gfxOffY);
                byte alpha = (byte)(255 *((float)(Projectile.oldPos.Length - k) / (float)Projectile.oldPos.Length));
                Color color = new Color(131, 51, 145, alpha);
                Main.EntitySpriteDraw(TextureAssets.Projectile[Projectile.type].Value, drawPos, null, color, Projectile.rotation, drawOrigin, Projectile.scale, SpriteEffects.None, 0);
            }
            return true;
        }
		
		public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
		{
			target.immune[Projectile.owner] = 3;
			Projectile.penetrate--;
			if (Projectile.penetrate <= 0)
			{
				Projectile.Kill();
			}
		}
	
	}
}