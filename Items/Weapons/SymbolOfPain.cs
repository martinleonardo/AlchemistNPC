using Microsoft.Xna.Framework;
using System.Linq;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using Terraria.Localization;
using Terraria.DataStructures;

namespace AlchemistNPC.Items.Weapons
{
	public class SymbolOfPain : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Scroll ''Symbol of Pain''");
			Tooltip.SetDefault("One-use item"
			+"\nContains the spell ''Symbol of Pain''"
			+"\nWhile used, all enemies on the screen would be heavily weakened for 1 minute"
			+"\nMakes you deal 25% more damage to affected enemies (not lowered by any caps)"
			+"\nAlso makes them deal 1/4 less damage"
			+"\nExhausts player for 1 minute, making him unable to use magic");
			DisplayName.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Russian), "Свиток ''Символа Боли''");
            Tooltip.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Russian), "Одноразовый предмет\nЭтот свиток содержит заклинание ''Символа Боли''\nПрименение ослабляет всех противников на экране\nПоражённые противники получают на 25% больше урона и наносят на 1/4 меньше урона\nИстощает игрока на 1 минуту, не позволяя ему использовать магию");
			DisplayName.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Chinese), "卷轴 ''痛苦法印''");
			Tooltip.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Chinese), "一次性物品"
			+"\n包含着 ''痛苦法印''法术"
			+"\n使用时, 屏幕内所有敌人都将被严重虚弱1分钟 (不会被任何限制降低)"
			+"\n对虚弱敌人多造成25%伤害"
			+"\n同样使敌人伤害降低1/4"
			+"\n使玩家精疲力尽1分钟, 期间无法使用魔法");
        }

		public override void SetDefaults()
		{
			Item.consumable = true;
			Item.maxStack = 99;
			Item.width = 32;
			Item.height = 32;
			Item.useTime = 60;
			Item.useAnimation = 60;
			Item.useStyle = 2;
			Item.noMelee = true;
			Item.rare = 11;
			Item.mana = 300;
			Item.autoReuse = false;
			Item.shoot = ProjectileType<Projectiles.SymbolOfPain>();
			Item.value = Item.sellPrice(1, 0, 0, 0);
			Item.UseSound = SoundID.NPCDeath59;
			Item.mana = 200;
		}
		
		public override bool Shoot(Player player, ProjectileSource_Item_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
		{
			Vector2 vel1 = new Vector2(-0, 0);
			vel1 *= 0f;
			Projectile.NewProjectile(source, player.position.X, player.position.Y, vel1.X, vel1.Y, ProjectileType<Projectiles.SymbolOfPainVision>(), Item.damage, 0, Main.myPlayer);
			Projectile.NewProjectile(source, player.position.X, player.position.Y, vel1.X, vel1.Y, ProjectileType<Projectiles.SymbolOfPain>(), Item.damage, 0, Main.myPlayer);
			player.AddBuff(ModContent.BuffType<Buffs.Exhausted>(), 3600); 
			return false;
		}
		public override bool CanUseItem(Player player)
		{
			if (!player.HasBuff(ModContent.BuffType<Buffs.Exhausted>()) && !player.HasBuff(ModContent.BuffType<Buffs.ExecutionersEyes>()) && !player.HasBuff(ModContent.BuffType<Buffs.CloakOfFear>()))
			{
				return true;
			}
			return false;
		}
	}
}
