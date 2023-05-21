﻿using System.Linq;
using NUnit.Framework;
using Terminal.Gui;
using TerminalGuiDesigner;
using TerminalGuiDesigner.Operations;

namespace UnitTests;

class ScrollViewTests : Tests
{
    [Test]
    public void TestRoundTrip_PreserveContentSize()
    {
        var scrollViewIn = this.RoundTrip<View, ScrollView>(
            (d, s) =>
                s.ContentSize = new Size(10, 5),
            out var scrollViewOut);

        Assert.AreNotSame(scrollViewOut, scrollViewIn);
        Assert.AreEqual(10, scrollViewIn.ContentSize.Width);
        Assert.AreEqual(5, scrollViewIn.ContentSize.Height);
    }

    [Test]
    public void TestRoundTrip_PreserveContentViews()
    {
        var scrollViewIn = this.RoundTrip<View, ScrollView>(
            (d, s) =>
                {
                    var op = new AddViewOperation(new Label("blarggg"), d, "myLbl");
                    op.Do();
                }, out _);

        var child = scrollViewIn.GetActualSubviews().Single();
        Assert.IsInstanceOf<Label>(child);
        Assert.IsInstanceOf<Design>(child.Data);

        var lblIn = (Design)child.Data;
        Assert.AreEqual("myLbl", lblIn.FieldName);
        Assert.AreEqual("blarggg", lblIn.View.Text.ToString());
    }

    [Test]
    public void TestRoundTrip_ScrollViewInsideTabView_PreserveContentViews()
    {
        var factory = new ViewFactory();
        var scrollOut = factory.Create(typeof(ScrollView));
        var buttonOut = factory.Create(typeof(Button));

        var tabIn = this.RoundTrip<View, TabView>(
            (d, tab) =>
                {
                    // Add a ScrollView to the first Tab
                    new AddViewOperation(scrollOut, d, "myTabView")
                    .Do();

                    // Add a Button to the ScrollView
                    new AddViewOperation(buttonOut, (Design)scrollOut.Data, "myButton")
                    .Do();
                }, out _);

        // The ScrollView should contain the Button
        Assert.Contains(buttonOut, scrollOut.GetActualSubviews().ToArray());

        // The TabView read back in should contain the ScrollView
        var scrollIn = tabIn.Tabs.First()
                .View.GetActualSubviews()
                .OfType<ScrollView>()
                .Single();

        var butttonIn = scrollIn.GetActualSubviews().Single();
        Assert.IsInstanceOf<Button>(butttonIn);
        Assert.AreNotSame(buttonOut, butttonIn);
    }
}
