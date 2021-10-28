using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using Terraria.Localization;
using Terraria.DataStructures;

namespace AlchemistNPC.Items.Weapons
{
	public class PandoraPF124 : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Pandora (PF124)");
			Tooltip.SetDefault("'A weapon of the underworld, capable of 666 different forms'"
			+"\nFixed Pandora with unlocked damaging potential"
			+"\nLaunches 3 heavy damaging homing rockets."
			+"\nAttacking fills Disaster Gauge"
			+"\nFull gauge allows you to switch weapon's form"
			+"\nRight click to change form");
			DisplayName.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Russian), "Пандора (Форма 124)");
            Tooltip.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Russian), "'Оружие преисподней, имеющее 666 различных форм'\nВерсия с разблокированным потенциалом\nЗапускает 3 мощных самонаводящихся ракеты\nПри наборе полной шкалы Бедствия вы можете сменить форму Пандоры\nНажмите правую кнопку мыши для смены формы");

            DisplayName.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Chinese), "潘多拉 (PF124)");
			Tooltip.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Chinese), "'来自地狱的武器, 有666种不同的形态'"
			+"\n修复了的潘多拉, 解锁了破坏潜力"
			+"\n发射3枚高伤追踪火箭"
			+"\n攻击装填灾厄槽"
			+"\n灾厄槽集满时能够切换武器形态"
			+"\n右键切换形态");
        }

		public override void SetDefaults()
		{
			Item.damage = 88;
			Item.DamageType = DamageClass.Ranged;
			Item.crit = 21;
			Item.width = 56;
			Item.height = 30;
			Item.useTime = 15;
			Item.useAnimation = 15;
			Item.useStyle = 5;
			Item.noMelee = true; //so the item's animation doesn't do damage
			Item.knockBack = 8;
			Item.value = 1000000;
			Item.rare = 11;
			Item.autoReuse = true;
			Item.shoot = 340;
			Item.shootSpeed = 32f;
			Item.UseSound = SoundID.Item11;
		}

		public override void HoldItem(Player player)
		{
		((AlchemistNPCPlayer)player.GetModPlayer<AlchemistNPCPlayer>()).PH = true;
		}
		
		public override bool Shoot(Player player, ProjectileSource_Item_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
		{
			((AlchemistNPCPlayer)player.GetModPlayer<AlchemistNPCPlayer>()).DisasterGauge += 4;
			if (player.altFunctionUse != 2)
			{
			type = 340;
			Projectile.NewProjectile(source, position.X, position.Y-8, velocity.X, velocity.Y, type, damage, knockback, player.whoAmI);
			Projectile.NewProjectile(source, position.X, position.Y, velocity.X, velocity.Y, type, damage, knockback, player.whoAmI);
			Projectile.NewProjectile(source, position.X, position.Y+8, velocity.X, velocity.Y, type, damage, knockback, player.whoAmI);
			return false;
			}
			if (player.altFunctionUse == 2)
			{
			return false;
			}
			return false;
		}
		
		public override bool AltFunctionUse(Player player)
		{
			return true;
		}

		public override bool CanUseItem(Player player)
		{
			if (player.altFunctionUse != 2)
			{
				return true;
			}
			if (player.altFunctionUse == 2 && ((AlchemistNPCPlayer)player.GetModPlayer<AlchemistNPCPlayer>()).DisasterGauge < 500)
			{
				return false;
			}
			if (player.altFunctionUse == 2 && ((AlchemistNPCPlayer)player.GetModPlayer<AlchemistNPCPlayer>()).DisasterGauge >= 500)
			{
				((AlchemistNPCPlayer)player.GetModPlayer<AlchemistNPCPlayer>()).DisasterGauge = 0;
				Item.SetDefaults(ModContent.ItemType<Items.Weapons.PandoraPF262>());
			}
			return false;
		}
	}
}