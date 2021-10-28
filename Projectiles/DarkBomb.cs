using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using System;

namespace AlchemistNPC.Projectiles
{
	public class DarkBomb : ModProjectile
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Dark Bomb");
		}

		public override void SetDefaults()
		{
			Projectile.CloneDefaults(261);
			Projectile.width = 30;
			Projectile.height = 28;
			Projectile.aiStyle = 14;
			AIType = 261;
		}
		
		public override void AI()
		{
		}
		
		public override bool OnTileCollide(Vector2 oldVelocity)
		{
			Projectile.Kill();
			return true;
		}
		
		public override void Kill(int timeLeft)
        {
			Player player = Main.player[Projectile.owner];
			Terraria.Audio.SoundEngine.PlaySound(2, (int)Projectile.position.X, (int)Projectile.position.Y, 62);
			for (int index1 = 0; index1 < 60; ++index1)
			{
				int index2 = Dust.NewDust(new Vector2(Projectile.position.X, Projectile.position.Y), Projectile.width, Projectile.height, 31, 0.0f, 0.0f, 100, Color.Purple, 1.5f);
				Main.dust[index2].velocity *= 1f;
			}
		}

		public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
		{
			target.immune[Projectile.owner] = 1;
			Projectile.Kill();
		}
	}
}
