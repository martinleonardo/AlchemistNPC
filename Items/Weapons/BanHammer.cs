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

namespace AlchemistNPC.Items.Weapons
{
	public class BanHammer : ModItem
	{
		public override void SetStaticDefaults()
		{
			Tooltip.SetDefault("[c/FF0000:Instantly kills any non-boss enemies]"
			+"\n[c/FF0000:If a part of the boss doesn't count as boss, it would be killed too]");
			
			DisplayName.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Russian), "Банхаммер");
			Tooltip.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Russian), "[c/FF0000:Мгновенно убивает всё, что не является боссом.]\n[c/FF0000:Если часть босса не считается боссом - она будет уничтожена]");

            DisplayName.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Chinese), "班锤");
            Tooltip.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Chinese), "[c/FF0000:秒杀一切非Boss敌人]" +
                "\n[c/FF0000:如果Boss的某个部分不算做Boss, 同样也会被秒杀]");
        }

		public override void SetDefaults()
		{
			Item.CloneDefaults(ItemID.Muramasa);
			Item.DamageType = DamageClass.Melee;
			Item.damage = 88;
			Item.crit = 100;
			Item.width = 40;
			Item.height = 40;
			Item.useTime = 10;
			Item.useAnimation = 10;
			Item.hammer = 666;
			Item.value = 500000;
			Item.rare = 10;
            Item.knockBack = 10;
            Item.autoReuse = true;
			Item.UseSound = SoundID.Item1;
			Item.expert = true;
			Item.scale = 1.5f;
		}
		
		public override void ModifyHitNPC(Player player, NPC target, ref int damage, ref float knockback, ref bool crit) 
		{
			if (target.boss == false)
			{
				if (target.type != 134 && target.type != 135 && target.type != 136 && target.type != 325 && target.type != 327 && target.type != 325 && target.type != 344 && target.type != 345 && target.type != 346 &&  target.type != 477)
				{
					target.buffImmune[ModContent.BuffType<Buffs.Banned>()] = false;
					target.AddBuff(ModContent.BuffType<Buffs.Banned>(), 60);
				}
			}
			if (target.type == NPCID.DungeonGuardian)
			{
				target.buffImmune[ModContent.BuffType<Buffs.Banned>()] = false;
				target.AddBuff(ModContent.BuffType<Buffs.Banned>(), 60);
			}
		}
		
		public override void MeleeEffects(Player player, Rectangle hitbox)
		{
			Dust.NewDust(new Vector2(hitbox.X, hitbox.Y), hitbox.Width, hitbox.Height, DustID.Electric);
		}	
	}
}
