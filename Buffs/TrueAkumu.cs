using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using Terraria.ID;
using Terraria.Localization;

namespace AlchemistNPC.Buffs
{
	public class TrueAkumu : ModBuff
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("True Akumu's Shield");
			Description.SetDefault("Reflects any hostile projectiles");
			Main.debuff[Type] = false;
			CanBeCleared = true;
			DisplayName.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Russian), "Защита Акуму");
			Description.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Russian), "Отражает любые снаряды противника");
            DisplayName.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Chinese), "真·Akumu之盾");
            Description.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Chinese), "反射所有敌对抛射物");
        }
		
		public override void Update(Player player, ref int buffIndex)
		{
			if (player.ownedProjectileCounts[ModContent.ProjectileType<Projectiles.TrueAkumuShield>()] == 0)
			{
				for (int h = 0; h < 1; h++) {
				Vector2 vel = new Vector2(0, -1);
				vel *= 0f;
				Projectile.NewProjectile(player.GetProjectileSource_Buff(buffIndex), player.position.X-15, player.position.Y, vel.X, vel.Y, ModContent.ProjectileType<Projectiles.TrueAkumuShield>(), 0, 0, player.whoAmI);
				}
			}
		}
	}
}
