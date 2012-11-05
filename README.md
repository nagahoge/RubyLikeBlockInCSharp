RubyLikeBlockInCSharp
=====================

A DLL library to use ruby-like block expressions in CSharp Language.


## API


### int#Times(Action proc)
### int#Times(Action<int> proc)
### long#Times(Action proc)
### long#Times(Action<long> proc)

    int n = 100;
    5.Times(idx => n += idx); // n will be 110


### int#To(int to)
### long#To(int to)

    int sum = 0;
    30.To(40).Each(n => sum += n); // sum will be 385


### IDictionary#Each<K, V>(Action<K, V> proc)

    (new Dictionary<string, int>() {
        {"one", 1},
        {"two", 2},
        {"three", 3},
        {"four", 4}
    }).Each((key, val) => Console.WriteLine(key + ":" + val));


### IDictionary#EachWithCount<K, V>(Action<K, V, long> proc)

    (new Dictionary<string, int>() {
        {"one", 1},
        {"two", 2},
        {"three", 3},
        {"four", 4}
    }).EachWithCount((key, val, count) => {
        Console.WriteLine(count + " " + key + ":" + val);
    });


### IDictionary#KeepIf<K, V>(Func<K, V, bool> proc)

    // Drop "one" and "three" key.
    var dict = (new Dictionary<string, int>() {
        {"one", 1},
        {"two", 2},
        {"three", 3},
        {"four", 4}
    }).KeepIf((key, val) => val % 2 == 0);



## How To Build

1. Clone RubyLikeBlockInCSharp repository.

    git clone git://github.com/nagahoge/RubyLikeBlockInCSharp.git


2. Open RubyLikeBlockInCSharp solution.

3. Build RubyLikeBlockInCSharp project.

It is desirable that before build project, change build option from Debug to Release.

(Right click solution, and select property will show a dialog.)

4. get RubyLikeBlockInCSharp.dll created in RubyLikeBlockInCSharp/RubyLikeBlockInCSharp/bin/Release


## How To Use

It is simple to use. You must only to do is that add a reference setting of project toward RubyLikeBlockInCSharp.dll.



## Technique

This library use Extension Methods technique.
No other difficult technique is used.


## License

RubyLikeBlockInCSharp is released under the MIT License.
