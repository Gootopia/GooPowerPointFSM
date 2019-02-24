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
            var s = ThisAddIn.CurrentSlide.Shapes.AddShape(Microsoft.Office.Core.MsoAutoShapeType.msoShapeRoundedRectangle, 100, 100, 100, 50);
            
            // Name is displayed centered in the shape
            s.TextFrame.TextRange.Text = name;
            s.Name = name;
            return s;
        }

        /// <summary>
        /// Create a new instance of a curved connector with an arrow at one end
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        static public PowerPoint.Shape NewConnector(string name)
        {
            Microsoft.Office.Interop.PowerPoint.Shape conn = ThisAddIn.CurrentSlide.Shapes.AddConnector(Microsoft.Office.Core.MsoConnectorType.msoConnectorCurve, 0, 0, 0, 0);
            conn.Line.EndArrowheadStyle = Microsoft.Office.Core.MsoArrowheadStyle.msoArrowheadTriangle;
            conn.Line.EndArrowheadWidth = Microsoft.Office.Core.MsoArrowheadWidth.msoArrowheadWide;
            conn.Line.EndArrowheadLength = Microsoft.Office.Core.MsoArrowheadLength.msoArrowheadLong;
            return conn;
        }

        /// <summary>
        /// Create a text block for use as a transition label
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        static public PowerPoint.Shape NewText(string name, float left, float top, float width, float height)
        {
            PowerPoint.Shape text = ThisAddIn.CurrentSlide.Shapes.AddLabel(Office.MsoTextOrientation.msoTextOrientationHorizontal, left, top, width, height);
            text.Name = name;
            text.TextFrame.TextRange.Text = name;
            text.TextFrame.TextRange.Font.Italic = Office.MsoTriState.msoCTrue;
            text.TextFrame.TextRange.Font.Size = 10;
            return text;
        }

        /// <summary>
        /// Get collection of slide tags
        /// </summary>
        /// <returns></returns>
        static public PowerPoint.Tags GetCurrentSlideTags()
        {
            var slide = GetCurrentSlide();
            return slide.Tags;
        }
    }
}
