using System;
using System.Collections.Generic;
using System.Globalization;
using Xamarin.Forms;
using Xamarin.Forms.GoogleMaps;
using Xamarin.Forms.Internals;

namespace Xam.Plugin.SimpleStaticMap
{
    /// <summary>
    /// Bindable static map image control
    /// </summary>
    [Preserve(AllMembers = true)]
    public class StaticMap : Image
    {
        #region Variables

        /// <summary>
        /// Bindable property for the <see cref="Pins"/> property
        /// </summary>
        public static readonly BindableProperty PinsProperty = BindableProperty.Create(nameof(Pins), typeof(IEnumerable<(Pin Pin, string Color)>), typeof(StaticMap), propertyChanged: OnPropertyChanged);

        /// <summary>
        /// Bindable property for the <see cref="Polylines"/> property
        /// </summary>
        public static readonly BindableProperty PolylinesProperty = BindableProperty.Create(nameof(Polylines), typeof(IEnumerable<(string EncodedString, string Color)>), typeof(StaticMap), null, propertyChanged: OnPropertyChanged);

        /// <summary>
        /// Bindable property for the <see cref="ApiKey"/> property
        /// </summary>
        public static readonly BindableProperty ApiKeyProperty = BindableProperty.Create(nameof(ApiKey), typeof(string), typeof(StaticMap), null, propertyChanged: OnPropertyChanged);

        /// <summary>
        /// Bindable property for the <see cref="Zoom"/> property
        /// </summary>
        public static readonly BindableProperty ZoomProperty = BindableProperty.Create(nameof(Zoom), typeof(int?), typeof(StaticMap), null, propertyChanged: OnPropertyChanged);

        /// <summary>
        /// Bindable property for the <see cref="CachingEnabled"/> property
        /// </summary>
        public static readonly BindableProperty CachingEnabledProperty = BindableProperty.Create(nameof(CachingEnabled), typeof(bool), typeof(StaticMap), false, propertyChanged: OnPropertyChanged);

        #endregion

        #region Constructor

        /// <summary>
        /// Constructor
        /// </summary>
        public StaticMap()
        { }

        #endregion

        #region Properties

        /// <summary>
        /// Pins
        /// </summary>
        public IEnumerable<(Pin Pin, string Color)> Pins
        {
            get => (IEnumerable<(Pin Pin, string Color)>)GetValue(PinsProperty);
            set => SetValue(PinsProperty, value);
        }

        /// <summary>
        /// Polylines
        /// </summary>
        public IEnumerable<(string EncodedString, string Color)> Polylines
        {
            get => (IEnumerable<(string EncodedString, string Color)>)GetValue(PolylinesProperty);
            set => SetValue(PolylinesProperty, value);
        }

        /// <summary>
        /// ApiKey
        /// </summary>
        public string ApiKey
        {
            get => (string)GetValue(ApiKeyProperty);
            set => SetValue(ApiKeyProperty, value);
        }

        /// <summary>
        /// Zoom level
        /// </summary>
        public int? Zoom
        {
            get => (int?)GetValue(ZoomProperty);
            set => SetValue(ZoomProperty, value);
        }

        /// <summary>
        /// Is caching enabled
        /// </summary>
        public bool CachingEnabled
        {
            get => (bool)GetValue(CachingEnabledProperty);
            set => SetValue(CachingEnabledProperty, value);
        }

        #endregion

        #region Protected

        /// <summary>
        /// New size allocated, we need to update the camera on the map (if applicable)
        /// </summary>
        /// <param name="width">width</param>
        /// <param name="height">height</param>
        protected override void OnSizeAllocated(double width, double height)
        {
            base.OnSizeAllocated(width, height);
            SetImageSource();
        }

        #endregion


        #region Private

        /// <summary>
        /// Handle the change a property
        /// </summary>
        /// <param name="bindable">Bindable object</param>
        /// <param name="o">Old values</param>
        /// <param name="n">New values</param>
        private static void OnPropertyChanged(BindableObject bindable, object o, object n)
        {
            if (!(bindable is StaticMap map))
                return;
            map.SetImageSource();
        }

        /// <summary>
        /// Set the image source
        /// </summary>
        private void SetImageSource()
        {
            if (Width < 1 || Height < 1)
                return;
            var url = $"https://maps.google.com/maps/api/staticmap?size={Convert.ToInt32(Width)}x{Convert.ToInt32(Height)}&scale=2";
            if (Zoom.HasValue)
                url += $"&zoom={Zoom}";
            url += $"&language={CultureInfo.CurrentCulture.TwoLetterISOLanguageName}";
            if (Pins != null)
            {
                foreach (var pin in Pins)
                {
                    url += !string.IsNullOrEmpty(pin.Color) ?
                       $"&markers=color:0x{pin.Color.Replace("#", "")}|{pin.Pin.Position.Latitude},{pin.Pin.Position.Longitude}" :
                       $"&markers={pin.Pin.Position.Latitude},{pin.Pin.Position.Longitude}";
                }
            }
            if (Polylines != null)
            {
                foreach (var polyline in Polylines)
                {
                    url += !string.IsNullOrEmpty(polyline.Color) ?
                         $"&path=color:0x{polyline.Color.Replace("#", "")}|enc:{polyline.EncodedString}" :
                         $"&path=enc:{polyline.EncodedString}";
                }
            }
            url += $"&key={ApiKey}";
            Source = new UriImageSource
            {
                Uri = new Uri(url),
                CachingEnabled = CachingEnabled
            };
        }

        #endregion
    }
}
