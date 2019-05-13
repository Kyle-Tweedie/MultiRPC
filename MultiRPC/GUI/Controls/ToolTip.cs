﻿using System.Windows;
using System.Windows.Media;
using System.Threading.Tasks;

namespace MultiRPC.GUI.Controls
{
    /// <summary>
    /// Edited Tooltip to have a string parameter, nothing special
    /// </summary>
    public class ToolTip : System.Windows.Controls.ToolTip
    {
        /// <summary>
        /// Tooltip with string parameter
        /// </summary>
        /// <param name="Text">Text to show on the tooltip</param>
        public ToolTip(string Text)
        {
            Content = Text;
            UISetup();
        }

        public async Task UISetup()
        {
            BorderThickness = new Thickness(1);
            SetResourceReference(BorderBrushProperty, "AccentColour1SCBrush");
            SetResourceReference(BackgroundProperty, "AccentColour2SCBrush");
        }

        public ToolTip()
        {
            UISetup();
        }
    }
}
