using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using Terraria.ID;
using Terraria.Localization;
using AlchemistNPC;

namespace AlchemistNPC.Buffs
{
	public class ShieldofSpring : ModBuff
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Shield of Spring");
			Description.SetDefault("Reduces all incoming damage by 15%");
			Main.buffNoSave[Type] = true;
			Main.debuff[Type] = false;
			CanBeCleared = true;
			Main.buffNoTimeDisplay[Type] = true;
			DisplayName.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Russian), "Щит Весны");
			Description.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Russian), "Уменьшает весь входящий урон на 15%");
            DisplayName.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Chinese), "源泉之盾");
            Description.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Chinese), "减免15%所受伤害");
        }
		public override void Update(Player player, ref int buffIndex)
		{
			player.endurance += 0.15f;
			if (player.ownedProjectileCounts[ModContent.ProjectileType<Projectiles.SpringShield>()] == 0)
			{
				for (int h = 0; h < 1; h++) {
				Vector2 vel = new Vector2(0, -1);
				vel *= 0f;
				Projectile.NewProjectile(player.GetProjectileSource_Buff(buffIndex), player.Center.X, player.Center.Y, vel.X, vel.Y, ModContent.ProjectileType<Projectiles.SpringShield>(), 0, 0, player.whoAmI);
				}
			}
		}
	}
}
