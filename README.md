RubyLikeBlockInCSharp
=====================

A DLL library to use ruby-like block expressions in CSharp Language.



## Examples


    int n = 100;
    5.Times(idx => n += idx); // n will be 110


    int sum = 0;
    30.To(40).Each(n => sum += n); // sum will be 385


## Technique

This library use Extension Methods technique.
No other difficult technique is not used.

