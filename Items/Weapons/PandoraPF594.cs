using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using Terraria.Localization;
using Terraria.DataStructures;

namespace AlchemistNPC.Items.Weapons
{
	public class PandoraPF594 : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Pandora (PF594)");
			Tooltip.SetDefault("'A weapon of the underworld, capable of 666 different forms'"
			+"\nFixed Pandora with unlocked damaging potential"
			+"\nSpecial attack #1 (Homing Rockets to all directions)"
			+"\nAttack depletes Disaster Gauge"
			+"\nRight click to change special attack");
			DisplayName.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Russian), "Пандора (Форма 594)");
            Tooltip.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Russian), "'Оружие преисподней, имеющее 666 различных форм'\nВерсия с разблокированным потенциалом\nСпециальная Атака №1 (самонаводящиеся ракеты вокруг)\nАтака опустошает шкалу Бедствия\nНажмите правую кнопку мыши для смены специальной атаки");

            DisplayName.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Chinese), "潘多拉 (PF594)");
			Tooltip.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Chinese), "'来自地狱的武器, 有666种不同的形态'"
			+"\n修复了的潘多拉, 解锁了破坏潜力"
			+"\n特殊攻击 #1 (向各个方向发射追踪火箭)"
			+"\n攻击装填灾厄槽"
			+"\n灾厄槽集满时能够切换武器形态"
			+"\n右键切换特殊攻击");
        }

		public override void SetDefaults()
		{
			Item.CloneDefaults(ItemID.SnowmanCannon);
			Item.noUseGraphic = true;
			Item.DamageType = DamageClass.Generic;
			Item.damage = 3333;
			Item.crit = 100;
			Item.width = 56;
			Item.height = 30;
			Item.useTime = 40;
			Item.useAnimation = 40;
			Item.noMelee = true; //so the item's animation doesn't do damage
			Item.knockBack = 8;
			Item.value = 1000000;
			Item.rare = 11;
			Item.autoReuse = false;
			Item.shootSpeed = 32f;
			Item.shoot = ProjectileID.VortexBeaterRocket;
			Item.value = Item.sellPrice(1, 0, 0, 0);
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
			Vector2 vel1 = new Vector2(-1, -1);
			vel1 *= 8f;
			Projectile.NewProjectile(source, player.position.X+30, player.position.Y+30, vel1.X, vel1.Y, ProjectileID.VortexBeaterRocket, Item.damage/2, 0, Main.myPlayer);
			Vector2 vel2 = new Vector2(1, 1);
			vel2 *= 8f;
			Projectile.NewProjectile(source, player.position.X-30, player.position.Y-30, vel2.X, vel2.Y, ProjectileID.VortexBeaterRocket, Item.damage/2, 0, Main.myPlayer);
			Vector2 vel3 = new Vector2(1, -1);
			vel3 *= 8f;
			Projectile.NewProjectile(source, player.position.X-30, player.position.Y+30, vel3.X, vel3.Y, ProjectileID.VortexBeaterRocket, Item.damage/2, 0, Main.myPlayer);
			Vector2 vel4 = new Vector2(-1, 1);
			vel4 *= 8f;
			Projectile.NewProjectile(source, player.position.X+30, player.position.Y-30, vel4.X, vel4.Y, ProjectileID.VortexBeaterRocket, Item.damage/2, 0, Main.myPlayer);
			Vector2 vel5 = new Vector2(0, -1);
			vel5 *= 8f;
			Projectile.NewProjectile(source, player.position.X, player.position.Y+30, vel5.X, vel5.Y, ProjectileID.VortexBeaterRocket, Item.damage/2, 0, Main.myPlayer);
			Vector2 vel6 = new Vector2(0, 1);
			vel6 *= 8f;
			Projectile.NewProjectile(source, player.position.X, player.position.Y-30, vel6.X, vel6.Y, ProjectileID.VortexBeaterRocket, Item.damage/2, 0, Main.myPlayer);
			Vector2 vel7 = new Vector2(1, 0);
			vel7 *= 8f;
			Projectile.NewProjectile(source, player.position.X-30, player.position.Y, vel7.X, vel7.Y, ProjectileID.VortexBeaterRocket, Item.damage/2, 0, Main.myPlayer);
			Vector2 vel8 = new Vector2(-1, 0);
			vel8 *= 8f;
			Projectile.NewProjectile(source, player.position.X+30, player.position.Y, vel8.X, vel8.Y, ProjectileID.VortexBeaterRocket, Item.damage/2, 0, Main.myPlayer);
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
				Item.SetDefaults(ModContent.ItemType<Items.Weapons.PandoraPF666>());
				return true;
			}
			return false;
		}
	}
}
