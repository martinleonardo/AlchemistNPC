using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace AlchemistNPC.Projectiles
{
	public class GrimReaper : ModProjectile
	{
		public override void SetDefaults()
		{
			Projectile.CloneDefaults(ProjectileID.Bunny);

			AIType = ProjectileID.Bunny;
			Main.projFrames[Projectile.type] = 8;
			Projectile.width = 40;
			Projectile.height = 50;
			Main.projPet[Projectile.type] = true;
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Gregg the Grim Reaper");

		}

		public override bool PreAI()
		{
			Player player = Main.player[Projectile.owner];
			player.bunny = false; // Relic from AIType
			return true;
		}

		public override void AI()
		{
			Player player = Main.player[Projectile.owner];
			AlchemistNPCPlayer modPlayer = player.GetModPlayer<AlchemistNPCPlayer>();
			if (player.dead || !player.HasBuff(ModContent.BuffType<Buffs.GrimReaper>()))
			{
				modPlayer.grimreaper = false;
			}
			if (modPlayer.grimreaper)
			{
				Projectile.timeLeft = 2;
			}
			
			if (Projectile.frameCounter > 20)
			{
				Projectile.frame++;
				Projectile.frameCounter = 0;
			}
			if (Projectile.frame >= 8)
			{ Projectile.frame = 0; }
		}
	}
}
