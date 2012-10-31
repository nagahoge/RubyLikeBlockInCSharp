RubyLikeBlockInCSharp
=====================

A DLL library to use ruby-like block expressions in CSharp Language.


## Examples

    int n = 100;
    5.Times(() => n += 5);


    int n = 100;
    5.Times(idx => n += idx);


    int sum = 0;
    30.To(40).Each(n => sum += n);



