using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;
using PowerPoint = Microsoft.Office.Interop.PowerPoint;
using Office = Microsoft.Office.Core;
using System.Windows;
using FSM;

namespace PPFSM
{
    /// <summary>
    /// Class to implement any powerpoint related operations.
    /// This is used to provide a wrapper layer if we need to upgrade anything when switching to Office 13/16/365.
    /// </summary>
    public class MyPowerPoint
    {
        /// <summary>
        /// Create new FSM Slide
        /// </summary>
        static public PowerPoint.Slide NewSlide()
        {
            var nextIndex = ThisAddIn.ActivePresentation.Slides.Count;
            var layout = ThisAddIn.ActivePresentation.Slides[1].CustomLayout;
            var newSlide = ThisAddIn.ActivePresentation.Slides.AddSlide(nextIndex, layout);
            return newSlide;
        }

        /// <summary>
        /// Get the currently active slide
        /// </summary>
        /// <returns></returns>
        static public PowerPoint.Slide GetCurrentSlide()
        {
            var slide = ThisAddIn.CurrentSlide;
            return slide;
        }

        /// <summary>
        /// Create a new instance of a rectangle.
        /// </summary>
        /// <returns></returns>
        static public PowerPoint.Shape NewRectangle(string name)
        {
            // TODO: Locate Initial shape
            // TODO: Initial Size
            var s = ThisAddIn.CurrentSlide.Shapes.AddShape(Microsoft.Office.Core.MsoAutoShapeType.msoShapeRoundedRectangle, 100, 100, 100, 100);
            
            // Name is displayed centered in the shape
            s.TextFrame.TextRange.Text = name;
            return s;
        }
    }
}
