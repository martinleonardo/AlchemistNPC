using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using System;
using AlchemistNPC.Items.Weapons;

namespace AlchemistNPC.Projectiles
{
	public class RickPortal2 : ModProjectile
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Rick Portal #2");
		}

		public override void SetDefaults()
		{
			Projectile.CloneDefaults(643);
			Projectile.friendly = false;
			Projectile.hostile = false;
			Projectile.width = 54;
			Projectile.height = 100;
			Projectile.penetrate = -1;
			Projectile.timeLeft = 90;
			Projectile.tileCollide = false;
			AIType = 641;
		}

		public override void AI()
		{
			Projectile.rotation = 0f;
			for (int i = 0; i < 200; i++)
            {
                NPC target = Main.npc[i];

                float shootToX = target.position.X + target.width * 0.5f - Projectile.Center.X;
                float shootToY = target.position.Y + target.height * 0.5f - Projectile.Center.Y;
                float distance = (float)Math.Sqrt(shootToX * shootToX + shootToY * shootToY);

                if (distance < 400f && target.catchItem == 0 && !target.friendly && target.active)
                {
                    if (Projectile.ai[0] > 20f)
                    {
                        distance = 1.6f / distance;
                        shootToX *= distance * 3;
                        shootToY *= distance * 3;
						Terraria.Audio.SoundEngine.PlaySound(SoundID.Item11.WithVolume(.6f), Projectile.position);
                        Projectile.NewProjectile(Projectile.GetProjectileSource_FromThis(), Projectile.Center.X, Projectile.Center.Y, shootToX, shootToY, ModContent.ProjectileType<Projectiles.Chloroshard>(), Projectile.damage, 0, Main.myPlayer, 0f, 0f);
                        Projectile.ai[0] = 0f;
                    }
                }
            }
		}
	}
}
