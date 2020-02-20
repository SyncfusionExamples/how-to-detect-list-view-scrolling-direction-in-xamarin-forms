using Syncfusion.ListView.XForms;
using Syncfusion.ListView.XForms.Control.Helpers;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Text;
using Xamarin.Forms;

namespace ListViewXamarin
{
    class Behavior : Behavior <SfListView>
    {
        ViewModel viewModel;
        VisualContainer container;
        ExtendedScrollView scrollview;
        double scrollOffet;
        double previousOffset;
        public SfListView listview { get; private set; }
        protected override void OnAttachedTo(SfListView bindable)
        {
            base.OnAttachedTo(bindable);
            listview = bindable as SfListView;
            viewModel = new ViewModel();
            listview.BindingContext = viewModel;
            container = listview.GetVisualContainer();
            scrollview = listview.GetScrollView();
            scrollview.Scrolled += Scrollview_Scrolled;
        }

        private void Scrollview_Scrolled(object sender, ScrolledEventArgs e)
        {
            scrollOffet = (double)container.GetType().GetRuntimeProperties().First(p => p.Name == "ScrollOffset").GetValue(container);
            if (e.ScrollY == 0)
                return;

            if (previousOffset >= e.ScrollY)
            {
                // Up direction  
                viewModel.ScrollDirection = "Up Direction";
            }
            else
            {
                //Down direction 
                viewModel.ScrollDirection = "Down Direction";
            }

            previousOffset = e.ScrollY;
        }

        protected override void OnDetachingFrom(SfListView bindable)
        {
            base.OnDetachingFrom(bindable);
            scrollview.Scrolled -= Scrollview_Scrolled;
            container = null;
            scrollview = null;
            listview = null;
        }
    }
}
