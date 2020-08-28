# tracert2csv
Takes a tracert export and converts it to comma-delimited CSV.

## How to use
```
tracert2csv <PATH_TO_TRACERT_EXPORT> <OUTPUT_CSV>
```

### Input
Tracing route to somenextdomain.com [34.102.136.180]
over a maximum of 30 hops:

  1     3 ms    15 ms     2 ms  hitronhub.home [192.168.0.1]
  2   265 ms    49 ms    17 ms  99.227.240.1
  3    26 ms    22 ms    14 ms  24.156.158.245
  4    16 ms    12 ms    13 ms  9019-cgw01.ym.rmgt.net.rogers.com [69.63.248.205]
  5    14 ms    18 ms    17 ms  209.148.235.18
  6    17 ms    13 ms    14 ms  72.14.209.126
  7     *        *        *     Request timed out.
  8    15 ms    12 ms    13 ms  180.136.102.34.bc.googleusercontent.com [34.102.136.180]

Trace complete.

### Output
1,3,15,2,hitronhub.home [192.168.0.1]
2,265,49,17,99.227.240.1
3,26,22,14,24.156.158.245
4,16,12,13,9019-cgw01.ym.rmgt.net.rogers.com [69.63.248.205]
5,14,18,17,209.148.235.18
6,17,13,14,72.14.209.126
7,*,*,*,Request timed out.
8,15,12,13,180.136.102.34.bc.googleusercontent.com [34.102.136.180]