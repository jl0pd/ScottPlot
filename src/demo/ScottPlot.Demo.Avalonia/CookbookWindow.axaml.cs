﻿using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using System.Diagnostics;

namespace ScottPlot.Demo.Avalonia
{
    public class CookbookWindow : Window
    {
        public CookbookWindow()
        {
            this.InitializeComponent();
            LoadTreeWithDemos();
#if DEBUG
            this.AttachDevTools();
#endif

            var demoTreeview = this.Find<TreeView>("DemoTreeview");
            demoTreeview.SelectionChanged += DemoSelected;
        }

        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);
        }

        private void DemoSelected(object sender, SelectionChangedEventArgs e)
        {
            TreeView DemoTreeview = this.Find<TreeView>("DemoTreeview");
            CookbookControl DemoPlotControl1 = this.Find<CookbookControl>("DemoPlotControl1");
            var AboutControl1 = this.Find<AboutControl>("AboutControl1");

            var selectedDemoItem = (Cookbook.TreeNode)DemoTreeview.SelectedItem;
            if (selectedDemoItem.ID != null)
            {
                DemoPlotControl1.IsVisible = true;
                AboutControl1.IsVisible = false;
                DemoPlotControl1.LoadDemo(selectedDemoItem.ID);
            }
            else
            {
                DemoPlotControl1.IsVisible = false;
                AboutControl1.IsVisible = true;
            }
        }

        private void LoadTreeWithDemos()
        {
            TreeView DemoTreeview = this.Find<TreeView>("DemoTreeview");
            var demos = Cookbook.Tree.GetRecipes();
            DemoTreeview.Items = demos;

            CookbookControl DemoPlotControl1 = this.Find<CookbookControl>("DemoPlotControl1");
            var AboutControl1 = this.Find<AboutControl>("AboutControl1");
            DemoPlotControl1.IsVisible = true;
            AboutControl1.IsVisible = false;
            DemoPlotControl1.LoadDemo(demos[0].Items[0].ID);
        }
    }
}
