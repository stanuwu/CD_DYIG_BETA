using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Net;

namespace CD_DYIG_BETA
{
    class Program
    {
        static void Main(string[] args)
        {
            //define input data for tests
            string name = "Test Username";
            int level = 99;
            string description = "Hello, this is a test text for a description.";
            string title = "Player";
            string cclass = "Commoner";
            int money = 5342645;
            int exp = 750;
            int maxhp = 175;
            int hp = 100;
            string weapon = "Wooden Test Sword";
            string armor = "Hardened Test Armor";
            string extra = "Supreme Test Talisman";
            decimal multi = 1.25m;
            string imageurl = "https://www.skansen.se/imager/www_skansen_se/uploads-aws/Besoeksinfo/Restauranger/gubbhyllanextMA_d8657c9a17e123a2fcdd697d12da885a.jpg";

            using (Bitmap image = new Bitmap("bg1.png"))
            using (Font hfont = new Font("Dubai Regular", 45))
            using (Font dfont = new Font("Consolas", 28))
            using (Font gfont = new Font("Consolas", 20))
            using (Graphics g = Graphics.FromImage(image))
            using (Brush hbrush = new SolidBrush(Color.FromArgb(9, 255, 252)))
            using (Brush brush = new SolidBrush(Color.FromArgb(0, 210, 210)))
            using (Brush hpbrush = new SolidBrush(Color.FromArgb(221, 46, 68)))
            using (WebClient client = new WebClient())
            using (Bitmap pfp = new Bitmap(client.OpenRead(imageurl)))
            {
                //settings for text drawing
                g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
                g.TextRenderingHint = System.Drawing.Text.TextRenderingHint.AntiAliasGridFit;
                StringFormat center = new StringFormat();
                center.Alignment = StringAlignment.Center;

                //draw name
                g.DrawString(name, hfont, hbrush, new PointF(185, 60));

                //draw desciption
                g.DrawString(description, dfont, brush, new Rectangle(180, 95, 390, 70));

                //draw profile picture
                g.DrawImage(pfp, 40, 40, 120, 120);

                //draw money
                g.DrawString(money.ToString("N0").Replace(",", "."), gfont, brush, new Rectangle(60, 270, 240, 34));

                //draw exp
                g.DrawString(exp.ToString("N0").Replace(",", "."), gfont, brush, new Rectangle(343, 270, 237, 34));

                //draw level
                g.DrawString("LVL " + level, dfont, brush, new Rectangle(442, 120, 100, 35), center);

                //draw class
                g.DrawString(cclass, gfont, brush, new Rectangle(240, 125, 195, 34));

                //draw title
                g.DrawString(title, gfont, brush, new Rectangle(172, 180, 192, 34));

                //drawhealthbar
                int healthbarlength = (int)Math.Round(((double)512/maxhp)*hp);
                g.FillRectangle(hpbrush, new Rectangle(69, 218, healthbarlength, 38));
                g.DrawString($"{hp}/{maxhp}", dfont, brush, new Rectangle(70, 221, 510, 35));

                //draw weapon
                g.DrawString(weapon, gfont, brush, new Rectangle(60, 310, 235, 34));

                //draw armor
                g.DrawString(armor, gfont, brush, new Rectangle(342, 310, 235, 34));

                //draw extra
                g.DrawString(extra, gfont, brush, new Rectangle(60, 350, 250, 34));

                //draw stat multiplier
                g.DrawString("Multiplier: x" + multi, gfont, brush, new Rectangle(365, 350, 277, 34));

                //finalize
                g.Dispose();
                image.Save("test.png", System.Drawing.Imaging.ImageFormat.Png);
            }
            System.Diagnostics.Process.Start("test.png");
        }
    }
}
