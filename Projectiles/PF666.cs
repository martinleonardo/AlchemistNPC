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
    public class PF666 : ModProjectile
    {
        public override void SetDefaults()
        {
            Projectile.friendly = true;
            Projectile.width = 1920;
            Projectile.height = 1080;
            Projectile.penetrate = -1;
            Projectile.timeLeft = 90;
            Projectile.tileCollide = false;
        }

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("PF666");
        }

        public override void AI()
        {
            Player player = Main.player[Projectile.owner];
            player.inferno = true;
            if (Projectile.timeLeft == 30)
            {
                Projectile.friendly = false;
            }
            //Main.monolithType = 3;
            player.ManageSpecialBiomeVisuals("Solar", true, player.Center);
        }

        public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
        {
            target.immune[Projectile.owner] = 1;
        }
    }
}
