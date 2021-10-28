using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using System;

namespace AlchemistNPC.Projectiles
{
	public class FA23 : ModProjectile
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Fire Cloud 3");
		}

		public override void SetDefaults()
		{
			Projectile.CloneDefaults(513);
			Projectile.DamageType = DamageClass.Throwing;
			Projectile.aiStyle = 92;
			AIType = 513;
		}
		
		public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
		{
			if (!Main.hardMode)
			{
			target.AddBuff(BuffID.OnFire, 180);
			}
			if (Main.hardMode && !NPC.downedMoonlord)
			{
			target.AddBuff(BuffID.CursedInferno, 180);
			}
			if (NPC.downedMoonlord)
			{
			target.AddBuff(BuffID.Daybreak, 180);
			}
		}
	}
}
