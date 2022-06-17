using System;
using TaleWorlds.CampaignSystem;
using TaleWorlds.CampaignSystem.CampaignBehaviors;
using TaleWorlds.CampaignSystem.Party;
using TaleWorlds.Core;
using TaleWorlds.Localization;

namespace PartyLowFood
{
    public class PartyLowFoodBehavior : FoodConsumptionBehavior
    {
        public override void RegisterEvents() => CampaignEvents.DailyTickPartyEvent.AddNonSerializedListener(this, new Action<MobileParty>(OnDailyTickParty));

        // Display a warning message when the player's party has less than or equal to 3 days of food left.
        private void OnDailyTickParty(MobileParty party)
        {
            if (party.IsMainParty)
            {
                float num = (party.Food > 0f) ? party.Food : 0f;
                int num2 = (int)Math.Ceiling(Math.Abs(num / party.FoodChange));
                MBTextManager.SetTextVariable("REMAINING_FOOD", num2);
                MBTextManager.SetTextVariable("PLURAL", (num2 > 1) ? 1 : 0);
                if (num2 <= 3 && num2 > 0)
                {
                    MBInformationManager.AddQuickInformation(new TextObject("Your party is low on food. You have {REMAINING_FOOD} {?PLURAL}days{?}day{\\?} until no food.", null), 0, null, "");
                }
            }
        }
    }
}
