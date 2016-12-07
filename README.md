# ClipUp
[![License](https://img.shields.io/github/license/JoeBiellik/clipup.svg)](LICENSE.md)
[![Release Version](https://img.shields.io/github/release/JoeBiellik/clipup.svg)](https://github.com/JoeBiellik/clipup/releases)
<img align="right" alt="Screenshot" src="https://cloud.githubusercontent.com/assets/43646/20990365/3ed513d6-bcd0-11e6-9749-0baf89f74852.png">

Tiny portable tray application to upload and share your clipboard and screenshots.
Currently Windows only.

Supports multiple upload hosts and has a plugin system to support 3rd party upload providers.

**Currently under development and not ready for use**

## Download
Download the [latest release](https://github.com/JoeBiellik/clipup/releases/latest). The application is portable and does not require installation.

## Providers
The following offical providers are in this repository and ship with the application:

Name | Type | Status
---- | ---- | ------
[Cubeupload](http://cubeupload.com/) | Image | Working
[Imgur](https://imgur.com/) | Image | Working
[Pastebin.com](http://pastebin.com/) | Text | Working
[paste.fyi](http://paste.fyi/) | Text | Working
[prntscr.com](http://prntscr.com/) | Image | Working
[sprunge](http://sprunge.us/) | Text | Working
[Tinyimg](http://tinyimg.io/) | Image | Working

To load other providers simply move the provider ``.dll`` file into the ``Providers`` directory and restart the program.
