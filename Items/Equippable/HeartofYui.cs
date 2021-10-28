using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using Terraria.Localization;
using Microsoft.Xna.Framework;

namespace AlchemistNPC.Items.Equippable
{
	public class HeartofYui : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Heart of Yui");
			Tooltip.SetDefault("Summons Pixie Helper"
			+"\nHighlights treasures, creatures and traps");
			DisplayName.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Russian), "Сердце Юи"); 
			Tooltip.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Russian), "Вызывает Фею-Помошника\nПодсвечивает сокровища, существ и ловушки");

            DisplayName.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Chinese), "小悠之心");
            Tooltip.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Chinese), "召唤小精灵助手\n照亮宝物, 生物和陷阱");
        }

		public override void SetDefaults()
		{
			Item.damage = 0;
			Item.useStyle = 1;
			Item.shoot = ProjectileType<Projectiles.Pets.Yui>();
			Item.width = 16;
			Item.height = 30;
			Item.UseSound = SoundID.Item2;
			Item.useAnimation = 20;
			Item.useTime = 20;
			Item.rare = 8;
			Item.noMelee = true;
			Item.value = Item.sellPrice(3, 0, 0, 0);
			Item.buffType = ModContent.BuffType<Buffs.Yui>();
			Item.expert = true;
		}

		public override void UseStyle(Player player, Rectangle heldItemFrame)
		{
			if (player.whoAmI == Main.myPlayer && player.itemTime == Item.useTime)
			{
				player.AddBuff(Item.buffType, 3600, true);
			}
		}
		
		public override void AddRecipes()
		{
			CreateRecipe()
				.AddIngredient(null, "HeartofYuiS")
				.Register();
		}
	}
}