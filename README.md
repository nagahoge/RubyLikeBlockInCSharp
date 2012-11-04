RubyLikeBlockInCSharp
=====================

A DLL library to use ruby-like block expressions in CSharp Language.



## Examples


int#Times(Action proc)
int#Times(Action<int> proc)
long#Times(Action proc)
long#Times(Action<long> proc)

    int n = 100;
    5.Times(idx => n += idx); // n will be 110


int#To(int to)
long#To(int to)

    int sum = 0;
    30.To(40).Each(n => sum += n); // sum will be 385


IDictionary#Each<K, V>(Action<K, V> proc)

    (new Dictionary<string, int>() {
        {"one", 1},
        {"two", 2},
        {"three", 3},
        {"four", 4}
    }).Each((key, val) => Console.WriteLine(key + ":" + val));


IDictionary#EachWithCount<K, V>(Action<K, V, long> proc)

    (new Dictionary<string, int>() {
        {"one", 1},
        {"two", 2},
        {"three", 3},
        {"four", 4}
    }).EachWithCount((key, val, count) => {
        Console.WriteLine(count + " " + key + ":" + val);
    });


IDictionary#KeepIf<K, V>(Func<K, V, bool> proc)

    // Drop "one" and "three" key.
    var dict = (new Dictionary<string, int>() {
        {"one", 1},
        {"two", 2},
        {"three", 3},
        {"four", 4}
    }).KeepIf((key, val) => val % 2 == 0);



## Technique

This library use Extension Methods technique.
No other difficult technique is used.


## License

RubyLikeBlockInCSharp is released under the MIT License.
