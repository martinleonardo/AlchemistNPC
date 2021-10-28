using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using Terraria.Localization;
using Terraria.DataStructures;

namespace AlchemistNPC.Items.Weapons
{
	public class PandoraPF398 : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Pandora (PF398)");
			Tooltip.SetDefault("'A weapon of the underworld, capable of 666 different forms'"
			+"\nFixed Pandora with unlocked damaging potential"
			+"\nChargeable Laser Device"
			+"\nAttacking fills Disaster Gauge"
			+"\nFull gauge allows you to switch weapon's form"
			+"\nRight click to change form");
			DisplayName.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Russian), "Пандора (Форма 398)");
            Tooltip.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Russian), "'Оружие преисподней, имеющее 666 различных форм'\nВерсия с разблокированным потенциалом\nЗаряжаемый лазер\nПри наборе полной шкалы Бедствия вы можете сменить форму Пандоры\nНажмите правую кнопку мыши для смены формы");

            DisplayName.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Chinese), "潘多拉 (PF398)");
			Tooltip.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Chinese), "'来自地狱的武器, 有666种不同的形态'"
			+"\n修复了的潘多拉, 解锁了破坏潜力"
			+"\n可蓄力的激光发射器"
			+"\n攻击装填灾厄槽"
			+"\n灾厄槽集满时能够切换武器形态"
			+"\n右键切换形态");
        }

		public override void SetDefaults()
		{
			Item.damage = 250;
			Item.noMelee = true;
			Item.DamageType = DamageClass.Ranged;
			Item.channel = true;
			Item.rare = 11;
			Item.width = 18;
			Item.height = 14;
			Item.useTime = 40;
			Item.UseSound = SoundID.Item13;
			Item.useStyle = 5;
			Item.shootSpeed = 14f;
			Item.useAnimation = 40;   
			Item.knockBack = 10;			
			Item.shoot = ProjectileType<Projectiles.PF398>();
			Item.value = Item.sellPrice(1, 0, 0, 0);
		}

		public override void HoldItem(Player player)
		{
		((AlchemistNPCPlayer)player.GetModPlayer<AlchemistNPCPlayer>()).PH = true;
		}
		
		public override bool Shoot(Player player, ProjectileSource_Item_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
		{
			((AlchemistNPCPlayer)player.GetModPlayer<AlchemistNPCPlayer>()).DisasterGauge += 10;
			if (player.altFunctionUse != 2)
			{
			return true;
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
				Item.SetDefaults(ModContent.ItemType<Items.Weapons.PandoraPF594>());
			}
			return false;
		}
	}
}
