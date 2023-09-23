using System;
using TaleWorlds.CampaignSystem;
using TaleWorlds.CampaignSystem.CampaignBehaviors;
using TaleWorlds.CampaignSystem.Party;
using TaleWorlds.Core;
using TaleWorlds.Library;
using TaleWorlds.Localization;

namespace PartyLowFood
{
    public class PartyLowFoodCampaignBehavior : FoodConsumptionBehavior
    {
        public override void RegisterEvents() => CampaignEvents.DailyTickPartyEvent.AddNonSerializedListener(this, new Action<MobileParty>(OnDailyTickParty));

        private void OnDailyTickParty(MobileParty party)
        {
            if (party.IsMainParty)
            {
                float totalFood = party.Food > 0f ? party.Food : 0f, foodChange = party.FoodChangeExplained.ResultNumber;
                int daysUntilNoFood = MathF.Ceiling(MathF.Abs(totalFood / foodChange));

                MBTextManager.SetTextVariable("REMAINING_FOOD", daysUntilNoFood);
                MBTextManager.SetTextVariable("PLURAL", daysUntilNoFood > 1 ? 1 : 0);

                if (daysUntilNoFood <= 3 && daysUntilNoFood > 0)
                {
                    // Display a warning message when the player's party has less than or equal to 3 days of food left.
                    MBInformationManager.AddQuickInformation(new TextObject("Your party is low on food. You have {REMAINING_FOOD} {?PLURAL}days{?}day{\\?} until no food.", null), 0, null, "");
                }
            }
        }
    }
}
