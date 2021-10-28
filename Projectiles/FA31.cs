using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using System;

namespace AlchemistNPC.Projectiles
{
	public class FA31 : ModProjectile
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Frost Cloud 1");
		}

		public override void SetDefaults()
		{
			Projectile.CloneDefaults(511);
			Projectile.DamageType = DamageClass.Throwing;
			Projectile.aiStyle = 92;
			AIType = 511;
		}
		
		public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
		{
			if (!Main.hardMode)
			{
			target.AddBuff(BuffID.Frostburn, 180);
			}
			if (Main.hardMode && !NPC.downedMoonlord)
			{
			target.AddBuff(BuffID.ShadowFlame, 180);
			}
			if (NPC.downedMoonlord)
			{
			target.AddBuff(ModContent.BuffType<Buffs.Patience>(), 60);
			}
		}
	}
}
