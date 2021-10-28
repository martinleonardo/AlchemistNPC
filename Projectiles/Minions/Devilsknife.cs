using System.Collections.Generic;
using Microsoft.Xna.Framework;
using System;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace AlchemistNPC.Projectiles.Minions
{
	public class Devilsknife : ModProjectile
    {
        public override void SetDefaults()
        {
			Projectile.CloneDefaults(533);
			Projectile.aiStyle = 66;
			AIType = 533;
            Projectile.width = 78;
            Projectile.height = 86;  
            Projectile.ignoreWater = true; 
            Projectile.timeLeft = 36000;
            Projectile.penetrate = -1; 
            Projectile.tileCollide = false; 
            Projectile.minion = true;
			Projectile.minionSlots = 1;
        }

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Devilsknife");
			Main.projFrames[Projectile.type] = 1;
			ProjectileID.Sets.MinionTargettingFeature[Projectile.type] = true;
		}
		
		public override bool TileCollideStyle(ref int width, ref int height, ref bool fallThrough, ref Vector2 hitboxCenterFrac)
		{
			return false;
		}
		
		public override void AI()
		{
			Projectile.tileCollide = false;
			Player player = Main.player[Projectile.owner];
			AlchemistNPCPlayer modPlayer = player.GetModPlayer<AlchemistNPCPlayer>();
			if (player.dead || !player.HasBuff(ModContent.BuffType<Buffs.Devilsknife>()))
			{
				modPlayer.devilsknife = false;
			}
			if (modPlayer.devilsknife)
			{
				Projectile.timeLeft = 2;
			}
			if (player.direction == 1)
			{
				Projectile.spriteDirection = -1;
			}
			if (player.direction == -1)
			{
				Projectile.spriteDirection = 1;
			}
		}
		
		public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
		{
			target.immune[Projectile.owner] = 6;
		}
	}
}