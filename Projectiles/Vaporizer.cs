using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using System;

namespace AlchemistNPC.Projectiles
{
	public class Vaporizer : ModProjectile
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Vaporizer");
		}

		public override void SetDefaults()
		{
			Projectile.CloneDefaults(302);
			Projectile.width = 6;
			Projectile.tileCollide = false;
			Projectile.aiStyle = 1;
			AIType = 302;
		}
		
		public override void ModifyHitNPC(NPC target, ref int damage, ref float knockback, ref bool crit, ref int hitDirection)
		{
			if (target.friendly)
			{
			damage /= 30;
			}
		}
		
		public override void ModifyHitPlayer(Player target, ref int damage, ref bool crit)
		{
			target.AddBuff(ModContent.BuffType<Buffs.Petrified>(), 10);
		}
	}
}
