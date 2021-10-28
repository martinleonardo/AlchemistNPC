using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using Terraria.Localization;

namespace AlchemistNPC.Items.Equippable
{
	public class SoulOfPower : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Soul Of Power");
			Tooltip.SetDefault("''No one can stop me now!''"
				+ "\nIncreases all damages by 15%"
				+ "\nReduces damage reduction by 10%");
				DisplayName.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Russian), "Душа Мощи");
            Tooltip.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Russian), "''Никто меня теперь не остановит!''\nУвеличивает урон всех типов на 15%\nСнижает сопротивление к урону на 10%");
            DisplayName.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Chinese), "伟力之魂");
            Tooltip.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Chinese), "''我无人可挡!''\n增加15%所有伤害");
        }
	
		public override void SetDefaults()
		{
			Item.stack = 1;
			Item.width = 27;
			Item.height = 28;
			Item.value = 100000;
			Item.rare = 5;
			Item.accessory = true;
		}

		public override void UpdateAccessory(Player player, bool hideVisual)
		{
			player.endurance -= 0.1f;
			player.GetDamage(DamageClass.Generic) += 0.15f;
		}
		
		
		public override void AddRecipes()
		{
			CreateRecipe()
				.AddIngredient(ItemID.SoulofMight, 99)
				.AddIngredient(ItemID.SoulofNight, 30)
				.AddTile(TileID.MythrilAnvil)
				.Register();
		}
	}
}