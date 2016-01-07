GamepadTest-XNA is an application for testing the GamePad API in Microsoft's XNA Framework 4.0.

Written in C# targetting .NET Framework 4.0.

![Screenshot](http://i.imgur.com/USXITuf.png)

License
-------
Copyright 2016 João Matos

Licensed under the Apache License, Version 2.0 (the "License");
you may not use this file except in compliance with the License.  
You may obtain a copy of the License at

  http://www.apache.org/licenses/LICENSE-2.0

Unless required by applicable law or agreed to in writing, software
distributed under the License is distributed on an "AS IS" BASIS,
WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.  
See the License for the specific language governing permissions and
limitations under the License.

Usage
-----

There are three cursors representing the position of the thumbsticks:
  * Diagonal reticle: raw value  
      GamePadDeadZone.None
  * Cross: value when using IndependentAxed deadzone setting  
      GamePadDeadZone.IndependentAxes
  * Circle: value when using Circular deadzone setting deadzone  
      GamePadDeadZone.Circular

#### Keys ####

  * Escape: close application
  * Numbers 1-4: change gamepad being tested

#### Gamepad ####

  * Back: close application
  * Thumbsticks: move cursors
  
Building
--------

Supported build environments:

  * Mono on GNU/Linux
  
Supported XNA Framework 4.0 implementations:

  * FNA (http://fna-xna.github.io/)

### On GNU/Linux ###

#### Dependencies ####

* Mono

    A Mono installation capable of targetting .NET Framework 4.0  
    Warning: some distributions (e.g. Debian) may not include the files needed to target 4.0 specifically.  
    Mono website: http://www.mono-project.com/

* FNA (http://fna-xna.github.io/)

    `FNA.dll` is required in the project's root directory.  
    The following files and directories should be present during runtime:
    
  * `FNA.dll`
  * `FNA.dll.config`
  * `lib64/` and/or `lib32/`  
	(these directories should contain the .so files required by FNA)

#### Makefile targets ####

  * help (default)  
    Print list of make targets

  * release  
    Build with optimization options, output to bin/Release

  * debug  
    Build with debug options, output to bin/Debug

  * run  
    Build the release target and run the resulting executable
  
  * debugrun  
    Build the debug target and run the resulting executable
    
  * clean  
    Removes build directories
