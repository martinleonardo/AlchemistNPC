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
	public class Twilight : ModItem
	{
		public static int counter = 0;
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Twilight (O-02-63)");
			Tooltip.SetDefault("''Eyes that never close, a scale that could measure all sins, and a beak that could swallow everything"
			+ "\nprotected the Black Forest in peace, and those who could wield this could also bring peace.''"
			+ "\n[c/FF0000:EGO weapon]"
			+ "\nInflicts several types of damage on hit"
			+ "\nHits every enemy on screen by 200 each second while held"
			+ "\nRight click teleports you to cursor, boosting your damage by 3x and making you unvulnerable for 2 seconds");
			DisplayName.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Russian), "Сумерки (O-02-63)");
            Tooltip.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Russian), "Глаза, что не закроются никогда, чешуя, что может измерить все грехи и клюв, \nкоторый способен поглотить всё, хранят Чёрный Лес в покое. \nИ те, кто способны носить ЕГО, тоже могут нести покой.\n[c/FF0000:Оружие Э.П.О.С.]\nПричиняет несколько типов урона\nРанит всех противников на экране по 150 урона каждую секунду\nПравый клик телепортирует вас на позицию курсора, делает вас неуязвимым и повышает ваш урон в 3 раза на 2 секунды");

            DisplayName.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Chinese), "薄暝 (O-02-63)");
            Tooltip.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Chinese), "'那永不闭合的眼睛, 那能衡量一切罪恶的天平, 那能吞噬一切的巨口'\n'这三者守护着黑森林的和平, 而那些能够同时驾驭这三者的人也能带来和平.'\n[c/FF0000:EGO 武器]\n对命中的敌人造成多种不同伤害\n握持时, 每秒对屏幕内所有敌人造成200点伤害\n右键传送到光标处, 伤害x3并且获得2秒无敌.");
        }

		public override void SetDefaults()
		{
			Item.DamageType = DamageClass.Melee;
			Item.damage = 300;
			Item.width = 60;
			Item.height = 62;
			Item.useTime = 12;
			Item.useAnimation = 12;
			Item.useStyle = 1;
			Item.value = 10000000;
			Item.rare = 11;
            Item.knockBack = 6;
            Item.autoReuse = true;
			Item.UseSound = SoundID.Item1;
		}
		
		public override bool AltFunctionUse(Player player)
		{
			return true;
		}
		
		public override void HoldItem(Player player)
		{
			counter++;
			if (counter == 60)
			{
				counter = 0;
				Projectile.NewProjectile(player.GetProjectileSource_Item(Item), player.Center.X, player.Center.Y, 0f, 0f, ProjectileType<Projectiles.Returner>(), 200, 0, player.whoAmI);
			}
		}
		
		public override void OnHitNPC(Player player, NPC target, int damage, float knockback, bool crit)
		{
			target.AddBuff(ModContent.BuffType<Buffs.Twilight>(), 600);
		}
		
		public override bool CanUseItem(Player player)
		{
			if (player.altFunctionUse != 2)
			{
				if (((AlchemistNPCPlayer)player.GetModPlayer<AlchemistNPCPlayer>()).ParadiseLost == true)
				{
					Item.damage = 400;
					Item.useTime = 10;
					Item.useAnimation = 10;
				}
				else
				{
					Item.damage = 300;
					Item.useTime = 12;
					Item.useAnimation = 12;
				}
			}
			if (player.altFunctionUse == 2 && !player.HasBuff(ModContent.BuffType<Buffs.TwilightCD>()))
			{
				player.AddBuff(ModContent.BuffType<Buffs.TwilightBoost>(), 120);
				player.AddBuff(ModContent.BuffType<Buffs.TwilightCD>(), 600);
				Vector2 vector = Main.screenPosition + new Vector2(Main.mouseX, Main.mouseY);
				player.Teleport(vector, 1, 0);
			}
			if (player.altFunctionUse == 2 && player.HasBuff(ModContent.BuffType<Buffs.TwilightCD>()))
			{
				return false;
			}
			return base.CanUseItem(player);
		}
		
		public override void AddRecipes()
		{
			CreateRecipe()
				.AddIngredient(null, "Justitia")
				.AddIngredient(null, "TheBeak")
				.AddIngredient(ItemID.TerraBlade)
				.AddIngredient(null, "EmagledFragmentation", 200)
				.AddTile(null, "WingoftheWorld")
				.Register();
		}
	}
}
