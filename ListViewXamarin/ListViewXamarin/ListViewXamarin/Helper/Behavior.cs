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
    public class Behavior : Behavior <SfListView>
    {
        #region Fields
        ViewModel viewModel;
        ExtendedScrollView scrollview;
        double previousOffset;
        public SfListView listview { get; private set; }
        #endregion

        #region Overrides
        protected override void OnAttachedTo(SfListView bindable)
        {
            base.OnAttachedTo(bindable);
            listview = bindable as SfListView;
            viewModel = new ViewModel();
            listview.BindingContext = viewModel;
            scrollview = listview.GetScrollView();
            scrollview.Scrolled += Scrollview_Scrolled;
        }

        protected override void OnDetachingFrom(SfListView bindable)
        {
            base.OnDetachingFrom(bindable);
            scrollview.Scrolled -= Scrollview_Scrolled;
            scrollview = null;
            listview = null;
            viewModel = null;
        }
        #endregion

        #region Call back

        private void Scrollview_Scrolled(object sender, ScrolledEventArgs e)
        {
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
        #endregion
    }
}
