using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace AlchemistNPC.Projectiles
{
	public class SporeTrap : ModProjectile
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Spore Trap");
		}

		public override void SetDefaults()
		{
			Projectile.CloneDefaults(ProjectileID.SporeTrap);
			Projectile.DamageType = DamageClass.Magic; 
			AIType = ProjectileID.ChlorophyteBullet;
		}
		
		public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
		{
			target.immune[Projectile.owner] = 1;
		}
	}
}