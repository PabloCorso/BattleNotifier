using BattleNotifier.Model;
using BattleNotifier.Properties;
using BattleNotifier.Utils;
using HtmlAgilityPack;
using System;
using System.Linq;
using System.Xml;
using Utils;

namespace BattleNotifier.BusinessLogic
{
    public class CurrentBattleApi
    {
        /// <summary>
        /// This flag helps to use elmaonline only once per battle and not spam/abuse.
        /// </summary>
        public bool EolDataLoaded { private get; set; }

        public Battle GetOngoingBattleIfAnyFromNewApi()
        {
            return null;
        }

        /// <summary>
        /// Get the current battle from domi's api, and elmaonline.
        /// </summary>
        /// <returns> Ongoing battle if any, else null.</returns>
        public Battle GetOngoingBattleIfAny()
        {
            try
            {
                XmlDocument xmlDoc = WebRequestHelper.GetXmlFromUrl(Settings.Default.CurrentBattleApiUrl);

                if (xmlDoc.FirstChild.HasChildNodes)
                {
                    Battle battle = new Battle();

                    battle.Desginer = xmlDoc.DocumentElement.SelectSingleNode("designer").InnerText;
                    battle.FileName = xmlDoc.DocumentElement.SelectSingleNode("file_name").InnerText;

                    int startDelta = 0;
                    string strDelta = xmlDoc.DocumentElement.SelectSingleNode("start_delta").InnerText;
                    if (!Int32.TryParse(strDelta, out startDelta))
                    {
                        double delta = double.Parse(strDelta, System.Globalization.CultureInfo.InvariantCulture);
                        startDelta = Convert.ToInt32(delta);
                    }

                    battle.StartedDateTime = battle.CreatedDateTime.AddSeconds(Convert.ToInt32(startDelta));

                    battle.Type = (BattleType)Convert.ToInt32(xmlDoc.DocumentElement.SelectSingleNode("battle_type").InnerText);
                    battle.Attributes = (BattleAttribute)Convert.ToInt32(xmlDoc.DocumentElement.SelectSingleNode("battle_attrs").InnerText);
                    battle.Duration = Convert.ToInt32(xmlDoc.DocumentElement.SelectSingleNode("duration").InnerText) / 60;

                    battle.Id = Convert.ToInt32(xmlDoc.DocumentElement.SelectSingleNode("id").InnerText);

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
                    EolDataLoaded = false;
                    return null;
                }
            }
            catch (Exception ex)
            {
                Logger.Log(100, ex);
                return null;
            }
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
