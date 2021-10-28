using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using System;

namespace AlchemistNPC.Projectiles
{
	public class QoH1 : ModProjectile
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("QoH1");
		}

		public override void SetDefaults()
		{
			Projectile.CloneDefaults(503);
			Projectile.aiStyle = 5;
			AIType = 503;
		}
		
		public override bool PreKill(int timeLeft)
		{
			Projectile.type = 503;
			return true;
		}
		
		public override void ModifyHitNPC (NPC target, ref int damage, ref float knockback, ref bool crit, ref int hitDirection)
		{
			Player player = Main.player[Projectile.owner]; 
			player.statLife += 2;
			player.HealEffect(2, true);
			target.immune[Projectile.owner] = 1;
		}
	}
}
