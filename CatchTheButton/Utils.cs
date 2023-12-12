using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CatchTheButton
{
    internal class Utils
    {
        public static ListView[] mainListViews = new ListView[2];
        public static void GenerateLeaderboard()
        {
            if (mainListViews[0] == null) return;
            if (mainListViews[1] == null) return;

            mainListViews[0].Items.Clear();
            mainListViews[1].Items.Clear();

            string[] items = new string[2];
            foreach (Dictionary<string, int> pairs in SaveManager.gameData["mode1"])
            {
                foreach (KeyValuePair<string, int> pair in pairs)
                {
                    items[0] = pair.Key;
                    items[1] = pair.Value.ToString();
                    ListViewItem lvi = new ListViewItem(items);
                    mainListViews[0].Items.Add(lvi);
                }
            }

            foreach (Dictionary<string, int> pairs in SaveManager.gameData["mode2"])
            {
                foreach (KeyValuePair<string, int> pair in pairs)
                {
                    items[0] = pair.Key;
                    items[1] = pair.Value.ToString();
                    ListViewItem lvi = new ListViewItem(items);
                    mainListViews[1].Items.Add(lvi);
                }
            }
        }
    }
}
