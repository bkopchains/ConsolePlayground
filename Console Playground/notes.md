- Think first, code second
- Ask clarifying questions
  - Edge cases
  - Input bounds/limits
- Globals are icky


Big O
-
we always only care about the larger notation when evaluating the fn

- O(1) --------- : constant time, always same
- O(log(n)) ---- : think of cases where we're halving every time (2^x = n)
  - Binary search
  - Push/pop from heap
- O(n) --------- : constant time, depending on size of n
- O(nlog(n)) --- : any sorting algo
- O(n^2) ------- : e.g. nested loop
- O(n*m) ------- : like O(n^2) but think different size loops
- O(2^n) ------- : 

Algos
-

BFS
- think going across each level of depth in order
- generally O(N)/O(N) if you're keeping it simple

DFS
- think going down each path in depth order
- generally recursive function

Funky Qs
-
good usings
```C#
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
class Solution {
  public void Whatever() {
    char c = '1';
    int i = c - '0'; // i == 1;
  }
}
```

pow(x,n):
```C#
if (n%2 > 0) { // is odd
    return x * MyPow(x*x, (n-1)/2); //remove one 'x', so we can reduce n by 1 to operate on evens
} else {
    return MyPow(x*x, n/2); 
}
```
binary search a list:
```C#
int left = 0;
int right = sums.Length;

while(left < right) {
    int mid = left + (right-left)/2; 
    if(target > sums[mid]) {
        left = mid+1;
    } else {
        right = mid;
    }
}
return left;
```