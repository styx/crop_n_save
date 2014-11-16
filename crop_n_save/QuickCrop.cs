//The MIT License (MIT)

//Copyright (c) <2014> <Mikhail S. Pobolovets>

//Permission is hereby granted, free of charge, to any person obtaining a copy
//of this software and associated documentation files (the "Software"), to deal
//in the Software without restriction, including without limitation the rights
//to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
//copies of the Software, and to permit persons to whom the Software is
//furnished to do so, subject to the following conditions:

//The above copyright notice and this permission notice shall be included in
//all copies or substantial portions of the Software.

//THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
//IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
//FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
//AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
//LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
//OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN
//THE SOFTWARE.

using Cairo;
using Gdk;
using Gtk;
using Pinta.Core;
using System;
using Action = Gtk.Action;

namespace PintaQuickCrop
{
    [Mono.Addins.Extension]
    public class QuickCropExtension : IExtension
    {
        private readonly Widget _menuItem;
        private const String Quality = "95";
        private readonly QuickSaver _quickSaver = new QuickSaver();

        #region IExtension Members
        public void Initialize()
        {
            PintaCore.Actions.Addins.AddMenuItem(_menuItem);
        }

        public void Uninitialize()
        {
            PintaCore.Actions.Addins.RemoveMenuItem(_menuItem);
        }
        #endregion

        public QuickCropExtension()
        {
            var menuAction = new Action(
                "quickcrop",
                "Quick Crop",
                "Saves selected area with autogenerated name",
                Stock.SaveAs);

            menuAction.Activated += (sender, e) => CropAndSave();
            _menuItem = menuAction.
                CreateAcceleratedMenuItem(Gdk.Key.Q, ModifierType.None);
        }

        public void CropAndSave ()
        {
            var doc = PintaCore.Workspace.ActiveDocument;

            using (var src = doc.GetFlattenedImage()) {
                var rect = doc.GetSelectedBounds (true);
                using (var dest = new ImageSurface(Format.Argb32, rect.Width, rect.Height)) {
                    using (var g = new Context(dest)) {
                        g.SetSourceSurface (src, -rect.X, -rect.Y);
                        g.Paint ();
                    }

                    // Save
                    var pb = dest.ToPixbuf ();
                    _quickSaver.Save (pb);

                    ((IDisposable)pb).Dispose ();
                }
            }
        }

    }
}