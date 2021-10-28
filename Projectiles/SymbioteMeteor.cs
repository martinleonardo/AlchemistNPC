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
	public class SymbioteMeteor : ModProjectile
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Symbiote Meteor");
		}

		public override void SetDefaults()
		{
			Projectile.CloneDefaults(ProjectileID.Bullet);
			// Unknown Damage Type
			//Projectile.ranged = false;
			Projectile.width = 34;
			Projectile.height = 34;
			Projectile.penetrate = 999;
			Projectile.timeLeft = 600;
			AIType = ProjectileID.Bullet;
		}
		
		public override void AI()
		{
			for (int index1 = 0; index1 < 3; ++index1)
			{
				int index2 = Dust.NewDust(new Vector2(Projectile.position.X, Projectile.position.Y), Projectile.width, Projectile.height, 31, 0.0f, 0.0f, 100, new Color(), 1.5f);
				Main.dust[index2].velocity *= 0.99f;
			}
			for (int index1 = 0; index1 < 3; ++index1)
			{
				int index2 = Dust.NewDust(new Vector2(Projectile.position.X, Projectile.position.Y), Projectile.width, Projectile.height, 6, 0.0f, 0.0f, 100, new Color(), 3.5f);
				Main.dust[index2].noGravity = true;
				Main.dust[index2].velocity *= 0.99f;
				int index3 = Dust.NewDust(new Vector2(Projectile.position.X, Projectile.position.Y), Projectile.width, Projectile.height, 6, 0.0f, 0.0f, 100, new Color(), 1.5f);
				Main.dust[index3].velocity *= 0.99f;
			}
		}
		
		public override bool OnTileCollide(Vector2 oldVelocity)
		{
			Projectile.Kill();
			return true;
		}
		
		public override void Kill(int timeLeft)
        {
			Terraria.Audio.SoundEngine.PlaySound(2, (int)Projectile.position.X, (int)Projectile.position.Y, 62);
			Terraria.Audio.SoundEngine.PlaySound(2, (int)Projectile.position.X, (int)Projectile.position.Y, 89);
			for (int index1 = 0; index1 < 60; ++index1)
			{
				int index2 = Dust.NewDust(new Vector2(Projectile.position.X, Projectile.position.Y), Projectile.width, Projectile.height, 31, 0.0f, 0.0f, 100, new Color(), 1.5f);
				Main.dust[index2].velocity *= 1.4f;
			}
			for (int index1 = 0; index1 < 40; ++index1)
			{
				int index2 = Dust.NewDust(new Vector2(Projectile.position.X, Projectile.position.Y), Projectile.width, Projectile.height, 6, 0.0f, 0.0f, 100, new Color(), 3.5f);
				Main.dust[index2].noGravity = true;
				Main.dust[index2].velocity *= 7f;
				int index3 = Dust.NewDust(new Vector2(Projectile.position.X, Projectile.position.Y), Projectile.width, Projectile.height, 6, 0.0f, 0.0f, 100, new Color(), 1.5f);
				Main.dust[index3].velocity *= 3f;
			}
			Item.NewItem((int)Projectile.Center.X, (int)Projectile.Center.Y, Projectile.width, Projectile.height, ModContent.ItemType<Items.Misc.SymbioteMeteorite>());
		}
	}
}