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
	public class MordenkainenSword : ModProjectile
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("MordenkainenSword");
			Projectile.light = 0.8f;
			Main.projFrames[Projectile.type] = 1;
		}

		public override void SetDefaults()
		{
			Projectile.width = 44;
			Projectile.height = 44;
			Projectile.timeLeft = 30;
			Projectile.penetrate = -1;
			Projectile.hostile = false;
			Projectile.friendly = true;
			Projectile.tileCollide = false;			Projectile.DamageType = DamageClass.Melee;
		}
		
		public override bool TileCollideStyle(ref int width, ref int height, ref bool fallThrough, ref Vector2 hitboxCenterFrac)
		{
			return false;
		}
			
		public override void AI()
		{
			Projectile.tileCollide = false;
			Projectile.velocity *= 0f;
			Projectile.rotation += 0.15f;
		}
		
		public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
		{
			target.immune[Projectile.owner] = 6;
		}
	}
}
