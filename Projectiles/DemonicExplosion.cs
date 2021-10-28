using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using System;

namespace AlchemistNPC.Projectiles
{
	public class DemonicExplosion : ModProjectile
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Demonic Explosion");     //The English name of the projectile
			Main.projFrames[Projectile.type] = 5;
		}

		public override void SetDefaults()
		{
			Projectile.CloneDefaults(612);
			Projectile.DamageType = DamageClass.Ranged;
			Projectile.aiStyle = 117;
			AIType = 612;
		}
	}
}
