using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using Terraria.Localization;

namespace AlchemistNPC.Items.Equippable
{
	public class CrackedCrown : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Cracked Crown");
			Tooltip.SetDefault("Summons the soul hunting entity");
			DisplayName.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Russian), "Треснувшая Корона");
            Tooltip.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Russian), "Призывает сущность, охотящуюся за душами");
            DisplayName.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Chinese), "破碎王冠");
            Tooltip.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Chinese), "召唤狩猎灵魂的实体");
        }    
		public override void SetDefaults()
		{
			Item.CloneDefaults(ItemID.Carrot);
			Item.width = 34;
			Item.height = 34;
			Item.value = 15000000;
			Item.shoot = ProjectileType<Projectiles.Pets.Snatcher>();
			Item.buffType = ModContent.BuffType<Buffs.Snatcher>();
			Item.expert = true;
		}

		public override void UseStyle(Player player, Rectangle heldItemFrame)
		{
			if (player.whoAmI == Main.myPlayer && player.itemTime == 0)
			{
				player.AddBuff(Item.buffType, 3600, true);
			}
		}
	}
}
