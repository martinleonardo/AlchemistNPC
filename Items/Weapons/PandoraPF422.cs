using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using Terraria.Localization;
using Terraria.DataStructures;

namespace AlchemistNPC.Items.Weapons
{
	public class PandoraPF422 : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Pandora (PF422)");
			Tooltip.SetDefault("'A weapon of the underworld, capable of 666 different forms'"
			+"\nSadly, this is a prototype, capable of using only one form"
			+"\nLaunches sharp shuriken, which sticks to enemies.");
			DisplayName.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Russian), "Пандора (Форма 422)");
            Tooltip.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Russian), "'Оружие преисподней, имеющее 666 различных форм'\nК сожалению, этот экземпляр всего лишь прототип, имеющий лишь одну форму\nЗапускает бритвенно-острый сюрикен, цепляющийся за противников");

            DisplayName.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Chinese), "潘多拉 (PF422)");
            Tooltip.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Chinese), "'来自地狱的武器, 有666种不同的形式'\n遗憾的是, 作为原型, 只能呈现一种形式\n发射锋利的手里剑, 能粘在敌人身上");
        }

		public override void SetDefaults()
		{
			Item.CloneDefaults(ItemID.PiranhaGun);
			Item.DamageType = DamageClass.Throwing;
			Item.damage = 88;
			Item.useStyle = 1;
			Item.UseSound = SoundID.Item1;
			Item.autoReuse = true;
			Item.noUseGraphic = true;
			Item.rare = 11;
			Item.knockBack = 8;
			Item.shoot = ProjectileType<Projectiles.PF422>();
		}
		
		public override bool Shoot(Player player, ProjectileSource_Item_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
		{
			type = ProjectileType<Projectiles.PF422>();
			return true;
		}
	}
}