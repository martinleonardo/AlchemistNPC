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
using AlchemistNPC.Items.PaleDamageClass;
using AlchemistNPC;
using Terraria.DataStructures;

namespace AlchemistNPC.Items.Weapons
{
    public class ParadiseLost : PaleDamageItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Paradise Lost (T-03-46)");
            Tooltip.SetDefault("''I knocked on the door, and it opened."
            + "\nI am from the end, I am merely staying."
            + "\nI am the one who kindled the lantern to face the world."
            + "\nMy loved ones, I shall show thou the best path from now on``"
            + "\n[c/FF0000:EGO weapon]"
            + "\nLeft click launcher travelling through walls projectile"
            + "\nRight click slices the air in place"
            + "\nFull set of Paradise Lost is required to use this weapon");
            DisplayName.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Russian), "Потерянный Рай (T-03-46)");
            Tooltip.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Russian), "''Я постучал в дверь, и она открылась.\nЯ из конца, я просто остаюсь.\nЯ тот, кто зажег фонарь.\nМои близкие, я покажу вам лучший путь с этого момента.''\n[c/FF0000:Оружие Э.П.О.С.]\nЗапускает проходящий сквозь стены снаряд по нажатию левой кнопки мыши\nРазрезает воздух на месте по нажатию правой кнопки мыши\nТребуется полный сет Потерянного Рая для использования");

            DisplayName.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Chinese), "失乐园 (T-03-46)");
            Tooltip.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Chinese), "乐园的大门因我的敲击而缓缓打开." +
                "\n我自终末而来, 我并无留恋, 只是在此驻足." +
                "\n我就是那个点燃希望之灯, 面对世界之人." +
                "\n我心爱的人儿, 从现在开始, 我会将那最美妙的, 无比璀璨的道路展现在你们面前." +
                "\n[c/FF0000:EGO 武器]" +
                "\n左键发射穿越方块的刀波" +
                "\n右键割裂周围的空间" +
                "\n只有穿着全套失乐园盔甲才能使用这件武器");
        }

        public override void SafeSetDefaults()
        {
            Item.damage = 666;
            Item.crit = 66;
            Item.width = 52;
            Item.height = 52;
            Item.useTime = 30;
            Item.useAnimation = 30;
            Item.useStyle = 1;
            Item.value = 10000000;
            Item.rare = 11;
            Item.knockBack = 8;
            Item.autoReuse = true;
            Item.UseSound = SoundID.Item1;
            Item.shoot = ProjectileType<Projectiles.ParadiseLostProjectile>();
            Item.shootSpeed = 8f;
        }

        public override bool AltFunctionUse(Player player)
        {
            return true;
        }

        public override bool CanUseItem(Player player)
        {
            if (((AlchemistNPCPlayer)player.GetModPlayer<AlchemistNPCPlayer>()).ParadiseLost == true)
            {
                return true;
            }
            if (player.altFunctionUse == 2)
            {
                Item.useTime = 40;
                Item.useAnimation = 40;
            }
            else
            {
                Item.useTime = 30;
                Item.useAnimation = 30;
            }
            return false;
        }

        public override bool Shoot(Player player, ProjectileSource_Item_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
        {
            if (player.altFunctionUse != 2)
            {
                Item.noMelee = false;
                Vector2 SPos = player.position;
                position = SPos;
                if (player.direction == 1)
                {
                    Projectile.NewProjectile(source, position.X + 10, position.Y, velocity.X, velocity.Y, ProjectileType<Projectiles.ParadiseLostProjectile>(), damage, knockback, player.whoAmI);
                }
                if (player.direction == -1)
                {
                    Projectile.NewProjectile(source, position.X - 10, position.Y, velocity.X, velocity.Y, ProjectileType<Projectiles.ParadiseLostProjectile>(), damage, knockback, player.whoAmI);
                }
            }
            if (player.altFunctionUse == 2)
            {
                Item.noMelee = true;
                if (player.direction == 1)
                {
                    for (int h = 0; h < 1; h++)
                    {
                        Vector2 vel = new Vector2(0, 0);
                        vel *= 0f;
                        Projectile.NewProjectile(source, position.X, position.Y, vel.X, vel.Y, ProjectileType<Projectiles.ParadiseLost>(), damage, knockback, player.whoAmI);
                    }
                }
                if (player.direction == -1)
                {
                    for (int h = 0; h < 1; h++)
                    {
                        Vector2 vel = new Vector2(-1, 0);
                        vel *= 0f;
                        Projectile.NewProjectile(source, position.X, position.Y, vel.X, vel.Y, ProjectileType<Projectiles.ParadiseLostMirror>(), damage, knockback, player.whoAmI);
                    }
                }
            }
            return false;
        }

        public override void OnHitNPC(Player player, NPC target, int damage, float knockback, bool crit)
        {
            target.AddBuff(ModContent.BuffType<Buffs.Twilight>(), 600);
        }

        public override void AddRecipes()
        {
            CreateRecipe()
                .AddIngredient(null, "Twilight")
                .AddIngredient(null, "ChromaticCrystal", 10)
                .AddIngredient(null, "SunkroveraCrystal", 10)
                .AddIngredient(null, "NyctosythiaCrystal", 10)
				// IMPLEMENT WHEN WEAKREFERENCES FIXED
				/*
				if (ModLoader.GetMod("CalamityMod") != null)
				{
						.AddIngredient((ModLoader.GetMod("CalamityMod").ItemType("UeliaceBar")), 10)
						.AddIngredient((ModLoader.GetMod("CalamityMod").ItemType("Phantoplasm")), 25)

				}
				if (ModLoader.GetMod("ThoriumMod") != null)
				{
						.AddIngredient((ModLoader.GetMod("ThoriumMod").ItemType("OceanEssence")), 5)
						.AddIngredient((ModLoader.GetMod("ThoriumMod").ItemType("DeathEssence")), 5)
						.AddIngredient((ModLoader.GetMod("ThoriumMod").ItemType("InfernoEssence")), 5)

				}
				*/
				.AddIngredient(null, "EmagledFragmentation", 250)
                .AddTile(null, "MateriaTransmutator")
                .Register();
        }
    }
}
