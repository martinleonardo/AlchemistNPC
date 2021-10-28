using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using Terraria.Localization;

namespace AlchemistNPC.Items.Equippable
{
    [AutoloadEquip(EquipType.Neck)]
    public class LaetitiaGift : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Laetitia Gift (O-01-67-1)");
            Tooltip.SetDefault("She says that she has many friends, but they can't come with you. So she came up with this brilliant idea!"
            + "\n[c/FF0000:EGO Gift/Weapon]"
            + "\n[c/FF0000:Warning!!! Will slowly consume your life if full set of armor is not equipped]"
            + "\nAllows to summon Little Witch Monster if full set of armor is on"
            + "\nLittle Witch Monster will dissapear if EGO armor set is not on"
            + "\nIncreases maximum amount of minions by 3");
            DisplayName.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Russian), "Дар Летиции (O-01-67-1)");
            Tooltip.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Russian), "Она говорила, что у неё много друзей, но они не смогут пойти с тобой. И тогда ей пришла в голову блестящая идея!\n[c/FF0000:Э.П.О.С Дар/Оружие]\n[c/FF0000:Осторожно!!! Будет медленно пожирать ваше HP, если полный сет брони не одет]\nПозволяет призвать Монстра Маленькой Ведьмы если одет полный сет Э.П.О.С брони Летиции.\nМонстр Маленькой Ведьмы пропадёт если если Э.П.О.С броня не одета\nУвеличивает максимальное число прислужников на 3");

            DisplayName.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Chinese), "蕾蒂希娅的礼物 (O-01-67-1)");
            Tooltip.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Chinese), "'它总是说, 它有许多朋友, 虽然它们都没法跟它待在一起. 于是, 她想出了这个绝妙的主意!'\n[c/FF0000:EGO 礼物/武器]\n[c/FF0000:警告!!! 如果没有召唤小巫怪, 会慢慢消耗你的生命值]\n如果穿着全套蕾蒂希娅EGO盔甲, 则可以召唤一只小巫怪\n如果脱下蕾蒂希娅EGO盔甲, 小巫怪会消失\n增加3个最大召唤物数量");
        }

        public override void SetDefaults()
        {
            Item.width = 26;
            Item.height = 28;
            Item.value = Item.buyPrice(0, 30, 0, 0);
            Item.rare = 7;
            Item.accessory = true;

        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            player.GetModPlayer<AlchemistNPCPlayer>().LaetitiaGift = true;
            ++player.maxMinions;
            ++player.maxMinions;
            ++player.maxMinions;
            if (player.ownedProjectileCounts[ProjectileType<Projectiles.Minions.LittleWitchMonster>()] != 1)
            {
                player.lifeRegen -= 20;
            }
            if (player.ownedProjectileCounts[ProjectileType<Projectiles.Minions.LittleWitchMonster>()] < 1)
            {
                player.AddBuff(ModContent.BuffType<Buffs.LittleWitchMonster>(), 60);
            }
        }

        public override void AddRecipes()
        {
            CreateRecipe()
                .AddIngredient(ItemID.SpiderFang, 5)
                .AddIngredient(ItemID.HallowedBar, 8)
                .AddIngredient(ItemID.SoulofFright, 10)
                .AddIngredient(ItemID.SoulofNight, 10)
                .AddTile(TileID.TinkerersWorkbench)
                .Register();
        }
    }
}