[![Nuget](https://img.shields.io/nuget/v/Xam.Plugin.SimpleStaticMap)](https://www.nuget.org/packages/Xam.Plugin.SimpleStaticMap) ![Nuget](https://img.shields.io/nuget/dt/Xam.Plugin.SimpleStaticMap)

![Icon](https://raw.githubusercontent.com/galadril/Xam.Plugin.SimpleStaticMap/master/Samples/Xam.Plugin.SimpleStaticMap.Samples/Xam.Plugin.SimpleStaticMap.Samples.Android/Resources/mipmap-xxhdpi/ic_launcher.png)

# Xam.Plugin.SimpleStaticMap
Just a nice and simple static map for your Xamarin Forms project. It uses the static api from GoogleMaps to show a static map image;


# Setup
* Available on Nuget:
https://www.nuget.org/packages/Xam.Plugin.SimpleStaticMap

!!Install into your .net standard Forms project. !!


# Usage
You can now use the StaticMap To generate a nice looking image of a map with pins and polylines

```

    <controls:StaticMap
            x:Name="map"
            ApiKey="SET YOUR APIKEY HERE"
            Aspect="AspectFill"
            HorizontalOptions="FillAndExpand"
            IsVisible="true"
            Pins="{Binding Pins}"
            Polylines="{Binding Polylines}"
            VerticalOptions="FillAndExpand"
            Zoom="6" />

```


(see sample project for more info)

