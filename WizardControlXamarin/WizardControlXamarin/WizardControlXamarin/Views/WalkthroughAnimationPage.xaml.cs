using Xamarin.Forms;
using Xamarin.Forms.Internals;
using Xamarin.Forms.Xaml;

namespace WizardControlXamarin
{
    /// <summary>
    /// Page to display on-boarding gradient with animation
    /// </summary>
    [Preserve(AllMembers = true)]
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class WalkthroughAnimationPage
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="WalkthroughAnimationPage" /> class.
        /// </summary>
        public WalkthroughAnimationPage()
        {
            InitializeComponent();
        }
    }
}