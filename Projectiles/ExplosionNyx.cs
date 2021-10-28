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
	public class ExplosionNyx : ModProjectile
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("ExplosionNyx");
			Projectile.timeLeft = 150;
			Projectile.light = 0.8f;
			ProjectileID.Sets.TrailCacheLength[Projectile.type] = 5;
			ProjectileID.Sets.TrailingMode[Projectile.type] = 0;
			Main.projFrames[Projectile.type] = 7;
		}

		public override void SetDefaults()
		{
			Projectile.CloneDefaults(ProjectileID.LaserMachinegunLaser);
			Projectile.DamageType = DamageClass.Ranged;
			Projectile.width = 98;
			Projectile.height = 98;
			Projectile.penetrate = 40;
			Projectile.timeLeft = 70;
			Projectile.tileCollide = false;
			AIType = ProjectileID.LaserMachinegunLaser;
		}
		public override void AI()
		{
			if (Projectile.frameCounter < 10)
				Projectile.frame = 0;
			else if (Projectile.frameCounter >= 10 && Projectile.frameCounter < 20)
				Projectile.frame = 1;
			else if (Projectile.frameCounter >= 20 && Projectile.frameCounter < 30)
				Projectile.frame = 2;
			else if (Projectile.frameCounter >= 30 && Projectile.frameCounter < 40)
				Projectile.frame = 3;
			else if (Projectile.frameCounter >= 40 && Projectile.frameCounter < 50)
				Projectile.frame = 4;
			else if (Projectile.frameCounter >= 50 && Projectile.frameCounter < 60)
				Projectile.frame = 5;
			else if (Projectile.frameCounter >= 60 && Projectile.frameCounter < 70)
				Projectile.frame = 6;
			else
				Projectile.frameCounter = 0;
			Projectile.frameCounter++;
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
			target.immune[Projectile.owner] = 1;
			Projectile.penetrate--;
			if (Projectile.penetrate <= 0)
			{
				Projectile.Kill();
			}
		}
	
	}
}
