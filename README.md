# Status

![](https://github.com/AyronK/poe-commerce/workflows/Build/badge.svg?branch=develop)
![](https://github.com/AyronK/poe-commerce/workflows/Tests/badge.svg?branch=develop)

# Requirements
- .NET Core 3.1 preview
- npm

# Running on desktop
To build and run this application on desktop use `Electron.NET App` launch setting. It will bundle and host locally an electron application.
To publish PoE Commerce use the following command in client app directory:

```
electronize build /target win
electronize build /target osx
electronize build /target linux
```

Please notice that in the current state the application was tested only on Windows 10 x64.

# Running in browser
Once it can be difficult and time consuming to debug the application it's possible to run the program in browser. 
It does not require any further configuration, just run application with `PoECommerce.Client` launch setting.

  
---   


© 2019 Marcin kotlicki (@AyronK & @The-Wraeclast) All Rights Reserved
