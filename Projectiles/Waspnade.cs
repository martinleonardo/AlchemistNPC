using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace AlchemistNPC.Projectiles
{
	public class Waspnade : ModProjectile
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Waspnade");
		}

		public override void SetDefaults()
		{
		Projectile.CloneDefaults(30);
		Projectile.aiStyle = 2;
		Projectile.timeLeft = 180;
		Projectile.scale = 0.8f;
		AIType = 30;
		}
		
		public override bool PreKill(int timeLeft)
		{
			Projectile.type = 338;
			return true;
		}
		
		public override bool OnTileCollide(Vector2 oldVelocity)
		{
			Projectile.aiStyle = 16;
			return true;
		}
		
		public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
		{
			Projectile.Kill();
		}
		
		public override void AI()
		{
			Projectile.aiStyle = 2;
		}
		
		public override void Kill(int timeLeft)
		{
			for (int h = 0; h < 11; h++)
			{
				Vector2 vel = new Vector2(0, -1);
				float rand = Main.rand.NextFloat() * 6.283f;
				vel = vel.RotatedBy(rand);
				vel *= 5f;
				Projectile.NewProjectile(Projectile.GetProjectileSource_FromThis(), Projectile.Center.X, Projectile.Center.Y, vel.X, vel.Y, ModContent.ProjectileType<Projectiles.Wasps>(), Projectile.damage, 0, Main.myPlayer);
			}
		}
	}
}
