using BattleNotifier.Model;
using BattleNotifier.Properties;
using BattleNotifier.Utils;
using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web.Script.Serialization;
using System.Xml;
using System.Xml.Linq;
using Utils;

namespace BattleNotifier.BusinessLogic
{
    public class CurrentBattleApi
    {
        /// <summary>
        /// This flag helps to use elmaonline only once per battle and not spam/abuse.
        /// </summary>
        public bool EolDataLoaded { private get; set; }

        /// <summary>
        /// Get the current battle from elmaonline api, and image from elmaonline.
        /// </summary>
        /// <returns> Ongoing battle if any, else null.</returns>
        public Battle GetOngoingBattleIfAny()
        {
            try
            {
                string json = null;
                using (WebClient wc = new WebClient())
                {
                    json = wc.DownloadString(Settings.Default.CurrentBattleApiUrl);
                }

                var json_serializer = new JavaScriptSerializer();
                var queue = json_serializer.Deserialize<EolApiBattle[]>(json);
                var newestBattle = queue.FirstOrDefault();

                if (!newestBattle.IsInQueue && !newestBattle.IsFinished)
                {
                    var battle = new Battle();
                    battle.StartedDateTime = UnixTimeStampToDateTime(newestBattle.Started);
                    battle.Id = newestBattle.Index;
                    battle.Desginer = newestBattle.Kuski;
                    battle.FileName = newestBattle.LevelName;
                    battle.Duration = newestBattle.Duration;
                    battle.Type = ParseBattleType(newestBattle.Type);

                    if (!EolDataLoaded)
                    {
                        try
                        {
                            SetBattleUrls(battle);
                            EolDataLoaded = true;
                        }
                        catch (Exception ex)
                        {
                            try
                            {
                                SetBattleUrls(battle);
                                Logger.Log(101, ex);
                            }
                            catch (Exception iex)
                            {
                                Logger.Log(103, iex);
                            }
                        }
                    }

                    return battle;
                }
                else
                {
                    Clear();
                    return null;
                }
            }
            catch (Exception ex)
            {
                Logger.Log(100, ex);
                return null;
            }
        }

        private BattleType ParseBattleType(string battleType)
        {
            switch (battleType)
            {
                case "Normal":
                    return BattleType.Normal;
                case "Apple":
                    return BattleType.Apple;
                default:
                    return BattleType.Normal;
            }
        }

        private static DateTime UnixTimeStampToDateTime(double unixTimeStamp)
        {
            // Unix timestamp is seconds past epoch
            System.DateTime dtDateTime = new DateTime(1970, 1, 1, 0, 0, 0, 0, System.DateTimeKind.Utc);
            dtDateTime = dtDateTime.AddSeconds(unixTimeStamp - (60 * 60 * 10)).ToLocalTime();
            return dtDateTime;
        }

        private void SetBattleUrls(Battle battle)
        {
            HtmlAgilityPack.HtmlDocument document = new HtmlWeb().Load(battle.Url);

            battle.LevelUrl = document.DocumentNode.Descendants("a")
                                                .Select(e => e.GetAttributeValue("href", null))
                                                .Where(s => !String.IsNullOrEmpty(s) && s.StartsWith(Settings.Default.EOLLevelUrl))
                                                .FirstOrDefault();

            battle.MapUrl = document.DocumentNode.Descendants("img")
                                            .Select(e => e.GetAttributeValue("src", null))
                                            .Where(s => !String.IsNullOrEmpty(s) && s.StartsWith(Settings.Default.EOLMapsUrl))
                                            .FirstOrDefault();
        }

        internal void Clear()
        {
            EolDataLoaded = false;
        }
    }
}
