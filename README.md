# ThisCord-Installer
Installer for [Thiscord](https://github.com/RJ-Infinity/ThisCord)

# Quick Start

Most of this is a C# application which can be built with visual studio.

Inside ThisCordLauncher is a small C executable that is downloaded by the launcher to start ThisCord correctly.

How to build ThisCordLauncher.

You will need [Clang](https://clang.llvm.org/) and optionaly [Resource Hacker](http://angusj.com/resourcehacker/) (for adding the icon)
```console
$ clang .\main.c -o ThisCord.exe -Wall -Wextra "-Wl,/SUBSYSTEM:WINDOWS"
$ rh -open .\ThisCord.exe -save .\ThisCord.exe -action addskip -res ..\ThiscordIcon.ico -mask "ICONGROUP,MAINICON,"
```
