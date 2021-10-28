using Microsoft.Xna.Framework;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using Terraria.ModLoader.IO;
using Terraria.Localization;
using AlchemistNPC;

namespace AlchemistNPC.Items.Weapons
{
	public class GoldenKnuckles : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Golden Knuckles");
			Tooltip.SetDefault("The weapon of the legendary grifter"
			+ "\nMay not look so tough, but hits hard");
			DisplayName.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Russian), "Золотой Кастет");
            Tooltip.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Russian), "Оружие легендарного мошенника\nМожет не выглядеть так уж сурово, но бьёт действительно сильно");
			DisplayName.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Chinese), "黄金指虎");
			Tooltip.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Chinese), "传奇骗术师的武器"
			+ "\n看起来不怎么牢固, 但是打人很疼");
        }

		public override void SetDefaults()
		{
			Item.DamageType = DamageClass.Melee;
			Item.damage = 666;
			Item.width = 28;
			Item.height = 28;
			Item.useTime = 6;
			Item.useAnimation = 6;
			Item.useStyle = 1;
			Item.value = 10000000;
			Item.rare = 11;
            Item.knockBack = 4;
            Item.autoReuse = true;
			Item.UseSound = SoundID.Item1;
			Item.scale = 0.5f;
		}
		
		public override void ModifyHitNPC(Player player, NPC target, ref int damage, ref float knockback, ref bool crit)
		{
			damage *= 3;
		}
		
		public override void OnHitNPC(Player player, NPC target, int damage, float knockback, bool crit)
		{
			target.AddBuff(ModContent.BuffType<Buffs.Patience>(), 120);
		}
	}
}
