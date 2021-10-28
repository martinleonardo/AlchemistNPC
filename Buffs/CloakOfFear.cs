using System;
using System.Linq;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.IO;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using Terraria.ModLoader.IO;
using Terraria.GameInput;
using Terraria.Localization;

namespace AlchemistNPC.Buffs
{
	public class CloakOfFear : ModBuff
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Cloak Of Fear");
			Description.SetDefault("Makes nearby non-boss enemies change their movement direction");
			Main.debuff[Type] = true;
			Main.pvpBuff[Type] = true;
			Main.buffNoSave[Type] = false;
			LongerExpertDebuff = false;
			DisplayName.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Russian), "Плащ Страха");
			Description.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Russian), "Заставляет обычных врагов около игрока менять направление движения");
            DisplayName.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Chinese), "恐惧之袍");
            Description.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Chinese), "使附近的非Boss敌人改变移动方向");
        }

		public override void Update(Player player, ref int buffIndex)
		{
			if (player.ownedProjectileCounts[ModContent.ProjectileType<Projectiles.CloakOfFear>()] == 0)
			{
				for (int h = 0; h < 1; h++) {
				Vector2 vel = new Vector2(0, -1);
				vel *= 0f;
				Projectile.NewProjectile(player.GetProjectileSource_Buff(buffIndex), player.Center.X, player.Center.Y, vel.X, vel.Y, ModContent.ProjectileType<Projectiles.CloakOfFear>(), 0, 0, player.whoAmI);
				}
			}
			if (player.buffTime[buffIndex] == 1) 
			{ 
				player.AddBuff(ModContent.BuffType<Buffs.Exhausted>(), 1800);
			}
		}
	}
}
