﻿﻿﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using LeagueSharp;
using LeagueSharp.Common;
using SharpDX;
using Color = System.Drawing.Color;

namespace Akali
{
    class Akali
    {
        public static Spell Q, E, W, R;
        public static Items.Item Zhonyas;
        public static SpellSlot Ignite;

        private static void Main(string[] args)
        {
            if (args != null)
            {
                CustomEvents.Game.OnGameLoad += CargarScript;
                AppDomain.CurrentDomain.UnhandledException +=
                delegate(object sender, UnhandledExceptionEventArgs eventArgs)
                {
                    var exception = eventArgs.ExceptionObject as Exception;
                    if (exception != null)
                    {
                        Console.WriteLine(exception.Message);
                    }
                };
            }
        }

        private static void CargarScript(EventArgs args)
        {
            if (ObjectManager.Player.BaseSkinName != "Akali")
            {
                Game.PrintChat("Estas cargando una assemblie de singed, cuando tu campeon es:" + ObjectManager.Player.BaseSkinName);
                return;
            }

            Zhonyas = new Items.Item(3157, 0f);
            Ignite = ObjectManager.Player.GetSpellSlot("SummonerDot");

            Q = new Spell(SpellSlot.Q, 600);
            W = new Spell(SpellSlot.W, 700);
            E = new Spell(SpellSlot.E, 325);
            R = new Spell(SpellSlot.R, 800);

            EjecutarMenu();
            Game.PrintChat("<font color=\"#DF0101\">LeagueSharp - Assemblie Akali cargada, el uso de exploits puede llevar una sanccion por parte de rito</font>");
        }

        private static void EjecutarMenu()
        {
            var champMenu = new Menu("Assemblie Akali", "Akali - Menu");
            {
                var comboMenu = new Menu("Combo", "Combo");
                {
                    comboMenu.AddItem(new MenuItem("UsarQ", "Utilizar Q").SetValue(true));
                    comboMenu.AddItem(new MenuItem("UsarW", "Utilizar W").SetValue(true));
                    comboMenu.AddItem(new MenuItem("UsarE", "Utilizar E").SetValue(false));
                    comboMenu.AddItem(new MenuItem("UsarR", "Utilizar R").SetValue(false));
                }

                var LimpiarLinea = new Menu("LimpiarLinea", "Limpiar la Linea");
                {
                    LimpiarLinea.AddItem(new MenuItem("LimpiarE", "Limpiar usando la E?").SetValue(true));
                    LimpiarLinea.AddItem(new MenuItem("MinimoEMinions", "Numero de Minions para usar la E").SetValue(new Slider(2, 1, 5)));
                    LimpiarLinea.AddItem(new MenuItem("LimpiarLineaActivo", "Activo:").SetValue(new KeyBind('V', KeyBindType.Press)));
                }

            }

        }

    }
}
