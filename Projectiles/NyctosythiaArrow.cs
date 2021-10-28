using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace AlchemistNPC.Projectiles
{
	public class NyctosythiaArrow : ModProjectile
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Nyctosythia Arrow");
		}

		public override void SetDefaults()
		{
			Projectile.CloneDefaults(ProjectileID.WoodenArrowFriendly);
			AIType = ProjectileID.WoodenArrowFriendly;
			
		}
		
		public override void AI()
		{
			if (Main.rand.Next(3) == 0)
				{
					Dust dust = Dust.NewDustDirect(Projectile.position, Projectile.height, Projectile.width, ModContent.DustType<Dusts.Hate>(),
						Projectile.velocity.X * .2f, Projectile.velocity.Y * .2f, 200, Scale: 1.2f);
					dust.velocity += Projectile.velocity * 0.3f;
					dust.velocity *= 0.2f;
				}
		}
		
		public override void ModifyHitNPC (NPC target, ref int damage, ref float knockback, ref bool crit, ref int hitDirection)
		{
			damage /= 2;
		}
		
		public override bool OnTileCollide(Vector2 oldVelocity)
		{
			Terraria.Audio.SoundEngine.PlaySound(SoundID.NPCDeath52.WithVolume(.3f), Projectile.position);
			Vector2 vel = new Vector2(0, -1);
			float rand = Main.rand.NextFloat() * 6.283f;
			vel = vel.RotatedBy(rand);
			vel *= 12f;
			Projectile.NewProjectile(Projectile.GetProjectileSource_FromThis(), Projectile.Center.X, Projectile.Center.Y, vel.X, vel.Y, ModContent.ProjectileType<Projectiles.NyctosyphiaBeam>(), Projectile.damage/6, 0, Main.myPlayer);
			Vector2 vel2 = new Vector2(0, -1);
			vel2 = vel.RotatedBy(rand);
			vel2 *= 12f;
			Projectile.NewProjectile(Projectile.GetProjectileSource_FromThis(), Projectile.Center.X, Projectile.Center.Y, vel2.X, vel2.Y, ModContent.ProjectileType<Projectiles.NyctosyphiaBeam>(), Projectile.damage/6, 0, Main.myPlayer);
			Vector2 vel3 = new Vector2(0, -1);
			vel3 = vel.RotatedBy(rand);
			vel3 *= 12f;
			Projectile.NewProjectile(Projectile.GetProjectileSource_FromThis(), Projectile.Center.X, Projectile.Center.Y, vel3.X, vel3.Y, ModContent.ProjectileType<Projectiles.NyctosyphiaBeam>(), Projectile.damage/6, 0, Main.myPlayer);
			return true;
		}
	}
}