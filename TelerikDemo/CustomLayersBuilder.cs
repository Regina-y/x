using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telerik.WinControls.Export;
using Telerik.WinControls.RichTextEditor.UI;
using Telerik.WinForms.Documents.UI;
using Telerik.WinForms.Documents.UI.Layers;

namespace TelerikDemo
{
    public class CustomLayersBuilder: UILayersBuilder
    {
        protected override void BuildUILayersOverride(IUILayerContainer uiLayerContainer)
        {
            uiLayerContainer.UILayers.AddAfter(DefaultUILayers.TableRowBordersResizeLayer, new CustomDecorationUILayerBase());
        }
    }

    public class CustomDecorationUILayerBase : IUILayer
    {
        public bool IsHitTestVisible { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public string Name => throw new NotImplementedException();

        public bool ShouldUpdateWhenNotInvalidated => throw new NotImplementedException();

        public bool ShouldClip => throw new NotImplementedException();

        public void ArrangeChildren()
        {
            throw new NotImplementedException();
        }

        public void ClearChildren()
        {
            throw new NotImplementedException();
        }

        public void DoOnPresentationChanged()
        {
            throw new NotImplementedException();
        }

        public UIElement GetLayerUIElement()
        {
            throw new NotImplementedException();
        }

        public void UpdateViewPort(UILayerUpdateContext context)
        {
            throw new NotImplementedException();
        }
    }

    public class painter : IPaintingContext
    {
        public painter(Graphics g)
        {
            graphics = g;
        }

        private Graphics graphics = null;

        public RectangleF ClipBounds => throw new NotImplementedException();

        public SizeF ScaleFactor => throw new NotImplementedException();

        public void DrawEllipse(RectangleF rectangle, Pen pen)
        {
            throw new NotImplementedException();
        }

        public void DrawImage(System.Drawing.Image image, RectangleF rectangle, double opacity)
        {
            throw new NotImplementedException();
        }

        public void DrawLine(PointF startPoint, PointF endPoint, Pen pen)
        {
            graphics.DrawLine(pen, startPoint, endPoint);
        }

        public void DrawLines(PointF[] pointF, Pen pen)
        {
            throw new NotImplementedException();
        }

        public void DrawPath(PointF[] pointF, Pen pen)
        {
            throw new NotImplementedException();
        }

        public void DrawPolygon(PointF[] pointF, Pen pen)
        {
            throw new NotImplementedException();
        }

        public void DrawRectangle(RectangleF rectangle, Pen pen)
        {
            throw new NotImplementedException();
        }

        public void FillEllipse(RectangleF rectangle, Brush brush)
        {
            throw new NotImplementedException();
        }

        public void FillPolygon(PointF[] pointF, Brush brush)
        {
            throw new NotImplementedException();
        }

        public void FillRectangle(RectangleF rectangle, Brush brush)
        {
            throw new NotImplementedException();
        }

        public void InvertRectangle(RectangleF rectangle)
        {
            throw new NotImplementedException();
        }

        public void ResetTransformation()
        {
            throw new NotImplementedException();
        }

        public void ScaleTransformation(float x, float y)
        {
            throw new NotImplementedException();
        }
    }
}
