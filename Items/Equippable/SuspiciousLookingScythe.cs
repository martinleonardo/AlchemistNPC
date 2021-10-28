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
	public class SuspiciousLookingScythe : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Suspicious Looking Scythe");
			Tooltip.SetDefault("Summons your own Grim Reaper. Increases your crits moderately.");
			DisplayName.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Russian), "Подозрительно Выглядящая Коса");
            Tooltip.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Russian), "Призывает вашего личного Жнеца. Увеличивает ваш шанс критического удара.");

            DisplayName.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Chinese), "可疑镰刀");
            Tooltip.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Chinese), "召唤你自己的死神. 适度提高你的爆击.");
        }    
		public override void SetDefaults()
		{
			Item.CloneDefaults(ItemID.Carrot);
			Item.width = 34;
			Item.height = 34;
			Item.value = 15000000;
			Item.shoot = ProjectileType<Projectiles.GrimReaper>();
			Item.buffType = ModContent.BuffType<Buffs.GrimReaper>();	//The buff added to player after used the item
			Item.expert = true;
		}

		public override void UseStyle(Player player, Rectangle rectangle)
		{
			if (player.whoAmI == Main.myPlayer && player.itemTime == Item.useTime)
			{
				player.AddBuff(Item.buffType, 3600, true);
			}
		}
	}
}
