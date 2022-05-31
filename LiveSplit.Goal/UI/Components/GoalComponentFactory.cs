using LiveSplit.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LiveSplit.UI.Components
{
    internal class GoalComponentFactory : IComponentFactory
    {
        public string ComponentName => "Goal";

        public string Description => "Calculate maximum timeloss to reach goal.";

        public ComponentCategory Category => ComponentCategory.Information;

        public string UpdateName => ComponentName;

        public string XMLURL => "";

        public string UpdateURL => "";

        public Version Version => Version.Parse("1.0.0");

        public IComponent Create(LiveSplitState state) => new GoalComponent(state);

    }
}
