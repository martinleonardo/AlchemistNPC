using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using Terraria.Localization;
using Terraria.DataStructures;

namespace AlchemistNPC.Items.Weapons
{
	public class PandoraPF666 : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Pandora (PF666)");
			Tooltip.SetDefault("'A weapon of the underworld, capable of 666 different forms'"
			+"\nFixed Pandora with unlocked damaging potential"
			+"\nSpecial attack #2 (Energy Release)"
			+"\nAttack depletes Disaster Gauge"
			+"\nRight click to change special attack");
			DisplayName.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Russian), "Пандора (Форма 666)");
            Tooltip.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Russian), "'Оружие преисподней, имеющее 666 различных форм'\nВерсия с разблокированным потенциалом\nСпециальная Атака №2 (Высвобождение энергии)\nАтака опустошает шкалу Бедствия\nНажмите правую кнопку мыши для смены специальной атаки");

            DisplayName.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Chinese), "潘多拉 (PF666)");
			Tooltip.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Chinese), "'来自地狱的武器, 有666种不同的形态'"
			+"\n修复了的潘多拉, 解锁了破坏潜力"
			+"\n特殊攻击 #2 (能量放出)"
			+"\n攻击装填灾厄槽"
			+"\n灾厄槽集满时能够切换武器形态"
			+"\n右键切换特殊攻击");
        }
		
		public override void SetDefaults()
		{
			Item.CloneDefaults(ItemID.SnowmanCannon);
			Item.DamageType = DamageClass.Generic;
			Item.damage = 666;
			Item.crit = 100;
			Item.width = 56;
			Item.height = 30;
			Item.useTime = 40;
			Item.useAnimation = 40;
			Item.noMelee = true;
			Item.knockBack = 8;
			Item.rare = 11;
			Item.autoReuse = false;
			Item.shootSpeed = 32f;
			Item.shoot = ProjectileType<Projectiles.PF666>();
			Item.value = Item.sellPrice(1, 0, 0, 0);
			Item.UseSound = SoundID.Item5;
			Item.useAmmo = 0;
		}

		public override void HoldItem(Player player)
		{
			((AlchemistNPCPlayer)player.GetModPlayer<AlchemistNPCPlayer>()).PH = true;
			((AlchemistNPCPlayer)player.GetModPlayer<AlchemistNPCPlayer>()).DisasterGauge = 500;
		}

		public override bool Shoot(Player player, ProjectileSource_Item_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
		{
			if (player.altFunctionUse != 2)
			{
			Vector2 vel1 = new Vector2(-0, 0);
			vel1 *= 0f;
			Projectile.NewProjectile(source, player.position.X, player.position.Y, vel1.X, vel1.Y, ProjectileType<Projectiles.PF666>(), Item.damage, 0, Main.myPlayer);
			((AlchemistNPCPlayer)player.GetModPlayer<AlchemistNPCPlayer>()).DisasterGauge = 0;
			Item.SetDefaults(ModContent.ItemType<Items.Weapons.Pandora>());
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
			if (player.altFunctionUse == 2)
			{
				Item.SetDefaults(ModContent.ItemType<Items.Weapons.PandoraPF594>());
				return true;
			}
			return false;
		}
	}
}
