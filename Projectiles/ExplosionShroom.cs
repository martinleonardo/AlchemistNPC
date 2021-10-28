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
	public class ExplosionShroom : ModProjectile
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("ExplosionShroom");
			Projectile.timeLeft = 30;
		}

		public override void SetDefaults()
		{
			Projectile.CloneDefaults(443);
			Projectile.friendly = false;
			Projectile.hostile = false;
			Projectile.DamageType = DamageClass.Ranged;
			Projectile.width = 40;
			Projectile.height = 40;
			Projectile.penetrate = 2;
			Projectile.timeLeft = 60;
			Projectile.tileCollide = false;
			AIType = 443;
		}

		public override void AI()
		{
			for (int i = 0; i < 200; i++)
            {
                NPC target = Main.npc[i];

                float shootToX = target.position.X + target.width * 0.5f - Projectile.Center.X;
                float shootToY = target.position.Y + target.height * 0.5f - Projectile.Center.Y;
                float distance = (float)Math.Sqrt(shootToX * shootToX + shootToY * shootToY);

                if (distance < 400f && target.catchItem == 0 && !target.friendly && target.active)
                {
                    if (Projectile.ai[0] > 25f)
                    {
                        distance = 1.6f / distance;
                        shootToX *= distance * 3;
                        shootToY *= distance * 3;
						Terraria.Audio.SoundEngine.PlaySound(SoundID.Item93.WithVolume(.5f), Projectile.position);
                        Projectile.NewProjectile(Projectile.GetProjectileSource_FromThis(), Projectile.Center.X, Projectile.Center.Y, shootToX*3, shootToY*3, ModContent.ProjectileType<Projectiles.ElectricBolt>(), Projectile.damage, 0, Main.myPlayer, 0f, 0f);
                        Projectile.ai[0] = 0f;
                    }
                }
            }
		}
	}
}
