# Scriptable Framework

In this repository you will find the source code, assets and project settings of the Scriptable Console for Unity app development (Unity 2019.3.0 or newer recommended) along with a DocFX project containing documentation assets and articles.

---

## How To Install

In order to install Scriptable Console in your project, add the following to the top of your manifest.json file right before the dependencies object. Next, save the file and restart the editor. You should then find the package in the package manager UI which can be installed like any other Unity package. You can even view a list of all previous versions of the package that are available in the registry.

``` js
"scopedRegistries": [
    {
        "name": "Open Source Packages",
        "url": "http://35.227.114.200:8080",
        "scopes": [
            "com.open"
        ]
    }
],
```

The manifest.json file can be found under:

"YOUR-PROJECT-FOLDER" > Packages > manifest.json

This needs to be done once for each Unity project you intend to use Scriptable Console with because new Unity projects are always created with the default manifest.json file for that editor version.

If you can't see the latest version of Scriptable Console in the package manager UI, it's likely because it supports only a later version of Unity than you are currently using.

---

## Roadmap

> Roadmap is subject to change. Last reviewed 14th of February 2020.

| Version | Defining Feature                  						  				    |
| ------- | --------------------------------------------------------------------------- |
| ~0.1~   | ~Foundation of defining command words and executing them has been set~	    |
| ~0.2~   | ~Unity Log messages and previous commands now appear below the input field~	|
| 1.0     | Full DocFX documentation and API clean up             									    |
| 2.0     | Now written for runtime UIElements instead of classic UGUI                  |
