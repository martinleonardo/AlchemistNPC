using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using Terraria.Localization;

namespace AlchemistNPC.Items.Weapons
{
	public class PandoraPF262 : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Pandora (PF262)");
			Tooltip.SetDefault("'A weapon of the underworld, capable of 666 different forms'"
			+"\nFixed Pandora with unlocked damaging potential"
			+"\nChaingun with very high shooting speed"
			+"\nAttacking fills Disaster Gauge"
			+"\nFull gauge allows you to switch weapon's form"
			+"\nRight click to change form");
			DisplayName.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Russian), "Пандора (Форма 262)");
            Tooltip.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Russian), "'Оружие преисподней, имеющее 666 различных форм'\nВерсия с разблокированным потенциалом\nПулемёт с очень высокой скоростью атаки\nПри наборе полной шкалы Бедствия вы можете сменить форму Пандоры\nНажмите правую кнопку мыши для смены формы");

            DisplayName.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Chinese), "潘多拉 (PF262)");
			Tooltip.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Chinese), "'来自地狱的武器, 有666种不同的形态'"
			+"\n修复了的潘多拉, 解锁了破坏潜力"
			+"\n射速极高的机枪"
			+"\n攻击装填灾厄槽"
			+"\n灾厄槽集满时能够切换武器形态"
			+"\n右键切换形态");
        }

		public override void SetDefaults()
		{
			Item.CloneDefaults(ItemID.ChainGun);
			Item.damage = 66;
			Item.DamageType = DamageClass.Ranged;
			Item.knockBack = 3;
			Item.width = 50;
			Item.height = 30;
			Item.useTime = 4;
			Item.useAnimation = 4;
			Item.noMelee = true; //so the item's animation doesn't do damage
			Item.value = 1000000;
			Item.rare = 11;
			Item.autoReuse = true;
			Item.shoot = 10;
			Item.useAmmo = 0;
		}

		public override void HoldItem(Player player)
		{
		((AlchemistNPCPlayer)player.GetModPlayer<AlchemistNPCPlayer>()).PH = true;
		}
		
		public override bool Shoot(Player player, ProjectileSource_Item_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
		{
			((AlchemistNPCPlayer)player.GetModPlayer<AlchemistNPCPlayer>()).DisasterGauge++;
			if (player.altFunctionUse != 2)
			{
			Projectile.NewProjectile(source, position.X, position.Y+3+Main.rand.Next(-5,5), velocity.X, velocity.Y, 638, damage, knockback, player.whoAmI);
			Projectile.NewProjectile(source, position.X, position.Y+Main.rand.Next(-5,5), velocity.X, velocity.Y, 638, damage, knockback, player.whoAmI);
			Projectile.NewProjectile(source, position.X, position.Y-3+Main.rand.Next(-5,5), velocity.X, velocity.Y, 638, damage, knockback, player.whoAmI);
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
				Item.SetDefaults(ModContent.ItemType<Items.Weapons.PandoraPF398>());
			}
			return false;
		}
	}
}
