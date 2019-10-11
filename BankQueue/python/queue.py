import sys
from collections import defaultdict
from heapq import *

nt = sys.stdin.readline().rstrip().split(" ")
n = int(nt[0])
t = int(nt[1])

customers = defaultdict(list)
for line in sys.stdin:
    cus = line.rstrip().split(" ")
    cash = int(cus[0])
    time = int(cus[1])
    customers[time].append(cash)

amounts = []
total = 0
while t >= 0:
    for price in customers[t]:
        # Negate price, since heapq is min heap q, therefore we make a "max heap q" by creating largest negative
        heappush(amounts, -price)
    
    if amounts:
        total += heappop(amounts)
    t -= 1

print(-total)