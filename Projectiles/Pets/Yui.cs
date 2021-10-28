using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace AlchemistNPC.Projectiles.Pets
{
	public class Yui : ModProjectile
	{
		public override void SetDefaults()
		{
			Projectile.CloneDefaults(87);
			Projectile.width = 72;
			Projectile.height = 64;
			Projectile.ignoreWater = true;
			Projectile.aiStyle = 11;
			AIType = 87;
			Main.projFrames[Projectile.type] = 4;
			ProjectileID.Sets.LightPet[Projectile.type] = true;
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Yui");

		}

		public override bool PreAI()
		{
			Player player = Main.player[Projectile.owner];
			player.bunny = false;
			return true;
		}

		public override void AI()
		{
			if (Main.rand.NextBool(3))
			{
				Dust.NewDust(new Vector2(Projectile.position.X, Projectile.position.Y), Projectile.width, Projectile.height, 61, Projectile.velocity.X * 0.1f, Projectile.velocity.Y * 0.1f, 0, default(Color), 1f);
			}
			Player player = Main.player[Projectile.owner];
			AlchemistNPCPlayer modPlayer = (AlchemistNPCPlayer)player.GetModPlayer<AlchemistNPCPlayer>();
			if (player.dead || !player.HasBuff(ModContent.BuffType<Buffs.Yui>()))
			{
				modPlayer.Yui = false;
			}
			if (modPlayer.Yui)
			{
				Projectile.timeLeft = 2;
			}
			Lighting.AddLight(Projectile.position, 3.0f, 3.0f, 3.0f);
		}
	}
}