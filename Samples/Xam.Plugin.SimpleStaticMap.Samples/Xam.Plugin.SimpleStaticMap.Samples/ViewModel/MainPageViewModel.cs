using System.Collections.Generic;
using Xam.Plugin.SimpleStaticMap.Samples.Helpers;
using Xamarin.Forms.GoogleMaps;

namespace Xam.Plugin.SimpleStaticMap.Samples.ViewModel
{
    /// <summary>
    /// View model to demonstrate the <see cref="StaticMap"/> control
    /// </summary>
    public class MainPageViewModel : ObservableObject
    {
        #region Variables

        /// <summary>
        /// List of pins
        /// </summary>
        private List<(Pin Pin, string Color)> _Pins;

        /// <summary>
        /// List of polylines
        /// </summary>
        private List<(string encodedPolyline, string Color)> _Polylines;

        #endregion

        #region Constructor & Destructor

        /// <summary>
        /// Default constructor
        /// </summary>
        public MainPageViewModel()
        {
            Pins = new List<(Pin Pin, string Color)>()
            {
                (new Pin() {Position = new Position(52.384150, 4.629128) }, null),
                (new Pin() {Position = new Position(52.355641, 4.873406) }, "#F8B711"),
                (new Pin() {Position = new Position(52.093092, 5.093924) }, null)
            };
            Polylines = new List<(string polyline, string Color)>()
            {
                ("}gv~Hacg[dqDwun@|gr@eaj@", "#003153")
            };
        }

        #endregion

        #region Properties

        /// <summary>
        /// Show different pins
        /// </summary>
        public List<(Pin Pin, string Color)> Pins
        {
            get => _Pins; private set
            {
                SetProperty(ref _Pins, value);
            }
        }

        /// <summary>
        /// Show polylines
        /// </summary>
        public List<(string encodedPolyline, string Color)> Polylines
        {
            get => _Polylines; private set
            {
                SetProperty(ref _Polylines, value);
            }
        }

        #endregion
    }
}

