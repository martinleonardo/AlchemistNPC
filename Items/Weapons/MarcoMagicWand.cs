using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using Terraria.ID;
using Terraria.Localization;
using System.Linq;
using Terraria.DataStructures;

namespace AlchemistNPC.Items.Weapons
{
    public class MarcoMagicWand : ModItem
    {
        public override void SetStaticDefaults()
        {
            Item.staff[Item.type] = true;
            DisplayName.SetDefault("Prince's Magic Wand");
            Tooltip.SetDefault("Magic Wand of Mewnian Prince"
            + "\nShoots wide beam that can eliminate everything on its way."
            + "\nThe longer you are holding the beam, the more powerful it becomes"
            + "\nMana cost grows respectively"
            + "\nRight click to launch kitten bombs");
            DisplayName.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Russian), "Волшебная Палочка Принца");
            Tooltip.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Russian), "Волшебная Палочка Принца Мьюни\nИспускает широкий луч, который способен уничтожить всё на своём пути\nЧем дольше удерживается луч, тем мощнее он становится\nЗатраты маны увеличиваются соответственно\nПравый клик для запуска бомб-котят");
            DisplayName.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Chinese), "王子的魔杖");
            Tooltip.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Chinese), "喵尼尔王子的魔杖"
            + "\n发射毁灭沿途一切事物的宽激光"
            + "\n激光持续时间越长, 威力越强"
            + "\n法力消耗分别增加"
            + "\n右键发射小猫炸弹");
        }

        public override void SetDefaults()
        {
            Item.damage = 250;
            Item.noMelee = true;
            Item.DamageType = DamageClass.Magic;
            Item.channel = true;                            //Channel so that you can held the weapon [Important]
            Item.crit = 10;
            Item.mana = 10;
            Item.rare = 11;
            Item.width = 30;
            Item.height = 30;
            Item.useTime = 20;
            Item.UseSound = SoundID.Item13;
            Item.useStyle = 5;
            Item.shootSpeed = 14f;
            Item.useAnimation = 20;
            Item.knockBack = 2;
            Item.shoot = ProjectileType<Projectiles.MagicWandM>();
            Item.value = Item.sellPrice(3, 0, 0, 0);
        }

        public override bool AltFunctionUse(Player player)
        {
            return true;
        }

        public override bool CanUseItem(Player player)
        {
            if (player.altFunctionUse != 2)
            {
                Item.damage = 250;
                Item.shootSpeed = 14f;
                Item.shoot = ProjectileType<Projectiles.MagicWandM>();
                Item.channel = true;
                Item.useTime = 20;
                Item.useAnimation = 20;
            }
            if (player.altFunctionUse == 2)
            {
                Item.damage = 2000;
                Item.shootSpeed = 0f;
                Item.shoot = ProjectileType<Projectiles.DarkBomb>();
                Item.channel = false;
                Item.useTime = 10;
                Item.useAnimation = 10;
            }
            return base.CanUseItem(player);
        }

        public override void UseStyle(Player player, Rectangle rectangle)
        {
            if (player.altFunctionUse != 2)
            {
                Item.UseSound = SoundID.Item13;
                Item.damage = 250;
                Item.mana = 10;
                ((AlchemistNPCPlayer)player.GetModPlayer<AlchemistNPCPlayer>()).chargetime++;
                if (((AlchemistNPCPlayer)player.GetModPlayer<AlchemistNPCPlayer>()).chargetime >= 390)
                {
                    Item.damage = 550;
                    Item.mana = 20;
                    player.moveSpeed *= 0.8f;
                }
                else if (((AlchemistNPCPlayer)player.GetModPlayer<AlchemistNPCPlayer>()).chargetime >= 210)
                {
                    Item.damage = 400;
                    Item.mana = 15;
                    player.moveSpeed *= 0.9f;
                }
            }
            if (player.altFunctionUse == 2)
            {
                Item.UseSound = SoundID.Item57;
            }
        }

        public override bool Shoot(Player player, ProjectileSource_Item_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
        {
            if (player.altFunctionUse == 2)
            {
                damage = 2000;
                Vector2 SPos = Main.screenPosition + new Vector2(Main.mouseX, Main.mouseY);
                position = SPos;
                return true;
            }
            if (player.altFunctionUse != 2)
            {
                damage = 250;
                return true;
            }
            return false;
        }

        public override void AddRecipes()
        {
            CreateRecipe()
                .AddIngredient(null, "DarkMagicWand")
				// IMPLEMENT WHEN WEAKREFERENCES FIXED
				/*
				if (ModLoader.GetMod("CalamityMod") != null)
				{
						.AddIngredient((ModLoader.GetMod("CalamityMod").ItemType("CosmiliteBar")), 10)
						.AddIngredient((ModLoader.GetMod("CalamityMod").ItemType("NightmareFuel")), 25)
						.AddIngredient((ModLoader.GetMod("CalamityMod").ItemType("EndothermicEnergy")), 25)
				}
				*/
				.AddIngredient(null, "EmagledFragmentation", 500)
                .AddTile(null, "MateriaTransmutator")
                .Register();
        }
    }
}
