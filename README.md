# Create a Wizard View in Xamarin.Forms

This repository showcases the creation of Wizard View in Xamarin.Forms with the help of a Rotator control.

1.   Follow the Getting Started with Xamarin Rotator Control documentation to add a Xamarin.Forms SfRotator control to your application.
2.  Let’s initialize the Rotator control and set the following necessary properties based on the UI requirements:

    *  Set the DotPlacement property as none and the NavigationDirection property as horizontal.
    *   Then, enable the swiping gesture in the Rotator control by setting the EnableSwiping property as True and disable looping by setting the EnableLooping property as False.

Refer to the following code example.

```
<sfRotator:SfRotator x:Name="Rotator"
                       BackgroundColor="Transparent"
                       DotPlacement="None"
                       EnableLooping="False"
                       EnableSwiping="True"
                       NavigationDirection="Horizontal" >
```
3.  In this walk-through, I’m going to load a Scalable Vector Graphics (SVG) image. Create a DataTemplate with an SVG image and two labels for the header and content of the page. Then, assign the DataTemplate to the ItemTemplate property of the Xamarin Rotator control.Refer to the following code example.

```
<sfRotator:SfRotator.ItemTemplate>
    <DataTemplate>
        <StackLayout BackgroundColor="Transparent"
                     Spacing="0"
                     VerticalOptions="Center">

            <!-- Image for display svg image -->
            <svg:SVGImage BackgroundColor="Transparent"
                          Source ="{Binding ImagePath}"
                          VerticalOptions="Center" />

            <!-- Label to display header -->
            <Label FontFamily="{StaticResource Montserrat-SemiBold}"
                   FontSize="20"
                   HorizontalTextAlignment="Center"
                   Text="{Binding Header}"
                   VerticalTextAlignment="Center" />

            <!-- Label to display content -->
            <Label FontFamily="{StaticResource Montserrat-Medium}"
                   FontSize="16"
                   Text="{Binding Content}"
                   VerticalTextAlignment="Center" />
        </StackLayout>
    </DataTemplate>
</sfRotator:SfRotator.ItemTemplate>
```
4.  Then, create a model class with the required properties for the page

```
public class PageModel
{ 
#region Properties

    /// <summary>
    /// Gets or sets the image.
    /// </summary>
    public string ImagePath { get; set; }

    /// <summary>
    /// Gets or sets the header.
    /// </summary>
    public string Header { get; set; }

    /// <summary>
    /// Gets or sets the content.
    /// </summary>
    public string Content { get; set; }

    /// <summary>
    /// Gets or sets the view.
    /// </summary>
    public View RotatorItem { get; set; }

#endregion
}
```
5.  Now, create a ViewModel class containing the business logic for the wizard control.
```
public class PageViewModel 
{
#region Fields

private ObservableCollection<PageModel> pages;

#endregion

#region Constructor

/// <summary>
/// Initializes a new instance for the <see cref=" PageViewModel " /> class.
/// </summary>
public PageViewModel ()
{
    this.Pages= new ObservableCollection<PageModel>
    {
        new PageModel()
        {
            ImagePath = "ReSchedule.png",
            Header = "RESCHEDULE",
            Content = "Drag and drop meetings in order to reschedule them easily.",
            RotatorItem = new WalkthroughItemPage()
        },
        new Boarding()
        {
            ImagePath = "ViewMode.png",
            Header = "VIEW MODE",
            Content = "Display your meetings using four configurable view modes",
            RotatorItem = new WalkthroughItemPage()
        },
        new Boarding()
        {
            ImagePath = "TimeZone.png",
            Header = "TIME ZONE",
            Content = "Display meetings created for different time zones.",
            RotatorItem = new WalkthroughItemPage()
        }
    };

}

#endregion

#region Properties

public ObservableCollection<PageModel> Pages
{
    get
    {
        return this.pages;
    }
    set
    {
        if (this.pages== value)
        {
            return;
        }

        this.pages= value;
        this.NotifyPropertyChanged();
    }
}

#endregion
```
6.  Finally, assign the Pages property of the ViewModel to the ItemsSource property of the Rotator control.

```
<sfRotator:SfRotator
         x:Name="Rotator"
           DotPlacement="None"
           EnableLooping="False"
           EnableSwiping="True"
           ItemsSource="{Binding Boardings}"
           NavigationDirection="Horizontal"
           SelectedIndex="{Binding SelectedIndex, Mode=TwoWay}">
 
    <sfRotator:SfRotator.ItemTemplate>
       <DataTemplate>
          <StackLayout>
 
            <!--  Image for display svg image  -->
            <svg:SVGImage BackgroundColor="Transparent"                               
                  Source ="{Binding ImagePath}" />
 
             <!--  Label to display header  -->
             <Label Text="{Binding Header}" />
 
             <!--  Label to display content  -->
             <Label Text="{Binding Content}" />
         </StackLayout>
      </DataTemplate>
   </sfRotator:SfRotator.ItemTemplate>
 </sfRotator:SfRotator>
 ```