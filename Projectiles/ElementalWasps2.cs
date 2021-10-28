using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using System.Linq;

namespace AlchemistNPC.Projectiles
{
    public class ElementalWasps2 : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Elemental Wasp");
            Main.projFrames[Projectile.type] = 4;
        }

        public override void SetDefaults()
        {
            Projectile.CloneDefaults(189);
            Projectile.netImportant = true;
            Projectile.netUpdate = true;
            Projectile.DamageType = DamageClass.Throwing;
            Projectile.aiStyle = 36;
            AIType = 189;
        }

        public override void AI()
        {
            Player player = Main.player[Projectile.owner];
            for (int index1 = 0; index1 < 8 + player.GetAmountOfExtraAccessorySlotsToShow(); ++index1)
            {
                // IMPLEMENT WHEN WEAKREFERENCES FIXED
                /*
				if (ModLoader.GetMod("CalamityMod") != null)
				{
					if (player.armor[index1].type == ModLoader.GetMod("CalamityMod").ItemType("PlagueHive"))
					{
						Projectile.scale = 1.5f;
					}	
					else if (player.armor[index1].type == 3333)
					{
						Projectile.scale = 1.5f;
					}
					else if (ModLoader.GetMod("FargowiltasSouls") != null)
					{
						if (player.armor[index1].type == ModLoader.GetMod("FargowiltasSouls").ItemType("BeeEnchant"))
						{
							Projectile.scale = 1.5f;
						}
					}
				}
				if (ModLoader.GetMod("CalamityMod") == null)
				{
					if (player.armor[index1].type == 3333)
					{
						Projectile.scale = 1.5f;
					}
					else if (ModLoader.GetMod("FargowiltasSouls") != null)
					{
						if (player.armor[index1].type == ModLoader.GetMod("FargowiltasSouls").ItemType("BeeEnchant"))
						{
							Projectile.scale = 1.5f;
						}
					}
				}	
				*/
                // DELETE THIS SECTION AFTER IMPLEMENTING COMMENTED OUT CODE
                if (player.armor[index1].type == 3333)
                {
                    Projectile.scale = 1.5f;
                }
                // END OF SECTION
            }
        }

        public override void ModifyHitNPC(NPC target, ref int damage, ref float knockback, ref bool crit, ref int hitDirection)
        {
            Player player = Main.player[Projectile.owner];
            for (int index1 = 0; index1 < 8 + player.GetAmountOfExtraAccessorySlotsToShow(); ++index1)
            {
                // IMPLEMENT WHEN WEAKREFERENCES FIXED
                /*
				if (ModLoader.GetMod("CalamityMod") != null)
				{
					if (player.armor[index1].type == ModLoader.GetMod("CalamityMod").ItemType("PlagueHive"))
					{
						damage += damage/2;
					}
					else if (player.armor[index1].type == 3333)
					{
						damage += damage/2;
					}
					else if (ModLoader.GetMod("FargowiltasSouls") != null)
					{
						if (player.armor[index1].type == ModLoader.GetMod("FargowiltasSouls").ItemType("BeeEnchant"))
						{
							damage += damage/2;
						}
					}
				}
				if (ModLoader.GetMod("CalamityMod") == null)
				{
					if (player.armor[index1].type == 3333)
					{
						damage += damage/2;
					}
					else if (ModLoader.GetMod("FargowiltasSouls") != null)
					{
						if (player.armor[index1].type == ModLoader.GetMod("FargowiltasSouls").ItemType("BeeEnchant"))
						{
							damage += damage/2;
						}
					}
				}	
				*/
                // DELETE THIS SECTION AFTER IMPLEMENTING COMMENTED OUT CODE
                if (player.armor[index1].type == 3333)
                {
                    damage += damage / 2;
                }
                // END OF SECTION
            }
        }

        public override bool OnTileCollide(Vector2 oldVelocity)
        {
            Projectile.penetrate--;
            if (Projectile.penetrate <= 0)
            {
                Projectile.Kill();
            }
            else
            {
                Projectile.ai[0] += 0.1f;
                if (Projectile.velocity.X != oldVelocity.X)
                {
                    Projectile.velocity.X = -oldVelocity.X;
                }
                if (Projectile.velocity.Y != oldVelocity.Y)
                {
                    Projectile.velocity.Y = -oldVelocity.Y;
                }
                Projectile.velocity *= 0.75f;
            }
            return false;
        }

        public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
        {
            target.immune[Projectile.owner] = 1;
            target.buffImmune[BuffID.Ichor] = false;
            target.AddBuff(BuffID.Ichor, 600);
            Projectile.penetrate = 1;
        }
    }
}
