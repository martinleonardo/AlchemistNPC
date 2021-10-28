using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using System;

namespace AlchemistNPC.Projectiles
{
	public class ConeOfColdProjectile : ModProjectile
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Cone Of Cold");     //The English name of the projectile
		}

		public override void SetDefaults()
		{
			Projectile.CloneDefaults(118);
			Projectile.DamageType = DamageClass.Magic;
			Projectile.aiStyle = 28;
			AIType = 118;
		}
		
		public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
		{
			if (!target.boss && Main.rand.Next(10) == 0)
			{
			target.buffImmune[ModContent.BuffType<Buffs.Slowness>()] = false;
			target.AddBuff(ModContent.BuffType<Buffs.Slowness>(), 120);
			}
			if (!target.boss && Main.rand.Next(30) == 0)
			{
			target.buffImmune[ModContent.BuffType<Buffs.Patience>()] = false;
			target.AddBuff(ModContent.BuffType<Buffs.Patience>(), 120);
			}
		}
	}
}
