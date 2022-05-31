using LiveSplit.Model;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace LiveSplit.UI.Components
{
    public class GoalComponent : IComponent
    {

        protected InfoTextComponent InternalComponent { get; set; }

        public GoalComponentSettings Settings { get; set; }

        protected LiveSplitState CurrentState { get; set; }

        public string ComponentName => "Goal";

        public float HorizontalWidth => InternalComponent.HorizontalWidth;

        public float MinimumHeight => InternalComponent.MinimumHeight;

        public float VerticalHeight => InternalComponent.VerticalHeight;

        public float MinimumWidth => InternalComponent.MinimumWidth;

        public float PaddingTop => InternalComponent.PaddingTop;

        public float PaddingBottom => InternalComponent.PaddingBottom;

        public float PaddingLeft => InternalComponent.PaddingLeft;

        public float PaddingRight => InternalComponent.PaddingRight;

        public IDictionary<string, Action> ContextMenuControls => null;

        protected List<float> SplitTimelosses { get; set; }

        protected float CurrentSplitTimeloss { get; set; }

        public GoalComponent(LiveSplitState state)
        {

            Settings = new GoalComponentSettings()
            {
                CurrentState = state
            };

            InternalComponent = new InfoTextComponent("Goal (Split)", String.Format("{0}", CalculateSplitGoal(state)));

            state.OnStart += State_OnStart;
            state.OnSplit += State_OnSplit;
            state.OnSkipSplit += State_OnSkipSplit;
            state.OnUndoSplit += State_OnUndoSplit;
            state.OnReset += State_OnReset;
            CurrentState = state;

        }

        private void State_OnReset(object sender, TimerPhase value)
        {
            throw new NotImplementedException();
        }

        private void State_OnUndoSplit(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        private void State_OnSkipSplit(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        private void State_OnSplit(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        private void State_OnStart(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            CurrentState.OnStart -= State_OnStart;
            CurrentState.OnSplit -= State_OnSplit;
            CurrentState.OnSkipSplit -= State_OnSkipSplit;
            CurrentState.OnUndoSplit -= State_OnUndoSplit;
            CurrentState.OnReset -= State_OnReset;
        }

        public void PrepareDraw(LiveSplitState state, LayoutMode mode)
        {
            InternalComponent.NameLabel.HasShadow = InternalComponent.ValueLabel.HasShadow = state.LayoutSettings.DropShadows;
            InternalComponent.NameLabel.ForeColor = Settings.TextColor;
            InternalComponent.ValueLabel.ForeColor = Settings.TextColor;
        }

        public void DrawBackground(Graphics g, float width, float height)
        {

            var brush = new LinearGradientBrush(new PointF(0, 0), new PointF(0, height), Settings.BackgroundColor, Settings.BackgroundColor);
            g.FillRectangle(brush, 0, 0, width, height);

        }

        public void DrawHorizontal(Graphics g, LiveSplitState state, float height, Region clipRegion)
        {
            DrawBackground(g, HorizontalWidth, height);
            PrepareDraw(state, LayoutMode.Horizontal);
            InternalComponent.DrawHorizontal(g, state, height, clipRegion);
        }

        public void DrawVertical(Graphics g, LiveSplitState state, float width, Region clipRegion)
        {
            DrawBackground(g, width, VerticalHeight);
            PrepareDraw(state, LayoutMode.Vertical);
            InternalComponent.DrawVertical(g, state, width, clipRegion);
        }

        public int GetSettingsHashCode() => Settings.GetSettingsHashCode();

        public XmlNode GetSettings(XmlDocument document) => Settings.GetSettings(document);

        public void SetSettings(XmlNode settings)
        {
            Settings.SetSettings(settings);
        }

        public System.Windows.Forms.Control GetSettingsControl(LayoutMode mode)
        {
            Settings.Mode = mode;
            return Settings;
        }

        public void Update(IInvalidator invalidator, LiveSplitState state, float width, float height, LayoutMode mode)
        {
            
        }

    }
}
