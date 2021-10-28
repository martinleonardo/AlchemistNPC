using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using System;

namespace AlchemistNPC.Projectiles
{
	public class QoH2 : ModProjectile
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("QoH2");
		}

		public override void SetDefaults()
		{
			Projectile.CloneDefaults(503);
			Projectile.DamageType = DamageClass.Magic;
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
			player.statMana += 10;
			player.ManaEffect(10);
			target.immune[Projectile.owner] = 1;
		}
	}
}
