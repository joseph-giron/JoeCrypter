This gets picked up as wannacry now. Thanks to whoever did that. Might as well make it public again. 

![Untitled](https://user-images.githubusercontent.com/1933739/135568562-c55ed2f9-3f02-4154-978a-b0c950894e62.png)

This is for educational purposes only.
To use, run it from the debug folder.

Here is how it works:

The minor mudging of exe code is done to the header to confuse analysts. Modified section names, time stamps, exports, etc is all done in .NET

The meat / potatoes is done in the 'joe_crypter' folder which has the C / assembly code. Here is where the trickery happens. I'm using Pelles C compiler (included inside) to work with my barebones.c file. Different 'tricks' are added to the file and the packaged exe is placed inside the resources section as a binary blob. 'payload.rc' points to our encrypted payload and the decryption key is inside the program. We use the C compiler to cram the exe inside. If the conditions are met (say a 5 min stall using weird timing API's and a 200mb allocation, vm checks) then the exe runs via classic Run PE methods (hollowed out notepad.exe spawned, exe copied inside, process set running). If not satisfied, then the thing simply exits. 

Over the years, other injection methods have been found. Transactional files, via APC's, CreateSection, and that control break thing with the console handler. I've tried to add others, but lack of interest keeps me from adding more / finishing.

I've invluded other packers inside in case you want further obfuscation.

The interesting things added lately are Region and Date checks. My idea was make it so that the exe only runs in a particular region (like Mexico or something) and fail crash otherwise. The other idea was to make it so that the exe will only run up to a particular date. This means if an analyst is looking at the thing and gets lazy, the exe will cease to function. I already made shellcode for this and it works on Linux and Windows.

Things to be done still:

* Use encryption on the payload stored in the resources section - done
* Implement other injection techniques like from this pro h4x0r https://modexp.wordpress.com/2019/06/15/4083/ - in progress
* Add better music - done
* Redesign UI - done
* Added transactional file execution
* APC execution works, but buggy, left it out. Same with control-break execution method.
* Make the encryption brute force itself rather than store key.
