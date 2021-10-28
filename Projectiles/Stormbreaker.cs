using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using System;

namespace AlchemistNPC.Projectiles
{
	public class Stormbreaker : ModProjectile
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Stormbreaker's Throw");
		}

		public override void SetDefaults()
		{
			Projectile.CloneDefaults(182);
			Projectile.width = 50;
			Projectile.height = 40;
			Projectile.aiStyle = 3;
			AIType = 182;
			Projectile.usesLocalNPCImmunity = true;
		}
		
		public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
		{
			Player player = Main.player[Projectile.owner];
			Terraria.Audio.SoundEngine.PlaySound(SoundID.Item94.WithVolume(.6f), Projectile.position);
			for (int h = 0; h < 2; h++)
				{
					Vector2 vel1 = new Vector2(0, -1);
					float rand = Main.rand.NextFloat() * 6.283f;
					vel1 = vel1.RotatedBy(rand);
					vel1 *= 16f;
					float ai = Main.rand.Next(100);
					int n1 = Projectile.NewProjectile(Projectile.GetProjectileSource_FromThis(), Projectile.Center.X, Projectile.Center.Y, vel1.X, vel1.Y, 580, damage/5, .5f, player.whoAmI, vel1.ToRotation(), ai);
					Main.projectile[n1].usesLocalNPCImmunity = true;
				}
		}
	}
}
