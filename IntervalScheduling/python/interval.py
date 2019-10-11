import sys

sys.stdin.next()

intervals = [map(int, line.rstrip().split(" ")) for line in sys.stdin]
intervals.sort(key=lambda tup: tup[1])

qty = 0 
end_time = -1

for (s,f) in intervals:
    if s >= end_time:
        qty += 1
        end_time = f
        
print qty
    