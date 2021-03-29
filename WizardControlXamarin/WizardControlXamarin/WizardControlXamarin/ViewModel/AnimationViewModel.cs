using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using Syncfusion.SfRotator.XForms;
using Xamarin.Forms;
using Xamarin.Forms.Internals;

namespace WizardControlXamarin.ViewModel
{
    /// <summary>
    /// ViewModel for gradient page with animation.
    /// </summary>
    [Preserve(AllMembers = true)]
    public class AnimationViewModel : INotifyPropertyChanged
    {
        #region Fields

        private ObservableCollection<WizardPageModel> pageModels;


        private string nextButtonText = "NEXT";

        private bool isSkipButtonVisible = true;

        private int selectedIndex;

        public event PropertyChangedEventHandler PropertyChanged;

        #endregion

        #region Constructor

        /// <summary>
        /// Initializes a new instance for the <see cref="AnimationViewModel" /> class.
        /// </summary>
        public AnimationViewModel()
        {
            this.SkipCommand = new Command(this.Skip);
            this.NextCommand = new Command(this.Next);
            this.PageModels = new ObservableCollection<WizardPageModel>
            {
                new WizardPageModel()
                {
                    ImagePath = "ReSchedule.png",
                    Header = "RESCHEDULE",
                    Content = "Drag and drop meetings in order to reschedule them easily.",
                    RotatorItem = new WalkthroughItemPage()
                },
                new WizardPageModel()
                {
                    ImagePath = "ViewMode.png",
                    Header = "VIEW MODE",
                    Content = "Display your meetings using four configurable view modes",
                    RotatorItem = new WalkthroughItemPage()
                },
                new WizardPageModel()
                {
                    ImagePath = "TimeZone.png",
                    Header = "TIME ZONE",
                    Content = "Display meetings created for different time zones.",
                    RotatorItem = new WalkthroughItemPage()
                }
            };

            // Set bindingcontext to content view.
            foreach (var boarding in this.PageModels)
            {
                boarding.RotatorItem.BindingContext = boarding;
            }
        }

        #endregion

        #region Properties

        public ObservableCollection<WizardPageModel> PageModels
        {
            get
            {
                return this.pageModels;
            }

            set
            {
                if (this.pageModels == value)
                {
                    return;
                }

                this.pageModels = value;
                this.NotifyPropertyChanged();
            }
        }

        public string NextButtonText
        {
            get
            {
                return this.nextButtonText;
            }

            set
            {
                if (this.nextButtonText == value)
                {
                    return;
                }

                this.nextButtonText = value;
                this.NotifyPropertyChanged();
            }
        }

        public bool IsSkipButtonVisible
        {
            get
            {
                return this.isSkipButtonVisible;
            }

            set
            {
                if (this.isSkipButtonVisible == value)
                {
                    return;
                }

                this.isSkipButtonVisible = value;
                this.NotifyPropertyChanged();
            }
        }

        public int SelectedIndex
        {
            get
            {
                return this.selectedIndex;
            }

            set
            {
                if (this.selectedIndex == value)
                {
                    return;
                }

                this.selectedIndex = value;
                this.NotifyPropertyChanged();
            }
        }

        #endregion

        #region Commands

        /// <summary>
        /// Gets or sets the command that is executed when the Skip button is clicked.
        /// </summary>
        public ICommand SkipCommand { get; set; }

        /// <summary>
        /// Gets or sets the command that is executed when the Done button is clicked.
        /// </summary>
        public ICommand NextCommand { get; set; }

        #endregion

        #region Methods

        private bool ValidateAndUpdateSelectedIndex(int itemCount)
        {
            if (this.SelectedIndex >= itemCount - 1)
            {
                return true;
            }

            this.SelectedIndex++;
            return false;
        }

        /// <summary>
        /// Invoked when the Skip button is clicked.
        /// </summary>
        /// <param name="obj">The Object</param>
        private void Skip(object obj)
        {
            this.MoveToNextPage();
        }

        /// <summary>
        /// Invoked when the Done button is clicked.
        /// </summary>
        /// <param name="obj">The Object</param>
        private void Next(object obj)
        {
            var itemCount = (obj as SfRotator).ItemsSource.Count();
            if (this.ValidateAndUpdateSelectedIndex(itemCount))
            {
                this.MoveToNextPage();
            }
        }

        private void MoveToNextPage()
        {
            Application.Current.MainPage.Navigation.PopAsync();
        }

        /// <summary>
        /// The PropertyChanged event occurs when changing the value of property.
        /// </summary>
        /// <param name="propertyName">The PropertyName</param>
        protected void NotifyPropertyChanged([CallerMemberName] string propertyName = null)
        {
            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        #endregion
    }
}
