# CryptoHash

## Benchmark

Tested on 12048  bytes

Class | Execution time
--- | ---
CryptoHash.SHA256C.SHA256C(256) | 2 ms.
System.Security.Cryptography.SHA256+Implementation(256) | 8 ms.
CryptoHash.Kupyna.KupynaHash(256) | 371 ms.
CryptoHash.Kupyna.KupynaHash(304) | 321 ms.
CryptoHash.Kupyna.KupynaHash(384) | 334 ms.
CryptoHash.Kupyna.KupynaHash(512) | 325 ms.

## Collision test

Tested on 256 bytes 

**CryptoHash.SHA256C.SHA256C -- 256**

Substring size | Average time | Average iterations
---|---|---
1  |  0,4 ms.  |  4,7
2  |  0,3 ms.  |  11,2
3  |  0,767 ms.  |  30
4  |  2,1 ms.  |  91,5
5  |  7,76 ms.  |  339,8
6  |  23,483 ms.  |  1032,8

**System.Security.Cryptography.SHA256+Implementation -- 256**

Substring size | Average time | Average iterations
---|---|---
1  |  0,7 ms.  |  3,2
2  |  0,35 ms.  |  9,4
3  |  0,233 ms.  |  35,7
4  |  0,4 ms.  |  96,8
5  |  1,62 ms.  |  356,2
6  |  5,817 ms.  |  1207,4

**CryptoHash.Kupyna.KupynaHash -- 256**

Substring size | Average time | Average iterations
---|---|---
1  |  57,8 ms.  |  5,2
2  |  107,45 ms.  |  10,6
3  |  277,667 ms.  |  29
4  |  1052,925 ms.  |  112,7
5  |  2969,1 ms.  |  317,4
6  |  11500,15 ms.  |  1235,5

**CryptoHash.Kupyna.KupynaHash -- 304**

Substring size | Average time | Average iterations
---|---|---
1  |  75,3 ms.  |  5,5
2  |  157,35 ms.  |  12,6
3  |  446,633 ms.  |  37,5
4  |  1050,95 ms.  |  89,6
5  |  3737,16 ms.  |  322,4
6  |  12086,7 ms.  |  1042,5

**CryptoHash.Kupyna.KupynaHash -- 384**

Substring size | Average time | Average iterations
---|---|---
1  |  64,1 ms.  |  4,6
2  |  192,3 ms.  |  15,4
3  |  479,167 ms.  |  40,2
4  |  1040,2 ms.  |  88,6
5  |  3955,74 ms.  |  339,8
6  |  13779,067 ms.  |  1179

**CryptoHash.Kupyna.KupynaHash -- 512**

Substring size | Average time | Average iterations
---|---|---
1  |  53,1 ms.  |  3,6
2  |  152,65 ms.  |  12
3  |  468,1 ms.  |  38,9
4  |  1444,55 ms.  |  121,6
5  |  3692,72 ms.  |  315,7
6  |  13683,833 ms.  |  1178
