"""
You're going to create a program that simulates tossing a coin 5,000 times. Your program should display how many times the head/tail appears.

Sample output should be like the following:

          Starting the program...

Attempt #1: Throwing a coin... It's a head! ... Got 1 head(s) so far and 0 tail(s) so far 
Attempt #2: Throwing a coin... It's a head! ... Got 2 head(s) so far and 0 tail(s) so far 
Attempt #3: Throwing a coin... It's a tail! ... Got 2 head(s) so far and 1 tail(s) so far 
Attempt #4: Throwing a coin... It's a head! ... Got 3 head(s) so far and 1 tail(s) so far
........
Attempt #5000: Throwing a coin... It's a head! ... Got 2412 head(s) so far and 2588 tail(s) so far 

Ending the program, thank you!
"""
import random

heads = 0
tails = 0

for i in range(1,5001):
    random_num = random.random()
    random_round = round(random_num)

    if random_round == 0:
        side = "heads"
        heads +=1
       
    else:
        side = "tails"
        tails +=1
        
    print "Attempt #%d : Throwing a coin...it's a %s! Got %d head(s) so far and %d tail(s) so far " %(i, side, heads, tails)
print "End of program!"


"""
ANSWER:
import math

print 'Starting the program'

head_count = 0
tail_count = 0
for i in range(1,5001):
    rand = round(random.random())  
    if rand == 0:
        face = 'tail'
        tail_count += 1
    else:
        face = 'head'
        head_count += 1
    print "Attempt #"+str(i)+": Throwing a coin...It's a "+face+"!...Got "+str(head_count)+" head(s) and "+str(tail_count)+" tail(s) so far"

print 'Ending the program, thank you!'
"""

