using System;
using System.IO;
using StardewModdingAPI;
using StardewModdingAPI.Events;
using StardewValley;

namespace StardewTwitchTrackerMod
{
    public class ModEntry : Mod
    {

        string FilePath = $@"{Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)}\StardewTwitchTracker\crops.txt";

        public override void Entry(IModHelper helper)
        {
            helper.Events.GameLoop.OneSecondUpdateTicking += this.OnOneSecondUpdateTicking;
        }

        private void OnOneSecondUpdateTicking(object sender, OneSecondUpdateTickingEventArgs e)
        {

            if (Context.IsWorldReady && File.Exists(FilePath))
            {
                string[] lines = File.ReadAllLines(FilePath);

                if (lines != null && lines.Length > 0)
                {
                    foreach (string line in lines)
                    {
                        if (line != "")
                        {
                            AddToInventory(line);
                        }

                    }

                    File.WriteAllText(FilePath, String.Empty);
                }

            }

        }

        private void AddToInventory(string id)
        {
            int item_id;

            switch (id)
            {
                case "potato":
                    item_id = 192;
                    break;
                case "cauliflower":
                    item_id = 190;
                    break;
                case "turnip":
                    item_id = 24;
                    break;
                case "tomato":
                    item_id = 256;
                    break;
                default:
                    item_id = 0;
                    break;
            }

            StardewValley.Object item = new StardewValley.Object(item_id, 1);
            Game1.player.addItemByMenuIfNecessary(item);
        }

    }
}
