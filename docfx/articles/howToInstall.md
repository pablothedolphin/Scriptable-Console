# How To Install

In order to install Scriptable Console in your project, add the following to the top of your manifest.json file right before the dependencies object. Next, save the file and restart the editor. You should then find the package in the package manager UI which can be installed like any other Unity package. You can even view a list of all previous versions of the package that are available in our registry.

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