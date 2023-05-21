using System.IO;
using NUnit.Framework;
using Terminal.Gui;
using TerminalGuiDesigner;
using TerminalGuiDesigner.UI;

namespace UnitTests;

internal class KeyboardManagerTests : Tests
{
    [Test]
    public void Backspace_WithDateFieldSelected()
    {
        var vf = new ViewFactory();
        var v = vf.Create(typeof(DateField));
        var d = new Design(new SourceCodeFile(new FileInfo("ff.cs")), "ff", v);
        v.Data = d;

        var mgr = new KeyboardManager(new KeyMap());
        Assert.IsFalse(mgr.HandleKey(v, new KeyEvent(Key.Backspace, new KeyModifiers())));
        
        Application.Top.Add(v);
        v.Redraw(v.Bounds = new Rect(0, 0, 6, 1));
    }

    [Test]
    public void ButtonRename()
    {
        var vf = new ViewFactory();
        var v = (Button)vf.Create(typeof(Button));
        var d = new Design(new SourceCodeFile(new FileInfo("ff.cs")), "ff", v);
        v.Data = d;

        var mgr = new KeyboardManager(new KeyMap());
        mgr.HandleKey(v, new KeyEvent(Key.Backspace, new KeyModifiers()));
        mgr.HandleKey(v, new KeyEvent(Key.Backspace, new KeyModifiers()));
        mgr.HandleKey(v, new KeyEvent(Key.Backspace, new KeyModifiers()));
        mgr.HandleKey(v, new KeyEvent(Key.Backspace, new KeyModifiers()));
        mgr.HandleKey(v, new KeyEvent(Key.Backspace, new KeyModifiers()));
        mgr.HandleKey(v, new KeyEvent(Key.Backspace, new KeyModifiers()));
        mgr.HandleKey(v, new KeyEvent(Key.Backspace, new KeyModifiers()));
        mgr.HandleKey(v, new KeyEvent(Key.Backspace, new KeyModifiers()));

        Assert.IsTrue(string.IsNullOrWhiteSpace(v.Text.ToString()));

        mgr.HandleKey(v, new KeyEvent(Key.B, new KeyModifiers { Shift = true }));
        mgr.HandleKey(v, new KeyEvent((Key)'a', new KeyModifiers()));
        mgr.HandleKey(v, new KeyEvent((Key)'d', new KeyModifiers()));

        Assert.AreEqual("Bad", v.Text.ToString());

        mgr.HandleKey(v, new KeyEvent(Key.Backspace, new KeyModifiers()));
        mgr.HandleKey(v, new KeyEvent(Key.Backspace, new KeyModifiers()));

        Assert.AreEqual("B", v.Text.ToString());
    }
}