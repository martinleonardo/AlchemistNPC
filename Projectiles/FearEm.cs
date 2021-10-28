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
	public class FearEm : ModProjectile
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Fear emitter effect");
		}

		public override void SetDefaults()
		{
			Projectile.width = 256;
			Projectile.height = 256;
			Projectile.penetrate = -1;
			Projectile.timeLeft = 90;
			Projectile.tileCollide = false;
			Projectile.hostile = false;
			Projectile.friendly = false;
		}
		public override void AI()
		{
			Projectile.ai[0]++;
			for (int i = 0; i < 200; i++)
            {
                NPC target = Main.npc[i];
				if(target.active && !target.friendly && !target.townNPC && !target.boss)
				{
					if (target.Hitbox.Intersects(Projectile.Hitbox))
					{
						if (!target.HasBuff(ModContent.BuffType<Buffs.CloakOfFearDebuff>())) target.velocity *= -1;
						if (Projectile.ai[0] == 5) target.velocity += target.velocity*(-3);
						target.buffImmune[ModContent.BuffType<Buffs.CloakOfFearDebuff>()] = false;
						target.AddBuff(ModContent.BuffType<Buffs.CloakOfFearDebuff>(), 360);
					}
				}
			}
			if (Projectile.ai[0] == 6) Projectile.ai[0] = 0;
		}
	}
}
