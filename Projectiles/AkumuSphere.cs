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
	public class AkumuSphere : ModProjectile
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Akumu");
			Projectile.light = 0.5f;
			Main.projFrames[Projectile.type] = 1;
		}

		public override void SetDefaults()
		{
			Projectile.CloneDefaults(533);
			Projectile.width = 24;
			Projectile.height = 24;
			Projectile.aiStyle = 66;
			AIType = 533;
			Projectile.tileCollide = false;
		}
		
		public override bool TileCollideStyle(ref int width, ref int height, ref bool fallThrough, ref Vector2 hitboxCenterFrac)
		{
			return false;
		}
			
		public override void AI()
		{
			Projectile.tileCollide = false;
			Player player = Main.player[Projectile.owner]; 
			if (player.statLife < player.statLifeMax2*0.35f || player.dead || !player.HasBuff(ModContent.BuffType<Buffs.TrueAkumuAttack>()))
			{
				Projectile.Kill();
			}
		}
		
		public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
		{
			target.immune[Projectile.owner] = 3;
		}
	}
}
