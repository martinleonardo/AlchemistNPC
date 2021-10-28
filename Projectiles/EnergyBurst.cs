using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using System;

namespace AlchemistNPC.Projectiles
{
	public class EnergyBurst : ModProjectile
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Energy Burst");     //The English name of the projectile
			Main.projFrames[Projectile.type] = 5;
		}

		public override void SetDefaults()
		{
			Projectile.width = 52;
			Projectile.height = 52;
			Projectile.DamageType = DamageClass.Ranged;
			Projectile.tileCollide = false;
			Projectile.usesLocalNPCImmunity = true;
			Projectile.localNPCHitCooldown = -1;
			Projectile.penetrate = 100;
			Projectile.timeLeft = 20;
		}
		
		public override void AI()
		{
			if (++Projectile.frameCounter >= 4)
            {
                Projectile.frameCounter = 0;
                if (++Projectile.frame >= 5)
                {
                    Projectile.Kill();
                }
            }
		}
	}
}
