
namespace AppCoreV1.ABLEModels
{
    public partial class TabCMP
    {
        public List<ClientGoalEx>? clientgoal { get; set; }
        public List<GoalEx>? goals { get; set; }
        public List<ActionAEx>? actions { get; set; }
        public List<LifeAreaEx>? factors { get; set; }
        public List<ActionHistoryEx>? history { get; set; }

    }
}
