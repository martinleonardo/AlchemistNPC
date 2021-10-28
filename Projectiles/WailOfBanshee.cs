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
	public class WailOfBanshee : ModProjectile
	{
		public override void SetDefaults()
		{
			Projectile.friendly = true;
			Projectile.width = 6400;
			Projectile.height = 6400;
			Projectile.penetrate = -1;
			Projectile.timeLeft = 90;
			Projectile.tileCollide = false;
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("WailOfBanshee");
		}

		public override void AI()
		{
			Player player = Main.player[Projectile.owner];
			// UPDATE FOR 1.4
			//Main.monolithType = 2;
			player.ManageSpecialBiomeVisuals("Stardust", true, player.Center);
		}
		
		public override void ModifyHitNPC (NPC target, ref int damage, ref float knockback, ref bool crit, ref int hitDirection)
		{
			if (!target.boss)
			{
			damage = 249999;
			}
			if (target.boss)
			{
			damage = 0;
			}
		}
		
		public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
		{
			target.immune[Projectile.owner] = 1;
		}
	}
}
