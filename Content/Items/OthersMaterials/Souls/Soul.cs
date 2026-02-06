using Microsoft.Xna.Framework.Graphics;
using System;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria;
using Microsoft.Xna.Framework;

namespace InPursuitOfSouls.Content.Items.OthersMaterials.Souls
{
    public class Soul : ModItem
    {
        public override void SetStaticDefaults()
        {
            // Включение свечения и эффекта парения
            ItemID.Sets.ItemNoGravity[Type] = true;
            ItemID.Sets.ItemIconPulse[Type] = true;
        }

        public override void SetDefaults()
        {
            Item.width = 22;
            Item.height = 22;
            Item.maxStack = 999999;
            Item.value = Item.sellPrice(0, 0, 0, 0);
            Item.rare = ItemRarityID.Green;

            // Звук при подборе (как у звезды)
            Item.UseSound = SoundID.Item29;
        }

        // Желтое свечение вокруг предмета
        public override void PostUpdate()
        {
            Lighting.AddLight(Item.Center, new Vector3(0.6f, 1.0f, 0.2f));
        }

        // Дополнительные визуальные эффекты при отрисовке
        public override bool PreDrawInWorld(SpriteBatch spriteBatch, Color lightColor, Color alphaColor, ref float rotation, ref float scale, int whoAmI)
        {
            Texture2D texture = ModContent.Request<Texture2D>(Texture).Value;
            Vector2 position = Item.position - Main.screenPosition + new Vector2(Item.width / 2, Item.height / 2);

            // Рисуем саму душу
            spriteBatch.Draw(texture, position, null, Color.White, rotation, texture.Size() * 0.5f, scale, SpriteEffects.None, 0f);

            // Добавляем свечение
            float glowScale = 1f + (float)Math.Sin(Main.GlobalTimeWrappedHourly * 3f) * 0.1f;
            Color glowColor = Color.Green * 0.7f;
            glowColor.A = 0;

            spriteBatch.Draw(texture, position, null, glowColor, rotation, texture.Size() * 0.5f, scale * glowScale, SpriteEffects.None, 0f);

            return false; // Отменяем стандартную отрисовку
        }
    }
}
