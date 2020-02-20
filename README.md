# how-to-detect-xamarin.forms-listview-scrolling-direction
ListView allows you to find the scrolling direction. You can find the scrolling direction in Xamarin.Forms ListView by using the Scrolled event of ScollView.

### Xaml

```xml
<ContentPage xmlns:syncfusion="clr-namespace:Syncfusion.ListView.XForms;assembly=Syncfusion.SfListView.XForms">
    <syncfusion:SfListView x:Name="listView" 
                           ItemsSource="{Binding ContactsInfo}"
                           IsStickyHeader="True"
                           ItemSize="70">
        <syncfusion:SfListView.Behaviors>
            <local:Behavior/>
        </syncfusion:SfListView.Behaviors>
        <syncfusion:SfListView.HeaderTemplate>
            <DataTemplate>
                <Label Text="{Binding ScrollDirection}" />
            </DataTemplate>
        </syncfusion:SfListView.HeaderTemplate>
        <syncfusion:SfListView.ItemTemplate>
            <DataTemplate>
                <Grid>
                    <Image Source="{Binding ContactImage}" 
                           Aspect="AspectFill"/>
                    <Label LineBreakMode="NoWrap"
                           Text="{Binding ContactName}"/>
                    <Label LineBreakMode="NoWrap"
                           Text="{Binding ContactNumber}"/>
                    <Label LineBreakMode="NoWrap"
                           Text="{Binding ContactType}"/>
                </Grid>
            </DataTemplate>
        </syncfusion:SfListView.ItemTemplate>
    </syncfusion:SfListView>
</ContentPage>
```
### C#

```c#
container = listview.GetVisualContainer();
scrollview = listview.GetScrollView();
scrollview.Scrolled += Scrollview_Scrolled;

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
```
### Output

![ScrollingDirection](https://github.com/SyncfusionExamples/how-to-detect-list-view-scrolling-direction-in-xamarin-forms/tree/master/Screenshots/ScrollingDirection.gif) 

