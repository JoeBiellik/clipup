# ClipUp
[![License](https://img.shields.io/github/license/JoeBiellik/clipup.svg)](LICENSE.md)
[![Dependency Status](https://img.shields.io/versioneye/d/user/projects/584b570ddf01d500374be6cd.svg)](https://www.versioneye.com/user/projects/584b570ddf01d500374be6cd)
[![Build Status](https://img.shields.io/travis/JoeBiellik/clipup.svg)](https://travis-ci.org/JoeBiellik/clipup)
[![Release Version](https://img.shields.io/github/release/JoeBiellik/clipup.svg)](https://github.com/JoeBiellik/clipup/releases)
<img align="right" alt="Screenshot" src="https://cloud.githubusercontent.com/assets/43646/21069322/8f04cf4e-be70-11e6-9518-d4d96fdc2834.png">

Tiny portable tray application to upload and share your clipboard and screenshots.
Currently Windows only.

Supports multiple upload hosts and has a plugin system to support 3rd party upload providers.

**Currently under development and not ready for use**

## Download
Download the [latest release](https://github.com/JoeBiellik/clipup/releases/latest). The application is portable and does not require installation. Requires .NET Framework 4.5.

## Providers
The following official providers are in this repository and ship with the application:

Name | Type | Status
---- | ---- | ------
[Cubeupload](http://cubeupload.com/) | Image | Working
[GitHub Gist](https://gist.github.com/) | Text | Working
[Imgur](https://imgur.com/) | Image | Working
[Pastebin.com](http://pastebin.com/) | Text | Working
[paste.fyi](http://paste.fyi/) | Text | Working
[prntscr.com](http://prntscr.com/) | Image | Working
[sprunge](http://sprunge.us/) | Text | Working
[Tinyimg](http://tinyimg.io/) | Image | Working

To load other providers simply move the provider ``.dll`` file into the ``Providers`` directory and restart the program.
