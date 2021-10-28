using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using System;
using Terraria.Audio;

namespace AlchemistNPC.Projectiles
{
	public class ChaosBomb : ModProjectile
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Chaos Bomb");
		}

		public override void SetDefaults()
		{
			Projectile.CloneDefaults(261);
			Projectile.width = 40;
			Projectile.height = 62;
			Projectile.DamageType = DamageClass.Throwing;
			Projectile.aiStyle = 14;
			Projectile.timeLeft = 360;
			AIType = 261;
		}
		
		public override void AI()
		{
			if (Projectile.timeLeft > 350) Projectile.tileCollide = false;
			else Projectile.tileCollide = true;
		}
		
		public override bool OnTileCollide(Vector2 oldVelocity)
		{
			Projectile.Kill();
			return true;
		}
		
		public override void Kill(int timeLeft)
        {
			Player player = Main.player[Projectile.owner];
			
			for (int index1 = 0; index1 < 30; ++index1)
			{
				int index2 = Dust.NewDust(new Vector2(Projectile.position.X, Projectile.position.Y), Projectile.width, Projectile.height, 31, 0.0f, 0.0f, 100, new Color(), 1.5f);
				Main.dust[index2].velocity *= 1.4f;
			}
			for (int index1 = 0; index1 < 20; ++index1)
			{
				int index2 = Dust.NewDust(new Vector2(Projectile.position.X, Projectile.position.Y), Projectile.width, Projectile.height, 6, 0.0f, 0.0f, 100, new Color(), 3.5f);
				Main.dust[index2].noGravity = true;
				Main.dust[index2].velocity *= 7f;
				int index3 = Dust.NewDust(new Vector2(Projectile.position.X, Projectile.position.Y), Projectile.width, Projectile.height, 6, 0.0f, 0.0f, 100, new Color(), 1.5f);
				Main.dust[index3].velocity *= 3f;
			}
			for (int index1 = 0; index1 < 2; ++index1)
			{
				float num2 = 0.4f;
				if (index1 == 1)
				num2 = 0.8f;
				int index2 = Gore.NewGore(new Vector2(Projectile.position.X, Projectile.position.Y), new Vector2(), Main.rand.Next(61, 64), 1f);
				Main.gore[index2].velocity *= num2;
				++Main.gore[index2].velocity.X;
				++Main.gore[index2].velocity.Y;
				int index3 = Gore.NewGore(new Vector2(Projectile.position.X, Projectile.position.Y), new Vector2(), Main.rand.Next(61, 64), 1f);
				Main.gore[index3].velocity *= num2;
				--Main.gore[index3].velocity.X;
				++Main.gore[index3].velocity.Y;
				int index4 = Gore.NewGore(new Vector2(Projectile.position.X, Projectile.position.Y), new Vector2(), Main.rand.Next(61, 64), 1f);
				Main.gore[index4].velocity *= num2;
				++Main.gore[index4].velocity.X;
				--Main.gore[index4].velocity.Y;
				int index5 = Gore.NewGore(new Vector2(Projectile.position.X, Projectile.position.Y), new Vector2(), Main.rand.Next(61, 64), 1f);
				Main.gore[index5].velocity *= num2;
				--Main.gore[index5].velocity.X;
				--Main.gore[index5].velocity.Y;
			}
			
            if (Projectile.owner == Main.myPlayer)
            {
				Vector2 vector2 = player.RotatedRelativePoint(player.MountedCenter, true);
				float num75 = 10f;
				float num82 = (float)Projectile.Center.X - vector2.X;
				float num83 = (float)Projectile.Center.Y - vector2.Y;
				float num84 = (float)Math.Sqrt((double)(num82 * num82 + num83 * num83));
				float num85 = num84;
				if ((float.IsNaN(num82) && float.IsNaN(num83)) || (num82 == 0f && num83 == 0f))
				{
					num82 = (float)Projectile.direction;
					num83 = 0f;
					num84 = 11f;
				}
				else
				{
					num84 = 11f / num84;
				}
				num82 *= num84;
				num83 *= num84;
				int num117 = 5;
				for (int num118 = 0; num118 < num117; num118++)
				{
					vector2 = new Vector2(player.position.X + (float)player.width * 0.5f + (float)(Main.rand.Next(201) * -(float)player.direction) + ((float)Projectile.Center.X - player.position.X), Projectile.Center.Y - 600f);
					vector2.X = (vector2.X + player.Center.X) / 2f + (float)Main.rand.Next(-350, 351);
					vector2.Y -= (float)(100 * num118);
					num82 = (float)Projectile.Center.X - vector2.X;
					num83 = (float)Projectile.Center.Y - vector2.Y;
					float ai2 = num83 + vector2.Y;
					if (num83 < 0f)
					{
						num83 *= -1f;
					}
					if (num83 < 20f)
					{
						num83 = 20f;
					}
					num84 = (float)Math.Sqrt((double)(num82 * num82 + num83 * num83));
					num84 = num75 / num84;
					num82 *= num84;
					num83 *= num84;
					Vector2 vector11 = new Vector2(num82, num83) / 2f;
					switch (Main.rand.Next(4))
					{
						case 0:
							Terraria.Audio.SoundEngine.PlaySound(2, (int)Projectile.position.X, (int)Projectile.position.Y, 89);
							Projectile.NewProjectile(Projectile.GetProjectileSource_FromThis(), vector2.X, vector2.Y, vector11.X*2f, vector11.Y*2f, ModContent.ProjectileType<Projectiles.CB1>(), Projectile.damage*2, 8f, player.whoAmI);
							break;
						case 1:
							Terraria.Audio.SoundEngine.PlaySound(2, (int)Projectile.position.X, (int)Projectile.position.Y, 89);
							Projectile.NewProjectile(Projectile.GetProjectileSource_FromThis(), vector2.X, vector2.Y, vector11.X*2f, vector11.Y*2f, ModContent.ProjectileType<Projectiles.CB2>(), Projectile.damage*2, 8f, player.whoAmI);
							break;
						case 2:
							Terraria.Audio.SoundEngine.PlaySound(2, (int)Projectile.position.X, (int)Projectile.position.Y, 89);
							Projectile.NewProjectile(Projectile.GetProjectileSource_FromThis(), vector2.X, vector2.Y, vector11.X*2f, vector11.Y*2f, ModContent.ProjectileType<Projectiles.CB3>(), Projectile.damage*2, 8f, player.whoAmI);
							break;
						case 3:
							Terraria.Audio.SoundEngine.PlaySound(2, (int)Projectile.position.X, (int)Projectile.position.Y, 89);
							Projectile.NewProjectile(Projectile.GetProjectileSource_FromThis(), vector2.X, vector2.Y, vector11.X*2f, vector11.Y*2f, ModContent.ProjectileType<Projectiles.CB4>(), Projectile.damage*2, 8f, player.whoAmI);
							break;
					}
				}
			}
		}
		
					
		public override void ModifyHitNPC (NPC target, ref int damage, ref float knockback, ref bool crit, ref int hitDirection)
		{
			if (target.type == ModContent.NPCType<NPCs.BillCipher>())
			{
			damage /= 250;
			}
		}
		
		public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
		{
			target.immune[Projectile.owner] = 1;
			Projectile.Kill();
		}
	}
}
