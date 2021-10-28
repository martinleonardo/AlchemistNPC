using System;
using System.Linq;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using Terraria.ID;
using Terraria.Localization;

namespace AlchemistNPC.Buffs
{
    public class TrueAkumuAttack : ModBuff
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Akumu");
            Description.SetDefault("Attacks nearby enemies");
            Main.debuff[Type] = false;
            CanBeCleared = true;
            DisplayName.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Russian), "Акуму");
            Description.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Russian), "Атакует ближайших противников");
            DisplayName.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Chinese), "Akumu");
            Description.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Chinese), "攻击附近敌人");
        }

        public override void Update(Player player, ref int buffIndex)
        {
            // IMPLEMENT WHEN WEAKREFERENCES FIXED
            /*
			if (ModLoader.GetMod("CalamityMod") != null)
			{
				if (player.ownedProjectileCounts[ModContent.ProjectileType<Projectiles.AkumuSphere>()] == 0)
				{
					for (int h = 0; h < 1; h++) {
					Vector2 vel = new Vector2(0, -1);
					vel *= 0f;
					Projectile.NewProjectile(player.GetProjectileSource_Buff(buffIndex), player.Center.X, player.Center.Y, vel.X, vel.Y, ModContent.ProjectileType<Projectiles.AkumuSphere>(), 1500, 0, player.whoAmI);
					}
				}
			}
			if (ModLoader.GetMod("CalamityMod") == null)
			{
				if (player.ownedProjectileCounts[ModContent.ProjectileType<Projectiles.AkumuSphere>()] == 0)
				{
					for (int h = 0; h < 1; h++) {
					Vector2 vel = new Vector2(0, -1);
					vel *= 0f;
					Projectile.NewProjectile(player.GetProjectileSource_Buff(buffIndex), player.Center.X, player.Center.Y, vel.X, vel.Y, ModContent.ProjectileType<Projectiles.AkumuSphere>(), 1000, 0, player.whoAmI);
					}
				}
			}
			*/
            // DELETE THIS SECTION AFTER IMPLEMENTING COMMENTED OUT CODE
            if (player.ownedProjectileCounts[ModContent.ProjectileType<Projectiles.AkumuSphere>()] == 0)
            {
                for (int h = 0; h < 1; h++)
                {
                    Vector2 vel = new Vector2(0, -1);
                    vel *= 0f;
                    Projectile.NewProjectile(player.GetProjectileSource_Buff(buffIndex), player.Center.X, player.Center.Y, vel.X, vel.Y, ModContent.ProjectileType<Projectiles.AkumuSphere>(), 1000, 0, player.whoAmI);
                }
            }
            // END OF SECTION
        }
    }
}
