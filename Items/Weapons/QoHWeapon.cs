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
	public class QoHWeapon : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("''In the name of Love and Hate'' (O-01-04)");
			Tooltip.SetDefault("''A magical rod radiating with magical girl's lovely energy."
			+"\nBad people will be purified by its holy light and be born again."
			+"\nThey will burn. They won't want to wake up.''"
			+ "\n[c/FF0000:EGO weapon]"
			+"\nShots 4 different types of projectile"
			+"\nThey may restore HP, Mana, inflict debuff or deal double damage.");
			DisplayName.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Russian), "''Во Имя Любви и Ненависти'' (O-01-04)");
            Tooltip.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Russian), "''Волшебный жезл, излучающий любовную энергию Магической Девочки.\nПлохие люди будут очищены её святым сиянием и будут рождены вновь.\nОни сгорят. Они не захотят пробудиться.''n[c/FF0000:Оружие Э.П.О.С.]\nВыстреливает 4 типа снарядов\nОни могут восстановить ХП, Ману, наложить дебафф или нанести двойной урон");
			DisplayName.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Chinese), "''以爱与恨之名'' (O-01-04)");
			Tooltip.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Chinese), "''这根闪闪发光的魔法棒散发着魔法少女的爱之能量."
			+"\n坏蛋将会被神圣的光辉净化, 然后重生."
			+"\n他们将会被烈焰灼烧, 失去醒来的意志.''"
			+"\n[c/FF0000:EGO 武器]"
			+"\n发射4种不同种类的抛射物"
			+"\n会根据伤害类型恢复生命值, 法力值, 造成Debuff或者双倍伤害.");
        }

		public override void SetDefaults()
		{
			Item.damage = 99;
			Item.noMelee = true;
			Item.DamageType = DamageClass.Magic;
			Item.mana = 10;
			Item.rare = 11;
			Item.width = 30;
			Item.height = 30;
			Item.useTime = 6;
			Item.UseSound = SoundID.Item13;
			Item.useStyle = 5;
			Item.shootSpeed = 12f;
			Item.useAnimation = 6;   
			Item.knockBack = 4;
			Item.value = Item.sellPrice(1, 0, 0, 0);
			Item.autoReuse = true;
		}
		
		public override bool CanUseItem(Player player)
		{
			if (((AlchemistNPCPlayer)player.GetModPlayer<AlchemistNPCPlayer>()).ParadiseLost == true)
			{
				Item.damage = 125;
				Item.useTime = 5;
				Item.useAnimation = 5;
			}
			else
			{
				Item.damage = 99;
				Item.useTime = 6;
				Item.useAnimation = 6;
			}
			switch (Main.rand.Next(4))
			{
				case 0:
				Item.shoot = ProjectileType<Projectiles.QoH1>();
				break;

				case 1:
				Item.shoot = ProjectileType<Projectiles.QoH2>();
				break;
				
				case 2:
				Item.shoot = ProjectileType<Projectiles.QoH3>();
				break;
				
				case 3:
				Item.shoot = ProjectileType<Projectiles.QoH4>();
				break;
			}
		return true;
		}
		
		public override bool Shoot(Player player, ProjectileSource_Item_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
		{
			velocity = velocity.RotatedByRandom(MathHelper.ToRadians(5));
			return true;
		}
		
		
		public override void AddRecipes()
		{
			CreateRecipe()
				.AddIngredient(ItemID.ManaCrystal)
				.AddIngredient(ItemID.LifeCrystal)
				.AddIngredient(ItemID.RainbowRod)
				.AddIngredient(ItemID.StarWrath)
				.AddIngredient(ItemID.LunarBar, 8)
				.AddIngredient(ItemID.FragmentNebula, 25)
				.AddIngredient(null, "ChromaticCrystal", 5)
				.AddIngredient(null, "SunkroveraCrystal", 5)
				.AddIngredient(null, "NyctosythiaCrystal", 5)
				.AddIngredient(null, "HateVial")
				.AddIngredient(null, "EmagledFragmentation", 100)
				.AddTile(null, "MateriaTransmutator")
				.Register();
		}
	}
}
