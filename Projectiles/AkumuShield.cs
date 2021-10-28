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
	public class AkumuShield : ModProjectile
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Akumu Shield");
			Projectile.light = 0.2f;
			ProjectileID.Sets.TrailCacheLength[Projectile.type] = 5;
			ProjectileID.Sets.TrailingMode[Projectile.type] = 0;
			Main.projFrames[Projectile.type] = 6;
		}

		public override void SetDefaults()
		{
			Projectile.width = 72;
			Projectile.height = 72;
			Projectile.penetrate = 200;
			Projectile.timeLeft = 9999;
			Projectile.tileCollide = false;
			Projectile.hostile = false;
			Projectile.friendly = false;
			Projectile.alpha = 50;
		}
		public override void AI()
		{
			Player player = Main.player[Projectile.owner];
			Projectile.Center = player.Center;
			if (++Projectile.frameCounter >= 10)
            {
                Projectile.frameCounter = 0;
                if (++Projectile.frame >= 6)
                {
                    Projectile.frame = 0;
                }
            }
			
			if (player.statLife > player.statLifeMax2/4 || player.dead || player.GetModPlayer<AlchemistNPCPlayer>().Akumu == false)
			{
				Projectile.Kill();
			}
			for(int i = 0; i < 1000; ++i)
			{
				if(Main.projectile[i].active && i != Projectile.whoAmI )
				{
					if(Main.projectile[i].Hitbox.Intersects(Projectile.Hitbox) && !Main.projectile[i].friendly)
					{
					ReflectProjectile(Main.projectile[i]);
					}
				}
			}
		}
			
			public void ReflectProjectile(Projectile proj)
			{
				proj.velocity *= -1;
				proj.damage *= 10;
				proj.hostile = false;
				proj.friendly = true;
			}
	}
}
