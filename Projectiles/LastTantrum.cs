using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using Terraria.GameContent;

namespace AlchemistNPC.Projectiles
{
	public class LastTantrum : ModProjectile
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Last Tantrum P");
			ProjectileID.Sets.TrailCacheLength[Projectile.type] = 3;
			ProjectileID.Sets.TrailingMode[Projectile.type] = 0;
		}

		public override void SetDefaults()
		{
			Projectile.CloneDefaults(616);
			Projectile.width = 10;
			Projectile.height = 24;
			AIType = 616;
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
			Projectile.Kill();
			Terraria.Audio.SoundEngine.PlaySound(SoundID.Item34, Projectile.position);
			Vector2 vel = new Vector2(0, -1);
			float rand = Main.rand.NextFloat() * 6.283f;
			vel = vel.RotatedBy(rand);
			vel *= 0f;
			Projectile.NewProjectile(Projectile.GetProjectileSource_FromThis(), Projectile.Center.X, Projectile.Center.Y, vel.X, vel.Y, ModContent.ProjectileType<Projectiles.ExplosionNyx>(), Projectile.damage, 0, Main.myPlayer);
			return true;
		}
		
		public override void ModifyHitNPC (NPC target, ref int damage, ref float knockback, ref bool crit, ref int hitDirection)
		{
			if (target.type == ModContent.NPCType<NPCs.BillCipher>())
			{
			damage /= 250;
			}
		}
		
		public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
		{
			Projectile.Kill();
			Terraria.Audio.SoundEngine.PlaySound(SoundID.Item34, Projectile.position);
			Vector2 vel = new Vector2(0, -1);
			float rand = Main.rand.NextFloat() * 6.283f;
			vel = vel.RotatedBy(rand);
			vel *= 0f;
			Projectile.NewProjectile(Projectile.GetProjectileSource_FromThis(), Projectile.Center.X, Projectile.Center.Y, vel.X, vel.Y, ModContent.ProjectileType<Projectiles.ExplosionNyx>(), Projectile.damage, 0, Main.myPlayer);
		}
	}
}