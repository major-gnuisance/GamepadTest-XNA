#!/bin/bash

cd "$(dirname "$(readlink -f "$0")")"

export SDL_GAMECONTROLLERCONFIG="03000000de280000ff11000001000000,Valve Streaming Gamepad,a:b0,b:b1,back:b6,dpdown:h0.4,dpleft:h0.8,dpright:h0.2,dpup:h0.1,guide:b8,leftshoulder:b4,leftstick:b9,lefttrigger:a2,leftx:a0,lefty:a1,rightshoulder:b5,rightstick:b10,righttrigger:a5,rightx:a3,righty:a4,start:b7,x:b2,y:b3,
03000000de280000fc11000001000000,Steam Controller,a:b0,b:b1,back:b6,dpdown:h0.4,dpleft:h0.8,dpright:h0.2,dpup:h0.1,guide:b8,leftshoulder:b4,leftstick:b9,lefttrigger:a2,leftx:a0,lefty:a1,rightshoulder:b5,rightstick:b10,righttrigger:a5,rightx:a3,righty:a4,start:b7,x:b2,y:b3,
$SDL_GAMECONTROLLERCONFIG"

export LD_LIBRARY_PATH="$PWD/lib64:$PWD/lib32:$LD_LIBRARY_PATH"

if [ "$1" == "debug" ]; then
    gamedir=bin/Debug
else
    gamedir=bin/Release
fi

exec mono $gamedir/GamepadTest.exe

