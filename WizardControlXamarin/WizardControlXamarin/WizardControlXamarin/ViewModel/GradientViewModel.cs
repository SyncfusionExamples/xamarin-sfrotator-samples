using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using Xamarin.Forms;
using Xamarin.Forms.Internals;

namespace WizardControlXamarin.ViewModel
{
    /// <summary>
    /// ViewModel for gradient page.
    /// </summary>
    [Preserve(AllMembers = true)]
    public class GradientViewModel : INotifyPropertyChanged
    {
        #region Fields

        private ObservableCollection<WizardPageModel> pageModels;

        private string nextButtonText = "NEXT";

        private bool isSkipButtonVisible = true;

        private int selectedIndex;

        #endregion

        #region Constructor

        /// <summary>
        /// Initializes a new instance for the <see cref="GradientViewModel" /> class.
        /// </summary>
        public GradientViewModel()
        {
            this.PageModels = new ObservableCollection<WizardPageModel>
            {
                new WizardPageModel
                {
                    ImagePath = "ChooseGradient.svg",
                    Header = "CHOOSE",
                    Content = "Pick the item that is right for you"
                },
                new WizardPageModel
                {
                    ImagePath = "ConfirmGradient.svg",
                    Header = "ORDER CONFIRMED",
                    Content = "Your order is confirmed and will be on its way soon"
                },
                new WizardPageModel
                {
                    ImagePath = "DeliverGradient.svg",
                    Header = "DELIVERY",
                    Content = "Your item will arrive soon. Email us if you have any issues"
                }
            };

            this.SkipCommand = new Command(this.Skip);
            this.NextCommand = new Command(this.Next);
        }

        #endregion
        
        #region Events

        /// <summary>
        /// The declaration of the property changed event.
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;

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
        
        #region Properties

        /// <summary>
        /// Gets or sets the boardings collection.
        /// </summary>
        public ObservableCollection<WizardPageModel> PageModels
        {
            get
            {
                return this.pageModels;
            }

            set
            {
                this.pageModels = value;
                this.OnPropertyChanged();
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
                this.OnPropertyChanged();
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
                this.OnPropertyChanged();
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
                this.OnPropertyChanged();
                this.ValidateSelection();
            }
        }

        #endregion

        #region Methods

        /// <summary>
        /// The PropertyChanged event occurs when changing the value of property.
        /// </summary>
        /// <param name="propertyName">Property name</param>
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private bool ValidateAndUpdateSelectedIndex()
        {
            if (this.selectedIndex >= this.PageModels.Count - 1)
            {
                return true;
            }

            this.SelectedIndex++;
            return false;
        }

        private void ValidateSelection()
        {
            if (this.selectedIndex < this.PageModels.Count - 1)
            {
                this.IsSkipButtonVisible = true;
                this.NextButtonText = "NEXT";
            }
            else
            {
                this.NextButtonText = "DONE";
                this.IsSkipButtonVisible = false;
            }
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
            if (this.ValidateAndUpdateSelectedIndex())
            {
                Application.Current.MainPage.Navigation.PopAsync();
                this.MoveToNextPage();
            }
        }

        private void MoveToNextPage()
        {
            // Move to next page
        }

        #endregion
    }
}