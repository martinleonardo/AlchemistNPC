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
	public class Returner : ModProjectile
	{
		public override void SetDefaults()
		{
			Projectile.friendly = true;
			Projectile.width = 1920;
			Projectile.height = 1080;
			Projectile.penetrate = -1;
			Projectile.timeLeft = 1;
			Projectile.tileCollide = false;
			Projectile.usesLocalNPCImmunity = true;
			Projectile.localNPCHitCooldown = -1;
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Returner");
		}
	}
}
